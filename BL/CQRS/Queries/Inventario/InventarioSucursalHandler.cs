using BusinessLayer.CQRS.Queries.Inventario;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DataLayer.DTOs.InventarioGeneralDTOs;

namespace BusinessLayer.CQRS.Queries.Inventario
{
    public class InventarioSucursalHandler: IRequestHandler<InventarioSucursalQuery, ModelLayer.Result>
    {

        private readonly DataLayer.AbarrotesBdContext _context;
        public InventarioSucursalHandler(DataLayer.AbarrotesBdContext context) => _context = context;

        public async Task<ModelLayer.Result> Handle(InventarioSucursalQuery request, CancellationToken cancelattionToken)
        {
            var result = new ModelLayer.Result { Objects = new List<object>() };

            try {

                var inventarios = _context.InventarioSucursals.AsNoTracking().AsQueryable();
                if (request.IdSucursal.HasValue)
                    inventarios = inventarios.Where(i => i.IdSucursal == request.IdSucursal.Value);

                var query =
                  from inventario in inventarios
                  join producto in _context.Productos.AsNoTracking() on inventario.IdProducto equals producto.IdProducto
                  join sucursal in _context.Sucursals.AsNoTracking() on inventario.IdSucursal equals sucursal.IdSucursal
                  group new { inventario, producto } by new { sucursal.IdSucursal, sucursal.Nombre } into gSucursal
                  select new
                  {
                      IdSucursal = gSucursal.Key.IdSucursal,
                      NombreSucursal = gSucursal.Key.Nombre,
                      Productos = gSucursal
                          .GroupBy(productoGb => new { productoGb.producto.IdProducto, productoGb.producto.Nombre })
                          .Select(gs => new
                          {
                              IdProducto = gs.Key.IdProducto,
                              NombreProducto = gs.Key.Nombre,
                              Cantidad = (int)(gs.Sum(z => (int?)z.inventario.Cantidad) ?? 0)
                          })
                          .OrderBy(p => p.NombreProducto)
                          .ToList()
                  };

                var lista = await query.ToListAsync(cancelattionToken);


                if (lista != null)
                {

                    foreach (var sucursalResponse in lista)
                    {
                        var Sucursal = new ModelLayer.Inventario
                        {
                            Sucursal = new ModelLayer.Sucursal
                            {
                                IdSucursal = sucursalResponse.IdSucursal,
                                Nombre = sucursalResponse.NombreSucursal
                            },
                            Producto = new ModelLayer.Producto
                            {
                                Productos = new List<object>() 
                            }
                        };

                        foreach (var productoResponse in sucursalResponse.Productos)
                        {
                            var itemProducto = new ModelLayer.Inventario
                            {
                                Producto = new ModelLayer.Producto
                                {
                                    IdProducto = productoResponse.IdProducto,
                                    Nombre = productoResponse.NombreProducto
                                },
                                Cantidad = productoResponse.Cantidad
                            };

                            Sucursal.Producto.Productos.Add(itemProducto);
                        }

                        result.Objects.Add(Sucursal);

                    }


                    result.Correct = true;
                }


            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                return result;
            }


            return result;

        }


    }
}
