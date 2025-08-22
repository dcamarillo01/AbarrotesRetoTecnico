using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class InventarioSucursal
{
    public int IdInventarioSucursal { get; set; }

    public int? IdSucursal { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Sucursal? IdSucursalNavigation { get; set; }
}
