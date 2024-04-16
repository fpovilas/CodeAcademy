using AutoFixture.Kernel;
using UnitTestPracticeApplication.DTOs;
using UnitTestPracticeApplication.Models;

namespace xUnitTestLecturersAPI.SpecimenBuilder
{
    internal class UserDtoSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if(request is Type type && type == typeof(UserDto))
            {
                return new UserDto() { Password = "password", Username = "username"};
            }

            return new NoSpecimen();
        }
    }
}
