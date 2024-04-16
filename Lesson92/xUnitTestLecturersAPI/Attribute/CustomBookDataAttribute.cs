using AutoFixture;
using AutoFixture.Xunit2;
using xUnitTestLecturersAPI.SpecimenBuilder;

namespace xUnitTestLecturersAPI.Attribute
{
    internal class CustomBookDataAttribute : AutoDataAttribute
    {
        public CustomBookDataAttribute() : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new BookSpecimenBuilder());
            return fixture;
        }){ }
    }
}
