using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FarmaciaDyM.Data.Entities
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public virtual Cliente Cliente { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public virtual ICollection<VentaDetalle> Detalles { get; set; }

        public static Venta crear(VentasRequest ventas)
              => new Venta()
              {
                  ClienteId = ventas.ClienteId,
                  Cliente = ventas.Cliente,
                  Total = ventas.Total,
                  Fecha = ventas.Fecha,
              };

        public bool Modificar(VentasRequest ventas)
        {
            var cambio = false;
            if (ClienteId != ventas.ClienteId)
            {
                ClienteId = ventas.ClienteId;
                cambio = true;
            }
            if (Cliente != ventas.Cliente)
            {
                Cliente = ventas.Cliente;
                cambio = true;
            }
            if (Total != ventas.Total)
            {
                Total = ventas.Total;
                cambio = true;
            }
            if (Fecha != ventas.Fecha)
            {
                Fecha = ventas.Fecha;
                cambio = true;
            }

            return cambio;
        }


        public VentaResponse ToResponse()
          => new VentaResponse()
          {
             Id = Id,
             ClienteId = ClienteId,
             Total = Total,
             Fecha = Fecha, 
             Detalles = Detalles,
             
          };
    }
}     
