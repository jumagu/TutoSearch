using Microsoft.EntityFrameworkCore;
using TutoSearch.Data.Base;
using TutoSearch.Data.ViewModels;
using TutoSearch.Models;

namespace TutoSearch.Data.Services
{
    public class BasicLessonService : EntityBaseRepository<BasicLesson>, IBasicLessonService
    {
        private readonly ApplicationDbContext _context;
        public BasicLessonService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewBasicLessonAsync(NewBasicLessonVM data)
        {
            var newBasicLesson = new BasicLesson()
            {
                Title = data.Title,
                Description = data.Description,
                VideoURL = data.VideoURL,
                ProfessorId = data.ProfessorId
            };
            await _context.BasicLesson.AddAsync(newBasicLesson);
            await _context.SaveChangesAsync();

            // Add BasicLesson Topics
            foreach (var topicId in data.TopicsIds)
            {
                var newTopicLesson = new Topic_Lesson()
                {
                    LessonId = newBasicLesson.Id,
                    TopicId = topicId
                };
                await _context.Topic_Lesson.AddAsync(newTopicLesson);
            }
            await _context.SaveChangesAsync();
        }

        public Task DeleteBasicLessonAsync(NewBasicLessonVM data)
        {
            throw new NotImplementedException();
        }

        public async Task<BasicLesson> GetBasicLessonByIdAsync(int id)
        {
            var basicLessonDetails = await _context.BasicLesson
                .Include(p => p.Professor)
                .Include(tl => tl.Topics_Lessons)
                .ThenInclude(t => t.Topic)
                .FirstOrDefaultAsync(l => l.Id == id);

            return basicLessonDetails;
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

        public async Task UpdateBasicLessonAsync(NewBasicLessonVM data)
        {
            var dbBasicLesson = await _context.BasicLesson.FirstOrDefaultAsync(bl => bl.Id == data.Id);
            if (dbBasicLesson != null)
            {
                dbBasicLesson.Title = data.Title;
                dbBasicLesson.Description = data.Description;
                dbBasicLesson.VideoURL = data.VideoURL;
                dbBasicLesson.ProfessorId = data.ProfessorId;

                await _context.SaveChangesAsync();
            }

            // Remove existing topics
            var existingTopicsDb = await _context.Topic_Lesson.Where(l => l.LessonId == data.Id).ToListAsync();
            _context.Topic_Lesson.RemoveRange(existingTopicsDb);
            await _context.SaveChangesAsync();

            // Add BasicLesson Topics
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
