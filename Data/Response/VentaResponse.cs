using FarmaciaDyM.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaDyM.Data.Response;
    public class VentaResponse

    {
        public int Id { get; set; }
        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public virtual Cliente Cliente { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public virtual ICollection<VentaDetalle> Detalles { get; set; }

        [NotMapped]
        public decimal SubTotal =>
            Detalles != null ? //IF
            Detalles.Sum(d => d.SubTotal) //Verdadero
            :
            0;//Falso
        }
