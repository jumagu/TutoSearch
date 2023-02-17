using Microsoft.EntityFrameworkCore;
using TutoSearch.Data.Base;
using TutoSearch.Data.ViewModels;
using TutoSearch.Models;

namespace TutoSearch.Data.Services
{
    public class ExpertLessonService : EntityBaseRepository<ExpertLesson>, IExpertLessonService
    {
        private readonly ApplicationDbContext _context;
        public ExpertLessonService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewExpertLessonAsync(NewExpertLessonVM data)
        {
            var newExpertLesson = new ExpertLesson()
            {
                Title = data.Title,
                Description = data.Description,
                VideoURL = data.VideoURL,
                Price = data.Price,
                ProfessorId = data.ProfessorId
            };
            await _context.ExpertLesson.AddAsync(newExpertLesson);
            await _context.SaveChangesAsync();

            // Add ExpertLesson Topics
            foreach (var topicId in data.TopicsIds)
            {
                var newTopicLesson = new Topic_Lesson()
                {
                    LessonId = newExpertLesson.Id,
                    TopicId = topicId
                };
                await _context.Topic_Lesson.AddAsync(newTopicLesson);
            }
            await _context.SaveChangesAsync();
        }

        public Task DeleteExpertLessonAsync(NewExpertLessonVM data)
        {
            throw new NotImplementedException();
        }

        public async Task<ExpertLesson> GetExpertLessonByIdAsync(int id)
        {
            var expertLessonDetails = await _context.ExpertLesson
                .Include(p => p.Professor)
                .Include(tl => tl.Topics_Lessons)
                .ThenInclude(t => t.Topic)
                .FirstOrDefaultAsync(l => l.Id == id);

            return expertLessonDetails;
        }

        public async Task<NewLessonDropdownsVM> GetNewLessonDropdownsVM()
        {
            var response = new NewLessonDropdownsVM()
            {
                Topics = await _context.Topic.OrderBy(t => t.Name).ToListAsync(),
                Professors = await _context.Professor.OrderBy(p => p.FullName).ToListAsync()
            };
            return response;
        }

        public async Task UpdateExpertLessonAsync(NewExpertLessonVM data)
        {
            var dbExpertLesson = await _context.ExpertLesson.FirstOrDefaultAsync(el => el.Id == data.Id);
            if (dbExpertLesson != null)
            {
                dbExpertLesson.Title = data.Title;
                dbExpertLesson.Description = data.Description;
                dbExpertLesson.VideoURL = data.VideoURL;
                dbExpertLesson.Price = data.Price;
                dbExpertLesson.ProfessorId = data.ProfessorId;

                await _context.SaveChangesAsync();
            }

            // Remove existing topics
            var existingTopicsDb = await _context.Topic_Lesson.Where(l => l.LessonId == data.Id).ToListAsync();
            _context.Topic_Lesson.RemoveRange(existingTopicsDb);
            await _context.SaveChangesAsync();

            // Add ExpertLesson Topics
            foreach (var topicId in data.TopicsIds)
            {
                var newTopicLesson = new Topic_Lesson()
                {
                    LessonId = data.Id,
                    TopicId = topicId
                };
                await _context.Topic_Lesson.AddAsync(newTopicLesson);
            }
            await _context.SaveChangesAsync();
        }
    }
}
