using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIAplicacion.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [JsonIgnore]
        public List<Producto>? Productos { get; set; }
    }
}
