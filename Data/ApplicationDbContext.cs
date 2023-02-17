using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TutoSearch.Models;

namespace TutoSearch.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Topic_Lesson>().HasKey(tl => new
            {
                tl.TopicId,
                tl.LessonId
            });

            builder.Entity<Topic_Lesson>()
                .HasOne(t => t.Topic)
                .WithMany(tl => tl.Topics_Lessons)
                .HasForeignKey(t => t.TopicId);

            builder.Entity<Topic_Lesson>()
                .HasOne(l => l.Lesson)
                .WithMany(tl => tl.Topics_Lessons)
                .HasForeignKey(l => l.LessonId);

            builder.Entity<Lesson>()
                .HasDiscriminator<int>("LessonType")
                .HasValue<Lesson>(1)
                .HasValue<BasicLesson>(2)
                .HasValue<ExpertLesson>(3);

            base.OnModelCreating(builder);
        }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<BasicLesson> BasicLesson { get; set; }
        public DbSet<ExpertLesson> ExpertLesson { get; set; }
        public DbSet<Topic_Lesson> Topic_Lesson { get; set; }
    }
}