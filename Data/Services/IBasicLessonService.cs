using TutoSearch.Data.Base;
using TutoSearch.Data.ViewModels;
using TutoSearch.Models;

namespace TutoSearch.Data.Services
{
    public interface IBasicLessonService : IEntityBaseRepository<BasicLesson>
    {
        Task<BasicLesson> GetBasicLessonByIdAsync(int id);
        Task<NewLessonDropdownsVM> GetNewLessonDropdownsVM();
        Task AddNewBasicLessonAsync(NewBasicLessonVM data);
        Task UpdateBasicLessonAsync(NewBasicLessonVM data);
        Task DeleteBasicLessonAsync(NewBasicLessonVM data);

    }
}
