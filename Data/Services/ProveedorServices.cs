using FarmaciaDyM.Data.Context;
using FarmaciaDyM.Data.Entities;
using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaDyM.Data.Services
{
    public interface IProveedorServices
    {
        Task<Result<List<ProveedorResponse>>> Consultar(string Filtro);
        Task<Result> Crear(ProveedorRequest request);
        Task<Result> Eliminar(ProveedorRequest request);
        Task<Result> Modificar(ProveedorRequest request);
    }

    public class ProveedorServices : IProveedorServices
    {
        private readonly IMyDbContext dbContext;

        public ProveedorServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(ProveedorRequest request)
        {
            try
            {
                var proveedor = Proveedor.Crear(request);

                dbContext.Proveedores.Add(proveedor);
                await dbContext.SaveChangesAsync();

                return new Result() { Message = "OK", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Modificar(ProveedorRequest request)
        {
            try
            {
                var proveedor = await dbContext.Proveedores.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (proveedor == null)
                    return new Result() { Message = "No se encontró el proveedor", Success = false };

                if (proveedor.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "OK", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Eliminar(ProveedorRequest request)
        {
            try
            {
                var proveedor = await dbContext.Proveedores.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (proveedor == null)
                    return new Result() { Message = "No se encontró el proveedor", Success = false };

                dbContext.Proveedores.Remove(proveedor);
                await dbContext.SaveChangesAsync();

                return new Result() { Message = "OK", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result<List<ProveedorResponse>>> Consultar(string Filtro)
        {
            try
            {
                var proveedores = await dbContext.Proveedores
                    .Where(c => (c.Nombre + " " + c.Id + " " + c.Nombre).ToLower().Contains(Filtro.ToLower()))
                    .Select(c => c.ToResponse())
                    .ToListAsync();

                return new Result<List<ProveedorResponse>>()
                {
                    Message = "OK",
                    Success = true,
                    Data = proveedores
                };
            }
            catch (Exception E)
            {
                return new Result<List<ProveedorResponse>>()
                {
                    Message = E.Message,
                    Success = false,
                };
            }
        }
    }
}
