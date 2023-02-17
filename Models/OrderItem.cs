using System.ComponentModel.DataAnnotations;

namespace TutoSearch.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        //Relationships
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
