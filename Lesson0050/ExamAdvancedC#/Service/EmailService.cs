using ExamAdvancedCSharp.Class;
using ExamAdvancedCSharp.Service.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Text;

namespace ExamAdvancedCSharp.Service
{
    internal class EmailService : IEmailService
    {

        public bool Send(Order order)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                            .AddUserSecrets<Program>()
                            .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
                            .Build();

            RecipientValidatorService recipientValidatorService = new();
            Console.Write("Please enter recipient e.mail: ");
            string? recipient = Console.ReadLine();
            if (!string.IsNullOrEmpty(recipient))
            {
                ((IRecipientValidator)recipientValidatorService).SetRecipientEmail(recipient);
                if(((IRecipientValidator)recipientValidatorService).CheckEmail())
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress($"Dining RegSys Receipt", configuration["email"]));
                    message.To.Add(new MailboxAddress(recipient, recipient));
                    message.Subject = $"Dining RegSys Order: {order.GetID():000000}";
                    message.Body = new TextPart("html")
                    {
                        Text = CreateReceipt(order)
                    };

                    using var client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate(configuration["email"], configuration["password"]);
                    client.Send(message);
                    client.Disconnect(true);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static string CreateReceipt(Order order)
        {
            StringBuilder stringBuilder = new();
            Dictionary<string, int> distinctFood = order.GetFoodItems().GroupBy(n => n.GetName())
                                                                       .ToDictionary(x => x.Key, x => x.Count());
            stringBuilder.AppendLine($"""
                                <table style="border-style:dotted; font-family:monospace; width: 45%">
                                <tr>
                                <th colspan="3" style="text-align: center;">Dining RegSys #NamePlaceHolder#</th>
                                <th style="text-align: right;">Order: {order.GetID():000000}</th>
                                </tr>
                                """);
            double total = 0;
            foreach (KeyValuePair<string, int> foodItem in distinctFood)
            {
                double price = order.GetFoodItems()
                                               .FirstOrDefault(x => x.GetName().Equals(foodItem.Key))!
                                               .GetPrice();
                double totalPrice = price * foodItem.Value;
                stringBuilder.AppendLine($"<tr>");
                stringBuilder.AppendLine($"<td colspan=\"2\">{foodItem.Key}</td>");
                stringBuilder.AppendLine($"<td>{price} x {foodItem.Value}</td>");
                stringBuilder.AppendLine($"<td style=\"text-align: right;\">{totalPrice:##0.00}€</td>");
                stringBuilder.AppendLine($"</tr >");
                total += price * foodItem.Value;
            }
            stringBuilder.AppendLine($"""
                                <tr>
                                <td>Waiter:</td>
                                <td colspan="2" style="text-align: left;">{order?.GetTable()?.GetWaiter()?.GetName()}</td>
                                <td style="text-align: right;">Order: {order?.GetOrderTime()}</td>
                                </tr>
                                <tr>
                                <td>Total:</td>
                                <td colspan="3">{total:##0.00}€</td>
                                </tr>
                                </table>
                                """);
            return stringBuilder.ToString();
        }
    }
}
