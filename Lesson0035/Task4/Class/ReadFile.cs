namespace Task4.Class
{
    internal class ReadFile
    {
        private readonly string[]? fileContent;
        private string? Path { get; set; } = "";

        public ReadFile(string? path)
        {
            Path = path;
            
            fileContent = File.ReadAllLines(Path!);

        }

        public void SetPath(string path) => Path = path;

        public string? GetPath() => Path;

        public string[]? GetContent() => fileContent;
    }
}
