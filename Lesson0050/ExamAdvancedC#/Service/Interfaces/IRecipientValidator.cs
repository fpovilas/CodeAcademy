namespace ExamAdvancedCSharp.Service.Interfaces
{
    internal interface IRecipientValidator
    {
        public void SetRecipientEmail(string recipientEmail);
        public bool CheckEmail();
    }
}
