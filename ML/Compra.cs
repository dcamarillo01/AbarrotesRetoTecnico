using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Compra
    {

        public int IdCompra { get; set; }

        public DateTime? FechaCompra { get; set; }

        public ModelLayer.Sucursal Sucursal { get; set; }

        public decimal? Total { get; set; }



    }
}
