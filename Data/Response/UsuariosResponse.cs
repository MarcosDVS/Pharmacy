using FarmaciaDyM.Data.Request;

namespace FarmaciaDyM.Data.Response
{
    public class UsuariosResponse
    {
        public int Id { get; set; }
        public string  Nombre { get; set; } = null!;
        public string? Rol { get; set; }
        public string CorreoElectronico { get; set; }  = null!;
        public string Clave { get; set; } = null!;

        public UsuariosRequest ToRequest()
        {  
            return new UsuariosRequest 
            { 
                Id = Id,
                Nombre = Nombre, 
                Rol = Rol, 
                CorreoElectronico = CorreoElectronico, 
                Clave = Clave
            }; 
        }
    }
}
