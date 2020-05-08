using System.Linq;
using HospitalService.Abstractions;
using HospitalService.Contracts.V1.Responses;
using HospitalService.Filters;
using HospitalService.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalService.Controllers.v1
{
    /// <summary>
    /// The WebApi that provides CRUD functionality 
    /// </summary>
    [Route("api/v1/hospital")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;
        /// <summary>
        /// Inject your repository here
        /// </summary>
        /// <param name="hospitalRepository"></param>
        public HospitalController(IHospitalRepository hospitalRepository) => 
            _hospitalRepository = hospitalRepository;

        // GET: api/v1/hospital
        [HttpGet]
        public IActionResult GetResult() =>
            !_hospitalRepository.GetHospitals().Any()
                ? (IActionResult) NotFound("No Hospitals in the System")
                : Ok(_hospitalRepository.GetHospitals());

        // GET: api/v1/hospital/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hospital = _hospitalRepository.GetHospital(id);
            return hospital == null ? (IActionResult) NotFound() : Ok(hospital);
        }
        
        // POST: api/v1/hospital
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public IActionResult Post([FromBody]hospital hospital)
        {
            _hospitalRepository.AddHospital(hospital);
            return CreatedAtAction("Get", new {id = hospital.Id}, hospital);
        }
        
        // DELETE: api/v1/hospital/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => 
            _hospitalRepository.DeleteHospital(id) == false
            ? (IActionResult) NotFound("This hospital doesn't exist")
            : Ok("Deleted Successfully");

        // PUT: api/v1/hospital/1
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilter))]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public IActionResult Put(int id, [FromBody]hospital hospitalToUpdate) =>
            _hospitalRepository.UpdateHospital(id, hospitalToUpdate) == false
            ? (IActionResult)NotFound("This hospital doesn't exist")
            : Ok("Updated Successfully");
    }
}