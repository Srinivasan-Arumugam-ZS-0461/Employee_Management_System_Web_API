using EmployeeLibrary.Commands;
using EmployeeLibrary.DTO;
using EmployeeLibrary.Interface;
using EmployeeLibrary.Models;
using EmployeeLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ISender _sender;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyService companyService, ISender sender, ILogger<CompanyController> logger)
        {
            _companyService = companyService;
            _sender = sender;
            _logger = logger;
        }

        [HttpGet, Route("Companies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            _logger.LogInformation("GET api/company/companies called");
            try
            {
                IEnumerable<CompanyDTO> companies = await _sender.Send(new GetAllCompaniesQuery());
                _logger.LogInformation("GET api/company/companies succeeded!");
                return Ok(companies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all companies.");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("Companies/{id}")]
        public async Task<IActionResult> GetCompanyById(Guid id)
        {
            _logger.LogInformation("GET api/company/companies/{Id} called", id);
            try
            {
                CompanyDTO company = await _sender.Send(new GetCompanyByIdQuery(id));
                if (company == null)
                {
                    _logger.LogWarning("Company with Id {Id} not found", id);
                    return NotFound();
                }
                _logger.LogInformation("GET api/company/companies/{Id} succeeded!", id);
                return Ok(company);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching Company with Id {id}.", id);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCompany(AddCompanyDTO addCompanyDTO)//modify the AddCompanyDTO to include id as well.
        {
            try
            {
                _logger.LogInformation("POST api/company called");
                //if (addCompanyDTO is null)
                //{
                //    return BadRequest("Company data is null");
                //}
                CompanyDTO addedCompany = await _sender.Send(new AddCompanyCommand(addCompanyDTO));
                _logger.LogInformation("POST api/company succeeded!");
                return CreatedAtAction(nameof(GetCompanyById), new { id = addedCompany.Id }, addedCompany);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while adding a new company: {exception}", ex);
                return StatusCode(500, ex.InnerException);
            }
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
