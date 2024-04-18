using JWTAuth.DB;
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
        [Authorize]
        public ActionResult<Car> GetCarByID(int carId)
        {
            var car = carService.GetCarByID(carId).Value;
            if (car is null) return StatusCode(418, "I am teapot");

            return Ok(car);
        }

        [HttpGet("/GetCars")]
        [Authorize]
        public ActionResult<List<Car>> GetCars()
        {
            var cars = carService.GetCars().Value;
            if(cars.IsNullOrEmpty()) return StatusCode(418, "I am teapot");

            return Ok(cars);
        }
    }
}
