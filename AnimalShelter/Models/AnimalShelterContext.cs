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
                  new Cat { CatId = 3, Name = "Three", Species = "Not a Cat", Age = 100000, Gender = "Lady" },
                  new Cat { CatId = 4, Name = "Four", Species = "Cat", Age = 1000000, Gender = "Lady" },
                  new Cat { CatId = 5, Name = "Five", Species = "Cat", Age = 1, Gender = "Lady" },
                  new Cat { CatId = 6, Name = "Six", Species = "Cat", Age = 2, Gender = "Dolphin" },
                  new Cat { CatId = 7, Name = "Seven", Species = "Cat", Age = 3, Gender = "Hotdog" },
                  new Cat { CatId = 8, Name = "Eight", Species = "Cat", Age = 4, Gender = "Hamburger" },
                  new Cat { CatId = 9, Name = "Nine Wives", Species = "Cat", Age = 5, Gender = "Bacon" },
                  new Cat { CatId = 10, Name = "Ten the Cat", Species = "Otter", Age = 6, Gender = "Salad" }
              );

          builder.Entity<Dog>()
              .HasData(
                  new Dog { DogId = 1, Name = "Good", Species = "Dog", Age = 2, Gender = "Dude" },
                  new Dog { DogId = 2, Name = "Bad", Species = "Dog", Age = 12, Gender = "Dude" },
                  new Dog { DogId = 3, Name = "Happy", Species = "Not a Dog", Age = 3, Gender = "Dude" },
                  new Dog { DogId = 4, Name = "Sad", Species = "Dog", Age = 5, Gender = "Dude" },
                  new Dog { DogId = 5, Name = "Indifferent", Species = "Dog", Age = 6, Gender = "Dude" },
                  new Dog { DogId = 6, Name = "Frank", Species = "Dog", Age = 1, Gender = "Not Dude" },
                  new Dog { DogId = 7, Name = "Peter", Species = "Dog", Age = 1, Gender = "Not Dude" },
                  new Dog { DogId = 8, Name = "Paul", Species = "Dog", Age = 2, Gender = "Not Dude" },
                  new Dog { DogId = 9, Name = "Mary", Species = "Dog", Age = 5, Gender = "Not Dude" },
                  new Dog { DogId = 10, Name = "Quite Contrary", Species = "Otter", Age = 8, Gender = "Not Dude" }
              );
        }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }
    }
}