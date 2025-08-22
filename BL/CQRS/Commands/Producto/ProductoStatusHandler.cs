using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.Producto
{
    public class ProductoStatusHandler : IRequestHandler<ProductoStatusCommand, ModelLayer.Result>
    {

        private readonly DataLayer.AbarrotesBdContext _context;
        public ProductoStatusHandler(DataLayer.AbarrotesBdContext context) => _context = context;

        public async Task<ModelLayer.Result> Handle(ProductoStatusCommand request, CancellationToken cancellationToken)
        {

            var result = new ModelLayer.Result();

            try {

                // 1) Buscar el producto por Id
                var productoGetById = await _context.Productos
                    .FirstOrDefaultAsync(producto => producto.IdProducto == request.IdProducto, cancellationToken);

                if (productoGetById is null)
                {
                    result.Correct = false;
                    result.ErrorMessage = $"Producto {request.IdProducto} no encontrado.";
                    return result;
                }

                productoGetById.Activo = request.Activo.Value;

                var filasAfectadas = await _context.SaveChangesAsync(cancellationToken);

                if (filasAfectadas > 0)
                {

                    result.Correct = true;
                }
                else {
                    result.Correct = false;
                    result.ErrorMessage = "Ocurrio un problema al cambiar estado de producto";
                }


            }
            catch (Exception ex) 
            {

                result.Correct = true;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }

    }
}
