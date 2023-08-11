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
  [Authorize]
  public class TreatsController : Controller
  {
    private readonly PierresTreatsAndFlavorsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public TreatsController(PierresTreatsAndFlavorsContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;
    }

    [AllowAnonymous]
    public async Task<ActionResult> Index()
    {
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
        Console.WriteLine(4848);
        Console.WriteLine(userId);
        // if (userId != null)
        // {
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        treat.User = currentUser;
        _db.Treats.Add(treat);
        _db.SaveChanges();
        return RedirectToAction("Index");
        // }
        // else
        // {
        //   return RedirectToAction("Register", "AccountUser");
        // }
      }
    }

    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats
      .AsNoTracking()
      .Include(treat => treat.JoinFlavorTreats)
      .ThenInclude(join => join.Flavor)
      .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats
        .Include(treat => treat.User)
        .FirstOrDefault(treat => treat.TreatId == id);
      Console.WriteLine(7777);
      Console.WriteLine(thisTreat.User.Id);
      return View(thisTreat);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(Treat treat)
    {
      if (!ModelState.IsValid)
      {
        return View(treat);
      }
      else
      {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        _db.Treats.Update(treat);
        _db.SaveChanges();
        return RedirectToAction("Index");

      }
    }

    public ActionResult Delete(int id)
    {
      Treat theTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(theTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}