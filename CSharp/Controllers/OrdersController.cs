using CSharp.Models;
using CSharp.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _orderRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrders(int id)
        {
            return await _orderRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrders([FromBody]Order order)
        {
            var newOrder = await _orderRepository.Create(order);
            return CreatedAtAction(nameof(GetOrders), new { id = newOrder.Id }, newOrder);
        }

        [HttpPut]
        public async Task<ActionResult> PutOrders(int id, [FromBody] Order order)
        {
            if(id != order.Id)
            {
                return BadRequest();
            }
            await _orderRepository.Update(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var deleteOrder = await _orderRepository.Get(id);

            if (deleteOrder == null)
                return NotFound();

            await _orderRepository.Delete(deleteOrder.Id);
            return NoContent();
        }
    }
}
