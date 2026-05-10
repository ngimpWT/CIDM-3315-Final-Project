using System.ComponentModel.DataAnnotations;

namespace CIDM_3315_Final_Project.Models;

public class Type
{
	public int TypeID {get; set;} //Primary Key
	[StringLength(60, MinimumLength = 3)]
    public string Name {get; set;} = string.Empty;
    public List<Item> Item {get; set;} = default!; //Nav property to Item THIS SHOULD BE SINGULAR??
}