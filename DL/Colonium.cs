﻿using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class Colonium
{
    public int IdColonia { get; set; }

    public string? Nombre { get; set; }

    public string? CodigoPostal { get; set; }

    public int? IdMunicipio { get; set; }

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual Municipio? IdMunicipioNavigation { get; set; }
}
