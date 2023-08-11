namespace PierresTreatsAndFlavors.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual List<FlavorTreat> JoinFlavorTreats { get; set; }
  }
}