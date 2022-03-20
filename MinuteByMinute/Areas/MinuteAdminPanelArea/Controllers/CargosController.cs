using Core.Entity.Entities;
using Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MinuteByMinute.Areas.MinuteAdminPanelArea.Controllers
{
    [Area("MinuteAdminPanelArea")]
    [Authorize("SuperAdmin")]
    public class CargosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CargosController(AppDbContext Context,UserManager<AppUser> userManager)
        {
            _context = Context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var cargo =await _context.Cargos.Include(x=>x.AppUser).Where(x=>x.Isdeleted==false).ToListAsync();
            return View(cargo);
        }
    }
}
