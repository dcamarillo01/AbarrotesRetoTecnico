using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BusinessLayer.CQRS.Commands.Producto
{
    public class ProductoValidator : AbstractValidator<ProductoAddCommand>
    {

        public ProductoValidator()
        {

            RuleFor(producto => producto.Nombre)
                .NotNull().WithMessage("Nombre de producto es obligatorio");

            RuleFor(producto => producto.Descripcion)
                .NotNull().WithMessage("Descripcion de producto es obligatorio");

            RuleFor(producto => producto.PrecioUnitario)
                .NotNull().WithMessage("El precio unitario es obligatorio.")
                .GreaterThan(0).WithMessage("El precio unitario debe ser mayor a 0.")
                .PrecisionScale(18, 2, true) // 18 dígitos totales, 2 decimales
                .WithMessage("El precio unitario tiene un formato inválido (máx 2 decimales).");



        }

    }

    public class ProductoUpdateValidator : AbstractValidator<ProductoUpdateCommand>
    {

        public ProductoUpdateValidator()
        {

            RuleFor(producto => producto.IdProducto)
                .NotNull().WithMessage("El producto es obligatorio")
                .GreaterThan(0).WithMessage("El producto debe ser un id válido (> 0).");

            RuleFor(producto => producto.Nombre)
               .NotNull().WithMessage("Nombre de producto es obligatorio");

            RuleFor(producto => producto.Descripcion)
                .NotNull().WithMessage("Descripcion de producto es obligatorio");

            RuleFor(producto => producto.PrecioUnitario)
                .NotNull().WithMessage("El precio unitario es obligatorio.")
                .GreaterThan(0).WithMessage("El precio unitario debe ser mayor a 0.")
                .PrecisionScale(18, 2, true) // 18 dígitos totales, 2 decimales
                .WithMessage("El precio unitario tiene un formato inválido (máx 2 decimales).");

        }


    }

    public class ProductoStatusValidator : AbstractValidator<ProductoStatusCommand>
    {


        public ProductoStatusValidator()
        {

            RuleFor(producto => producto.IdProducto)
                .NotNull().WithMessage("El producto es obligatorio")
                .GreaterThan(0).WithMessage("El producto debe ser un id válido (> 0).");

            RuleFor(producto => producto.Activo)
                .NotNull().WithMessage("Es estado del producto es obligatorio");

        }
    }

}
