using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PovilasWebProject.Server.Data;
using PovilasWebProject.Server.Models;

namespace PovilasWebProject.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly PovilasDbContext _context;

        public ProductsController(PovilasDbContext context)
        {
            _context = context;
        }

        // GET: Products
        [HttpGet(Name = "GetProducts")]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        // POST: Products/Create
        [HttpPost(Name = "CreateProduct")]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
            return BadRequest(ModelState);
        }

        // PUT: Products/Edit/5
        [HttpPut("{id}", Name = "EditProduct")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return BadRequest(ModelState);
        }

        // DELETE: Products/Delete/5
        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
