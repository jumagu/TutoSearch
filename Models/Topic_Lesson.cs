using System.ComponentModel.DataAnnotations.Schema;

namespace TutoSearch.Models
{
    public class Topic_Lesson
    {
        public int LessonId { get; set; }
        [ForeignKey("LessonId")]
        public Lesson Lesson { get; set; }
        public int TopicId { get; set; }
        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }
    }
}
