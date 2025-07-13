using Microsoft.EntityFrameworkCore;
using CompleteProject.Models;

namespace CompleteProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Bug>("Bug")
                .HasValue<Feature>("Feature");

            modelBuilder.Entity<Bug>()
                .HasOne(b => b.AttachedBug)
                .WithMany()
                .HasForeignKey(b => b.AttachedBugId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feature>()
                .HasOne(f => f.AttachedFeature)
                .WithMany()
                .HasForeignKey(f => f.AttachedFeatureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}