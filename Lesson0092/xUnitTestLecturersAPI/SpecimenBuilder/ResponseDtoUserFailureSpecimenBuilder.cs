using AutoFixture.Kernel;
using UnitTestPracticeApplication.DTOs;
using UnitTestPracticeApplication.Models;

namespace xUnitTestLecturersAPI.SpecimenBuilder
{
    internal class ResponseDtoUserFailureSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (request is Type type && type.IsEquivalentTo(typeof(ResponseDto)))
            {
                return new ResponseDto(false);
            }

            return new NoSpecimen();
        }
    }
}
