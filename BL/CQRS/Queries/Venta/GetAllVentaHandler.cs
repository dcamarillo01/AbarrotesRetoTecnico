using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Queries.Venta
{
    public class GetAllVentaHandler : IRequestHandler<GetAllVentaQuery, ModelLayer.Result>
    {

        private readonly DataLayer.AbarrotesBdContext _context;

        public GetAllVentaHandler(DataLayer.AbarrotesBdContext context) => _context = context;

        public async Task<ModelLayer.Result> Handle(GetAllVentaQuery request, CancellationToken cancellationToken)
        {

            var result = new ModelLayer.Result();
            result.Objects = new List<object>();

            try
            {

                var response = await _context.Venta.ToListAsync(cancellationToken);
                if (response != null)
                {

                    foreach (var ventaResponse in response)
                    {


                        ModelLayer.Venta venta = new ModelLayer.Venta
                        {
                            Sucursal = new ModelLayer.Sucursal(),
                            DetalleVenta = new ModelLayer.DetalleVenta()
                            {
                                Producto = new ModelLayer.Producto()
                            }
                        };

                        venta.IdVenta = ventaResponse.IdVenta;
                        venta.Sucursal.IdSucursal = ventaResponse.IdSucursal;
                        venta.FechaVenta = ventaResponse.FechaVenta;
                        venta.Total = ventaResponse.Total;


                        result.Objects.Add(venta);

                    }

                    result.Correct = true;

                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Ocurrio un problema al obtener ventas";
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
