
namespace Grocery.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public virtual Items Item { get; set; }
    }
}