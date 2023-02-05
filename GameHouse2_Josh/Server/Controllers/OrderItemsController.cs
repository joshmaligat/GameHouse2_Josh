using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameHouse2_Josh.Server.Data;
using GameHouse2_Josh.Shared.Domain;
using GameHouse2_Josh.Server.IRepository;

namespace GameHouse2_Josh.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public OrderItemsController(ApplicationDbContext context)
        public OrderItemsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/OrderItems
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        public async Task<IActionResult> GetOrderItems()
        {
            //return await _context.OrderItems.ToListAsync();
            var orderitems = await _unitOfWork.OrderItems.GetAll(includes: q => q.Include(x => x.Order).Include(x => x.Product));
            return Ok(orderitems);
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<OrderItems>> GetOrderItem(int id)
        public async Task<IActionResult> GetOrderItem(int id)
        {
            //var orderitem = await _context.OrderItems.FindAsync(id);
            var orderitem = await _unitOfWork.OrderItems.Get(q => q.ID == id);

            if (orderitem == null)
            {
                return NotFound();
            }

            return Ok(orderitem);
        }

        // PUT: api/OrderItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(int id, OrderItem orderitem)
        {
            if (id != orderitem.ID)
            {
                return BadRequest();
            }

            //_context.Entry(orderitem).State = EntityState.Modified;
            _unitOfWork.OrderItems.Update(orderitem);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!OrderItemExists(id))
                if (!await OrderItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem orderitem)
        {
            //_context.OrderItems.Add(orderitem);
            //await _context.SaveChangesAsync();
            await _unitOfWork.OrderItems.Insert(orderitem);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetOrderItem", new { id = orderitem.ID }, orderitem);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            //var orderitem = await _context.OrderItems.FindAsync(id);
            var orderitem = await _unitOfWork.OrderItems.Get(q => q.ID == id);
            if (orderitem == null)
            {
                return NotFound();
            }

            //_context.OrderItems.Remove(orderitem);
            //await _context.SaveChangesAsync();
            await _unitOfWork.OrderItems.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool OrderItemExists(int id)
        private async Task<bool> OrderItemExists(int id)
        {
            //return _context.OrderItems.Any(e => e.ID == id);
            var orderitem = await _unitOfWork.OrderItems.Get(q => q.ID == id);
            return orderitem != null;
        }
    }
}
