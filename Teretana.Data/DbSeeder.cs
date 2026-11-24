using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Teretana.Domain.Entities;

namespace Teretana.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(TeretanaDbContext db)
        {
            if (await db.Uplate.AsNoTracking().AnyAsync()) return; // vec napunjeno

            Randomizer.Seed = new Random(12345);
            var rnd = new Random(12345);

            var redovni = new Faker<RedovanClan>()
                .RuleFor(c => c.Ime, f => f.Name.FirstName())
                .RuleFor(c => c.Prezime, f => f.Name.LastName())
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Ime, c.Prezime))
                .RuleFor(c => c.DatumUclanjenja, f => f.Date.Between(new DateTime(2023, 1, 1), new DateTime(2024, 12, 31)))
                .Generate(1500);

            var studentski = new Faker<StudentskiClan>()
                .RuleFor(c => c.Ime, f => f.Name.FirstName())
                .RuleFor(c => c.Prezime, f => f.Name.LastName())
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Ime, c.Prezime))
                .RuleFor(c => c.DatumUclanjenja, f => f.Date.Between(new DateTime(2023, 1, 1), new DateTime(2024, 12, 31)))
                .RuleFor(c => c.Fakultet, f => f.Company.CompanyName())
                .RuleFor(c => c.Popust, f => 20m)
                .Generate(500);

            db.Clanovi.AddRange(redovni);
            db.Clanovi.AddRange(studentski);
            await db.SaveChangesAsync();

            var clanIds = await db.Clanovi.Select(c => c.Id).ToListAsync();
            var start = new DateTime(2025, 1, 1);

            const int ukupno = 100_000;
            const int batch = 5_000;

            for (int i = 0; i < ukupno; i += batch)
            {
                var uplate = new List<Uplata>(batch);
                for (int j = 0; j < batch; j++)
                {
                    var r = rnd.NextDouble();
                    var status = r < 0.60 ? StatusUplate.Placena
                               : r < 0.85 ? StatusUplate.NaCekanju
                               : StatusUplate.Istekla;

                    uplate.Add(new Uplata
                    {
                        ClanId = clanIds[rnd.Next(clanIds.Count)],
                        Datum = start.AddDays(rnd.Next(730)).AddSeconds(rnd.Next(86_400)),
                        Status = status,
                        Iznos = rnd.Next(30, 121) * 100m
                    });
                }
                db.Uplate.AddRange(uplate);
                await db.SaveChangesAsync();
                db.ChangeTracker.Clear(); // da ne raste memorija
            }
        }
    }
}
