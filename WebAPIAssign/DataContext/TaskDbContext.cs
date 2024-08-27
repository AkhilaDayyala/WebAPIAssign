using Microsoft.EntityFrameworkCore;
using WebAPIAssign.Models;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }

    public DbSet<ProjectTask> Tasks { get; set; }
    public DbSet<SubTask> SubTasks { get; set; }
 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuring the Tasks entity
        modelBuilder.Entity<ProjectTask>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
            entity.Property(t => t.CreatedBy).IsRequired().HasMaxLength(50);
            entity.Property(t => t.CreatedOn).IsRequired();
            entity.Property(t => t.Description).HasMaxLength(500);

            // Configure one-to-many relationship with SubTask
            entity.HasMany(t => t.SubTasks)
                  .WithOne(st => st.Tasks)
                  .HasForeignKey(st => st.TaskId);
        });

        // Configuring the SubTask entity
        modelBuilder.Entity<SubTask>(entity =>
        {
            entity.HasKey(st => st.Id);
            entity.Property(st => st.SubTaskName).IsRequired().HasMaxLength(100);
            entity.Property(st => st.CreatedBy).IsRequired().HasMaxLength(50);
            entity.Property(st => st.CreatedOn).IsRequired();
            entity.Property(st => st.TaskId).IsRequired();
        });
    }
}