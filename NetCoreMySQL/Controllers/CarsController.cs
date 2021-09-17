using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiMySQL.Data.Repositories;
using NetCoreApiMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await _carRepository.GetAllCars());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarDetails(int id)
        {
            return Ok(await _carRepository.GetCarDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {

            // Validaciones 
            if (car == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _carRepository.InsertCar(car);

            return Created("Created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] Car car)
        {

            // Validaciones 
            if (car == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _carRepository.UpdateCar(car);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carRepository.DeteleCar(new Car() { Id = id });

            return NoContent();
        }


    }
}
