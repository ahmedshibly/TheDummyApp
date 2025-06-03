using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TheDummyApp.ETestability.Not.Helpers;
using SmtpClient = TheDummyApp.ETestability.Not.Helpers.SmtpClient;

namespace TheDummyApp.ETestability.Not
{

    public class OrderProcessor
    {
        public void ProcessOrder(int orderId)
        {
            // Hidden dependencies everywhere!
            var order = new SqlOrderRepository().GetById(orderId);
            var paymentResult = new PaymentGateway().Charge(order.Amount);

            if (paymentResult.IsSuccess)
            {
                File.WriteAllText($"receipt_{orderId}.txt", order.ToString());
                new SmtpClient().Send(order.CustomerEmail, "Order confirmed");
            }
        }
    }

}
