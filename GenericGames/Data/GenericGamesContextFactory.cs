namespace GenericGames.Data;

public class GenericGamesContextFactory : IDesignTimeDbContextFactory<GenericGamesContext>
{
    public GenericGamesContext CreateDbContext(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var GenericGamesConnection = builder.Configuration.GetConnectionString("GenericGamesConnection")
            ?? throw new InvalidOperationException("Connection string 'GenericGamesConnection' not found.");

        var optionsBuilder = new DbContextOptionsBuilder<GenericGamesContext>();
        optionsBuilder.UseSqlite(GenericGamesConnection);

        return new GenericGamesContext(optionsBuilder.Options);
    }
}
