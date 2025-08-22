using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Queries.Venta
{
    public class GetAllVentaQuery : IRequest<ModelLayer.Result>
    {
    }
}
