using System.ComponentModel.DataAnnotations;

namespace CIDM_3315_Final_Project.Models;

public class Type
{
	public int TypeID {get; set;} //Primary Key
	[StringLength(60, MinimumLength = 3)]
    public string Name {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty; //Does "Type" need a description?
    public string ImageURL {get; set;} = string.Empty; // Does "Type" need an image?
    public int ItemID {get; set;} //Foreign Key
    public List<Item> Items {get; set;} = default!; //Nav property to Item
}