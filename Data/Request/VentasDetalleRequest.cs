using FarmaciaDyM.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FarmaciaDyM.Data.Request
{
    public class VentasDetalleRequest
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }

        [ForeignKey(nameof(ProductoId))]
        public virtual Producto Producto { get; set; }

        public int Cantidad { get; set; }
        public decimal PrecioDeVenta { get; set; }
        public decimal Descuento { get; set; }

        [ForeignKey(nameof(VentaId))]
        public virtual Venta Venta { get; set; }



    }
}
