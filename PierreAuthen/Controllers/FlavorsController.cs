using Microsoft.AspNetCore.Mvc;
using PierreAuthen.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class FlavorController : Controller
    {
        private readonly PierreAuthenContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public FlavorController(UserManager<ApplicationUser> userManager, PierreAuthenContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            List<Flavor> model = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Flavor flavor)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            flavor.User = currentUser;
            _db.Flavors.Add(flavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Flavor thisFlavor = _db.Flavors
            .Include(flavor => flavor.Treats)
            .ThenInclude(join => join.Treat)
            .FirstOrDefault(flavor => flavor.FlavorId == id);
 
 
            return View(thisFlavor);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Flavor foundAuthor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            return View(foundAuthor);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Destroy(int id)
        {
            Flavor foundFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            _db.Flavors.Remove(foundFlavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Flavor foundFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            return View(foundFlavor);
        }
        [HttpPost]
        public ActionResult Edit(Flavor flavor)
        {
            _db.Entry(flavor).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddTreat(int id)
        {
            Flavor foundFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
            return View(foundFlavor);
        }
        [HttpPost,ActionName("AddTreat")]
        public ActionResult AddTreat(int id, Treat treat)
        {
            if (id != 0)
            {
                _db.TreatFlavors.Add(new TreatFlavor() { TreatId = treat.TreatId, FlavorId = id });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}