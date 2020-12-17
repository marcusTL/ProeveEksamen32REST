using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using ModelLib;
using PrøveEksamenREST.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrøveEksamenREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        MeasurementManager manager = new MeasurementManager(false);
        // GET: api/<MeasurementsController>
        [HttpGet]
        [EnableCors]//Hopefully works
        public IEnumerable<Measurement> GetAll()
        {
            return manager.GetAll();
        }

        // GET api/<MeasurementsController>/5
        [HttpGet("{id}")]
        [EnableCors]//Hopefully works
        public IActionResult GetOne(int id)
        {

            Measurement result = manager.GetOne(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/<MeasurementsController>
        [HttpPost]
        [EnableCors]//Hopefully works
        public IActionResult Post([FromBody] Measurement value)
        {
            bool result = manager.AddMeasurement(value);
            if (result == false)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE api/<MeasurementsController>/5
        [HttpDelete("{id}")]
        [EnableCors]//Hopefully works
        public IActionResult Delete(int id)
        {
            bool result = manager.DeleteMeasurement(id);
            if (result == false)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
