using FarmaciaDyM.Data.Context;
using FarmaciaDyM.Data.Entities;
using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaDyM.Data.Services
{
    public interface IProductoServices
    {
        Task<Result<List<ProductoResponse>>> Consultar(string Filtro);
        Task<Result> Crear(ProductosRequest request);
        Task<Result> Eliminar(ProductosRequest request);
        Task<Result> Modificar(ProductosRequest request);
    }

    public class ProductoServices : IProductoServices

    {
        private readonly IMyDbContext dbContext;

        public ProductoServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(ProductosRequest request)
        {
            try
            {
                var producto = Producto.crear(request);

                dbContext.Productos.Add(producto);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "OK", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }

        }
        public async Task<Result> Modificar(ProductosRequest request)
        {
            try
            {
                var Producto = await dbContext.Productos.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (Producto == null)
                    return new Result() { Message = "No se Encontro El Producto", Success = false };
                if (Producto.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "OK", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(ProductosRequest request)
        {
            try
            {
                var Producto = await dbContext.Productos.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (Producto == null)
                    return new Result() { Message = "No se Encontro El Producto", Success = false };
                dbContext.Productos.Remove(Producto);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "OK", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }

        }
        public async Task<Result<List<ProductoResponse>>> Consultar(string Filtro)
        {
            try
            {
                var producto = await dbContext.Productos.Where(c =>

                (c.Nombre + "" + c.Codigo + " " + c.Nombre)
                .ToLower()
                .Contains(Filtro.ToLower()
                )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
                return new Result<List<ProductoResponse>>()
                {
                    Message = "OK",
                    Success = true,
                    Data = producto
                };
            }
            catch (Exception E)
            {
                return new Result<List<ProductoResponse>>()
                {
                    Message = E.Message,
                    Success = false,
                };
            }

        }

    }
}


