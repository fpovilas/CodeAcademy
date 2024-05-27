using MongoDB.Driver;
using Task1.Model;
using Task1.Repository.Interface;

namespace Task1.Repository
{
    internal class RobotRepositoryMDB : IRobotRepositoryMDB
    {
        private readonly IMongoCollection<Robot> _robots;
        public RobotRepositoryMDB()
        {
            const string connectionUri = "mongodb+srv://<user>:<pass>@mongodb.vpiwb1q.mongodb.net/?retryWrites=true&w=majority&appName=MongoDB";

            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var client = new MongoClient(settings);

            var database = client.GetDatabase("RobotsFactory");
            _robots = database.GetCollection<Robot>("Robots");
        }
        public void CreateRobot(Robot robot)
        {
            _robots.InsertOne(robot);
        
        }

        public void CreateRobots(List<Robot> robots)
        {
            _robots.InsertMany(robots);
        }

        public List<Robot> GetAllRobots()
        {
            return _robots.Find(robot => true).ToList();
        }

        public Robot GetRobotByID(string id)
        {
            return _robots.Find<Robot>(robot => robot.ID.ToString() == id).FirstOrDefault();
        }

        public void UpdateRobot(string id, Robot robotIn)
        {
            _robots.ReplaceOne(robot => robot.ID.ToString() == id, robotIn);
        }

        public void DeleteRobot(string id)
        {
            _robots.DeleteOne(robot => robot.ID.ToString() == id);
        }

        public void DeleteAllRobots()
        {
            _robots.DeleteMany(robot => true);
        }
    }
}
