using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class RandomOsobyViewModel
    {
        public Osoby Osoby { get; set; }
        public List<Konta> Konta { get; set; }
    }
}