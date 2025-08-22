using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public int? IdDireccion { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Direccion? IdDireccionNavigation { get; set; }

    public virtual ICollection<InventarioSucursal> InventarioSucursals { get; set; } = new List<InventarioSucursal>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
