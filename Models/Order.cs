using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Цена")]
        public int PriceId { get; set; }

        [DisplayName("Количество билетов")]
        [Required]
        [Range(typeof(int), "0", "200")]
        public int CountId { get; set; }

        [DisplayName("Название Фильмы")]
        public string FilmName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy | HH:mm}")]
        [DisplayName("Дата и время")]
        public DateTime TimeDate { get; set; }

        public int SeanceId { get; set; }

        public Seance Seance { get; set; }

        //public string UserId { get; set; }


    }
}
