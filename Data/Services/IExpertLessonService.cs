using TutoSearch.Data.Base;
using TutoSearch.Data.ViewModels;
using TutoSearch.Models;

namespace TutoSearch.Data.Services
{
    public interface IExpertLessonService : IEntityBaseRepository<ExpertLesson>
    {
        Task<ExpertLesson> GetExpertLessonByIdAsync(int id);
        Task<NewLessonDropdownsVM> GetNewLessonDropdownsVM();
        Task AddNewExpertLessonAsync(NewExpertLessonVM data);
        Task UpdateExpertLessonAsync(NewExpertLessonVM data);
        Task DeleteExpertLessonAsync(NewExpertLessonVM data);
    }
}