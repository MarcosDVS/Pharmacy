using FarmaciaDyM.Data.Request;

namespace FarmaciaDyM.Data.Response
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;

        public ClientesRequest ToRequest()
        {  
            return new ClientesRequest 
            { 
                Id = Id,
                Nombre = Nombre,
                Telefono = Telefono, 
                Direccion = Direccion
            }; 
        }
    }
}
