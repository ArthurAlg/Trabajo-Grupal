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

public DbSet<Producto> DataProductos { get; set; }
public DbSet<Contacto> DataContactos {get;set;}
public DbSet<Proforma> DataProformas {get;set;}
public DbSet<Pago> DataPago { get; set; }
public DbSet<Pedido> DataPedido {get;set;}
public DbSet<DetallePedido> DataDetallePedido {get;set;}
public DbSet<MiLista> DataMiLista {get;set;}
}
