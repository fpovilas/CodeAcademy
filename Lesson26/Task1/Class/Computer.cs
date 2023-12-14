namespace Task1.Class
{
    internal class Computer
    {
        private string Brand { get; set; }
        private string Model { get; set; }
        private double RAM { get; set; }
        private double Storage { get; set; }

        public Computer(string brand, string model, double ram, double storage)
        {
            Brand = brand;
            Model = model;
            RAM = ram;
            Storage = storage;
        }

        public string GetBrand() { return Brand; }

        public string GetModel() { return Model; }

        public double GetRAM() { return RAM; }

        public double GetStorage() { return Storage; }

        public bool CanRunProgram(double amoutRamNeed) => amoutRamNeed <= RAM;
    }
}
