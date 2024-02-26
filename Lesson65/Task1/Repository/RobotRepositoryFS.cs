using Task1.Model;
using Task1.Repository.Interface;

namespace Task1.Repository
{
    internal class RobotRepositoryFS : IRobotRepositoryFS
    {
        private static readonly string _pathToRobotRepoFile
            = @"[PATH]\Lesson65\Task1\DB\TXT\RobotData.txt";

        private static readonly Robot _robot = new();

        private static string[]? _contentOfFile;

        public RobotRepositoryFS()
        {
            try
            {
                if (File.Exists(_pathToRobotRepoFile))
                {
                    _contentOfFile = File.ReadAllLines(_pathToRobotRepoFile);

                    LoadRobot(_contentOfFile);
                }
                else
                    throw new ArgumentNullException($"The File {_pathToRobotRepoFile} does not exists.");
            }
            catch (ArgumentNullException msg)
            {
                Console.WriteLine(msg);
            }
        }

        private static void LoadRobot(string[] contentOfFile)
        {
            if (contentOfFile.Length <= 0)
            { Console.WriteLine("There is no data in file."); }
            else
            {
                Head head = CreateHeadFromContent(contentOfFile);
                Torso torso = CreateTorsoFromContent(contentOfFile);
                List<Leg> Legs = CreateLegsFromContent(contentOfFile);
                List<Arm> Arms = CreateArmsFromContent(contentOfFile);

                _robot.Head = head;
                _robot.Torso = torso;
                _robot.Legs = Legs;
                _robot.Arms = Arms;
            }
        }

        private static Head CreateHeadFromContent(string[] contentOfFile)
            => new()
            {
                HeadT = (Head.HeadType)Convert.ToInt32(contentOfFile[0].Trim(';')),
            };

        private static Torso CreateTorsoFromContent(string[] contentOfFile)
            => new()
            {
                ChestMeasurements = Convert.ToDouble(contentOfFile[1].Trim(';').Split(',').ToList()[0].Replace('.', ',')),
                WaistMeasurements = Convert.ToDouble(contentOfFile[1].Trim(';').Split(',').ToList()[1].Replace('.', ','))
            };

        private static List<Leg> CreateLegsFromContent(string[] contentOfFile)
        {
            List<Leg> legs = [];
            int indexer = Convert.ToInt32(contentOfFile[2].Trim(';'));

            for (int j = 3; j < 3 + indexer; j++)
            {
                Leg leg = new()
                {
                    Material = contentOfFile[j].Trim(';').Split(',')[0],
                    NumberOfJoints = Convert.ToInt32(contentOfFile[j].Trim(';').Split(',')[1]),
                    SizeOfFoot = Convert.ToInt32(contentOfFile[j].Trim(';').Split(',')[2])
                };
                legs.Add(leg);
            }

            return legs;
        }

        private static List<Arm> CreateArmsFromContent(string[] contentOfFile)
        {
            List<Arm> arms = [];
            int indexer = Convert.ToInt32(contentOfFile[5].Trim(';'));

            for (int j = 6; j < 6 + indexer; j++)
            {
                Arm arm = new()
                {
                    Material = contentOfFile[j].Trim(';').Split(',')[0],
                    NumberOfJoints = Convert.ToInt32(contentOfFile[j].Trim(';').Split(',')[1]),
                    NumberOfFingers = Convert.ToInt32(contentOfFile[j].Trim(';').Split(',')[2])
                };
                arms.Add(arm);
            }

            return arms;
        }

        public Robot GetRobot() => _robot;
    }
}
