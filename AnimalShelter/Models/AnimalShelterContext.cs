using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Cat>()
              .HasData(
                  new Cat { CatId = 1, Name = "One", Species = "Cat", Age = 1000, Gender = "Lady" },
                  new Cat { CatId = 2, Name = "Two", Species = "Cat", Age = 10000, Gender = "Lady" },
                  new Cat { CatId = 3, Name = "Three", Species = "Cat", Age = 100000, Gender = "Lady" },
                  new Cat { CatId = 4, Name = "Four", Species = "Cat", Age = 1000000, Gender = "Lady" },
                  new Cat { CatId = 5, Name = "Five", Species = "Cat", Age = 1, Gender = "Lady" }
              );

          builder.Entity<Dog>()
              .HasData(
                  new Dog { DogId = 1, Name = "Good", Species = "Dog", Age = 2, Gender = "Dude" },
                  new Dog { DogId = 2, Name = "Bad", Species = "Dog", Age = 2, Gender = "Dude" },
                  new Dog { DogId = 3, Name = "Happy", Species = "Dog", Age = 2, Gender = "Dude" },
                  new Dog { DogId = 4, Name = "Sad", Species = "Dog", Age = 2, Gender = "Dude" },
                  new Dog { DogId = 5, Name = "Indifferent", Species = "Dog", Age = 2, Gender = "Dude" }
              );
        }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }
    }
}