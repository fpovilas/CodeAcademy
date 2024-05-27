namespace Task2.Class
{
    internal class Validation<T>
    {
        private T VariableToCheck
        {
            get => VariableToCheck;
            set { }
        }

        public Validation(T variableToCheck)
        {
            VariableToCheck = variableToCheck;
        }

        public void SetVariableToCheck(T variableToCheck)
        {
            VariableToCheck = variableToCheck;
        }

        public static void Validate(T parameterToCheck)
        {
            if (parameterToCheck == null)
            {
                Console.WriteLine("Your parameter is null");
            }
            else { Console.WriteLine("Your parameter has value"); }
        }
    }
}
