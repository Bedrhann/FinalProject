using FinalProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Persistance.Contexts.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var hasher = new PasswordHasher<AppUser>();
            builder.HasData(
                 new AppUser
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     Email = "admin@gmail.com",
                     NormalizedEmail = "ADMIN@GMAIL.COM",
                     FirstName = "System",
                     LastName = "Admin",
                     UserName = "Admınıstrator",
                     NormalizedUserName = "ADMINISTRATOR",
                     PasswordHash = hasher.HashPassword(null, "Password@123"),
                     EmailConfirmed = false
                 }
            );
        }

    }
}
