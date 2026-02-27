namespace SnakeBE.Infrastructure.configurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SnakeBE.Domain;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userBuilder)
        {
            userBuilder.HasKey(user => user.UserId);
            userBuilder.Property(user => user.Username).IsRequired();
            userBuilder.Property(user => user.Password).IsRequired();
            userBuilder.Property(game => game.SubDate).IsRequired();

            userBuilder.HasMany(user => user.Games) // un utente può avere diversi giochi associati
                .WithOne(game => game.User) // // ciascun gioco appartiene ad un solo utente
                .HasForeignKey(game => game.UserId) // ciascun gioco è referenziato ad un utente 
                .OnDelete(DeleteBehavior.Cascade); // se un utente viene eliminato, i suoi giochi vengono eliminati a cascata

            // gioco.
            // [gioco_associato].
            // [ha_un_utente].
            // [gioco_associato_ad_utente].
            // [elimina_giochi]
        }
    }
}
