using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoApp.Models.Parameters
{
    public class Ingredientes
    {
        public int Id { get; set; }

        [ForeignKey("UnidadMedida")]
        public int IdUnidadPesaje { get; set; }
        public string Cantidad { get; set; }
        public int IdInventario { get; set; }

        public virtual UnidadMedida UnidadMedida { get; set; }
    }
}
