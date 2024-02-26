using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text;

namespace Task1.Model
{
    internal class Robot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ID { get; set; }
        public List<Arm>? Arms { get; set; }
        public List<Leg>? Legs { get; set; }
        public Torso? Torso { get; set; }
        public Head? Head { get; set; }

        public override string ToString()
            => $"""
            Robot Head:
                {Head!.HeadT}
            Robot Torso:
                Waist: {Torso!.WaistMeasurements} cm
                Chest: {Torso!.ChestMeasurements} cm
            Robot Arms:
            {GenericPrint(Arms!)}
            Robot Legs:
            {GenericPrint(Legs!)}
            """;

        private string GenericPrint<T>(List<T> value) where T : class
        {
            StringBuilder stringBuilder = new();

            foreach(var item in value)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
