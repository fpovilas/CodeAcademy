using Task1.Data.Interface;
using Task1.Model;

namespace Task1.Data
{
    public class CarData : ICarData
    {
        public List<Car> Cars { get; } =
        [
            new Car
            {
                Id = 1,
                Manufacturer = "Hyundai",
                Color = "Green"
            },
            new Car
            {
                Id= 2,
                Manufacturer = "Toyota",
                Color = "Red"
            },
            new Car
            {
                Id = 3,
                Manufacturer = "Mitsubishi",
                Color = "Silver"
            }
        ];
    }
}
