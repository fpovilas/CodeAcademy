using JWTAuth.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuth.Service.Interface
{
    public interface ICarService
    {
        public bool Add(CarDto car);
        public bool Delete(int id);
        public ActionResult<Car> GetCarByID(int id);
        public ActionResult<List<Car>> GetCars();
        public bool Update(CarDto car, int carToUpdateId);
    }
}