using Company.API.Interfaces.ServiceInterfaces;
using Company.API.Models.DataParameters;
using Company.API.Models.DataTransferObjects;
using Company.API.Models.Views;
using Company.API.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet("[action]/{id}")]
    [ProducesResponseType(typeof(Response<CompanyView>), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(object), 500)]
    public async Task<IActionResult> GetCompanyById([FromRoute] string id)
    {
        var result = await _companyService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("[action]/{id}")]
    [ProducesResponseType(typeof(Response<CompanyWithDepartmentsView>), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(object), 500)]
    public async Task<IActionResult> GetCompanyWithDepartmentsById([FromRoute] string id)
    {
        var result = await _companyService.GetByIdWithDepartmentsAsync(id);
        return Ok(result);
    }

    [HttpGet("[action]/{id}")]
    [ProducesResponseType(typeof(Response<CompanyDetailsView>), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(object), 500)]
    public async Task<IActionResult> GetCompanyDetailsById([FromRoute] string id)
    {
        var result = await _companyService.GetByIdDetailsAsync(id);
        return Ok(result);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(Response<string>), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(object), 500)]
    public async Task<IActionResult> CreateNewCompany([FromBody] NewCompanyParameters parameters)
    {
        var dto = NewCompanyDto.Create(parameters);
        var result = await _companyService.CreateNewCompanyAsync(dto);
        return Ok(result);
    }
    
    [HttpPost("[action]")]
    [ProducesResponseType( 204)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(object), 500)]
    public async Task<IActionResult> CreateNewDepartmentCompany([FromBody] NewCompanyDepartmentParameters parameters)
    {
        var dto = NewCompanyDepartmentDto.Create(parameters);
        await _companyService.AddNewDepartmentAsync(dto);
        return NoContent();
    }
}
