using Microsoft.EntityFrameworkCore;
using Submission.Domain.Entities;

namespace Submission.Persistence
{
    public class SubmissionDbContext:DbContext
    {
        public SubmissionDbContext(DbContextOptions options):base()
        {
        }
        #region Entities
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Article> Articles { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
