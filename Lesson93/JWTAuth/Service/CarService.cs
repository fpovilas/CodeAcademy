using JWTAuth.DB;
using JWTAuth.Models;
using JWTAuth.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuth.Service
{
    public class CarService(CarContext carContext) : ICarService
    {
        public ActionResult<Car> GetCarByID(int id)
        {
            var newCar = (from car in carContext.Cars
                         where car.Id == id
                         select car).FirstOrDefault();

            return newCar;
        }

        public ActionResult<List<Car>> GetCars()
        {
            var cars = from car in carContext.Cars
                       select car;

            return cars.ToList();
        }
    }
}
