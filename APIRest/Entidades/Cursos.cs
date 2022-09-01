using System.Collections;
using System.Collections.Generic;

namespace APIRest.Entidades
{
    public class Cursos
    {
        public int IdCurso { get; set; }
        public string Descripcion { get; set; }
        public int IdProfesor { get; set; }
        public virtual Profesores Profesor { get; set; }
        public virtual ICollection<Alumnos> Alumnos {get; set;}
    }
}
