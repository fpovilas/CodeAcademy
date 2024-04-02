using Microsoft.AspNetCore.Mvc;
using Task1.Model;

namespace Task1.Service.Interface
{
    public interface ICarService
    {
        public IEnumerable<Car> GetAllCars();
        public IEnumerable<Car> GetCarsByColor(string color);
        public void AddNewCar(Car car);
        public void UpdateCar(Car car);
        public void DeleteCar(int id);
    }
}
