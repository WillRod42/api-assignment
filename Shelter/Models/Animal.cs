namespace Shelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public bool IsMale { get; set; }
    public int Age { get; set; }
    public int TypeId { get; set; }
  }
}