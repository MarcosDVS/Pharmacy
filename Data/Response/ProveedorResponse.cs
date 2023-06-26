using FarmaciaDyM.Data.Request;

namespace FarmaciaDyM.Data.Response
{
    public class ProveedorResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Telefono { get; set; }

        public ProveedorRequest ToRequest()
        {  
            return new ProveedorRequest 
            { 
                Id = Id,
                Nombre = Nombre, 
                Telefono = Telefono 
            }; 
        }
    }
}
