using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SafariVacations
{
    public partial class SafariVacationsContext : DbContext
    {
        public SafariVacationsContext()
        {
        }

        public SafariVacationsContext(DbContextOptions<SafariVacationsContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("server=localhost;database=SafariVacations;User Id=postgres;Password=Nadas0ul12#");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
        }
        public DbSet<Animal> Animals { get; set; }
    }
}
