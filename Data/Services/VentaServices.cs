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
        Task<Result<List<VentaResponse>>> Consultar(string Filtro);
        Task<Result> Crear(VentasRequest request);
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

        public async Task<Result> Crear(VentasRequest request)
        {
            try
            {
                var venta = Venta.crear(request);

                dbContext.Ventas.Add(venta);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "OK", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
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
        public async Task<Result<List<VentaResponse>>> Consultar(string Filtro)
        {
            try
            {
                var venta = await dbContext.Ventas.Where(c =>

                (c.Id + "" + c.ClienteId + " " + c.Detalles)
                .ToLower()
                .Contains(Filtro.ToLower()
                )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
                return new Result<List<VentaResponse>>()
                {
                    Message = "OK",
                    Success = true,
                    Data = venta
                };
            }
            catch (Exception E)
            {
                return new Result<List<VentaResponse>>()
                {
                    Message = E.Message,
                    Success = false,
                };
            }
        }
    }

}
