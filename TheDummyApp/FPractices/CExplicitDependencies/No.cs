using TheDummyApp.ETestability.Not.Helpers;

namespace TheDummyApp.FPractices.CExplicitDependencies
{
    public class No
    {       
        public void PlaceOrder(Order order)
        {
            
            var emailSender = new SmtpClient();
            emailSender.Send(order.CustomerEmail, "Order Confirmation");

            // ... more logic ...
        }
    }
}
