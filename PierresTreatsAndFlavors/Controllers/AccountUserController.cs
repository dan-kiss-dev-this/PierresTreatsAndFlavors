using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PierresTreatsAndFlavors.Models;
using System.Threading.Tasks;
using PierresTreatsAndFlavors.ViewModels;

namespace PierresTreatsAndFlavors.Controllers
{
  public class AccountUserController : Controller
  {
    private readonly PierresTreatsAndFlavorsContext _db;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountUserController(PierresTreatsAndFlavorsContext db, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _signInManager = signInManager;
      _userManager = userManager;
    }

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      else
      {
        ApplicationUser user = new ApplicationUser { UserName = model.Email };
        IdentityResult result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          return RedirectToAction("Index", "Home");
        }
        else
        {
          foreach (IdentityError error in result.Errors)
          {
            ModelState.AddModelError("", error.Description);
          }
          return View(model);
        }
      }
      // return RedirectToAction("Index", "Home");
    }
  }
}
