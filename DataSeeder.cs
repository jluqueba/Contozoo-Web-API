using Contozoo.Resources.Animals;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contozoo
{
	public class DataSeeder
	{        
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new AnimalsContext(
                      serviceProvider
                      .GetRequiredService<DbContextOptions<AnimalsContext>>());

            if (context.Animals.Any()) { return; }

            var hobbies = new List<AnimalItem>() {
                new AnimalItem()
                {
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
                }
           };
           
            context.Animals.AddRange(hobbies);
           context.SaveChanges();
        }        
    }
}
