using AutoFixture;
using AutoFixture.Xunit2;

namespace FinalProject.Test.Data
{
    public class UserDataAttribute(string name = "") : AutoDataAttribute(() =>
        {
            var fixture = new Fixture();

            if (name.Equals("Failure"))
            { fixture.Customizations.Add(new UserFailureSpecimenBuilder()); }
            else { fixture.Customizations.Add(new UserSpecimenBuilder()); }

            return fixture;
        })
    {
    }
}
