using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CasinoApp.Models.Parameters;
using Casino.Models.Parameters;

namespace Casino.Data
{
    public class CasinoContext : DbContext
    {
        internal IEnumerable<object> Users;

        public CasinoContext (DbContextOptions<CasinoContext> options)
            : base(options)
        {
        }

        public DbSet<CasinoApp.Models.Parameters.TipoDocumentos> TipoDocumentos { get; set; }

        public DbSet<CasinoApp.Models.Parameters.TipoEmpleado> TipoEmpleado { get; set; }

        public DbSet<CasinoApp.Models.Parameters.GrupoEmpleado> GrupoEmpleado { get; set; }

        public DbSet<Casino.Models.Parameters.CostoCasino> CostoCasino { get; set; }

        public DbSet<CasinoApp.Models.Parameters.Empleado> Empleado { get; set; }

        public DbSet<CasinoApp.Models.Parameters.MovimientoCasino> MovimientoCasino { get; set; }

        public DbSet<CasinoApp.Models.Parameters.Ingredientes> Ingredientes { get; set; }

        public DbSet<Casino.Models.Parameters.TipoComida> TipoComida { get; set; }

        public DbSet<Casino.Models.Parameters.Inventario> Inventario { get; set; }

        public DbSet<CasinoApp.Models.Parameters.UnidadMedida> UnidadMedida { get; set; }

    }
}
