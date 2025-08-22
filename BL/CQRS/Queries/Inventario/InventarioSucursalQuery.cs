using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Queries.Inventario
{
    public record InventarioSucursalQuery(int? IdSucursal = null)
    : IRequest<ModelLayer.Result>;

}
