using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<InheritanceFiltering.Entities.DbContext>(options => options.UseInMemoryDatabase("TestSql"));

builder.Services.AddGraphQLServer()
    .RegisterDbContext<InheritanceFiltering.Entities.DbContext>()
            .AddQueryType<InheritanceFiltering.Query>()
            .AddType<InheritanceFiltering.Entities.Cat>()
            .AddType<InheritanceFiltering.Entities.Dog>()
            .AddType<InheritanceFiltering.Entities.Food>()
            .AddProjections()
            .AddSorting().AddFiltering();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<InheritanceFiltering.Entities.DbContext>();
    context.Database.EnsureCreated();
}
app.Run();
