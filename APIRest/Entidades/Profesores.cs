using System.Collections;
using System.Collections.Generic;

namespace APIRest.Entidades
{
    public class Profesores
    {
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Cursos> Cursos { get; set; }
    }
}
