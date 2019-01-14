using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrimePaper.Database.Entities;

namespace PrimePaper.Database.Contexts
{
    public class SISContext : IdentityDbContext
        <UserEntity, 
         RoleEntity, 
         int, 
         IdentityUserClaim<int>, 
         UserRoleEntity, 
         IdentityUserLogin<int>, 
         IdentityRoleClaim<int>, 
         IdentityUserToken<int>>
    {
        public SISContext(DbContextOptions<SISContext> options) : base(options) { }

        public DbSet<ProductEntity> ProductTableAccess { get; set; }
        public DbSet<CartEntity> CartTableAccess { get; set; }
        public DbSet<UserEntity> UserTableAccess { get; set; }
        public DbSet<ContactEntity> ContactTableAccess { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRoleEntity>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
