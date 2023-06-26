using System.Collections.Generic;
using FarmaciaDyM.Data.Context;
using FarmaciaDyM.Data.Entities;
using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaDyM.Data.Services
{
    public interface IUsuarioServices
    {
        Task<Result<List<UsuariosResponse>>> Consultar(string filtro);
        Task<Result> Crear(UsuariosRequest request);
        Task<Result> Eliminar(UsuariosRequest request);
        Task<Result> Modificar(UsuariosRequest request);
    }

    public class UsuarioServices : IUsuarioServices
    {
        private readonly IMyDbContext dbContext;

        public UsuarioServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(UsuariosRequest request)
        {
            try
            {
                var contacto = Usuario.crear(request);
                dbContext.Usuarios.Add(contacto);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(UsuariosRequest request)
        {
            try
            {
                var user = await dbContext.Usuarios
                    .FirstOrDefaultAsync(c => c.Id == request.Id);
                if (user == null)
                    return new Result() { Message = "No se encontro el usuario", Success = false };

                if (user.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(UsuariosRequest request)
        {
            try
            {
                var contacto = await dbContext.Usuarios
                    .FirstOrDefaultAsync(c => c.Id == request.Id);
                if (contacto == null)
                    return new Result() { Message = "No se encontro el usuario", Success = false };

                dbContext.Usuarios.Remove(contacto);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<UsuariosResponse>>> Consultar(string filtro)
        {
            try
            {
                var usuarios = await dbContext.Usuarios
                    .Where(u =>
                        (u.Nombre + " " + u.Rol + " " + u.CorreoElectronico + " " + u.Clave)
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(u => u.ToResponse())
                    .ToListAsync();
                return new Result<List<UsuariosResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = usuarios
                };
            }
            catch (Exception E)
            {
                return new Result<List<UsuariosResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }

    }
}

