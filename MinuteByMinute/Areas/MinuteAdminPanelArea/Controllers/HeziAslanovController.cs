using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinuteByMinute.Areas.MinuteAdminPanelArea.Controllers
{
    public class HeziAslanovController : Controller
    {
        private readonly AppDbContext _context;

        public HeziAslanovController(AppDbContext Context)
        {
            _context = Context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
