using Core.Entity.Entities;
using Core.Entity.ViewModel;
using Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinuteByMinute.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(AppDbContext Context,UserManager<AppUser> userManager)
        {
            Context = _context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
     
      
        
             
    }

}
