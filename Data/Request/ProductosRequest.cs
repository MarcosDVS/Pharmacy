using FarmaciaDyM.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaDyM.Data.Request
{
    public class ProductosRequest
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public DateTime FechaDeCaducidad { get; set; }
        public int ProveedorId { get; set; }

        [ForeignKey(nameof(ProveedorId))]
        public virtual Proveedor Proveedor { get; set; } = null!;

    }
}
