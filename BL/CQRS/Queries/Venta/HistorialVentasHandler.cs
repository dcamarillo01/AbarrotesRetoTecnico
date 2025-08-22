using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DataLayer.DTOs.HistorialVentasDTOs;

namespace BusinessLayer.CQRS.Queries.Venta
{
    public class HistorialVentasHandler : IRequestHandler<HistorialVentasQuery, ModelLayer.Result>
    {

        private readonly DataLayer.AbarrotesBdContext _context;
        public HistorialVentasHandler(DataLayer.AbarrotesBdContext context) => _context = context;

        public async Task<ModelLayer.Result> Handle(HistorialVentasQuery request, CancellationToken cancellationToken)
        {

            var result = new ModelLayer.Result { Objects = new List<object>() };

            try
            {
                var query =
                 from v in _context.Venta
                 join dv in _context.DetalleVenta on v.IdVenta equals dv.IdVenta
                 join s in _context.Sucursals on v.IdSucursal equals s.IdSucursal
                 select new
                 {
                     IdVenta = v.IdVenta,
                     Fecha = v.FechaVenta, 
                     IdSucursal = s.IdSucursal,
                     Sucursal = s.Nombre,
                     Cantidad = dv.Cantidad,
                     IdDetalleVenta = dv.IdDetalleVenta,
                     IdProducto = dv.IdProducto,
                     PrecioUnitario = dv.PrecioUnitario,
                     Total = dv.Cantidad * dv.PrecioUnitario
                 };

                var lista = await query.ToListAsync(cancellationToken);

                if (lista != null)
                {
                    result.Correct = true;


                    foreach (var ventaResponse in query)
                    {

                        ModelLayer.Venta venta = new()
                        {
                            Sucursal = new ModelLayer.Sucursal(),
                            DetalleVenta = new ModelLayer.DetalleVenta() { 
                                Producto = new ModelLayer.Producto()
                            }
                        };

                        venta.IdVenta = ventaResponse.IdVenta;
                        venta.FechaVenta = ventaResponse.Fecha;
                        venta.Sucursal.Nombre = ventaResponse.Sucursal;
                        venta.DetalleVenta.cantidad = ventaResponse.Cantidad;
                        venta.DetalleVenta.Producto.IdProducto = ventaResponse.IdProducto;
                        venta.DetalleVenta.PrecioUnitario = ventaResponse.PrecioUnitario;
                        venta.Total = ventaResponse.Total;


                        result.Objects.Add(venta);

                    }

                }
                else
                {
                    result.Correct = false;
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
