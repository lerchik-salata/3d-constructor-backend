using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ConstructorApi.Models;

namespace ConstructorApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectSetting> ProjectSettings { get; set; }
        public DbSet<Scene> Scenes { get; set; }
        public DbSet<Texture> Textures { get; set; }
        public DbSet<SceneObject> SceneObjects { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<CustomShape> CustomShapes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Settings)
                .WithOne(ps => ps.Project)
                .HasForeignKey<ProjectSetting>(ps => ps.ProjectId);

            modelBuilder.Entity<SceneObject>()
                .HasOne(so => so.Scene)
                .WithMany(s => s.Objects)
                .HasForeignKey(so => so.SceneId);

            modelBuilder.Entity<SceneObject>()
                .HasOne(o => o.Texture)
                .WithMany(t => t.SceneObjects)
                .HasForeignKey(o => o.TextureId);

        }
    }
}
