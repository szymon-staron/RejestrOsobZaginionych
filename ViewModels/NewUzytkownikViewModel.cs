using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
    public class NewUzytkownikViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Konta Konto { get; set; }
    }
}