using Microsoft.AspNetCore.Identity;

namespace PierresTreatsAndFlavors.Models
{
  public class ApplicationUser : IdentityUser
  {
    // add an additional property to ApplicationUser 
    public string AboutMe { get; set; }
  }
}