namespace Task2.Class
{
    internal class Person(string name, List<Animal> animals)
    {
        public string Name { get; set; } = name;
        public List<Animal> Animals { get; set; } = animals;
    }
}
