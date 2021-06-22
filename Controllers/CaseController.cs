using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microservico_Crud.Domain;
using Microservico_Crud.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservico_Crud.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : Controller
    {
        private readonly ICaseRepository _caseRepository;
        public CaseController(ICaseRepository caseRepository)
        {
            _caseRepository = caseRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cases = _caseRepository.GetCases();
            return new OkObjectResult(cases);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _caseRepository.GetCaseByID(id);
            return Ok(product);
        }

        [HttpGet("Number/{number}", Name = "GetByCaseNumber")]
        public IActionResult GetByCaseNumber(string number)
        {
            var product = _caseRepository.GetCaseByNumber(number);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Case cases)
        {
            if (ModelState.IsValid)
            {

                return Created(nameof(Get), _caseRepository.InsertCase(cases));
                
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPut]
        public IActionResult Put([FromBody] Case cases)
        {
            if (ModelState.IsValid)
            {
                return Ok(_caseRepository.UpdateCase(cases));
                
            }
            else
            {
                return BadRequest(ModelState);
            }


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            return  Ok(_caseRepository.DeleteCase(id));
        }
    }
}
