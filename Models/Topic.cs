using System.ComponentModel.DataAnnotations;
using TutoSearch.Data.Base;
using TutoSearch.Data.Enum;

namespace TutoSearch.Models
{
    public class Topic : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Nombre del tema requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre completo debe tener entre 3 y 50 caracteres")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción del tema es requerida")]
        public string Description { get; set; }
        [Display(Name = "Asignatura")]
        [Required(ErrorMessage = "La asignatura es requerida")]
        [EnumDataType(typeof(TopicSubject))]
        public TopicSubject TopicSubject { get; set; }

        //Relationships
        public List<Topic_Lesson>? Topics_Lessons { get; set; }
    }
}
