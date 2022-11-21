using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleCRUD.Models;
using SampleCRUD.Services;

namespace SampleCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorDataController : ControllerBase
    {
        SensorDataService service;
        public SensorDataController()
        {
            service = new SensorDataService();
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<SensorData>> GetAll()
        {
            try
            {
                return service.GetAllData().ToList();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<SensorData> Details(int id)
        {
            try
            {
                var sensorData = service.GetData(id);
                if (sensorData == null)
                {
                    return NotFound();
                }
                return sensorData;
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(SensorData sensorData)
        {
            try
            {
                if (!IsValidAddContract(sensorData))
                {
                    return BadRequest();
                }
                service.AddData(sensorData);
                return CreatedAtAction(nameof(Details), new { id = sensorData.Id }, sensorData);
            }
            catch
            {
                return BadRequest();
            }
        }

        private static bool IsValidAddContract(SensorData sensorData)
        {
            return true;
        }
    }
}
