using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
