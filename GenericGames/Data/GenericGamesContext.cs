namespace GenericGames.Data;

public class GenericGamesContext : IdentityDbContext
{
    public GenericGamesContext(DbContextOptions<GenericGamesContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
}
