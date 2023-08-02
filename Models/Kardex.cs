using System;
using System.Collections.Generic;

namespace ProyectoBaseDD.Models
{
    public partial class Kardex
    {
        public Kardex()
        {
            Prerequisitos = new HashSet<Prerequisito>();
        }

        public int IdKardex { get; set; }
        public string? CveAsig { get; set; }
        public int Calificacion { get; set; }
        public string? TipoEval { get; set; }
        public string? Ncontrol { get; set; }

        public virtual Asignatura? CveAsigNavigation { get; set; }
        public virtual Estudiante? NcontrolNavigation { get; set; }
        public virtual ICollection<Prerequisito> Prerequisitos { get; set; }
    }
}
