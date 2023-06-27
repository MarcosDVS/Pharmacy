using FarmaciaDyM.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaDyM.Data.Response
{
    public class VentaDetalleResponse
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

        [NotMapped]
        public decimal SubTotal => Cantidad * PrecioDeVenta;
    }
}
