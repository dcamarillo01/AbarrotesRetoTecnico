using BusinessLayer.CQRS.Commands.Producto;
using MediatR;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.Inventario
{
    public class InventarioHandler : IRequestHandler<InventarioCommand, ModelLayer.Result>
    {

        private readonly DataLayer.AbarrotesBdContext _context;
        public InventarioHandler(DataLayer.AbarrotesBdContext context) => _context = context;

        public async Task<Result> Handle(InventarioCommand request, CancellationToken cancellationToken)
        {

            var result = new Result();

            try
            {

                var inventario = new DataLayer.InventarioSucursal
                {
                    IdSucursal = request.IdSucursal,
                    IdProducto = request.IdProducto,
                    Cantidad = request.Cantidad,
                };

                _context.InventarioSucursals.Add(inventario);
                var filasAfectadas = await _context.SaveChangesAsync(cancellationToken);

                if (filasAfectadas > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Ocurrio un problema al registrar inventario";
                }


            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }


            return result;
        }
    }
}
