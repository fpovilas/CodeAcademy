using AutoFixture;
using AutoFixture.Xunit2;
using xUnitTestLecturersAPI.SpecimenBuilder;

namespace xUnitTestLecturersAPI.Attribute
{
    internal class CustomUserDtoAttribute : AutoDataAttribute
    {
        public CustomUserDtoAttribute() : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new UserDtoSpecimenBuilder());
            return fixture;
        }){ }
    }
}
