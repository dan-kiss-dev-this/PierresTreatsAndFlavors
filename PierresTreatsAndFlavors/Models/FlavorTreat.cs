namespace PierresTreatsAndFlavors.Models
{
  public class FlavorTreat
  {
    public int FlavorTreatId { get; set; }
    public int FlavorId { get; set; }
    public int TreatId { get; set; }
    // EF Core
    public Flavor Flavor { get; set; }
    public Treat Treat { get; set; }
  }
}