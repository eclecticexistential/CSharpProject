using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Grocery.Models
{
    public class RecipeItems
    {
        public int Id { get; set; }

        public virtual List<Items> Item { get; set; }
        [Required]
        public string RecipeName { get; set; }
    }
}