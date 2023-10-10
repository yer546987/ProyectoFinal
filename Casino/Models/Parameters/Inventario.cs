using CasinoApp.Models.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Models.Parameters
{
    public class Inventario
    {
        public Guid Id { get; set; }
        public string Producto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int Stock { get; set; }

        [ForeignKey("UnidadMedidas")]
        public string IdUnidadMedida { get; set; }
        public float Cantidad { get; set; }

        [ForeignKey("Inventarios")]
        public Guid IdInventario { get; set; }

        public virtual UnidadMedida UnidadMedidas { get; set; }
        public virtual Inventario Inventarios { get; set; }
    }
}
