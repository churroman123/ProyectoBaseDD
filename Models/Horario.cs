using System;
using System.Collections.Generic;

namespace ProyectoBaseDD.Models
{
    public partial class Horario
    {
        public string CveAsig { get; set; } = null!;
        public string Grupo { get; set; } = null!;
        public string? IdProfesor { get; set; }
        public string? Horario1 { get; set; }
        public string Aula { get; set; } = null!;

        public virtual Asignatura? CveAsigNavigation { get; set; }
        public virtual Profesore? IdProfesorNavigation { get; set; }
    }
}
