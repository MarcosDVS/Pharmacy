using FarmaciaDyM.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaDyM.Data.Context
{
    public class MyDbContext : Microsoft.EntityFrameworkCore.DbContext, IMyDbContext
    {
        private readonly IConfiguration configuration;

        public MyDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: configuration.GetConnectionString(name: "MSSQL"));

        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}