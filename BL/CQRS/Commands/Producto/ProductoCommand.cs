using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.Producto
{

    public class ProductoAddCommand : IRequest<ModelLayer.Result>
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? PrecioUnitario { get; set; }
    }
    public record ProductoUpdateCommand(
        int? IdProducto,
        string? Nombre,
        string? Descripcion,
        decimal? PrecioUnitario
    ) : IRequest<ModelLayer.Result>;


    public record ProductoStatusCommand(
    int? IdProducto,
    bool? Activo
    ) : IRequest<ModelLayer.Result>;

}
