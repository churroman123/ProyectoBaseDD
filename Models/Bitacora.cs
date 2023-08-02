using System;
using System.Collections.Generic;

namespace ProyectoBaseDD.Models
{
    public partial class Bitacora
    {
        public int IdBitacora { get; set; }
        public DateOnly Fecha { get; set; }
        public string? Operacion { get; set; }
        public string? ObjInfo { get; set; }
        public string? Valores { get; set; }
        public string? ValorAnterior { get; set; }
        public string? ValorNuevo { get; set; }
    }
}
