using System.ComponentModel.DataAnnotations;

namespace APIAplicacion.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        // Relaciones
        public int IdProveedor { get; set; }
        public Proveedor? Proveedor { get; set; }

        public int IdCategoria { get; set; }
        public Categoria? Categoria { get; set; }
    }
}