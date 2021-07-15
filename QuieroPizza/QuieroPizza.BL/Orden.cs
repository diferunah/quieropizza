using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuieroPizza.BL
{
    public class Orden
    {
        public int Id { get; set; }
        public int ClienteId { get; set; } //insertar una relacion entre tablas, llave foranea
        public Cliente Cliente { get; set; } //manejo interno entityframework
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }

        public List<OrdenDetalle> ListadeOrdenDetalle { get; set; } //lista de los productos

        //captura el tiempo en que se crea la orden
        public Orden()
        {
            Activo = true;
            Fecha = DateTime.Now;

            ListadeOrdenDetalle = new List<OrdenDetalle>();
        }
    }

    public class OrdenDetalle
    {
        public int Id { get; set; } //tener correlativo
        public int OrdenId { get; set; }
        public Orden Orden { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }//Llamamos los productos

        //para guardar historico de los productos llamados
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }
    }
}
