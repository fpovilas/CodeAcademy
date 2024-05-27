using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp.Service.Interfaces
{
    internal interface IEmailService
    {
        public bool Send(Order order);
    }
}
