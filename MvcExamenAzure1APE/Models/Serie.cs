using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcExamenAzure1APE.Models
{
    public class Serie
    {
        public int IdSerie { get; set; }
        public string NombreSerie { get; set; }
        public string Imagen { get; set; }
        public double Puntuacion { get; set; }
        public int Año { get; set; }
    }
}
