using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.Venta
{
    public class RegistrarVentaCommandValidator : AbstractValidator<RegistrarVentaCommand>
    {

        public RegistrarVentaCommandValidator() {

            // IdSucursal es obligatorio y debe ser > 0
            RuleFor(venta => venta.IdSucursal)
                .NotNull().WithMessage("La sucursal es obligatoria.")
                .GreaterThan(0).WithMessage("La sucursal debe ser un id válido (> 0).");

            // FechaVenta es obligatoria y no puede ser futura
            RuleFor(venta => venta.FechaVenta)
                .NotNull().WithMessage("La fecha de la venta es obligatoria.")
                .LessThanOrEqualTo(_ => DateTime.UtcNow.AddMinutes(1))
                .WithMessage("La fecha de la venta no puede ser futura.");

            // Total es obligatorio, > 0 y con escala (2 decimales típicos de moneda)
            RuleFor(venta => venta.Total)
                .NotNull().WithMessage("El total es obligatorio.")
                .GreaterThan(0).WithMessage("El total debe ser mayor a 0.")
                .PrecisionScale(18,2,true) // 18 dígitos totales, 2 decimales
                .WithMessage("El total tiene un formato inválido (máx 2 decimales).");


        }

    }
    public class RegistrarDetalleVentaCommandValidator : AbstractValidator<RegistrarDetalleVentaCommand>
    {

        public RegistrarDetalleVentaCommandValidator() {

            // IdVenta es obligatorio y debe ser > 0
            RuleFor(detalleVenta => detalleVenta.IdVenta)
                .NotNull().WithMessage("El IdVenta es obligatoria.")
                .GreaterThan(0).WithMessage("La venta debe ser un id válido (> 0).");

            // IdProducto es obligatorio y debe ser > 0
            RuleFor(detalleVenta => detalleVenta.IdProducto)
                .NotNull().WithMessage("El IdProducto es obligatoria.")
                .GreaterThan(0).WithMessage("El producto debe ser un id válido (> 0).");

            //Cantidad debe de ser mayor a 0 

            RuleFor(detalleVenta => detalleVenta.Cantidad)
                .NotNull().WithMessage("La cantidad es obligatoria")
                .GreaterThan(0).WithMessage("Cantidad debe ser mayor a 0");

      

            // Precio Unitario mayor a 0 y no puede ser nulo
            RuleFor(detalleVenta => detalleVenta.PrecioUnitario)
                .NotNull().WithMessage("El PrecioUnitario es obligatorio.")
                .GreaterThan(0).WithMessage("El precioUnitario debe ser mayor a 0.")
                .PrecisionScale(18,2,true) // 18 dígitos totales, 2 decimales
                .WithMessage("El precio unitario tiene un formato inválido (máx 2 decimales).");


        }

    }
}
