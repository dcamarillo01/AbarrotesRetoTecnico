using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.Compra
{
    public class CompraCommand : IRequest<ModelLayer.Result>
    {

        public DateTime? FechaCompra { get; set; }
        public int? IdSucursal { get; set; }
        public decimal? Total { get; set; }
        public int? IdProveedor { get; set; }

    }
}
