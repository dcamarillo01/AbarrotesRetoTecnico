﻿using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class DetalleVentum
{
    public int IdDetalleVenta { get; set; }

    public int? IdVenta { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Ventum? IdVentaNavigation { get; set; }
}
