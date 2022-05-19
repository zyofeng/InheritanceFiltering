namespace InheritanceFiltering;

public class Query
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Entities.Animal> Animals(Entities.DbContext dbContext)
    => dbContext.Animals;
}
