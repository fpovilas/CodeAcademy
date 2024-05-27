namespace Task1.Model
{
    internal class Arm
    {
        public string? Material { get; set; }
        public int NumberOfJoints { get; set; }
        public int NumberOfFingers { get; set; }

        public override string ToString()
        {
            return $"""
                    Material: {Material},
                    NumberOfJoints: {NumberOfJoints},
                    NumberOfFingers: {NumberOfFingers}
                """;
        }
    }
}
