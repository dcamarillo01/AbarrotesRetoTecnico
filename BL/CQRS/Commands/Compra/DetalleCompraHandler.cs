using MediatR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.Compra
{
    public class DetalleCompraHandler : IRequestHandler<DetalleCompraCommand, ModelLayer.Result>
    {

        private readonly DataLayer.AbarrotesBdContext _context;
        public DetalleCompraHandler(DataLayer.AbarrotesBdContext context) => _context = context;

        public async Task<ModelLayer.Result> Handle(DetalleCompraCommand request , CancellationToken cancellationToken) 
        {

            var result = new ModelLayer.Result();

            try {

                var detallleCompra = new DataLayer.DetalleCompra() { 
                    
                    IdCompra = request.IdCompra,
                    IdProducto = request.IdProducto,
                    Cantidad = request.Cantidad,
                    PrecioUnitario = request.PrecioUnitario
                };


                _context.DetalleCompras.Add(detallleCompra);
                var filasAfectadas = await _context.SaveChangesAsync(cancellationToken);

                if (filasAfectadas > 0)
                {

                    result.Correct = true;
                }
                else {
                    result.Correct = false;
                    result.ErrorMessage = "Ocurrio un problema al registrar detalle de compra";
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
