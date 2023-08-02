using System;
using System.Collections.Generic;

namespace ProyectoBaseDD.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Kardices = new HashSet<Kardex>();
        }

        public string Ncontrol { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int Semestre { get; set; }
        public string? CveCarrera { get; set; }
        public string Apellido { get; set; } = null!;

        public virtual Carrera? CveCarreraNavigation { get; set; }
        public virtual ICollection<Kardex> Kardices { get; set; }
    }
}
