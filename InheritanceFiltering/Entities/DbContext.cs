using Microsoft.EntityFrameworkCore;

namespace InheritanceFiltering.Entities;
public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Food> Food => Set<Food>();
    public DbSet<Animal> Animals => Set<Animal>();
    public DbSet<Cat> Cats => Set<Cat>();
    public DbSet<Dog> Dogs => Set<Dog>();
    public DbSet<AnimalFood> AnimalFood => Set<AnimalFood>();

    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var food = new Food[] {
            new () { Id = 1, Name = "Steak" },
            new () { Id = 2, Name = "Chicken" },
            new () { Id = 3, Name = "Fish" },
            new () { Id = 4, Name = "Carrot" },
            new () { Id = 5, Name = "Lettuce" },
        };
        var animals = new Animal[] {
            new Cat { Id = 1, Name = "Luna" },
            new Cat { Id = 2, Name = "Oliver" },
            new Cat { Id = 3, Name = "Charlie" },
            new Dog { Id = 4, Name = "Milo" },
            new Dog { Id = 5, Name = "Max" },
            new Dog { Id = 6, Name = "Jasper" },
        };
        modelBuilder.Entity<Food>().HasData(food);

        modelBuilder.Entity<Cat>().HasData(animals[0..3]);
        modelBuilder.Entity<Dog>().HasData(animals[3..]);

        modelBuilder.Entity<AnimalFood>().HasData(new AnimalFood { Id = 1, AnimalId = 1, FoodId = 1 });
        modelBuilder.Entity<AnimalFood>().HasData(new AnimalFood { Id = 2, AnimalId = 1, FoodId = 2 });
        modelBuilder.Entity<AnimalFood>().HasData(new AnimalFood { Id = 3, AnimalId = 2, FoodId = 1 });
        modelBuilder.Entity<AnimalFood>().HasData(new AnimalFood { Id = 4, AnimalId = 2, FoodId = 1 });
        modelBuilder.Entity<AnimalFood>().HasData(new AnimalFood { Id = 5, AnimalId = 3, FoodId = 2 });
        modelBuilder.Entity<AnimalFood>().HasData(new AnimalFood { Id = 6, AnimalId = 3, FoodId = 4 });
        modelBuilder.Entity<AnimalFood>().HasData(new AnimalFood { Id = 7, AnimalId = 3, FoodId = 4 });
        modelBuilder.Entity<AnimalFood>().HasData(new AnimalFood { Id = 8, AnimalId = 4, FoodId = 3 });
        modelBuilder.Entity<AnimalFood>().HasData(new AnimalFood { Id = 9, AnimalId = 4, FoodId = 2 });
        modelBuilder.Entity<AnimalFood>().HasData(new AnimalFood { Id = 10, AnimalId = 5, FoodId = 3 });
        modelBuilder.Entity<AnimalFood>().HasData(new AnimalFood { Id = 11, AnimalId = 5, FoodId = 2 });
        modelBuilder.Entity<AnimalFood>().HasData(new AnimalFood { Id = 12, AnimalId = 6, FoodId = 3 });
        modelBuilder.Entity<AnimalFood>().HasData(new AnimalFood { Id = 13, AnimalId = 6, FoodId = 4 });
    }
}
