using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Queries.Compra
{
    public class CompraHandler : IRequestHandler<CompraQuery, ModelLayer.Result>
    {

        private readonly DataLayer.AbarrotesBdContext _context;

        public CompraHandler(DataLayer.AbarrotesBdContext context) => _context = context;


        public async Task<ModelLayer.Result> Handle(CompraQuery request, CancellationToken cancellationToken)
        {

            var result = new ModelLayer.Result()
            {
                Objects = new List<object>()
            };

            try {


                var compras = await _context.Compras.AsNoTracking().ToListAsync(cancellationToken);

                if (compras != null) {

                    foreach (var compraResponse in compras) {

                        ModelLayer.Compra compra = new()
                        {

                            Sucursal = new ModelLayer.Sucursal()
                        };

                        compra.IdCompra = compraResponse.IdCompra;
                        compra.FechaCompra = compraResponse.FechaCompra;
                        compra.Sucursal.IdSucursal = compraResponse.IdSucursal;
                        compra.Total = compraResponse.Total;

                        result.Objects.Add(compra);

                    }

                    result.Correct = true;  

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
