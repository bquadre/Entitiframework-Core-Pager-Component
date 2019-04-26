using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PagerComponent.Models;

namespace PagerComponent.Controllers
{
    public class HomeController : Controller
    {
        private readonly PagerDbContext _context;

        public HomeController(PagerDbContext context)
        {
            _context = context;
            _context.GenerateSampleData();
        }
        public IActionResult Index(int page = 1)
        {
            var dataPage = _context.Contacts.GetPaged(page, 10);

            return View(dataPage);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
