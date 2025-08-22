using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BusinessLayer.CQRS.Commands.Inventario
{
    public class InventarioValidator : AbstractValidator<InventarioCommand>
    {

        public InventarioValidator() { 
            
            RuleFor(inventario => inventario.IdSucursal)
                .NotNull().WithMessage("La sucursal es obligatoria")
                .GreaterThan(0).WithMessage("La sucursal debe ser un id válido (> 0).");

            
            RuleFor(inventario => inventario.IdProducto)
                .NotNull().WithMessage("El producto es obligatoria")
                .GreaterThan(0).WithMessage("El producto debe ser un id válido (> 0).");

            RuleFor(inventario => inventario.Cantidad)
                .NotNull().WithMessage("La cantidad es obligatoria")
                .GreaterThan(0).WithMessage("La cantidad debe ser mayor a 0");
            


        }

    }
}
