using APIAplicacion.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAplicacion.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación entre Producto y Proveedor
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Proveedor)
                .WithMany(p => p.Productos)
                .HasForeignKey(p => p.IdProveedor);

            // Configuración de la relación entre Producto y Categoria
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.IdCategoria);
        }
    }
}