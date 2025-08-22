using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.Compra
{
    public class CompraValidator : AbstractValidator<CompraCommand>
    {

        public CompraValidator()
        {

            RuleFor(compra => compra.IdSucursal)
                .NotNull().WithMessage("La sucursal es obligatoria.")
                .GreaterThan(0).WithMessage("La sucursal debe ser un id válido (> 0).");

            RuleFor(compra => compra.IdProveedor)
                .NotNull().WithMessage("El proveedor es obligatoria.")
                .GreaterThan(0).WithMessage("El proveedor debe ser un id válido (> 0).");

            RuleFor(compra => compra.FechaCompra)
                .NotNull().WithMessage("La fecha de la compra es obligatoria.")
                .LessThanOrEqualTo(_ => DateTime.UtcNow.AddMinutes(1))
                .WithMessage("La fecha de la compra no puede ser futura.");

            RuleFor(compra => compra.Total)
                .NotNull().WithMessage("El total es obligatorio.")
                .GreaterThan(0).WithMessage("El total debe ser mayor a 0.")
                .PrecisionScale(18, 2, true) // 18 dígitos totales, 2 decimales
                .WithMessage("El total tiene un formato inválido (máx 2 decimales).");


        }

    }

    public class DetalleCompraValidator : AbstractValidator<DetalleCompraCommand>
    {

        public DetalleCompraValidator()
        {

            RuleFor(detalle => detalle.IdCompra)
                .NotNull().WithMessage("La compra es obligatoria.")
                .GreaterThan(0).WithMessage("La compra debe ser un id válido (> 0).");

            RuleFor(detalle => detalle.IdProducto)
                .NotNull().WithMessage("El producto es obligatoria.")
                .GreaterThan(0).WithMessage("El producto debe ser un id válido (> 0).");

            RuleFor(detalle => detalle.Cantidad)
                .NotNull().WithMessage("La cantidad es obligatoria")
                .GreaterThan(0).WithMessage("La cantidad tiene que ser mayor a 0");

            RuleFor(detalle => detalle.PrecioUnitario)
                .NotNull().WithMessage("El precio unitario es obligatorio.")
                .GreaterThan(0).WithMessage("El precio unitario debe ser mayor a 0.")
                .PrecisionScale(18, 2, true) // 18 dígitos totales, 2 decimales
                .WithMessage("El precio unitario tiene un formato inválido (máx 2 decimales).");


        }



    }

}
