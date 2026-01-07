namespace B_Infrastructure.configurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using D_Domain;

    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> gameBuilder)
        {
            gameBuilder.HasOne(game => game.User)
                .WithMany(user => user.Games)
                .HasForeignKey(game => game.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            gameBuilder.Property(game => game.Time).IsRequired();
            gameBuilder.Property(game => game.Points).IsRequired();
            gameBuilder.Property(game => game).IsRequired();
        }
    }
}
