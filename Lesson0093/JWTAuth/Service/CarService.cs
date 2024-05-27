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
            Car newCar = (from car in carContext.Cars
                         where car.Id == id
                         select car).FirstOrDefault()!;

            return newCar;
        }

        public ActionResult<List<Car>> GetCars()
        {
            var cars = from car in carContext.Cars
                       select car;

            return cars.ToList();
        }

        public bool Add(CarDto car)
        {
            if (car is null) return false;

            Car newCar = new();
            newCar.ConvertFromDto(car);

            carContext.Cars.Add(newCar);
            carContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Car car = carContext.Cars.FirstOrDefault(x => x.Id == id) ?? new();
            if(car is null) return false;

            carContext.Cars.Remove(car);
            carContext.SaveChanges();
            return true;
        }

        public bool Update(CarDto car, int carToUpdateId)
        {
            Car carToUpdate = carContext.Cars.FirstOrDefault(c => c.Id == carToUpdateId) ?? new();
            if(carToUpdate is null) return false;

            carToUpdate.ConvertFromDto(car);
            carContext.Update(carToUpdate);
            carContext.SaveChanges();
            return true;
        }
    }
}
