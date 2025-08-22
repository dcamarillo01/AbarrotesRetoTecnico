using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Inventario
    {

        public int? IdInventarioSucursal { get; set; }

        public ModelLayer.Sucursal? Sucursal { get; set; }

        public ModelLayer.Producto? Producto { get; set; }

        public int? Cantidad { get; set; }

    }
}
