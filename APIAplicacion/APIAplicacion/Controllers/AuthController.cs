using APIAplicacion.Helpers;
using APIAplicacion.Models;
using APIAplicacion.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAplicacion.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario
            {
                Id = 1,
                Username = "admin",
                Password = HashHelper.HashPassword("admin123"),
                Nombre = "Administrador",
                Correo = "admin@test.com"
            }
        };

        private readonly JwtService jwtService = new JwtService();

        [HttpPost("login")]
        public IActionResult Login(LoginRequest login)
        {
            var hashed = HashHelper.HashPassword(login.Password);

            var user = usuarios.FirstOrDefault(u => u.Username == login.Username && u.Password == hashed);

            if (user == null)

                return Unauthorized("Credenciales inválidas.");

            var token = jwtService.GenerateToken(user);

            return Ok(new { token });
        }

        [Authorize]
        [HttpPost("refresh")]
        public IActionResult Refresh()
        {
            var username = User.Identity?.Name;

            if (username == null)
                return Unauthorized("Usuario no autenticado.");

            var user = usuarios.FirstOrDefault(u => u.Username == username);

            var newToken = jwtService.GenerateToken(user);

            return Ok(new { token = newToken });
        }
    }
}
