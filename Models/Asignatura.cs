using System;
using System.Collections.Generic;
using ProyectoBaseDD.Data;
namespace ProyectoBaseDD.Models
{
    public partial class Asignatura
    {
        public Asignatura()
        {
            Kardices = new HashSet<Kardex>();
            Prerequisitos = new HashSet<Prerequisito>();
        }

        public string Nombre { get; set; } = null!;
        public string CveCarrera { get; set; } = null!;
        public int Creditos { get; set; }
        public string CveAsig { get; set; } = null!;

        public virtual Carrera? CveCarreraNavigation { get; set; }
        public virtual Horario? Horario { get; set; }
        public virtual ICollection<Kardex> Kardices { get; set; }
        public virtual ICollection<Prerequisito> Prerequisitos { get; set; }
    }
}
