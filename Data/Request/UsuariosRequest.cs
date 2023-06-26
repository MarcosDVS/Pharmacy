using FarmaciaDyM.Data.Entities;

namespace FarmaciaDyM.Data.Request
{
    public class UsuariosRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Rol { get; set; }
        public string CorreoElectronico { get; set; } = null!;
        public string Clave { get; set; } = null!;


    }
}
