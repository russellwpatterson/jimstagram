using System;
using Jimstagram.PostsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Jimstagram.PostsApi
{
    public partial class JimstagramContext : DbContext
    {
        public JimstagramContext()
        {
        }

        public JimstagramContext(DbContextOptions<JimstagramContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=jimbook;Username=jimbook_admin;Password=jimbook_is_my_favorite_site");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ThatsDecents)
                    .IsRequired()
                    .HasDefaultValue(0)
                    .HasColumnName("thats_decents");

                entity.Property(e => e.NotSoGoods)
                    .IsRequired()
                    .HasDefaultValue(0)
                    .HasColumnName("not_so_goods");

                entity.Property(e => e.ImageFilename)
                    .HasColumnName("image_filename");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message");

                entity.Property(e => e.SoGoods)
                    .IsRequired()
                    .HasDefaultValue(0)
                    .HasColumnName("so_goods");

                entity.Property(e => e.Username).HasColumnName("username");
            });
        }
    }
}
