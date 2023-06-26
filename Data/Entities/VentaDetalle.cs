using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FarmaciaDyM.Data.Entities
{
    public class VentaDetalle
    {
        [Key]
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

        public static VentaDetalle crear(VentasDetalleRequest ventasDetalle)
         => new VentaDetalle()
         {
             VentaId = ventasDetalle.VentaId,
             ProductoId = ventasDetalle.ProductoId,
             Cantidad = ventasDetalle.Cantidad,
             PrecioDeVenta = ventasDetalle.PrecioDeVenta,
             Descuento = ventasDetalle.Descuento,
             Venta = ventasDetalle.Venta,

         };

        public bool Modificar(VentasDetalleRequest ventasDetalle)
        {
            var cambio = false;
            if (VentaId != ventasDetalle.VentaId)
            {
                VentaId = ventasDetalle.VentaId;
                cambio = true;
            }
            if (ProductoId != ventasDetalle.VentaId)
            {
                ProductoId = ventasDetalle.VentaId;
                cambio = true;
            }
            if (Cantidad != ventasDetalle.Cantidad)
            {
                Cantidad = ventasDetalle.Cantidad;
                cambio = true;
            }
            if (PrecioDeVenta != ventasDetalle.PrecioDeVenta)
            {
                PrecioDeVenta = ventasDetalle.PrecioDeVenta;
                cambio = true;
            }
            if (Descuento != ventasDetalle.Descuento)
            {
                Descuento = ventasDetalle.Descuento;
                cambio = true;
            }
            if (Venta != ventasDetalle.Venta)
            {
                Venta = ventasDetalle.Venta;
                cambio = true;
            }
            return cambio;

        }


        public VentaDetalleResponse ToResponse()
         => new VentaDetalleResponse()
         {
           Id = Id,
          Venta=Venta,
          ProductoId=ProductoId,
          Producto=Producto,
          PrecioDeVenta=PrecioDeVenta,
          Cantidad=Cantidad,
          Descuento=Descuento,
          VentaId=VentaId,
             

         };



    }
}
