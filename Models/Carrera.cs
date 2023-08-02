using System;
using System.Collections.Generic;

namespace ProyectoBaseDD.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Asignaturas = new HashSet<Asignatura>();
            Estudiantes = new HashSet<Estudiante>();
            Profesores = new HashSet<Profesore>();
        }

        public string CveCarrera { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int Creditos { get; set; }

        public virtual ICollection<Asignatura> Asignaturas { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Profesore> Profesores { get; set; }
    }
}
