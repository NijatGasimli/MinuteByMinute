using Core.Entity.AdminPanelEntityes;
using Core.Entity.Entities;
using Data.DAL;
using Data.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinuteByMinute.Areas.MinuteAdminPanelArea.Controllers
{
    [Area("MinuteAdminPanelArea")]
    public class TurkishStorageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public TurkishStorageController(AppDbContext Context,UserManager<AppUser> userManager)
        {
            _context = Context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var cargos =await _context.TurkishStorages.ToListAsync();
            return View(cargos);
        }

        public IActionResult CameCargos()
        {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> CameCargos(int OrderId)
        {
            if (!ModelState.IsValid) return View();
            var cargos = await _context.Cargos.Where(x => x.Isdeleted == false)
                .ToListAsync();
          
            var user = await _userManager.GetUserAsync(HttpContext.User);
            foreach (var item in cargos)
            {
                if (OrderId == item.Id)
                {

                    var fromdb = new TurkishStorage
                    {
                        About = item.About,
                        Count = item.Count,
                        Link = item.Link,
                        Price = item.Price,
                        Size = item.Size,
                        ComingTime = DateTime.Today,
                        CustomerName=user.Fullname
                        
                    };
                    item.Status = "Turkey Office";
                    await _context.TurkishStorages.AddAsync(fromdb);
                    EmailHelper emailHelper = new EmailHelper();
                    var message = "<html><body><h1>My title</h1><p>Mehsulunuz Turkiye Anbarindadi Zehmet Olmasa Sifarisinizi Smart Customda Beyan Edin</p></body></html>";
                    bool emailResponse = emailHelper.SendEmail(user.Email,message);

                    
                  
                }
                else
                {
                    ModelState.AddModelError("Message", "Yazdiginiz cargo bazasinda movcud deyil");
                }
            }



         
            await _context.SaveChangesAsync();
            return View();
        }
    }
}
