using System.Collections.Generic;

namespace Shelter.Models
{
  public class AnimalType
  {
    public int AnimalTypeId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Animal> Animals { get; set; }

		public AnimalType()
		{
			this.Animals = new HashSet<Animal>();
		}
  }
}