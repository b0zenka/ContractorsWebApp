using AutoMapper;
using ContratorsWebAPI.Entities;
using ContratorsWebAPI.Models;
using ContratorsWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratorsWebAPI.Controllers
{
    [Route("api/contractors")]
    [ApiController]
    public class ContractorController : ControllerBase
    {
        private readonly IContractorService _contractorService;
        public ContractorController(IContractorService contractorService)
        {
            _contractorService = contractorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContractorDto>> GetAll()
        {
            var contractorDtos = _contractorService.GetAll();
            return Ok(contractorDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<ContractorDto> Get([FromRoute] int id)
        {
            var contractorDto = _contractorService.GetbyId(id);
            if (contractorDto is null)
                return NotFound();

            return Ok(contractorDto);
        }

        [HttpPost]
        public ActionResult CreateContractor([FromBody] ContractorDto dto)
        {
            int id = _contractorService.Create(dto);

            return Created($"/api/contractors/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] ContractorDto dto, [FromRoute] int id)
        {
            bool isUpdated = _contractorService.Update(id, dto);
            if (isUpdated)
                return Ok();
            
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            bool isDeleted = _contractorService.Delete(id);
            if (isDeleted)
                return NoContent();

            return NotFound();
        }

    }
}
