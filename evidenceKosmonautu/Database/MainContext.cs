using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using evidenceKosmonautu.Models;

namespace evidenceKosmonautu.Database
{
    public class MainContext : DbContext
    {
        public DbSet<SuperheroModel> Superheroes { get; set; }
        public DbSet<SuperpowerModel> Superschopnosti { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<jt_superhero_superpower>()
                .HasKey(k => new { k.SuperheroId, k.SuperpowerId });

            modelBuilder.Entity<jt_superhero_superpower>()
                .HasOne(s => s.Superhero)
                .WithMany(s => s.Superpowers)
                .HasForeignKey(f => f.SuperheroId);

            modelBuilder.Entity<jt_superhero_superpower>()
                .HasOne(s => s.Superpower)
                .WithMany(s => s.Superheroes)
                .HasForeignKey(f => f.SuperheroId);
        }
    }
}
