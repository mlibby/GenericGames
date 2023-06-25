namespace MikeysGames.Data;

public class MikeysGamesContext : IdentityDbContext
{
    public MikeysGamesContext(DbContextOptions<MikeysGamesContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
}
