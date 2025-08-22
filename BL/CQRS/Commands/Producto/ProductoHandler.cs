using MediatR;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.Producto
{
    public class ProductoHandler : IRequestHandler<ProductoAddCommand, Result>
    {

        private readonly DataLayer.AbarrotesBdContext _context;
        public ProductoHandler(DataLayer.AbarrotesBdContext context) => _context = context;

        public async Task<Result> Handle(ProductoAddCommand request , CancellationToken cancellationToken) 
        {

            var result = new Result();


            try {

                var producto = new DataLayer.Producto
                {
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion,
                    PrecioUnitario = request.PrecioUnitario,
                    Activo = true
                };

                _context.Productos.Add(producto);
                var filasAfectadas = await _context.SaveChangesAsync(cancellationToken);

                if (filasAfectadas > 0)
                {
                    result.Correct = true;
                }
                else { 
                    result.Correct = false;
                    result.ErrorMessage = "Ocurrio un problema al agregar producto";
                }


            }
            catch (Exception ex) {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }


            return result;
            
        }

    }
}
