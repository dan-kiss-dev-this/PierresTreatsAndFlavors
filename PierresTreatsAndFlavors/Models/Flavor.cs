namespace PierresTreatsAndFlavors.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    public string Description { get; set; }

    public List<FlavorTreat> JoinFlavorTreats { get; set; }
  }
}