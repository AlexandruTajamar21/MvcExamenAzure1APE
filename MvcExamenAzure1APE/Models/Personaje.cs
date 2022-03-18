using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcExamenAzure1APE.Models
{
    public class Personaje
    {
        public int IdPersonaje { get; set; }
        public string NombrePersonaje { get; set; }
        public string Imagen { get; set; }
        public int IdSerie { get; set; }
    }
}
