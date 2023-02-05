﻿using System;
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
    public class OrdersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public OrdersController(ApplicationDbContext context)
        public OrdersController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Orders
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        public async Task<IActionResult> GetOrders()
        {
            //return await _context.Orders.ToListAsync();
            var orders = await _unitOfWork.Orders.GetAll();
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Orders>> GetOrder(int id)
        public async Task<IActionResult> GetOrder(int id)
        {
            //var order = await _context.Orders.FindAsync(id);
            var order = await _unitOfWork.Orders.Get(q => q.ID == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.ID)
            {
                return BadRequest();
            }

            //_context.Entry(order).State = EntityState.Modified;
            _unitOfWork.Orders.Update(order);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!OrderExists(id))
                if (!await OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            //_context.Orders.Add(order);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Orders.Insert(order);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetOrder", new { id = order.ID }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            //var order = await _context.Orders.FindAsync(id);
            var order = await _unitOfWork.Orders.Get(q => q.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            //_context.Orders.Remove(order);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Orders.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool OrderExists(int id)
        private async Task<bool> OrderExists(int id)
        {
            //return _context.Orders.Any(e => e.ID == id);
            var order = await _unitOfWork.Orders.Get(q => q.ID == id);
            return order != null;
        }
    }
}
