using System;
using System.Collections.Generic;

namespace ProyectoBaseDD.Models
{
    public partial class Profesore
    {
        public Profesore()
        {
            Horarios = new HashSet<Horario>();
        }

        public string IdProfesores { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Depto { get; set; } = null!;
        public string GradAcadem { get; set; } = null!;
        public decimal Sueldo { get; set; }

        public virtual Carrera? DeptoNavigation { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; }
    }
}
