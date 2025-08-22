using MediatR;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer.CQRS.Commands.Venta
{
    public class RegistrarVentaHandler : IRequestHandler<RegistrarVentaCommand, Result>
    {

        private readonly AbarrotesBdContext _context;
        public RegistrarVentaHandler(AbarrotesBdContext context) => _context = context;

        public async Task<Result> Handle(RegistrarVentaCommand request, CancellationToken cancellationToken)
        {

            var result = new Result();

            try
            {

                var venta = new Ventum() { 
                    
                    IdSucursal = request.IdSucursal,
                    FechaVenta = request.FechaVenta,
                    Total = request.Total,

                };

                _context.Venta.Add(venta);
                var filasAfectadas = await _context.SaveChangesAsync(cancellationToken);

                if (filasAfectadas > 0)
                {

                    result.Correct = true;

                }
                else { 
                    
                    result.Correct = false;
                    result.ErrorMessage = "Ocurrio un problema al registar venta";
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
