using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataLayer.DTOs.InventarioGeneralDTOs;

namespace BusinessLayer.CQRS.Queries.Inventario
{
    public class InventarioGeneralHandler : IRequestHandler<InventarioGeneralQuery, ModelLayer.Result>
    {

        private readonly DataLayer.AbarrotesBdContext _context;
        public InventarioGeneralHandler(DataLayer.AbarrotesBdContext context) => _context = context;

        public async Task<ModelLayer.Result> Handle(InventarioGeneralQuery request, CancellationToken cancelattionToken)
        {
            var result = new ModelLayer.Result { Objects = new List<object>() };

            try
            {
                var inventarios = _context.InventarioSucursals
              .AsNoTracking()
              .AsQueryable();



                var query =
                         from producto in _context.Productos
                         join inventario in _context.InventarioSucursals on producto.IdProducto equals inventario.IdProducto
                         join sucursal in _context.Sucursals on inventario.IdSucursal equals sucursal.IdSucursal
                         group new { inventario, sucursal } by new { producto.IdProducto, producto.Nombre } into g
                         select new
                         {
                             g.Key.IdProducto,
                             NombreProducto = g.Key.Nombre,
                             Sucursales = g.Select(x => new
                             {
                                 x.sucursal.IdSucursal,
                                 NombreSucursal = x.sucursal.Nombre,
                                 x.inventario.Cantidad
                             }).ToList()
                         };


                var lista = await query.ToListAsync(cancelattionToken);

                if (lista != null)
                {

                    foreach (var inventarioResponse in lista)
                    {

                        var inventario = new ModelLayer.Inventario
                        {
                            Producto = new ModelLayer.Producto
                            {
                                IdProducto = inventarioResponse.IdProducto,
                                Nombre = inventarioResponse.NombreProducto
                            },
                            Sucursal = new ModelLayer.Sucursal
                            {
                                IdSucursal = inventarioResponse.Sucursales.FirstOrDefault()?.IdSucursal ?? 0,
                                Nombre = inventarioResponse.Sucursales.FirstOrDefault()?.NombreSucursal ?? string.Empty
                            },
                        };


                        result.Objects.Add(inventario);
                        result.Correct = true;

                    }
                }
                else
                {

                    result.Correct = false;
                    result.ErrorMessage = "Ocurrio un problema al obtener inventarios generales";
                }

            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }


            return result;
        }

    }
}
