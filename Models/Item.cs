using System.ComponentModel.DataAnnotations;

namespace CIDM_3315_Final_Project.Models;

public class Item
{
	public int ItemID {get; set;} //Primary Key
	[StringLength(60, MinimumLength = 3)]
    public string Name {get; set;} = string.Empty;
    [StringLength(120, MinimumLength = 3)]
    public string Description {get; set;} = string.Empty;
    public string ImageURL {get; set;} = string.Empty;

    //All of this was causing a problem when trying to seed the data
/*     public int TypeID {get; set;} //Foreign Key
    public int RarityID {get; set;} //Foreign Key
    public Type Type {get; set;} = default!; // Navigation Property to Type
    public Rarity Rarity {get; set;} = default!; // Navigation Property to Rarity */
}