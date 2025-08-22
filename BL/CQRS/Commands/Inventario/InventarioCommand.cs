using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.Inventario
{
    public class InventarioCommand : IRequest<ModelLayer.Result>
    {
        public int? IdSucursal { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }


    }
}
