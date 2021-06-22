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
            return new OkObjectResult(product);
        }

        [HttpGet("Number/{number}", Name = "GetByCaseNumber")]
        public IActionResult GetByCaseNumber(string number)
        {
            var product = _caseRepository.GetCaseByNumber(number);
            return new OkObjectResult(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Case cases)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope())
                {
                    _caseRepository.InsertCase(cases);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = cases.Id }, cases);
                }
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
                using (var scope = new TransactionScope())
                {
                    _caseRepository.UpdateCase(cases);
                    scope.Complete();
                    return new OkResult();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _caseRepository.DeleteCase(id);
            return new OkResult();
        }
    }
}
