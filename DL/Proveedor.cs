using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<RompimientoProductoProveedor> RompimientoProductoProveedors { get; set; } = new List<RompimientoProductoProveedor>();
}
