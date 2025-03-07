using Data_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Layer.DbContextF
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data (Optional)
            modelBuilder.Entity<Note>().HasData(
                new Note { Id = 1, Title = "First Note", Content = "This is my first note." }
            );
        }
    }
}
