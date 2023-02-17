using TutoSearch.Models;

namespace TutoSearch.Data.ViewModels
{
    public class NewLessonDropdownsVM
    {
        public NewLessonDropdownsVM()
        {
            Professors = new List<Professor>();
            Topics = new List<Topic>();
        }

        public List<Professor> Professors { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
