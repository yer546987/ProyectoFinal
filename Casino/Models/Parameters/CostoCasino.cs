using CasinoApp.Models.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Models.Parameters
{
    public class CostoCasino
    {
        public int Id { get; set; }
        public float Precio { get; set; }

        [ForeignKey("TipoComida")]
        public int IdTipoComida { get; set; }

        [ForeignKey("GrupoEmpleado")]
        public int IdGrupoEmpleado { get; set; }

        public virtual TipoComida TipoComida { get; set; }
        public virtual GrupoEmpleado GrupoEmpleado{ get; set; }
    }
}
