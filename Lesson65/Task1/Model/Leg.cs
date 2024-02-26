namespace Task1.Model
{
    internal class Leg
    {
        public string? Material { get; set; }
        public int NumberOfJoints { get; set; }
        public int SizeOfFoot { get; set; }

        public override string ToString()
        {
            return $"""
                        Material: {Material},
                        NumberOfJoints: {NumberOfJoints},
                        SizeOfFoot: {SizeOfFoot}
                    """;
        }
    }
}
