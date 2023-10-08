using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trabajo_Grupal.Models;

namespace Trabajo_Grupal.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
public DbSet<Trabajo_Grupal.Models.Producto> DataProducto{get;set;}
public DbSet<Contacto> DataContactos {get;set;}
public DbSet<Carrito> DataCarrito {get;set;}
}
