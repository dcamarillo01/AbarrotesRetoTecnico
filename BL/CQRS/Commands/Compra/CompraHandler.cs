using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.Compra
{
    public class CompraHandler : IRequestHandler<CompraCommand, ModelLayer.Result>
    {

        private readonly DataLayer.AbarrotesBdContext _context;
        public CompraHandler(DataLayer.AbarrotesBdContext context) => _context = context;

        
        public async Task<ModelLayer.Result> Handle(CompraCommand request, CancellationToken cancellationToken) 
        {
            
            var result = new ModelLayer.Result();

            try {


                var compra = new DataLayer.Compra() { 
                    
                    FechaCompra = request.FechaCompra,
                    IdSucursal = request.IdSucursal,
                    Total = request.Total,
                    IdProveedor = request.IdProveedor

                };

                _context.Compras.Add(compra);
                var filasAfectadas = await _context.SaveChangesAsync(cancellationToken);

                if (filasAfectadas > 0)
                {

                    result.Correct = true;
                }
                else {
                    result.Correct = false;
                    result.ErrorMessage = "Ocurrio un problema al hacer compras";
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
