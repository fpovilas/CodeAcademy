using AutoFixture;
using AutoFixture.Xunit2;
using xUnitTestLecturersAPI.SpecimenBuilder;

namespace xUnitTestLecturersAPI.Attribute
{
    internal class CustomResponseDtoFailureAttribute : AutoDataAttribute
    {
        public CustomResponseDtoFailureAttribute() : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new ResponseDtoFailureSpecimenBuilder());
            return fixture;
        })
        { }
    }
}
