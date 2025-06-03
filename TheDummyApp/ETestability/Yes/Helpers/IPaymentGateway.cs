using TheDummyApp.ETestability.Not.Helpers;

namespace TheDummyApp.ETestability.Yes.Helpers
{
    public interface IPaymentGateway
    {
        Task<PaymentResult> ChargeAsync(int ammount);
    }
}
