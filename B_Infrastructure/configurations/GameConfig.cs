namespace SnakeBE.Infrastructure.configurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SnakeBE.Domain;

    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> gameBuilder)
        {
            gameBuilder.HasOne(game => game.User) // è associato ad una specifica istanza
                .WithMany(user => user.Games) // one-to-many: un utente ha tanti giochi 
                .HasForeignKey(game => game.UserId) // l'utente deve già esistere ! 
                .OnDelete(DeleteBehavior.Restrict);

            // gioco.[utente_associato].
            // [utente_ha_tanti_giochi].
            // [utente_associato].
            // [cancella_solo_gioco]

            gameBuilder.HasKey(game => game.GameId);
            gameBuilder.Property(game => game.Time).IsRequired();
            gameBuilder.Property(game => game.Points).IsRequired();
        }
    }
}
