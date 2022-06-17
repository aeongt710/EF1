using EF1.Data;
using EF1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EF1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var teachers = _db.Teachers.AsNoTracking().ToList();

            //_db.Dispose();
            var student = _db.Students.FirstOrDefault(a => a.Name.Equals("asd"));
            //_db.Students.Remove(student);


            var a = _db.ChangeTracker.DebugView.LongView;

            var cla = _db.Classes.Include(a => a.Teacher).Include(b => b.Student).ToList();

            //var user = new SqlParameter("Name", "asd");

            //var std = _db.Students
            //    .FromSqlRaw("EXECUTE dbo.Students @user", user)
            //    .ToList();


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
