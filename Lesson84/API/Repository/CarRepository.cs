using API.Repository.Interface;
using DatabaseLayer.Context;
using DatabaseLayer.Database.Model;

namespace API.Repository
{
    public class CarRepository(CarsContext context) : ICarRepository
    {
        public IEnumerable<Car> GetAllCars() => context.Cars;

        public IEnumerable<Car> GetCarsByColor(string color) => context.Cars.Where(c => c.Color == color);

        public void AddNewCar(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            context.Cars.Update(car);
            context.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            Car carToRemove = context.Cars.FirstOrDefault(c => c.Id == id)!;
            context.Cars.Remove(carToRemove);
            context.SaveChanges();
        }
    }
}
