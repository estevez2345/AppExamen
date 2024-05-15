using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCelulares.Entidades
{
    public class Modelo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public DateOnly Año_Lanzamiento { get; set; }

        public int CelularId { get; set; }  //FK
        public Celular? Celular { get; set; }
    }
}
