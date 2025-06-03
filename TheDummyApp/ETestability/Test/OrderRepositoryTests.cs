using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using TheDummyApp.ETestability.Not.Helpers;
using TheDummyApp.ETestability.Yes;
using TheDummyApp.ETestability.Yes.Helpers;
using Xunit;

namespace TheDummyApp.ETestability.Test
{
    public class OrderRepositoryTests
    {

        [Fact]
        public async Task ProcessOrder_WhenPaymentSucceeds_ShouldWriteReceiptAndSendEmail()
        {
            // Arrange
            var orderId = 42;
            var order = new Order
            {
                Id = orderId,
                Amount = 100,
                CustomerEmail = "customer@example.com"
            };

            var orders = Substitute.For<IOrderRepository>();
            var payments = Substitute.For<IPaymentGateway>();
            var fileSystem = Substitute.For<IFileSystem>();
            var emailService = Substitute.For<IEmailService>();

            orders.GetByIdAsync(orderId).Returns(order);
            payments.ChargeAsync(order.Amount).Returns(new PaymentResult { IsSuccess = true });

            var processor = new OrderProcessor(orders, payments, fileSystem, emailService);

            // Act
            await processor.ProcessOrder(orderId);

            // Assert
            await fileSystem.Received(1)
                .WriteTextAsync($"receipt_{orderId}.txt", order.Id.ToString());

            await emailService.Received(1)
                .SendAsync(order.CustomerEmail, "Order confirmed");
        }
    }
}
