using AutoFixture.Kernel;
using DatabaseLayer.Database.Model;
using Microsoft.OpenApi.Extensions;

namespace xUnitAPITest.SpecimenBuilder
{
    public class CarSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            Random rand = new();

            if(request is Type type && type.IsEquivalentTo(typeof(Car)))
            {
                return new Car { Id = rand.Next(0, int.MaxValue),
                                Color = ((Colors)(rand.Next(0, 41) / 10)).GetDisplayName(),
                                Manufacturer = ((Manufacturer)(rand.Next(0, 51) / 10)).GetDisplayName() };
            }
            return new NoSpecimen();
        }
    }

    public enum Colors
    {
        Green,
        Blue,
        Red,
        Yellow,
        Black
    }

    public enum Manufacturer
    {
        Hyundai,
        BMW,
        Toyota,
        Subaru,
        Mitsubishi,
        Daihatsu
    }
}