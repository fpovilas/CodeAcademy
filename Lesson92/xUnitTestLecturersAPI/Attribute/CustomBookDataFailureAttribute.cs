using AutoFixture;
using AutoFixture.Xunit2;
using xUnitTestLecturersAPI.SpecimenBuilder;

namespace xUnitTestLecturersAPI.Attribute
{
    internal class CustomBookDataFailureAttribute : AutoDataAttribute
    {
        public CustomBookDataFailureAttribute() : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new BookFailureSpecimenBuilder());
            return fixture;
        }){ }
    }
}
