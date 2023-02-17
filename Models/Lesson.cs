using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TutoSearch.Data.Base;

namespace TutoSearch.Models
{
    public class Lesson : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Título")]
        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El título  debe tener entre 3 y 50 caracteres")]
        public string Title { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción es requerida")]
        public string Description { get; set; }
        [Display(Name = "Video")]
        [Required(ErrorMessage = "El vídeo es requerido")]
        public string VideoURL { get; set; }

        //Relationships
        public List<Topic_Lesson> Topics_Lessons { get; set; }
        public int ProfessorId { get; set; }
        [ForeignKey("ProfessorId")]
        public Professor Professor { get; set; }
    }
}
