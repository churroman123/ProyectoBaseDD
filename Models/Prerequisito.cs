using System;
using System.Collections.Generic;

namespace ProyectoBaseDD.Models
{
    public partial class Prerequisito
    {
        public int IdPrerequisitos { get; set; }
        public string? CveAsig { get; set; }
        public int? IdKardex { get; set; }

        public virtual Asignatura? CveAsigNavigation { get; set; }
        public virtual Kardex? IdKardexNavigation { get; set; }
    }
}
