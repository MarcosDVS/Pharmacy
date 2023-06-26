using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;

namespace FarmaciaDyM.Data.Entities
{
    public class Cliente
    {
        public DateTime Fecha { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;

        public static Cliente crear(ClientesRequest clientes)
      => new Cliente()
      {
          Nombre = clientes.Nombre,
          Telefono = clientes.Telefono,
          Direccion = clientes.Direccion,
      };
        public bool Modificar(ClientesRequest clientes)
        {
            var cambio = false;
            if (Nombre != clientes.Nombre)
            {
                Nombre = clientes.Nombre;
                cambio = true;
            }
            if (Telefono != clientes.Telefono)
            {
                Telefono = clientes.Telefono;
                cambio = true;
            }
            if (Direccion != clientes.Direccion)
            {
                Direccion = clientes.Direccion;
                cambio = true;
            }

            return cambio;

        }

        public ClienteResponse ToResponse()
          => new ClienteResponse()
          {
              Id = Id,
              Nombre = Nombre,
              Telefono = Telefono,
              Direccion = Direccion,
          };

    }
}
 