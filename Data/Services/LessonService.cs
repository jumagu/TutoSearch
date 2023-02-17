using Microsoft.EntityFrameworkCore;
using TutoSearch.Data.Base;
using TutoSearch.Models;

namespace TutoSearch.Data.Services
{
    public class LessonService : EntityBaseRepository<Lesson>, ILessonService
    {
        private readonly ApplicationDbContext _context;
        public LessonService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Lesson> GetLessonByIdAsync(int id)
        {
            var lessonDetails = await _context.Lesson
                .Include(p => p.Professor)
                .Include(tl => tl.Topics_Lessons)
                .ThenInclude(t => t.Topic)
                .FirstOrDefaultAsync(l => l.Id == id);

            return lessonDetails;
        }
    }
}
