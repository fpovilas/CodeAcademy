using AutoFixture;
using AutoFixture.Xunit2;
using xUnitAPITest.SpecimenBuilder;

namespace xUnitAPITest.Attribute
{
    internal class CustomDataAttribute : AutoDataAttribute
    {
        public CustomDataAttribute() : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new CarSpecimenBuilder());
            return fixture;
        })
        {}
    }
}
