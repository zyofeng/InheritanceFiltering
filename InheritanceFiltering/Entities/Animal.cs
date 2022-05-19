namespace InheritanceFiltering.Entities;

[InterfaceType]
public abstract class Animal
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    [UseFiltering()]
    [UseSorting]
    public virtual ICollection<AnimalFood> Food { get; internal set; } = new HashSet<AnimalFood>();
}
