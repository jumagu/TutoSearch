using System.ComponentModel.DataAnnotations;

namespace TutoSearch.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Lesson Lesson { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
