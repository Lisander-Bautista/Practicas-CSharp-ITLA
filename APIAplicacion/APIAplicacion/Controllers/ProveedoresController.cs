using APIAplicacion.Data;
using APIAplicacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIAplicacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProveedoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/proveedores
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var proveedores = await _context.Proveedores
                .Include(p => p.Productos)
                .ToListAsync();

            return Ok(proveedores);
        }

        // GET: api/proveedores/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var proveedor = await _context.Proveedores
                .Include(p => p.Productos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (proveedor == null)

                return NotFound("\nProducto no encontrado.");

            return Ok(proveedor);

        }

        // POST: api/proveedores
        [HttpPost]
        public async Task<IActionResult> Post(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();

            return Ok(proveedor);
        }

        // PUT: api/proveedor/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Proveedor proveedor)
        {
            if (id != proveedor.Id)

                return BadRequest("\nID del proveedor no coincide.");

            _context.Entry(proveedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/proveedor/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null)

                return NotFound("\nProveedor no encontrado.");

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
