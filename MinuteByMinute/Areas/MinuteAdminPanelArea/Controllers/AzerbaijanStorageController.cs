using Core.Entity.AdminPanelEntityes;
using Core.Entity.Entities;
using Data.DAL;
using Data.Utilities;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize("AzerbaycanAdmin")]
    public class AzerbaijanStorageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AzerbaijanStorageController(AppDbContext Context,UserManager<AppUser> userManager)
        {
            _context = Context;
            _userManager = userManager; 
        }
        public async Task<IActionResult> Index()
        {
            var fromdb = await _context.AzerbaijanStorages.Where(p=>p.Isdeleted==false).ToListAsync();
            return View(fromdb);
        }

        public IActionResult CameCargos()
        {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> CameCargos(int OrderId,string office)
        {
            if (!ModelState.IsValid) return View();
            if (OrderId == null)
            {
                return View();
            }
            if (office == null)
            {
                return View();
            }
            var cargos = await _context.Cargos.Where(x => x.Isdeleted == false)
                .ToListAsync();
            var Azerbaijan = await _context.AzerbaijanStorages.FindAsync(OrderId);
            if(Azerbaijan != null)
            {
                ModelState.AddModelError("Message","Siz Artıq Bu Məhsulu Əlavə Etdiniz");
                return View();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);
            foreach (var item in cargos)
            {

                if (OrderId == item.Id)
                {

                    var fromdb = new AzerbaijanStorage
                    {
                        About = item.About,
                        Count = item.Count,
                        Link = item.Link,
                        Price = item.Price,
                        Size = item.Size,
                        ComingTime = DateTime.Today,
                        OrderId = OrderId,
                        AzerbaijanOffices=office,
                        CustomerName=user.Fullname
                    };
                    item.Status = "Azerbaijan Office";
                    await _context.AzerbaijanStorages.AddAsync(fromdb);
                    EmailHelper emailHelper = new EmailHelper();
                    var message = "<html><body><h1>My title</h1><p>Mehsulunuz Turkiye Anbarindadi Zehmet Olmasa Sifarisinizi Smart Customda Beyan Edin</p></body></html>";
                    bool emailResponse = emailHelper.SendEmail(user.Email, message);

                    if(office == "Ichariseher")
                    {
                        foreach (var items in cargos)
                        {
                            if (items.Id == OrderId)
                            {
                                await _context.AddAsync(AddIchariseher(items));
                            }
                          
                        }

                    }
                    else
                    {
                        foreach (var items in cargos)
                        {
                            if (items.Id == OrderId)
                            {
                                await _context.AddAsync(AddHeziAslanov(items));
                            }

                        }
                    }

                }
                else
                {
                    ModelState.AddModelError("Message", "Yazdiginiz cargo bazasinda movcud deyil");
                }
            }




            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private static IcharisaharOffice AddIchariseher(Cargos cargos)
        {
            IcharisaharOffice ichericargos = new IcharisaharOffice
            {
                About = cargos.About,
                ComingTime = DateTime.Today,
                Count = cargos.Count,
                Link = cargos.Link,
                Price = cargos.Price,
                Size = cargos.Size
            };

            return ichericargos;

        }
        private static HaziAslanovOffice AddHeziAslanov(Cargos cargos)
        {
            HaziAslanovOffice ichericargos = new HaziAslanovOffice
            {
                About = cargos.About,
                ComingTime = DateTime.Today,
                Count = cargos.Count,
                Link = cargos.Link,
                Price = cargos.Price,
                Size = cargos.Size
            };

            return ichericargos;

        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fromdb = await _context.AzerbaijanStorages.FindAsync(id);
            var fromall= await _context.Cargos.FindAsync(id);
            fromdb.Isdeleted = true;
            fromdb.Achieve = "Təhvil Verildi";
            fromall.Achieve= "Təhvil Verildi"; 

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
