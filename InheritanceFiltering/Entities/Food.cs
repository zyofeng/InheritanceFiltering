namespace InheritanceFiltering.Entities
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<AnimalFood> Animals { get; internal set; } = new HashSet<AnimalFood>();
    }
}
