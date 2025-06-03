using TheDummyApp.ETestability.Not.Helpers;

namespace TheDummyApp.ETestability.Yes.Helpers
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Task<Order> GetByIdAsync(int orderId);
    }
}
