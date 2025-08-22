using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Password { get; set; }

    public bool? Status { get; set; }

    public int? IdRol { get; set; }

    public int? IdSucursal { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual Sucursal? IdSucursalNavigation { get; set; }
}
