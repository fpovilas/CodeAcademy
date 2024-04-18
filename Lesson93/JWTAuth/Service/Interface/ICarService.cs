using JWTAuth.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuth.Service.Interface
{
    public interface ICarService
    {
        public ActionResult<Car> GetCarByID(int id);
        public ActionResult<List<Car>> GetCars();
    }
}