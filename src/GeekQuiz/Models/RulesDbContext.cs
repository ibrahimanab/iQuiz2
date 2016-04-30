using Microsoft.Data.Entity;

namespace GeekQuiz.Models
{
    public class RulesDbContext : DbContext
    {
        private static bool _rcreated = false;

        public RulesDbContext()
        {
            if (!_rcreated)
            {
                _rcreated = true;
                Database.EnsureCreated();
            }
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Rules>()
                .HasKey(o => new { o.RulesID });

           
        }

        public DbSet<Rules> Rules { get; set; }

        





    }
}