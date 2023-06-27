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
        public string? Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioDeVenta { get; set; }
        public decimal Descuento { get; set; }
        public decimal SubTotal => Cantidad * PrecioDeVenta;



    }
}
