using Castle.Core.Smtp;
using TheDummyApp.ETestability.Not.Helpers;

namespace TheDummyApp.FPractices.CExplicitDependencies
{
    internal class Yes(IEmailSender emailSender)
    {
        private readonly IEmailSender _emailSender = emailSender;
        public void PlaceOrder(Order order)
        {
            _emailSender.Send(order.CustomerEmail,"", "",  "Order Confirmation");
            // ... more logic ...
        }

    }
}
