using Task1.Model;

namespace Task1.Repository.Interface
{
    internal interface IRobotRepositoryMDB
    {
        public void CreateRobot(Robot robot);
        public void CreateRobots(List<Robot> robots);
        public List<Robot> GetAllRobots();
        public Robot GetRobotByID(string id);
        public void UpdateRobot(string id, Robot robotIn);
        public void DeleteRobot(string id);
        public void DeleteAllRobots();
    }
}
