using Casino.Models.Parameters;
using CasinoApp.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Models.ViewModel
{
    public class CrearActualizarModeloEmpleado
    {
        public CostoCasino Costos { get; set; }
        public Empleado Empleados { get; set; }
        public TipoComida tipoComidas { get; set; }
        public MovimientoCasino movimientos { get; set; }
        public List<TipoComida> ListTipoComidas { get; set; }
        public List<Empleado> listEmpleado { get; set; }
        public List<TipoEmpleado> ListTipoEmpleados { get; set; }
        public List<GrupoEmpleado> ListGrupoEmpleados { get; set; }
    }
}
