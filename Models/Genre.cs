using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Жанр")]
        public String Name { get; set; }

        public ICollection<Film> Films { get; set; }
        public Genre()
        {
            Films = new List<Film>();

        }
    }
}
