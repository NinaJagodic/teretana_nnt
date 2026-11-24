using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Teretana.Domain.Entities;

namespace Teretana.Data
{
    public class TeretanaDbContext : DbContext
    {
        public TeretanaDbContext(DbContextOptions<TeretanaDbContext> options) : base(options) { }

        public DbSet<Clan> Clanovi => Set<Clan>();
        public DbSet<Uplata> Uplate => Set<Uplata>();
        public DbSet<Trening> Treninzi => Set<Trening>();
        public DbSet<PrijavaNaTrening> Prijave => Set<PrijavaNaTrening>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<Clan>(e =>
            {
                e.Property(x => x.Ime).HasMaxLength(50).IsRequired();
                e.Property(x => x.Prezime).HasMaxLength(50).IsRequired();
                e.Property(x => x.Email).HasMaxLength(100).IsRequired();
            });

            b.Entity<StudentskiClan>(e =>
            {
                e.Property(x => x.Fakultet).HasMaxLength(100);
                e.Property(x => x.Popust).HasPrecision(5, 2);
            });

            b.Entity<Uplata>(e =>
            {
                e.Property(x => x.Iznos).HasPrecision(10, 2);
                e.Property(x => x.Status).HasConversion<string>().HasMaxLength(20);
                e.HasOne(x => x.Clan).WithMany(c => c.Uplate).HasForeignKey(x => x.ClanId);
            });

            b.Entity<Trening>(e =>
            {
                e.Property(x => x.Naziv).HasMaxLength(50).IsRequired();
                e.Property(x => x.Trener).HasMaxLength(50).IsRequired();
            });

            b.Entity<PrijavaNaTrening>(e =>
            {
                e.HasKey(x => new { x.ClanId, x.TreningId });
                e.HasOne(x => x.Clan).WithMany(c => c.Prijave).HasForeignKey(x => x.ClanId);
                e.HasOne(x => x.Trening).WithMany(t => t.Prijave).HasForeignKey(x => x.TreningId);
            });
        }
    }
}
