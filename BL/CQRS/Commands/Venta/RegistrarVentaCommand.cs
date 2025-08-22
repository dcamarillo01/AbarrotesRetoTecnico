using MediatR;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.Venta
{   
    public class RegistrarVentaCommand : IRequest<Result>
    {
        public int? IdSucursal { get; set; }
        public DateTime? FechaVenta { get; set; }
        public decimal? Total { get; set; }
    }

    public class RegistrarDetalleVentaCommand : IRequest<Result> { 
        
        public int? IdVenta { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad  { get; set; }
        public decimal? PrecioUnitario { get; set; }
    }

}
