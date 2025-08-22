using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class RompimientoProductoProveedor
{
    public int IdDetalle { get; set; }

    public int? IdProducto { get; set; }

    public int? IdCompra { get; set; }

    public int? IdProveedor { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Compra? IdCompraNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }
}
