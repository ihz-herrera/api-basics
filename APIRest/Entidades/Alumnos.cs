using System;
using System.ComponentModel.DataAnnotations;

namespace APIRest.Entidades
{
    public class Alumnos
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public DateTime Nacimiento { get; set; }
        public int IdCurso { get; set; }
        public virtual Cursos Curso { get; set; }
    }
}
