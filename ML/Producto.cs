using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Producto
    {
        public  int? IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? PrecioUnitario { get; set; }

        public bool Activo { get; set; }

        public List<Object>? Productos { get; set; }

    }
}
