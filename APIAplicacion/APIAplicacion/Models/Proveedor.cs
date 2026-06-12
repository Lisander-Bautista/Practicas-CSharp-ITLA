using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIAplicacion.Models
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }
        public string? Contacto { get; set; }
        
        [JsonIgnore]
        public List<Producto>? Productos { get; set; }
    }
}
