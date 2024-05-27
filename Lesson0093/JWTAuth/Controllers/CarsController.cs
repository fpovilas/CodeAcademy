using JWTAuth.Models;
using JWTAuth.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController(ICarService carService) : Controller
    {
        [HttpGet("/GetCarID/{carID}")]
        [Authorize(Roles = "User, Admin")]
        public ActionResult<Car> GetCarByID(int carId)
        {
            var car = carService.GetCarByID(carId).Value;
            if (car is null) return StatusCode(418, "I am teapot");

            return Ok(car);
        }

        [HttpGet("/GetCars")]
        [Authorize(Roles = "User, Admin")]
        public ActionResult<List<Car>> GetCars()
        {
            var cars = carService.GetCars().Value;
            if(cars.IsNullOrEmpty()) return StatusCode(418, "I am teapot");

            return Ok(cars);
        }

        [HttpPut("/AddCar")]
        [Authorize(Roles = "Admin")]
        public ActionResult Add([FromBody]CarDto car)
        {
            if(carService.Add(car))
                return Ok(car);
            else return BadRequest();
        }

        [HttpPost("/UpdateCar/{idToUpdate}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Update([FromBody]CarDto car, int idToUpdate)
        {
            if(carService.Update(car, idToUpdate))
                return Ok(car);
            else return BadRequest();
        }

        [HttpPost("/DeleteCar/{idToUpdate}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Update(int idToUpdate)
        {
            Car car = GetCarByID(idToUpdate).Value!;

            if (carService.Delete(idToUpdate))
                return Ok(car);
            else return BadRequest();
        }
    }
}