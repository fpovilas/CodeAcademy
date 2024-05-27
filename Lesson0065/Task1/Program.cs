using MongoDB.Bson;
using System.Text;
using Task1.Model;
using Task1.Repository;
using Task1.Repository.Interface;

namespace Task1
{
    internal class Program
    {

        private static readonly IRobotRepositoryFS robotRepositoryFS = new RobotRepositoryFS();
        private static readonly IRobotRepositoryMDB robotRepositoryMDB = new RobotRepositoryMDB();

        static void Main()
        {
            Robot robot = robotRepositoryFS.GetRobot();

            //Console.WriteLine($"""
            //Robot Head: {robot.Head!.HeadT}
            //Robot Torso:
            //        Chest: {robot.Torso!.ChestMeasurements}
            //        Waist: {robot.Torso!.WaistMeasurements}
            //Robot Legs:
            //        Leg1: {robot.Legs[0].Material} {robot.Legs[0].NumberOfJoints} {robot.Legs[0].SizeOfFoot}
            //        Leg2: {robot.Legs[1].Material} {robot.Legs[1].NumberOfJoints} {robot.Legs[1].SizeOfFoot}
            //Robot Arms:
            //        Arm1: {robot.Arms[0].Material} {robot.Arms[0].NumberOfJoints} {robot.Arms[0].NumberOfFingers}
            //""");

            List<Robot> robots =
                [
                    new Robot()
                    {
                        ID = ObjectId.GenerateNewId(),
                        Arms =
                        [
                            new Arm()
                            {
                                Material = "Titanium",
                                NumberOfJoints = 1,
                                NumberOfFingers = 5,
                            },
                            new Arm()
                            {
                                Material = "Titanium",
                                NumberOfJoints = 2,
                                NumberOfFingers = 4,
                            }
                        ],
                        Legs =
                        [
                            new Leg()
                            {
                                Material = "Steel",
                                NumberOfJoints = 3,
                                SizeOfFoot = 5
                            },
                            new Leg()
                            {
                                Material = "Steel",
                                NumberOfJoints = 2,
                                SizeOfFoot = 9
                            }
                        ],
                        Torso = new Torso()
                        {
                            ChestMeasurements = 50,
                            WaistMeasurements = 50
                        },
                        Head = new Head()
                        {
                            HeadT = Head.HeadType.Square
                        }
                    },
                    robot
                ];

            //robotRepositoryMDB.CreateRobot(robot);

            //robotRepositoryMDB.DeleteRobot("65dcd54a9e765c089408b91a");

            //robotRepositoryMDB.CreateRobots(robots);

            //Console.WriteLine(robotRepositoryMDB.GetRobotByID("65dcd9a8813d4693196fe976"));

            //FindRobotByUserSelection();

            //Robot newRobot = robotRepositoryMDB.GetRobotByID("65dcd6c06e0065a402133fd3");
            //newRobot.Legs[1].Material = "Metal";
            //newRobot.Legs[1].NumberOfJoints = 3;
            //robotRepositoryMDB.UpdateRobot("65dcd6c06e0065a402133fd3", newRobot);

            //WriteRobotMDBToFile();
        }

        private static void FindRobotByUserSelection()
        {
            Console.Write("""
                1. Find by ID
                2. Find by HeadType
                Your Choice: 
                """);
            if(!int.TryParse(Console.ReadLine(), out int choice))
            { SomethingWentWrong(); }
            else
            {
                switch(choice)
                {
                    case 1:
                        Console.Write("Please enter Robot ID: ");
                        string? robotID = Console.ReadLine();
                        if(string.IsNullOrEmpty(robotID))
                        { SomethingWentWrong(); }
                        else { Console.WriteLine(robotRepositoryMDB.GetRobotByID(robotID)); }
                        break;
                    case 2:
                        Console.Write("Please enter Robot HeadType: ");
                        string? robotHeadType = Console.ReadLine();
                        if (string.IsNullOrEmpty(robotHeadType))
                        { SomethingWentWrong(); }
                        else
                        {
                            List<Robot> robotList = robotRepositoryMDB.GetAllRobots();
                            if(robotList.Count > 0)
                            {
                                switch (robotHeadType.ToLower())
                                {
                                    case "square":
                                        foreach(Robot robot in robotList)
                                        {
                                            if(robot.Head!.HeadT == Head.HeadType.Square)
                                                { Console.WriteLine(robot); }
                                        }
                                        break;
                                    case "round":
                                        foreach (Robot robot in robotList)
                                        {
                                            if (robot.Head!.HeadT == Head.HeadType.Round)
                                            { Console.WriteLine(robot); }
                                        }
                                        break;
                                    case "triangle":
                                        foreach (Robot robot in robotList)
                                        {
                                            if (robot.Head!.HeadT == Head.HeadType.Triangle)
                                            { Console.WriteLine(robot); }
                                        }
                                        break;
                                    case "oblong":
                                        foreach (Robot robot in robotList)
                                        {
                                            if (robot.Head!.HeadT == Head.HeadType.Oblong)
                                            { Console.WriteLine(robot); }
                                        }
                                        break;
                                    default:
                                        SomethingWentWrong();
                                        break;
                                }
                            }
                            else { SomethingWentWrong(); }
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
            }
        }

        private static void SomethingWentWrong()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Something went wrong");
            Console.ResetColor();
        }

        private static void WriteRobotMDBToFile()
        {
            List<Robot> list = robotRepositoryMDB.GetAllRobots();
            StringBuilder stringBuilder = new();
            foreach (Robot robot in list)
            {
                stringBuilder.AppendLine(robot.ToString());
                stringBuilder.AppendLine("------------");
            }

            string pathToFile
                = @"D:\Projektai\Programavimas\CodeAcademy\Lesson65\Task1\DB\TXT\RobotDataFromDB.txt";
            StreamWriter writer = new(pathToFile, true);

            if (File.Exists(pathToFile))
            {
                
                writer.WriteLine(stringBuilder.ToString());
            }
            else
            {
                File.Create(pathToFile);
                writer.WriteLine(stringBuilder.ToString());
                
            }
            writer.Close();
        }
    }
}
