using API.Repository.Interface;
using API.Service.Interface;
using DatabaseLayer.Database.Model;

namespace API.Service
{
    public class CarService(ICarRepository carRepository) : ICarService
    {
        private readonly ICarRepository carRepository = carRepository;

        public IEnumerable<Car> GetAllCars() => carRepository.GetAllCars();

        public IEnumerable<Car> GetCarsByColor(string color) => carRepository.GetCarsByColor(color);

        public void AddNewCar(Car car) => carRepository.AddNewCar(car);

        public void UpdateCar(Car car) => carRepository.UpdateCar(car);

        public Car DeleteCar(int id) => carRepository.DeleteCar(id);

        public Car GetCarByID(int id) => carRepository.GetCarByID(id);
    }
}
