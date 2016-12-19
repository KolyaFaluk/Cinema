using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Seance
    {
        public int Id { get; set; }

        [DisplayName("Дата и время")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy | HH:mm}")]
        public DateTime DateTime { get; set; }

        public int PriceTicket { get; set; }

        public int CountTickets { get; set; }

        public int HallId { get; set; }

        public int? FilmId { get; set; }

        public Film Film { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Seance()
        {
            Orders = new List<Order>();

        }

    }
}
