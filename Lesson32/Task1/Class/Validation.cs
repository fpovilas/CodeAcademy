namespace Task1.Class
{
    internal class Validation<T>
    {
        private T? VariableToCheck { get; set; }

        public Validation(T? variableToCheck)
        {
            VariableToCheck = variableToCheck;
        }

        public void Validate()
        {
            if (VariableToCheck == null)
            {
                Console.WriteLine("Your parameter is null");
            }
            else { Console.WriteLine("Your parameter has value"); }
        }
    }
}
