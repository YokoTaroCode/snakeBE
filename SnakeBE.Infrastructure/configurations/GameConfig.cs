namespace SnakeBE.Infrastructure.configurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SnakeBE.Domain;

    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> gameBuilder)
        {
            gameBuilder.HasOne(game => game.User)
                .WithMany(user => user.Games)
                .HasForeignKey(game => game.UserId)
                .OnDelete(DeleteBehavior.Restrict) 
                .HasConstraintName("FK_Games_Player_UserId");

            gameBuilder.HasKey(game => game.GameId);
            gameBuilder.Property(game => game.Time).IsRequired();
            gameBuilder.Property(game => game.Points).IsRequired();
        }
    }
}
