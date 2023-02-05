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
    public class ShippingAddressesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public ShippingAddressesController(ApplicationDbContext context)
        public ShippingAddressesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/ShippingAddresses
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<ShippingAddress>>> GetShippingAddresses()
        public async Task<IActionResult> GetShippingAddresses()
        {
            //return await _context.Categories.ToListAsync();
            var addresses = await _unitOfWork.ShippingAddresses.GetAll();
            return Ok(addresses);
        }

        // GET: api/ShippingAddresses/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<ShippingAddress>> GetShippingAddress(int id)
        public async Task<IActionResult> GetShippingAddress(int id)
        {
            //var address = await _context.ShippingAddresses.FindAsync(id);
            var address = await _unitOfWork.ShippingAddresses.Get(q => q.ID == id);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        // PUT: api/ShippingAddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippingAddress(int id, ShippingAddress address)
        {
            if (id != address.ID)
            {
                return BadRequest();
            }

            //_context.Entry(address).State = EntityState.Modified;
            _unitOfWork.ShippingAddresses.Update(address);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!CategoryExists(id))
                if (!await ShippingAddressExists(id))
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

        // POST: api/ShippingAddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShippingAddress>> PostShippingAddress(ShippingAddress address)
        {
            //_context.ShippingAddresses.Add(address);
            //await _context.SaveChangesAsync();
            await _unitOfWork.ShippingAddresses.Insert(address);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetShippingAddress", new { id = address.ID }, address);
        }

        // DELETE: api/ShippingAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippingAddress(int id)
        {
            //var address = await _context.ShippingAddresses.FindAsync(id);
            var address = await _unitOfWork.ShippingAddresses.Get(q => q.ID == id);
            if (address == null)
            {
                return NotFound();
            }

            //_context.ShippingAddresses.Remove(address);
            //await _context.SaveChangesAsync();
            await _unitOfWork.ShippingAddresses.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool ShippingAddressExists(int id)
        private async Task<bool> ShippingAddressExists(int id)
        {
            //return _context.ShippingAddresses.Any(e => e.ID == id);
            var address = await _unitOfWork.ShippingAddresses.Get(q => q.ID == id);
            return address != null;
        }
    }
}
