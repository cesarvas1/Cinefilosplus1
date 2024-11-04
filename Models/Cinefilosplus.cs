using System.ComponentModel.DataAnnotations;

namespace Cinefilosplus.Models
{
    public class Cinefilosplus
    {
        [Key]
        public int idpeliculas { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Sinopsis { get; set; }
        public int Duracion { get; set; }
        public string Clasificacion { get; set; }
        public string Genero { get; set; }

    }
}