using AutoFixture.Kernel;
using UnitTestPracticeApplication.Models;

namespace xUnitTestLecturersAPI.SpecimenBuilder
{
    internal class BookSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if(request is Type type && type == typeof(Book))
            {
                Genre bookGenre = new() {Id = Guid.NewGuid(), Name = "Custom Genre" };
                Book book = new() { Id = Guid.NewGuid(), Genre = bookGenre, Title = "Custom Title" };
                return book;
            }

            return new NoSpecimen();
        }
    }
}
