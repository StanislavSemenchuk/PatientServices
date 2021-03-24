using Microsoft.AspNetCore.Mvc;
using PatientService.Db.Ef;
using PatientServiceCore.DTOs;
using PatientServiceCore.Helpers;
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
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        // GET: api/<PatientController>
        [HttpGet]
        public async Task<IActionResult> GetPagedPatients(int? page, int size, string sortOrder, string filter)
        {
            return Ok(await _patientService.GetWithPaging(page, size, sortOrder, filter));
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _patientService.GetById(id));
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task AddPatient([FromBody] PatientDTO patientDTO)
        {
            await _patientService.Add(patientDTO);
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public async Task EditPatient(int id, [FromBody] PatientDTO patientDTO)
        {
            await _patientService.Update(id, patientDTO);
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _patientService.Delete(id);
        }
    }
}
