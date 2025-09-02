using System.Runtime.CompilerServices;
using AutoMapper;
using EmployeeLibrary.Commands;
using EmployeeLibrary.DTO;
using EmployeeLibrary.Exceptions;
using EmployeeLibrary.Interface;
using EmployeeLibrary.Models;
using EmployeeLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ISender _sender;

        public CompanyController(ICompanyService companyService, ISender sender)
        {
            _companyService = companyService;
            _sender = sender;
        }

        [HttpGet, Route("Companies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                IEnumerable<CompanyDTO> companies = await _sender.Send(new GetAllCompaniesQuery());
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("Companies/{id}")]
        public async Task<IActionResult> GetCompanyById(Guid id)
        {
            try
            {
                CompanyDTO company = await _sender.Send(new GetCompanyByIdQuery(id));
                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCompany(AddCompanyDTO addCompanyDTO)
        {
            if (addCompanyDTO is null)
            {
                return BadRequest("Company data is null");
            }
            CompanyDTO addedCompany = await _sender.Send(new AddCompanyCommand(addCompanyDTO));
            return CreatedAtAction(nameof(GetCompanyById), new { id = addedCompany.Id }, addedCompany);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] UpdateCompanyDTO updateCompanyDTO)
        {
            try
            {
                if (id != updateCompanyDTO.Id)
                {
                    return BadRequest("Company Id doesn't match");
                }
                CompanyDTO updatedCompany = await _sender.Send(new UpdateCompanyCommand(updateCompanyDTO));
                if (updatedCompany == null)
                {
                    return NotFound();
                }
                return Ok(updatedCompany);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{companyId}")]
        public async Task<IActionResult> DeleteCompany(Guid companyId)
        {
            try
            {
                Company company = await _companyService.GetCompanyByIdAsync(companyId);
                if (company is null)
                {
                    return NotFound("Company not found");
                }
                bool result = await _sender.Send(new DeleteCompanyCommand(companyId));
                return Ok(new { message = "Company : " + company.Name + " is deleted successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
