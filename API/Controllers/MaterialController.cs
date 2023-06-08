using System.ComponentModel.DataAnnotations;
using Domen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Enums;
using Services.Interfaces;


namespace Api.Controllers;

/// <summary>
///     Факультеты
/// </summary>
[Route("/[Controller]")]
[Produces("application/json")]
public class MaterialController : Microsoft.AspNetCore.Mvc.Controller
{
	private readonly IMaterial _material;

	public  MaterialController(IMaterial material)
	{
		_material = material;
	}

	/// <summary>
	///     Добавить дисконт
	/// </summary>
	/// <param name="model"></param>
	/// <returns></returns>
	[HttpPost]
	[Route($"{nameof(Create)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	//[Authorize]
	
	public async Task Create([FromBody] MaterialDTO item)
	{
		await _material.Create(item);
		
	}

	/// <summary>
	///     Получить список всех факультетов
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetMaterialList)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<List<Material>>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]

	public async Task<List<Material?>> GetMaterialList()
	
	{
		var result = await _material.GetMaterialList();
		return result;
	}

	/// <summary>
	///     Получить факультет
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetMaterial)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<Material>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<Material> GetMaterial(int id)
	
	{
		var result = await _material.GetMaterial(id);
		return result;
	}

	/// <summary>
	///     Переименовать факультет
	/// </summary>
	/// <returns></returns>
	[HttpPatch]
	[Route($"{nameof(Update)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	[Authorize]

	public async Task Update(MaterialDTO material)
	{
		_material.Update(material);
		
	}

	/// <summary>
	///     Удалить факультет
	/// </summary>
	/// </summary>
	/// <returns></returns>
	[HttpDelete]
	[Route($"{nameof(Delete)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	//[Authorize]
	public async Task Delete([FromQuery] int id)
	
	{
		await _material.Delete(id);
		
	}
}