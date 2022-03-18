using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MinuteByMinute.Areas.MinuteAdminPanelArea.Controllers
{
    [Area("MinuteAdminPanelArea")]
    public class DecleredCargosController : Controller
    {
        private readonly AppDbContext _context;

        public DecleredCargosController(AppDbContext Context)
        {
            _context = Context;
        }
        public async Task<IActionResult> Index()
        {
            var fromdb =await _context.DeclaredCargos.Include(p=>p.Cargos.AppUser).ToListAsync();
         
            return View(fromdb);
        }
    }
}
