using OrderService.Dtos.OrderDto;

namespace OrderService.Services
{
    public interface IOrderService
    {
        Task<long> CreateOrderAsync(OrderCreateDto dto);
        Task<IEnumerable<OrderGetDto>> GetOrdersByUserAsync(long userId);
        Task<OrderGetDto?> GetOrderByIdAsync(long orderId);
        Task<bool> UpdateOrderStatusAsync(long orderId, string status);
        Task<bool> CancelOrderAsync(long orderId);
    }
}
