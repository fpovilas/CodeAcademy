using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp.Service.Interfaces
{
    internal interface IEmailService
    {
        public void Send(Order order);
    }
}
