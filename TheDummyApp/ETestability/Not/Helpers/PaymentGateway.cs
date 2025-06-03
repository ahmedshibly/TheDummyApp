using Ardalis.Result;

namespace TheDummyApp.ETestability.Not.Helpers
{
    public class PaymentGateway
    {
        public Result<PaymentResult> Charge(int ammount)
        {
            return new PaymentResult();
        }
    }

}
