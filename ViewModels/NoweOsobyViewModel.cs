using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class NoweOsobyViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Osoby Osoba { get; set; }
        public string Title
        {
            get
            {
                if (Osoba != null && Osoba.Id != 0)
                    return "Edytuj osobe";

                return "Dodaj osobe";
            }
        }
    }
}