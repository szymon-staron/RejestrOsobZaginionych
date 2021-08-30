using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;
using System.Data.Entity;
using WebApplication2.Migrations;

namespace WebApplication2.Controllers
{
    public class OsobyController : Controller
    {
        //public ViewResult Index()
        //{
        //    var osoba = GetOsoby();

        //    return View(osoba);
        //}

        //private IEnumerable<Osoby> GetOsoby()
        //{
        //    return new List<Osoby>
        //    {
        //        new Osoby { Id = 1, Name = "Shrek" },
        //        new Osoby { Id = 2, Name = "Wall-e" }
        //    };
        //}
        //// GET: Osoby
        //public ActionResult Random()
        //{
        //    var osoba = new Osoby() { Name = "Jan" };
        //    var konta = new List<Konta>
        //    {
        //    new Konta { Name = "Konto 1"},
        //    new Konta { Name = "Konto 2"}
        //    };

        //    var viewModel = new RandomOsobyViewModel {
        //        Osoby = osoba,
        //        Konta = konta
        //    };

        //    return View(viewModel);
        //}


        //public ActionResult Edit(int id)
        //{
        //    return Content("Id=" + id);
        //}
        ////osoby
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("PageIndex={0}&sortBy={1}",pageIndex, sortBy));
        //}

        //[Route("osoby/zag/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        //public ActionResult OdZag(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}
        private ApplicationDbContext _context;
        public OsobyController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var osoby = _context.Osoby.Include(m => m.Genre).ToList();

            return View(osoby);
        }
        public ActionResult Details(int id)
        {
            var osoby = _context.Osoby.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (osoby == null)
                return HttpNotFound();

            return View(osoby);

        }

        [Authorize]
        public ViewResult New()
        {
            var genres = _context.Genre.ToList();

            var viewModel = new NoweOsobyViewModel
            {
                Genres = genres
            };

            return View("NowaOsoba", viewModel);
        }

     //public actionresult edit(int id)
     //{
     //    var osoby = _context.osoby.singleordefault(c => c.id == id);
     //
     //    if (osoby == null)
     //        return httpnotfound();
     //
     //    var viewModel = new NoweOsobyViewModel
     //    {
     //        Osoba = osoby,
     //        Genres = _context.Genre.ToList()
     //    };
     //
     //    return View("NowaOsoba", viewModel);
     //}

        public ActionResult Edit(int id)
        {
            var osoby = _context.Osoby.SingleOrDefault(c => c.Id == id);

            if (osoby == null)
                return HttpNotFound();

            var viewModel = new NoweOsobyViewModel
            {
                Osoba = osoby,
                Genres = _context.Genre.ToList()
            };
            if (User.IsInRole("Admin"))
            return View("NowaOsoba", viewModel);
            else
                return View("ReadOnly", viewModel);
        }





        public ActionResult Random()
        {
            var osoba = new Osoby() { Name = "Jan" };
            var konta = new List<Konta>
            {
            new Konta { Name = "Konto 1"},
            new Konta { Name = "Konto 2"}
            };

            var viewModel = new RandomOsobyViewModel
            {
                Osoby = osoba,
                Konta = konta
            };

            return View(viewModel);
        }

        public ActionResult Save(Osoby osoby)
        {
            if (osoby.Id == 0)
            {
                _context.Osoby.Add(osoby);
            }

            else
            {
                var osobyInDb = _context.Osoby.Single(m => m.Id == osoby.Id);
                osobyInDb.Name = osoby.Name;
                osobyInDb.GenreId = osoby.GenreId;
                osobyInDb.Wiek = osoby.Wiek;
                osobyInDb.Wzrost = osoby.Wzrost;
                osobyInDb.DataZag = osoby.DataZag;
                osobyInDb.Miasto = osoby.Miasto;
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Osoby");
        }

    }
}