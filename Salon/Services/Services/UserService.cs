using Domen;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using Services.Enums;
using Services.Interfaces;

namespace Services.Services;

public interface UserService
{
    public class UserService:IUser
    {
        private readonly AplicationContext _db;

        public UserService(AplicationContext db)
        {
            _db = db;
        }

        public async Task<User> Add(string Supername, string Name,  string Phone, string pas1,string pas2)
        {
        
            if (await _db.Users.AllAsync(x => x.Supername==Supername))
                throw new TirException($"Value {Supername} already exists!", EnumErrorCode.EntityIsAlreadyExists);
            if (await _db.Users.AllAsync(x => x.Name==Supername))
                throw new TirException($"Value {Name} already exists!", EnumErrorCode.EntityIsAlreadyExists);
            if (await _db.Users.AllAsync(x => x.Phone == Phone))
                throw new TirException($"Emayl {Phone} already exists!", EnumErrorCode.EntityIsAlreadyExists);
            var user = new User
            {
                Supername = Supername,
                Name =Name, 
                Phone= Phone,
                PasswordHash = pas1,
                PasswordKey = pas2
			
            };
            await _db.AddAsync(user);
            await _db.SaveChangesAsync();
		
            return user;

        }

	

        public async Task<User> SearchUser(string STRmodel)
        {
		
            return await _db.Users
                .Where(x =>
                    x.Supername.Contains(STRmodel)
                    || x.Phone.Contains(STRmodel)).
                {
                    Id =x.Id,
                    Supername = x.Fio,
                    Name = x.Email,
                    Role = x.Role,
                    PasswordHash = x.PasswordHash,
                    PasswordKey = x.PasswordKey
			
                });
        }



	
	
        public async Task Update(long id, string Supername, string Name,string Phone, string pas1,string pas2)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
                throw new TirException($"Person Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);
			
            if (!string.IsNullOrWhiteSpace(Supername))
                user.Supername = Supername;
            if (!string.IsNullOrWhiteSpace(Supername))
                user.Name = Name;
            if (!string.IsNullOrWhiteSpace(Phone))
                user.Phone = Phone;
            if (!string.IsNullOrWhiteSpace(pas1))
                user.PasswordHash = pas1;
            if (!string.IsNullOrWhiteSpace(pas2))
                user.PasswordKey = pas2;

		
            //await _db.Update(discont);
            await _db.SaveChangesAsync();
        }

	
        public async Task DeleteUserAsync(long id)
        {
            if (await _db.Users.AnyAsync(x => x.Id == id))
                throw new TirException("User is not exists!", EnumErrorCode.EntityIsNotFound);

            _db.Users.Remove(new User {Id = id});
            await _db.SaveChangesAsync();
        }


    }
}