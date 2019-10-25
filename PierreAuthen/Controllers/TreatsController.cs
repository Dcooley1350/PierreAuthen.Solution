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
    public class TreatController : Controller
    {
        private readonly PierreAuthenContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public TreatController(UserManager<ApplicationUser> userManager, PierreAuthenContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            List<Treat> model = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Treat treat)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            treat.User = currentUser;
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Treat thisTreat = _db.Treats
            .Include(treat => treat.Flavors)
            .ThenInclude(join => join.Flavor)
            .FirstOrDefault(treat => treat.TreatId == id);


            return View(thisTreat);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Treat foundAuthor = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(foundAuthor);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Destroy(int id)
        {
            Treat foundTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            _db.Treats.Remove(foundTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Treat foundFlavor = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(foundFlavor);
        }
        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            _db.Entry(treat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddFlavor(int id)
        {
            Treat foundtreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
            return View(foundtreat);
        }
        [HttpPost, ActionName("AddFlavor")]
        public ActionResult AddFlavor(int id, Flavor flavor)
        {
            if (id != 0)
            {
                _db.TreatFlavors.Add(new TreatFlavor() { FlavorId = flavor.FlavorId, TreatId = id });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}