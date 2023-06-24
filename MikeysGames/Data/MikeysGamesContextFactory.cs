namespace MikeysGames.Data;

public class MikeysGamesContextFactory : IDesignTimeDbContextFactory<MikeysGamesContext>
{
    public MikeysGamesContext CreateDbContext(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var MikeysGamesConnection = builder.Configuration.GetConnectionString("MikeysGamesConnection")
            ?? throw new InvalidOperationException("Connection string 'MikeysGamesConnection' not found.");

        var optionsBuilder = new DbContextOptionsBuilder<MikeysGamesContext>();
        optionsBuilder.UseSqlite(MikeysGamesConnection);

        return new MikeysGamesContext(optionsBuilder.Options);
    }
}
