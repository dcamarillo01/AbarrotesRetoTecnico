using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.Compra
{
    public class DetalleCompraCommand : IRequest<ModelLayer.Result>
    {
        public int? IdCompra { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

    }
}
