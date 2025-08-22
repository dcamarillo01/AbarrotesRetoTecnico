using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class HistorialVentasDTOs
    {
        public class VentaResumenDto
        {
            public int IdVenta { get; set; }
            public DateOnly? FechaHora { get; set; }
            public int IdSucursal { get; set; }
            public string Sucursal { get; set; } = "";
            public int? CantidadTotal { get; set; }
            public decimal? Total { get; set; }
        }
    }
}
