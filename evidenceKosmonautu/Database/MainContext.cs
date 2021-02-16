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
        public DbSet<jt_superhero_superpower> jtHeroPower { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<jt_superhero_superpower>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<jt_superhero_superpower>()
                .HasOne(s => s.SuperheroModel)
                .WithMany(s => s.jtHeroPower)
                .HasForeignKey(f => f.SuperheroId);

            modelBuilder.Entity<jt_superhero_superpower>()
                .HasOne(s => s.SuperpowerModel)
                .WithMany(s => s.jtHeroPower)
                .HasForeignKey(f => f.SuperpowerId);
        }
    }
}
