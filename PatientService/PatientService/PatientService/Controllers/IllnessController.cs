using Microsoft.AspNetCore.Mvc;
using PatientServiceCore.DTOs;
using PatientServiceCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IllnessController : ControllerBase
    {
        public readonly IIllnessService _illnessService;
        public IllnessController(IIllnessService illnessService)
        {
            _illnessService = illnessService;
        }
        // GET: api/<IllnessController>
        [HttpGet]
        public async Task<IActionResult> GetPagedIllness(int? page, int size, string sortorder, string filter)
        {
            return Ok(await _illnessService.GetWithPaging(page, size, sortorder, filter));
        }

        // GET api/<IllnessController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _illnessService.GetById(id));
        }

        // POST api/<IllnessController>
        [HttpPost]
        public async Task AddIllness([FromBody] IllnessDTO illnessDTO)
        {
            await _illnessService.Add(illnessDTO);
        }

        // PUT api/<IllnessController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] IllnessDTO illnessDTO)
        {
            await _illnessService.Update(id, illnessDTO);
        }

        // DELETE api/<IllnessController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _illnessService.Delete(id);
        }
    }
}
