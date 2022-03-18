using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinuteByMinute.Controllers
{
    public class ShopsController : Controller
    {
        private readonly AppDbContext _context;

        public ShopsController(AppDbContext Context)
        {
            _context = Context;
        }
        public async Task<IActionResult> Index()
        {
            var fromdb = await _context.Categories.Include(p=>p.Shops).ToListAsync();
            return View(fromdb);
        }
    }
}
