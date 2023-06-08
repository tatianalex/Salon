using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domen;
using Domen.Enums;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.Enums;
using Services.Interfaces;

namespace Services.Services.UsersServices;


	public class UserService : IUserService
	{
		private readonly AplicationContext _db;
		private IUser _userImplementation;
		private IUserService _userServiceImplementation;

		public UserService(AplicationContext db)
		{
			_db = db;
		}

		public async Task<BaseResponse<UserResponse>> Login(UserRequest request)
		{
			if (request == null) throw new ArgumentNullException(nameof(request));
			if (string.IsNullOrWhiteSpace(request.Password))
				throw new SalonException(EnumErrorCode.PasswordIsAreRequired);

			if (string.IsNullOrWhiteSpace(request.Phone))
				throw new SalonException(EnumErrorCode.PhoneAreRequired);

			var user = await _db.Users.FirstOrDefaultAsync(x => x.Phone == request.Phone);
			if (user == null)

				throw new SalonException("нет такого телефона", EnumErrorCode.AccessDenied);
			if (user.Status is EnumUserStatus.New or EnumUserStatus.Blocked)
				throw new SalonException("новый", EnumErrorCode.AccessDenied);
			if (user.PasswordHash != PasswordHashService.GetHashPassword(request.Password, user.PasswordKey))
				throw new SalonException("Password are incorrect", EnumErrorCode.AccessDenied);

			var response = new UserResponse
			{
				Token = (await GenerateToken(user.Id)).Token,
				Id = user.Id,
				Supername = user.Supername,
				Name = user.Name,
				Role = user.Role
			};

			return new BaseResponse<UserResponse>(response);
		}

	
		public async Task<BaseResponse> Register(RegisterRequest request)
		{
			if (await _db.Users.AnyAsync(x => x.Phone == request.Phone))
				throw new SalonException(EnumErrorCode.PhoneIsAlreadyInUse);
////н
			if (string.IsNullOrWhiteSpace(request.Phone))
				throw new SalonException(EnumErrorCode.PhoneAreRequired);


			if (string.IsNullOrWhiteSpace(request.Password))
				throw new SalonException(EnumErrorCode.PasswordIsAreRequired);

			if (string.IsNullOrWhiteSpace(request.ConfirmPassword))
				throw new SalonException(EnumErrorCode.PasswordIsAreRequired);

			if (request.Password != request.ConfirmPassword)
				throw new SalonException(EnumErrorCode.PasswordsDoNotMatch);

			var guidPhone = Guid.NewGuid();

			var password = PasswordHashService.GenHashPassword(request.Password);

			var user = new User
			{
				Phone = request.Phone,
				Supername = request.Supername,
				Name = request.Name,
				Status = EnumUserStatus.New,
				Role = EnumUserRole.User,
				PasswordKey = password.Key,
				PasswordHash = password.Hash
			};

			var token = new MailToken
			{
				DateExpire = DateTime.UtcNow.AddDays(5),
				Key = guidPhone,
				User = user
			};

			await _db.MailTokens.AddAsync(token);
			await _db.SaveChangesAsync();

			return new BaseResponse();
		}

		public async  Task<BaseResponse<TokenResponse>> ActivateAccount(ActivateAccountRequest request)
		{
			var dateExpire = DateTime.UtcNow;
			var user = await _db.Users.FirstOrDefaultAsync(x =>
				x.Tokens.Any(z => z.Key == request.Key && z.DateExpire > dateExpire));

			if (user is null)
				throw new SalonException(EnumErrorCode.TokenIsNotFound);

			user.Status = EnumUserStatus.Verified;
			await _db.SaveChangesAsync();

			return new BaseResponse<TokenResponse>(await GenerateToken(user.Id));
		}


		private async Task<TokenResponse> GenerateToken(long id)
		{
			(User user, ClaimsIdentity claim) identity = await GetIdentity(id);
			if (identity.user is null)
				throw new SalonException("User is not found!", EnumErrorCode.EntityIsNotFound);

			var now = DateTime.UtcNow;
			var jwt = new JwtSecurityToken(
				AuthOptions.ISSUER,
				AuthOptions.AUDIENCE,
				notBefore: now,
				claims: identity.claim.Claims,
				expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
				signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
					SecurityAlgorithms.HmacSha256));

			var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

			return new TokenResponse
			{
				UserId = identity.user.Id,
				Supername = identity.user.Supername,
				Name = identity.user.Name,

				Token = $"Bearer {encodedJwt}"
			};
		}

		private async Task<(User, ClaimsIdentity)> GetIdentity(long id)
		{
			var person = await _db.Users.FindAsync(id);
			if (person is null)
				throw new SalonException("User is not found!", EnumErrorCode.EntityIsNotFound);

			if (person.Status == EnumUserStatus.Blocked)
				throw new SalonException(EnumErrorCode.UserIsBlocked);

			var claims = new List<Claim> {new(ClaimTypes.Name, person.Id.ToString())};
			var claimsIdentity =
				new ClaimsIdentity(claims, "TokenResponse", ClaimsIdentity.DefaultNameClaimType,
					ClaimsIdentity.DefaultRoleClaimType);
			return (person, claimsIdentity);
		}

	}





