using APIAplicacion.Data;
using APIAplicacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIAplicacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/productos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productos = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .ToListAsync();

            return Ok(productos);
        }

        // GET: api/productos/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (producto == null)
            {
                return NotFound("\nProducto no encontrado.");
            }
            return Ok(producto);

        }

        // POST: api/productos
        [HttpPost]
        public async Task<IActionResult> Post(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            var productoCreado = await _context.Productos
                .Include(p => p.Proveedor)
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == producto.Id);

            return Ok(productoCreado);
        }

        // PUT: api/productos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Producto producto)
        {
            if (id != producto.Id)

                return BadRequest("\nID del producto no coincide.");

            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/productos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)

                return NotFound("\nProducto no encontrado.");

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // GET: api/productos/estadisticas
        [HttpGet("estadisticas")]
        public async Task<IActionResult> Estadisticas()
        {
            var productos = await _context.Productos
                .Include(p => p.Proveedor)
                .Include(p => p.Categoria)
                .ToListAsync();

            var data = new
            {
                MasCaro = productos.OrderByDescending(p => p.Precio).FirstOrDefault(),

                MasBarato = productos.OrderBy(p => p.Precio).FirstOrDefault(),

                Suma = productos.Sum(p => p.Precio),

                Promedio = productos.Average(p => p.Precio)
            };

            return Ok(data);
        }

        // GET: api/productos/categoria/{IdCategoria}
        [HttpGet("categoria/{id}")]
        public async Task<IActionResult> PorCategoria(int id)
        {
            var productos = await _context.Productos
                .Where(p => p.IdCategoria == id)
                .Include(p => p.Proveedor)
                .Include(p => p.Categoria)
                .ToListAsync();

            return Ok(productos);
        }

        // GET: api/productos/proveedor/{proveedorId}
        [HttpGet("proveedor/{id}")]
        public async Task<IActionResult> PorProveedor(int id)
        {
            var productos = await _context.Productos
                .Where(p => p.IdProveedor == id)
                .Include(p => p.Proveedor)
                .Include (p => p.Categoria)
                .ToListAsync();

            return Ok(productos);
        }

        // GET: api/productos/total
        [HttpGet("total")]
        public async Task<IActionResult> Total()
        {
            var total = await _context.Productos.CountAsync();

            return Ok(new { Total = total });
        }
    }
}
