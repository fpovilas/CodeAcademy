using AutoFixture;
using AutoFixture.Xunit2;
using xUnitTestLecturersAPI.SpecimenBuilder;

namespace xUnitTestLecturersAPI.Attribute
{
    internal class CustomResponseDtoAttribute : AutoDataAttribute
    {
        public CustomResponseDtoAttribute() : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new ResponseDtoSpecimenBuilder());
            return fixture;
        })
        { }
    }
}
