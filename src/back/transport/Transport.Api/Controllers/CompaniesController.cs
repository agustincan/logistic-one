using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transport.Domain.Models;
using Transport.Api.Services;

namespace Transport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : _BaseController<CompaniesController>
    {
        private readonly ICompanyServiceUow _service;

        public CompaniesController(ICompanyServiceUow service)
        {
            _service = service;
        }

        // GET: api/companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            var companies = await _service.GetAllAsync();
            return Ok(companies);
        }

        // GET: api/companies/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _service.GetByIdAsync(id);
            if (company == null)
                return NotFound();
            return Ok(company);
        }

        // POST: api/companies
        [HttpPost]
        public async Task<ActionResult<Company>> CreateCompany(Company company)
        {
            var created = await _service.CreateAsync(company);
            return CreatedAtAction(nameof(GetCompany), new { id = created.Id }, created);
        }

        // PUT: api/companies/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, Company company)
        {
            var updated = await _service.UpdateAsync(id, company);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        // DELETE: api/companies/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
