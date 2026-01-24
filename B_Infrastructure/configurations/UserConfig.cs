namespace B_Infrastructure.configurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using D_Domain;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userBuilder)
        {
            userBuilder.HasKey(user => user.UserId);
            userBuilder.Property(user => user.Username).IsRequired();
            userBuilder.Property(user => user.Password).IsRequired();
            userBuilder.Property(game => game.SubDate).IsRequired();
        }
    }
}
