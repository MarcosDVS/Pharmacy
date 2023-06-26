using FarmaciaDyM.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaDyM.Data.Context
{
    public interface IMyDbContext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Producto> Productos { get; set; }
        DbSet<Proveedor> Proveedores { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<VentaDetalle> VentaDetalles { get; set; }
        DbSet<Venta> Ventas { get; set; }

       public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task SaveChangesAsync();
    }
}