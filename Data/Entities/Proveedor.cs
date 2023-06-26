using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaDyM.Data.Entities
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Telefono { get; set; }

        public static Proveedor crear(ProveedorRequest proveedor)
        => new Proveedor()
        {
            Nombre = proveedor.Nombre,
            Telefono = proveedor.Telefono,

        };
        public bool Modificar(ProveedorRequest proveedor)
        {
            var cambio = false;
            if (Nombre != proveedor.Nombre)
            {
                Nombre = proveedor.Nombre;
                cambio = true;
            }
            if (Telefono != proveedor.Telefono)
            {
                Telefono = proveedor.Telefono;
                cambio = true;
            }


            return cambio;
        }


        public ProveedorResponse ToResponse()
         => new ProveedorResponse()
         {
             Id = Id,
             Nombre = Nombre,
             Telefono = Telefono,
             
         };

    }

}

