using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PierreAuthen.Models;
using PierreAuthen.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace PierreAuthen.Solution.Controllers
{
    public class HomeController : Controller
    {
        private readonly PierreAuthenContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(UserManager<ApplicationUser> userManager, PierreAuthenContext db)
        {
            _userManager = userManager;
            _db = db;
        }
    [HttpGet("/")]
    public ActionResult Index()
    {
        List<Flavor> foundFlavors = _db.Flavors.ToList();
        List<Treat> foundTreats = _db.Treats.ToList();
        HomeIndexViewModel viewModel = new HomeIndexViewModel(foundTreats,foundFlavors);
        return View(viewModel);   
    }
    }
}
