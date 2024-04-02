using Microsoft.AspNetCore.Mvc;
using Task1.Data.Interface;
using Task1.Model;
using Task1.Repository.Interface;

namespace Task1.Repository
{
    public class CarRepository(ICarData carData) : ICarRepository
    {
        private readonly ICarData carData = carData;

        public IEnumerable<Car> GetAllCars() => carData.Cars;

        public IEnumerable<Car> GetCarsByColor(string color) => carData.Cars.Where(c => c.Color == color);

        public void AddNewCar(Car car) => carData.Cars.Add(car);

        public void UpdateCar(Car car)
        {
            int index = carData.Cars.FindIndex(c => c.Id == car.Id);
            carData.Cars[index] = car;
        }

        public void DeleteCar(int id)
        {
            Car carToRemove = carData.Cars.FirstOrDefault(c => c.Id == id)!;
            carData.Cars.Remove(carToRemove);
        }
    }
}
