using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuieroPizza.BL
{
    public class ReporteVentasPorProducto
    {
        //Para consultas 
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
    }
}
