using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contozoo.Resources.Animals
{
	public class AnimalsContext : DbContext
    {
        public AnimalsContext(DbContextOptions<AnimalsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalItem>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<AnimalItem>().
                HasData(
                new AnimalItem() { 
                    Id = 1, 
                    CAI = 1,
                    Name = "Monkey", 
                    Number = 12, 
                    Location = "Safari Zone", 
                    ActiveHour = 9,
                    Notes = "They like bananas"
                },
                new AnimalItem()
                {
                    Id = 2,
                    CAI = 2,
                    Name = "Lion",
                    Number = 4,
                    Location = "Thy male lion is named Simba. The females are named Nala, Rasa, and Tara",
                    ActiveHour = 20,
                    Notes = "They like bananas"
                },
                new AnimalItem()
                {
                    Id = 3,
                    CAI = 3,
                    Name = "Monkey",
                    Number = 14,
                    Location = "Peeting Zoo",
                    ActiveHour = 10,
                    Notes = "You can feed the goats and pet them! "
                });
        }

        public DbSet<AnimalItem> Animals { get; set; }
    }
}
