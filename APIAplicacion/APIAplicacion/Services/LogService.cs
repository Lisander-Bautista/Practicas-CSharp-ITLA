using System.Text.Json;
using APIAplicacion.Models;

namespace APIAplicacion.Services
{
    public class LogService
    {
        private readonly string filePath = "logs_usuarios.txt";

        public void GuardarLog(Usuario usuario)
        {
            try
            {
                var log = new
                {
                        usuario.Id,
                        usuario.Username,
                        usuario.Nombre,
                        usuario.Correo,
                        FechaRegistro = DateTime.Now
                };

                var json = JsonSerializer.Serialize(log);

                File.AppendAllText(filePath, json + Environment.NewLine);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el log: " + ex.Message);
            }
        }

        public List<object> ObtenerLogs()
        {
            var logs = new List<object>();

            if (!File.Exists(filePath))
                return logs;

            var lineas = File.ReadAllLines(filePath);

            foreach (var linea in lineas)
            {
                try 
                {
                    var obj = JsonSerializer.Deserialize<object>(linea);
                    if (obj != null)
                        logs.Add(obj);
                }

                catch
                {

                }
            }

            return logs;
        }
    }
}