using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public int? IdSucursal { get; set; }

    public DateTime? FechaVenta { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Sucursal? IdSucursalNavigation { get; set; }
}
