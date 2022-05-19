namespace InheritanceFiltering.Entities
{
    public class AnimalFood
    {
        public int Id { get; init; }
        public int AnimalId { get; init; }
        public Animal Animal { get; init; } = null!;
        public int FoodId { get; init; }
        public Food Food { get; init; } = null!;
    }
}
