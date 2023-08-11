using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PierresTreatsAndFlavors.Models;
using System.Threading.Tasks;
// using PierresTreatsAndFlavors.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace PierresTreatsAndFlavors.Controllers
{
  public class TreatsController : Controller
  {
    private readonly PierresTreatsAndFlavorsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public TreatsController(PierresTreatsAndFlavorsContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;
    }

    public async Task<ActionResult> Index()
    {
      // string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      List<Treat> allTreats = _db.Treats.ToList();
      return View(allTreats);
    }

    public ActionResult Create()
        {
            return View();
        }

    [HttpPost]
        public async Task<ActionResult> Create(Treat treat)
        {
            if (!ModelState.IsValid)
            {
                return View(treat);
            }
            else
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
                treat.User = currentUser;
                _db.Treats.Add(treat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

  }
}