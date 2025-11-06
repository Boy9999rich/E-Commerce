using Microsoft.EntityFrameworkCore;
using OrderService.Dtos.OrderDto;
using OrderService.Dtos.OrderItemDto;
using OrderService.Entities;
using OrderService.Persistence;

namespace OrderService.Services
{
    public class OrderServicess : IOrderService
    {
        private readonly AppDbContext _dbcontext;

        public OrderServicess(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> CancelOrderAsync(long orderId)
        {
            var order = await _dbcontext.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            if (order == null) return false;

            // faqat hali jo‘natilmagan yoki to‘lanmagan buyurtmalarni bekor qilish mumkin
            if (order.Status == "Pending" || order.Status == "Processing")
            {
                order.Status = "Cancelled";
                await _dbcontext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<long> CreateOrderAsync(OrderCreateDto dto)
        {
            var order = new Order
            {
                UserId = dto.UserId,
                Status = "Pending",
                OrderDate = DateTime.UtcNow,
                TotalAmount = dto.Items.Sum(i => i.Quantity * i.UnitPrice),
                OrderItems = dto.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };

            _dbcontext.Orders.Add(order);
            await _dbcontext.SaveChangesAsync();

            return order.OrderId;

        }

        public async Task<OrderGetDto?> GetOrderByIdAsync(long orderId)
        {
            var order = await _dbcontext.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
                return null;

            return new OrderGetDto
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                Status = order.Status,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Items = order.OrderItems.Select(i => new OrderItemmDto
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };
        }

        public async Task<IEnumerable<OrderGetDto>> GetOrdersByUserAsync(long userId)
        {
            var orders = await _dbcontext.Orders
                .Include(o => o.OrderItems)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new OrderGetDto
                {
                    OrderId = o.OrderId,
                    UserId = o.UserId,
                    Status = o.Status,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    Items = o.OrderItems.Select(i => new OrderItemmDto
                    {
                        ProductId = i.ProductId,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice
                    }).ToList()
                })
                .ToListAsync();

            return orders;
        }

        public async Task<bool> UpdateOrderStatusAsync(long orderId, string status)
        {
            var order = await _dbcontext.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            if (order == null) return false;

            order.Status = status;
            _dbcontext.Orders.Update(order);
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
