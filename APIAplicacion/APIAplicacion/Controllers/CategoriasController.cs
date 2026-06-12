using APIAplicacion.Data;
using APIAplicacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIAplicacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/categorias
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categorias = await _context.Categorias
                .Include(p => p.Productos)
                .ToListAsync();

            return Ok(categorias);
        }

        // GET: api/categorias/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var categoria = await _context.Categorias
                .Include(p => p.Productos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (categoria == null)

                return NotFound("\nCategoria no encontrado.");

            return Ok(categoria);

        }

        // POST: api/categorias
        [HttpPost]
        public async Task<IActionResult> Post(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return Ok(categoria);
        }

        // PUT: api/categorias/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Categoria categoria)
        {
            if (id != categoria.Id)

                return BadRequest("\nID de la categoria no coincide.");

            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/categorias/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)

                return NotFound("\nCategoria no encontrado.");

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
