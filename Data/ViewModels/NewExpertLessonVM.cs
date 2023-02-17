using System.ComponentModel.DataAnnotations;

namespace TutoSearch.Models
{
    public class NewExpertLessonVM
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El título  debe tener entre 3 y 50 caracteres")]
        public string Title { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción es requerida")]
        public string Description { get; set; }

        [Display(Name = "Video")]
        [Required(ErrorMessage = "La URL del vídeo es requerida")]
        public string VideoURL { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El precio es requerido")]
        public double Price { get; set; }

        [Display(Name = "Seleccione el/los tema(s)")]
        [Required(ErrorMessage = "Seleccione por lo menos un (1) tema (requerido)")]
        public List<int> TopicsIds { get; set; }

        [Display(Name = "Seleccione el profesor")]
        [Required(ErrorMessage = "El profesor de la clase es requerido")]
        public int ProfessorId { get; set; }
    }
}
