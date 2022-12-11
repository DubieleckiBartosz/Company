using Company.API.Interfaces.ServiceInterfaces;
using Company.API.Models.DataParameters;
using Company.API.Models.DataTransferObjects;
using Company.API.Models.Views;
using Company.API.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers;

[Route("api/company/{companyId}/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    } 

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(Response<string>), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(object), 500)]
    public async Task<IActionResult> AddNewEmployee([FromRoute] string companyId, [FromBody] NewDepartmentEmployeeParameters parameters)
    {
        var dto = NewDepartmentEmployeeDto.Create(companyId, parameters);
        await _departmentService.AddNewEmployeeAsync(dto);
        return NoContent();
    }

    //[HttpPost("[action]")]
    //[ProducesResponseType(typeof(Response<List<>>), 200)]
    //[ProducesResponseType(typeof(object), 400)]
    //[ProducesResponseType(typeof(object), 500)]
    //public async Task<IActionResult> GetDepartmentsBySearch()
    //{
    //    var dto = NewDepartmentEmployeeDto.Create(companyId, parameters);
    //    await _departmentService.AddNewEmployeeAsync(dto);
    //    return NoContent();
    //}
}