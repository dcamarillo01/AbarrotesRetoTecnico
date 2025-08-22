using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public ModelLayer.Sucursal? Sucursal { get; set; }
        public ModelLayer.DetalleVenta? DetalleVenta { get; set; }
        public DateTime? FechaVenta { get; set; }
        public decimal? Total { get; set; }
    }

    public class Sucursal
    {
        public int? IdSucursal { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
    }

    public class DetalleVenta
    {

        public int? IdDetalleVenta { get; set; }

        public ModelLayer.Producto? Producto { set; get; }

        public int? cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }

    }



    
}
