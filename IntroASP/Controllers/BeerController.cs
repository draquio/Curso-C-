using IntroASP.Models;
using IntroASP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly CursoCContext _context;

        public BeerController(CursoCContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var beers = _context.Beers.Include(b => b.IdBrandNavigation);
            return View(await beers.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["title"] = "Titulo de la pagina";
            ViewData["Brands"] = new SelectList(_context.Brands, "idBrand", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var beer = new Beer()
                {
                    Name = model.Name,
                    idBrand = model.idBrand,
                };
                _context.Add(beer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Brands"] = new SelectList(_context.Brands, "idBrand", "Name", model.idBrand);
            return View(model);
        }
    }
}
