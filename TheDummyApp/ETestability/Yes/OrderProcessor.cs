using TheDummyApp.ETestability.Yes.Helpers;

namespace TheDummyApp.ETestability.Yes
{


    public class OrderProcessor
    {
        private readonly IOrderRepository _orders;
        private readonly IPaymentGateway _payments;
        private readonly IFileSystem _fileSystem;
        private readonly IEmailService _emailService;

        public OrderProcessor(IOrderRepository orders, IPaymentGateway payments,
                             IFileSystem fileSystem, IEmailService emailService)
        {
            _orders = orders;
            _payments = payments;
            _fileSystem = fileSystem;
            _emailService = emailService;
        }

        public async Task ProcessOrder(int orderId)
        {
            var order = await _orders.GetByIdAsync(orderId);
            var paymentResult = await _payments.ChargeAsync(order.Amount);

            if (paymentResult.IsSuccess)
            {
                await _fileSystem.WriteTextAsync($"receipt_{orderId}.txt", order.Id.ToString());
                await _emailService.SendAsync(order.CustomerEmail, "Order confirmed");
            }
        }
    }
}
