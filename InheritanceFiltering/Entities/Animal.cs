namespace InheritanceFiltering.Entities;

[InterfaceType]
public abstract class Animal
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Food> Food { get; internal set; } = new HashSet<Food>();
}
