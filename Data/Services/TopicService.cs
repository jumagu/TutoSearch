using Microsoft.EntityFrameworkCore;
using TutoSearch.Data.Base;
using TutoSearch.Models;

namespace TutoSearch.Data.Services
{
    public class TopicService : EntityBaseRepository<Topic>, ITopicService
    {
        public TopicService(ApplicationDbContext context) : base(context) { }
    }
}
