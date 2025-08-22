using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class Direccion
{
    public int IdDireccion { get; set; }

    public string? Calle { get; set; }

    public string? NumeroInterior { get; set; }

    public string? NumeroExterior { get; set; }

    public int? IdColonia { get; set; }

    public virtual Colonium? IdColoniaNavigation { get; set; }

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
