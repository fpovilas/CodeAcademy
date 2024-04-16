using AutoFixture;
using AutoFixture.Xunit2;
using xUnitTestLecturersAPI.SpecimenBuilder;

namespace xUnitTestLecturersAPI.Attribute
{
    internal class CustomResponseDtoUserFAttribute : AutoDataAttribute
    {
        public CustomResponseDtoUserFAttribute() : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new ResponseDtoUserFailureSpecimenBuilder());
            fixture.Customizations.Add(new UserDtoSpecimenBuilder());
            return fixture;
        })
        { }
    }
}
