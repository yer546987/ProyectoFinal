using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.Models.Parameters
{
    public class TipoComida
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Descripcion { get; set; }
        public DateTime? TiempoInicial { get; set; }
        public DateTime? TiempoFinal { get; set; }
        public int Limite { get; set; }
        public bool Cronograma { get; set; }

    }
}
