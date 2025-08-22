using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Queries.Producto
{
    public class ProductoHandler : IRequestHandler<ProductoQuery, ModelLayer.Result>
    {

        private readonly DataLayer.AbarrotesBdContext _context;

        public ProductoHandler(DataLayer.AbarrotesBdContext context) => _context = context;


        public async Task<ModelLayer.Result> Handle(ProductoQuery request, CancellationToken cancellationToken) 
        {

            var result = new ModelLayer.Result() { 
                Objects = new List<object>()
            };

            try
            {

                var response = await _context.Productos.ToListAsync(cancellationToken);

                if (response.Count > 0)
                {

                    foreach (var productoResponse in response) {

                        var producto = new ModelLayer.Producto()
                        {
                            IdProducto = productoResponse.IdProducto,
                            Nombre = productoResponse.Nombre,
                            Descripcion = productoResponse.Descripcion,
                            PrecioUnitario = productoResponse.PrecioUnitario,
                            Activo = productoResponse.Activo
                        };

                        result.Objects.Add(producto);
                    }


                    result.Correct = true;
                }
                else {
                    result.Correct = false;
                    result.ErrorMessage = "Ocurrio un error al obtener productos";
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
