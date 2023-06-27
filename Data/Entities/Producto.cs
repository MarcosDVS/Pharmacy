using System;
using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaDyM.Data.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public decimal Costo { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public DateTime FechaDeCaducidad { get; set; } = DateTime.Now.AddMonths(3);
        public int ProveedorId { get; set; }

        [ForeignKey(nameof(ProveedorId))]
        public virtual Proveedor Proveedor { get; set; }  = null!;

        public static Producto crear(ProductosRequest productos)
       => new Producto()
       {
           Codigo = productos.Codigo,
           Nombre = productos.Nombre,
           Costo = productos.Costo,
           Precio = productos.Precio,
           Existencia = productos.Existencia,
           FechaDeCaducidad = productos.FechaDeCaducidad,
           ProveedorId = productos.ProveedorId,
       };
        public bool Modificar(ProductosRequest productos)
        {
            var cambio = false;
            if (Codigo != productos.Codigo)
            {
                Codigo = productos.Codigo;
                cambio = true;
            }
            if (Nombre != productos.Nombre)
            {
                Nombre = productos.Nombre;
                cambio = true;
            }
            if (Costo != productos.Costo)
            {
                Costo = productos.Costo;
                cambio = true;
            }

            if (Precio != productos.Precio)
            {
                Precio = productos.Precio;
                cambio = true;
            }
            if (Existencia != productos.Existencia)
            {
                Existencia = productos.Existencia;
                cambio = true;
            }
            if (FechaDeCaducidad != productos.FechaDeCaducidad)
            {
                FechaDeCaducidad = productos.FechaDeCaducidad;
                cambio = true;
            }
            if (ProveedorId != productos.ProveedorId)
            {
                ProveedorId = productos.ProveedorId;
                cambio = true;
            }

            return cambio;


        }


        public ProductoResponse ToResponse()
          => new  ProductoResponse()
          {
              Id = Id,
              Codigo = Codigo,
              Nombre = Nombre,
              Costo = Costo,
              Precio = Precio,
              Existencia = Existencia, 
              FechaDeCaducidad = FechaDeCaducidad, 
              ProveedorId = ProveedorId,
           
            
             
          };

    }
}
