using System.ComponentModel.DataAnnotations;
using TutoSearch.Data.Base;

namespace TutoSearch.Models
{
    public class Professor : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Foto de Perfil")]
        [Required(ErrorMessage = "Foto de perfil requerida")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "Nombre completo requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre completo debe tener entre 3 y 50 caracteres")]
        public string FullName { get; set; }
        [Display(Name = "Biografía")]
        [Required(ErrorMessage = "Biografía requerida")]
        public string Bio { get; set; }

        //Relationships
        public List<Lesson>? Lessons { get; set; }
    }
}
