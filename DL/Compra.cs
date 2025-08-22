using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class Compra
{
    public int IdCompra { get; set; }

    public DateTime? FechaCompra { get; set; }

    public int? IdSucursal { get; set; }

    public decimal? Total { get; set; }

    public int? IdProveedor { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Proveedor? IdProveedorNavigation { get; set; }

    public virtual Sucursal? IdSucursalNavigation { get; set; }

    public virtual ICollection<RompimientoProductoProveedor> RompimientoProductoProveedors { get; set; } = new List<RompimientoProductoProveedor>();
}
