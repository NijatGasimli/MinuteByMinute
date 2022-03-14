using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinuteByMinute.Areas.MinuteAdminPanelArea.Controllers
{
    [Area("MinuteAdminPanelArea")]
    public class AzerbaijanStorageController : Controller
    {
        private readonly AppDbContext _context;

        public AzerbaijanStorageController(AppDbContext Context)
        {
            _context = Context;
        }
        public IActionResult Index()
        {
          
            return View();
        }
    }
}
