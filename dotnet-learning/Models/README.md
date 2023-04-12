# Models
The classes in this folder are models that we will be encapsulating our data in and serving up from our API.

## Database Context
A DbContext instance represents a session with the database, and is used to query and save instances of our entities

Typically, we create a class that derives from `DbContext`
```cs
public class RestaurantReviewContext : DbContext
```
and contains `DbSet<TEntity>` properties for each _entity_ in the model. An entity is a type that has included in the Entity Framework model.
```cs
public DbSet<RestaurantReview> RestaurantReviews { get; set; } = null!;
```

By convention, each `<TEntity>` type (e.g. `RestaurantReview` in our example above) will map to a database table with the same name as the `DbSet` property that exposes the entity. You can also manually configure the table name by adding the `Table` tag to the underlying class
```cs
[Table("review")]
public class RestaurantReview
```

The constructor for our DbContext includes an `options` argument
```cs
public RestaurantReviewContext(DbContextOptions<RestaurantReviewContext> options) : base(options)
```
We use the options to specify what kind of database we will be using when registering the DbContext in our program. In our API, we are currently using an in-memory database (Nuget dependency: `Microsoft.EntityFrameworkCore.InMemory`) and so it is registered as:

```cs
builder.Services.AddDbContext<RestaurantReviewContext>(options => 
    options.UseInMemoryDatabase("RestaurantReviews"));
```

The DbContext comes with methods to interact with the database, e.g:
- `Add`
- `FindAsync`
- `FromSql`
- `SaveChanges`