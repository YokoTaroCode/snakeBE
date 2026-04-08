namespace SnakeBE.Infrastructure.configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SnakeBE.Domain;

    public class UserConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> userBuilder)
        {
            userBuilder.HasKey(player => player.UserId);
            userBuilder.Property(player => player.Username).IsRequired();

            userBuilder.HasMany(player => player.Games)
                .WithOne(game => game.User)
                .HasForeignKey(game => game.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Games_Player_UserId");

            userBuilder.HasOne<IdentityUser>()
            .WithMany()
            .HasForeignKey(player => player.IdentityUserId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Player_IdentityUser")
            .IsRequired();
        }
    }
}
