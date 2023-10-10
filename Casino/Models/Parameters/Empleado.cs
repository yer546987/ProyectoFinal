using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoApp.Models.Parameters
{
    public class Empleado
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Identificacion { get; set; }

        [ForeignKey("TipoDocumentos")]
        public Guid IdTipoIdentificacion { get; set; }

        [ForeignKey("TipoEmpleado")]
        public int IdTipoEmpleado { get; set; }

        [ForeignKey("GrupoEmpleado")]
        public int IdGrupoE { get; set; }
        public bool Interno { get; set; }
        public virtual TipoEmpleado TipoEmpleado { get; set; }
        public virtual GrupoEmpleado GrupoEmpleado { get; set; }
        public virtual TipoDocumentos TipoDocumentos { get; set; }

    }
}
