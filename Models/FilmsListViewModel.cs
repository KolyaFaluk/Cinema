using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Models
{
    public class FilmsListViewModel
    {
        public IEnumerable<Film> Films { get; set; }
        public SelectList Genres { get; set; }
    }
}