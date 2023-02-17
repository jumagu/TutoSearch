using Microsoft.EntityFrameworkCore;
using TutoSearch.Data.Base;
using TutoSearch.Models;

namespace TutoSearch.Data.Services
{
    public class ProfessorService : EntityBaseRepository<Professor>, IProfessorService
    {
        public ProfessorService(ApplicationDbContext context) : base(context) { }
    }
}
