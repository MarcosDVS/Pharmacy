using FarmaciaDyM.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FarmaciaDyM.Data.Request
{
    public class VentasRequest
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public virtual Cliente Cliente { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public virtual ICollection<VentaDetalle> Detalles { get; set; }
    }
}
