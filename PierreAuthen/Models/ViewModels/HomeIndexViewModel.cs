using System.Collections.Generic;
using PierreAuthen.Models;

namespace PierreAuthen.ViewModels
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel(List<Treat> allTreats, List<Flavor> allFlavors)
        {
            AllTreats = allTreats;
            AllFlavors = allFlavors;
        }
        public List<Treat> AllTreats { get; set; }
        public List<Flavor> AllFlavors { get; set; }
    }
}