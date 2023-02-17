using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TutoSearch.Models
{
    public class ExpertLesson : Lesson
    {
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El precio es requerido")]
        public double Price { get; set; }
    }
}
