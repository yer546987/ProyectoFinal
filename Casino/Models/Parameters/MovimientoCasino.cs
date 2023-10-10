using Casino.Models.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoApp.Models.Parameters
{
    public class MovimientoCasino
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Costo { get; set; }

        [ForeignKey("TipoComida")]
        public int IdTipoComida { get; set; }

        [ForeignKey("GrupoEmpleado")]
        public int IdGrupoEmpleado { get; set; }

        [ForeignKey("Empleado")]
        public Guid IdEmpleado { get; set; }
        public DateTime HoraRegistro { get; set; }
        public virtual TipoComida TipoComida { get; set; }
        public virtual GrupoEmpleado GrupoEmpleado { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
