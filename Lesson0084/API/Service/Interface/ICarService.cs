using DatabaseLayer.Database.Model;

namespace API.Service.Interface
{
    public interface ICarService
    {
        public IEnumerable<Car> GetAllCars();
        public IEnumerable<Car> GetCarsByColor(string color);
        public void AddNewCar(Car car);
        public void UpdateCar(Car car);
        public Car DeleteCar(int id);
        public Car GetCarByID(int id);
    }
}
