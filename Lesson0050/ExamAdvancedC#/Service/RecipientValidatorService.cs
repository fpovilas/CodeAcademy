using ExamAdvancedCSharp.Service.Interfaces;
using System.Text.RegularExpressions;

namespace ExamAdvancedCSharp.Service
{
    internal class RecipientValidatorService : IRecipientValidator
    {
        private string RecipientEmail { get; set; } = string.Empty;

        public void SetRecipientEmail(string recipientEmail) => RecipientEmail = recipientEmail;

        public bool CheckEmail()
        {
            string pattern = @"(\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b)";
            Regex regex = new(pattern);

            bool isValid = regex.IsMatch(RecipientEmail);

            if (isValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void AskEmail() => Console.Write("Please enter recipient e. mail: ");

    }
}
