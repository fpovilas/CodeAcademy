using AutoFixture.Kernel;
using UnitTestPracticeApplication.Models;

namespace xUnitTestLecturersAPI.SpecimenBuilder
{
    internal class BookFailureSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if(request is Type type && type == typeof(Book))
            {
                return new Book();
            }

            return new NoSpecimen();
        }
    }
}
