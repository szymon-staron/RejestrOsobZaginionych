using WebApplication2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication2.Models;
using System.Data.Entity;

namespace WebApplication2.Controllers
{
    public class KontaController : Controller
    {
        private ApplicationDbContext _context;

        public KontaController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewUzytkownikViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("New", viewModel);
        }
        [HttpPost]
        public ActionResult Create(Konta konta)
        {

            if (konta.Id == 0)
                _context.Konta.Add(konta);
            else
            {

                var kontaInDb = _context.Konta.Single(c => c.Id == konta.Id);
                kontaInDb.Name = konta.Name;
                kontaInDb.MembershipTypeId = konta.MembershipTypeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Konta");
        }



        public ViewResult Index()
        {
            var konta = _context.Konta.Include(c => c.MembershipType).ToList();

            return View(konta);
        }

        public ActionResult Details(int id)
        {
            var konto = _context.Konta.SingleOrDefault(c => c.Id == id);

            if (konto == null)
                return HttpNotFound();

            return View(konto);
        }

        public ActionResult Edit(int id)
        {

            var konto = _context.Konta.SingleOrDefault(c => c.Id == id);

            if (konto == null)
                return HttpNotFound();


            var viewModel = new NewUzytkownikViewModel
            {
                Konto = konto,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New", viewModel);
        }

    }
}