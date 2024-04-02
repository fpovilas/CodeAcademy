using Microsoft.AspNetCore.Mvc;
using Task1.Model;
using Task1.Repository.Interface;
using Task1.Service.Interface;

namespace Task1.Service
{
    public class CarService(ICarRepository carRepository) : ICarService
    {
        private readonly ICarRepository carRepository = carRepository;

        public IEnumerable<Car> GetAllCars() => carRepository.GetAllCars();

        public IEnumerable<Car> GetCarsByColor(string color) => carRepository.GetCarsByColor(color);

        public void AddNewCar(Car car) => carRepository.AddNewCar(car);

        public void UpdateCar(Car car) => carRepository.UpdateCar(car);

        public void DeleteCar(int id) => carRepository.DeleteCar(id);
    }
}
