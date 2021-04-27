using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Data.Repositories;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _CompanyService;

        public CompanyController(ICompanyService CompanyService)
        {
            _CompanyService = CompanyService;
        }

        // GET: api/Company
        [HttpGet]
        public ActionResult<IEnumerable<Company>> Get()
        {
            try
            {
                var result = _CompanyService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public ActionResult<Company> Get(long id)
        {
            try
            {
                var result = _CompanyService.Get(id);

                if (result == null)
                    return NotFound();
                else
                    return Ok(result);

            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // POST: api/Company
        [HttpPost]
        public ActionResult Post([FromBody] Company Company)
        {
            try
            {
                _CompanyService.Insert(Company);
                return Ok(Company);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Company Company)
        {
            try
            {
                _CompanyService.Update(id, Company);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(long id)
        {
            try
            {
                _CompanyService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }
    }
}
