using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PierresTreatsAndFlavors.Models;

namespace PierresTreatsAndFlavors.Controllers;

public class HomeController : Controller
{
    private readonly PierresTreatsAndFlavorsContext _db;

    public HomeController(PierresTreatsAndFlavorsContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        // string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        // ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        List<Treat> allTreats = _db.Treats.ToList();
        List<Flavor> allFlavors = _db.Flavors.ToList();
        ViewBag.allTreats = allTreats;
        ViewBag.allFlavors = allFlavors;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
