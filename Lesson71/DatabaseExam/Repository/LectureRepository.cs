using DatabaseExam.Database;
using DatabaseExam.Database.Models;
using DatabaseExam.Repository.Interface;

namespace DatabaseExam.Repository
{
    internal class LectureRepository(StudentISContext context) : ILectureRepository
    {
        private readonly StudentISContext studentISContext = context;

        public int AddLecture(Lecture lecture)
        {
            studentISContext.Lectures.Add(lecture);
            studentISContext.SaveChanges();

            return studentISContext.Lectures.FirstOrDefault(dID => dID.Id == lecture.Id)!.Id;
        }

        public Lecture GetLectureByID(int lectureId)
            => studentISContext.Lectures.FirstOrDefault(dID => dID.Id == lectureId) ?? new();

        public List<Lecture> GetAllLectures() => studentISContext.Lectures.ToList();

        public void UpdateLecture(Lecture lectureIn)
        {
            studentISContext.Lectures.Update(lectureIn);
            studentISContext.SaveChanges();
        }

        public void DeleteLectureByID(int lectureId)
        {
            studentISContext.Lectures.Remove(GetLectureByID(lectureId));
        }
    }
}
