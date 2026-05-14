using System.ComponentModel.DataAnnotations;

namespace CIDM_3315_Final_Project.Models;
public class Rarity
{
	public int RarityID {get; set;} //Primary Key
	[StringLength(60, MinimumLength = 3)]
    public string Name {get; set;} = string.Empty;
    public List<Item>? Items {get; set;} = default!; //Nav property to Item
}