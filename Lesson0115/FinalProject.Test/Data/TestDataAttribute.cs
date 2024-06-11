using AutoFixture;
using AutoFixture.Xunit2;
using FinalProject.Shared.Enums;

namespace FinalProject.Test.Data
{
    public class TestDataAttribute(TestDataValue testType = TestDataValue.None) : AutoDataAttribute(() =>
        {
            var fixture = new Fixture();

            switch (testType)
            {
                case TestDataValue.UCSuccess:
                    fixture.Customizations.Add(new UserControllerSpecimenBuilder());
                    break;
                case TestDataValue.UCFailure:
                    fixture.Customizations.Add(new UserControllerFailureSpecimenBuilder());
                    break;
                case TestDataValue.USSuccess:
                    fixture.Customizations.Add(new UserServiceSpecimenBuilder());
                    break;
                case TestDataValue.USFailure:
                    fixture.Customizations.Add(new UserServiceFailureSpecimenBuilder());
                    break;
                default:
                    throw new Exception("Could not add customization to SpecimenBuilder");
            }

            return fixture;
        })
    {
    }
}