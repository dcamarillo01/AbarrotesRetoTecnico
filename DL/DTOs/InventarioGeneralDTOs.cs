using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class InventarioGeneralDTOs
    {

        public class InventarioPorSucursalDto
        {
            public int IdSucursal { get; set; }
            public string Sucursal { get; set; } = "";
            public int Existencia { get; set; }
        }

        public class InventarioGeneralItemDto
        {
            public int IdProducto { get; set; }
            public string Producto { get; set; } = "";
            public int ExistenciaTotal { get; set; }
            public List<InventarioPorSucursalDto> PorSucursal { get; set; } = new();
        }

    }
}
