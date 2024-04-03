using Microsoft.AspNetCore.Mvc;
using API.Model;
using API.Service.Interface;
using DatabaseLayer.Database.Model;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController(ILogger<CarController> logger, ICarService carService) : ControllerBase
    {
        [HttpGet]
        [Route("/GetAllCars")]
        public IEnumerable<Car> GetAllCars()
        {
            var cars = carService.GetAllCars();
            if(cars.IsNullOrEmpty())
            {
                logger.LogError("No Cars in Database");
                return cars;
            }
            else
            {
                logger.LogInformation("Successfully returned Cars");
                return cars;
            }
        }

        [HttpGet]
        [Route("/GetCarsByColor")]
        public IEnumerable<Car> GetCarsByColor([FromQuery] string color) => carService.GetCarsByColor(color);

        [HttpPost]
        [Route("/AddNewCar")]
        public ActionResult AddNewCar(CarDTO car)
        {
            //int newId = (GetAllCars().OrderBy(x => x.Id).LastOrDefault()?.Id ?? 0) + 1;
            Car newCar = new()
            {
                //Id = newId,
                Manufacturer = car.Manufacturer,
                Color = car.Color,
            };

            carService.AddNewCar(newCar);

            return Ok(newCar);
        }

        [HttpPost]
        [Route("/UpdateCar")]
        public ActionResult UpdateCar(int id, [FromBody] CarDTO car)
        {
            Car newCar = new()
            {
                Id = id,
                Manufacturer = car.Manufacturer,
                Color = car.Color,
            };

            carService.UpdateCar(newCar);

            return Ok(newCar);
        }

        [HttpDelete]
        [Route("/DeleteCar/{id}")]
        public ActionResult DeleteCar([FromRoute] int id)
        {
            Car deletedCar = GetAllCars().Where(c => c.Id == id).FirstOrDefault()!;
            carService.DeleteCar(id);

            return Ok(deletedCar);
        }
    }
}
