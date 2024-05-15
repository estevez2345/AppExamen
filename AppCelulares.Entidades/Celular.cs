using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCelulares.Entidades
{
    public class Celular
    {
        [Key]
        public int Id { get; set; }  //PK

        [DisplayName("Numero de Serie")]
        public string NumeroSerie { get; set; }
        public string Color { get; set; }
        public int Almacenamiento { get; set; }
        public DateOnly FechaCompra { get; set; }

        public List<Modelo>? ModeloList { get; set; }


    }
}
