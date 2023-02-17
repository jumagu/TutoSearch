using TutoSearch.Data.Base;
using TutoSearch.Models;

namespace TutoSearch.Data.Services
{
    public interface ILessonService : IEntityBaseRepository<Lesson>
    {
        Task<Lesson> GetLessonByIdAsync(int id);
    }
}
