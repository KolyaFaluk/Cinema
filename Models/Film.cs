using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Film
    {
        public int Id { get; set; }
        [DisplayName("Название фильма")]
        public String Name { get; set; }
        [DisplayName("Производство")]
        public string Production { get; set; }
        [DisplayName("Год выпуска")]
        public int Year { get; set; }

        [DisplayName("Длительность")]
        public int Duration { get; set; }

        public int? GenreId { get; set; }
        public Genre Genre { get; set; }

        public ICollection<Seance> Seances { get; set; }

        public Film()
        {
            Seances = new List<Seance>();

        }

    }
}
