using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Dtos.OrderDto;
using OrderService.Entities;
using OrderService.Services;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Create")]

        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto dto)
        {
            var orderId = await _orderService.CreateOrderAsync(dto);
            return Ok(new { OrderId = orderId, Message = "Order created successfully." });
        }

        [HttpGet("GetOrderById")]
        public async Task<IActionResult> GetOrderById(long orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null)
                return NotFound(new { Message = "Order not found." });
            return Ok(order);
        }

        [HttpGet("GetOrdersByUser")]
        public async Task<IActionResult> GetOrdersByUser(long userId)
        {
            var orders = await _orderService.GetOrdersByUserAsync(userId);
            return Ok(orders);
        }

        [HttpPut("UpdateOrderStatus")]
        public async Task<IActionResult> UpdateOrderStatus(long orderId, string status)
        {
            var result = await _orderService.UpdateOrderStatusAsync(orderId, status);
            if (!result)
                return NotFound(new { Message = "Order not found or status update failed." });
            return Ok(new { Message = "Order status updated successfully." });
        }

        [HttpDelete("CancelOrder")]
        public async Task<IActionResult> CancelOrder(long orderId)
        {
            var result = await _orderService.CancelOrderAsync(orderId);
            if (!result)
                return NotFound(new { Message = "Order not found or cannot be cancelled." });
            return Ok(new { Message = "Order cancelled successfully." });
        }
    }
}
