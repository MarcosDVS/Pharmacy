using FarmaciaDyM.Data.Context;
using FarmaciaDyM.Data.Entities;
using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using FarmaciaDyM.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaDyM.Data.Services
{
    public interface IVentaServices
    {
        Task<Result<List<VentaResponse>>> Consultar();
        Task<Result<VentaResponse>> Crear(VentasRequest request);
        Task<Result> Eliminar(VentasRequest request);
        Task<Result> Modificar(VentasRequest request);
    }

    public class VentaServices : IVentaServices
    {
        private readonly IMyDbContext dbContext;

        public VentaServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result<List<VentaResponse>>> Consultar()
        {
            try
            {
                var facturas = await dbContext.Ventas
                    .Include(f => f.Cliente)
                    .Include(f => f.Detalles)
                    .ThenInclude(d => d.Producto)
                    .Select(f => f.ToResponse())
                    .ToListAsync();
                return new Result<List<VentaResponse>>()
                {
                    Data = facturas,
                    Success = true,
                    Message = "Ok"
                };
            }
            catch (Exception E)
            {
                return new Result<List<VentaResponse>>()
                {
                    Data = null,
                    Success = false,
                    Message = E.Message
                };
            }
        }

        public async Task<Result<VentaResponse>> Crear(VentasRequest request)
        {
            try
            {
                var factura = Venta.crear(request);
                dbContext.Ventas.Add(factura);
                await dbContext.SaveChangesAsync();
                return new Result<VentaResponse>()
                {
                    Data = factura.ToResponse(),
                    Success = true,
                    Message = "Ok"
                };
            }
            catch (Exception E)
            {
                return new Result<VentaResponse>()
                {
                    Data = null,
                    Success = false,
                    Message = E.Message
                };
            }
        }

        public async Task<Result> Modificar(VentasRequest request)
        {
            try
            {
                var venta = await dbContext.Ventas.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (venta == null)
                    return new Result() { Message = "No se Encontro La Venta", Success = false };
                if (venta.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "OK", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Eliminar(VentasRequest request)
        {
            try
            {
                var venta = await dbContext.Ventas.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (venta == null)
                    return new Result() { Message = "No se Encontro El Producto", Success = false };
                dbContext.Ventas.Remove(venta);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "OK", Success = true };


            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }

        }
    }

}
