using Microsoft.AspNetCore.Mvc;
using PatientService.Db.Entities;
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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        // GET: api/<AddressController>
        [HttpGet]
        public async Task<IActionResult> GetPaginatedAddresses(int? page, int size, string sortorder, string filter)
        {
            return Ok(await _addressService.GetWithPaging(page, size, sortorder, filter));
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _addressService.GetById(id));
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task Add([FromBody] AddressDTO addressDTO)
        {
            await _addressService.Add(addressDTO);
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] AddressDTO addressDTO)
        {
            await _addressService.Update(id, addressDTO);
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _addressService.Delete(id);
        }
    }
}
