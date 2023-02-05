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
    public class GamingProductsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public GamingProductsController(ApplicationDbContext context)
        public GamingProductsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/GamingProducts
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<GamingProduct>>> GetGamingProducts()
        public async Task<IActionResult> GetGamingProducts()
        {
            //return await _context.GamingProducts.ToListAsync();
            var products = await _unitOfWork.GamingProducts.GetAll();
            return Ok(products);
        }

        // GET: api/GamingProducts/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<GamingProducts>> GetGamingProduct(int id)
        public async Task<IActionResult> GetGamingProduct(int id)
        {
            //var product = await _context.GamingProducts.FindAsync(id);
            var product = await _unitOfWork.GamingProducts.Get(q => q.ID == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/GamingProduct/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGamingProduct(int id, GamingProduct product)
        {
            if (id != product.ID)
            {
                return BadRequest();
            }

            //_context.Entry(product).State = EntityState.Modified;
            _unitOfWork.GamingProducts.Update(product);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!GamingProductExists(id))
                if (!await GamingProductExists(id))
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

        // POST: api/GamingProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GamingProduct>> PostGamingProduct(GamingProduct product)
        {
            //_context.GamingProducts.Add(product);
            //await _context.SaveChangesAsync();
            await _unitOfWork.GamingProducts.Insert(product);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetGamingProduct", new { id = product.ID }, product);
        }

        // DELETE: api/GamingProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamingProduct(int id)
        {
            //var product = await _context.GamingProducts.FindAsync(id);
            var product = await _unitOfWork.GamingProducts.Get(q => q.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            //_context.GamingProducts.Remove(product);
            //await _context.SaveChangesAsync();
            await _unitOfWork.GamingProducts.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool GamingProductExists(int id)
        private async Task<bool> GamingProductExists(int id)
        {
            //return _context.GamingProducts.Any(e => e.ID == id);
            var product = await _unitOfWork.GamingProducts.Get(q => q.ID == id);
            return product != null;
        }
    }
}
