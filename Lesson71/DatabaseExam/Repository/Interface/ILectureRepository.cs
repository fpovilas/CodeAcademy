using DatabaseExam.Database.Models;

namespace DatabaseExam.Repository.Interface
{
    public interface ILectureRepository
    {
        public int AddLecture(Lecture lecture);
        public Lecture GetLectureByID(int lectureId);
        public List<Lecture> GetAllLectures();
        public void UpdateLecture(Lecture lectureIn);
        public void DeleteLectureByID(int lectureId);
    }
}
