using MediatR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.Venta
{
    public class RegistrarDetalleVentaHandler : IRequestHandler<RegistrarDetalleVentaCommand, ModelLayer.Result>
    {

        private readonly DataLayer.AbarrotesBdContext _context;
        public RegistrarDetalleVentaHandler(DataLayer.AbarrotesBdContext context) => _context = context;

        public async Task<ModelLayer.Result> Handle(RegistrarDetalleVentaCommand request, CancellationToken cancellationToken) 
        {
        
            var result = new ModelLayer.Result();

            try {

                var detalleVenta = new DataLayer.DetalleVentum() { 
                    
                    IdVenta = request.IdVenta,
                    IdProducto = request.IdProducto,
                    Cantidad = request.Cantidad,
                    PrecioUnitario = request.PrecioUnitario,

                };

                _context.DetalleVenta.Add(detalleVenta);
                var filasAfectadas = await _context.SaveChangesAsync(cancellationToken);

                if (filasAfectadas > 0)
                {
                    result.Correct = true;
                }
                else {
                    result.Correct = false;
                    result.ErrorMessage = "Ocurrio un problema al registrar detalle de venta";
                }


            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }

            return result;
        }

    }
}
