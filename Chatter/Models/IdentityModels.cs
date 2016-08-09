using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chatter.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser

    {
        //public string ProfilePicUrl { get; set; }
        //need to find how to use hashset for password
        //HashSet<string> PasswordHashset = new HashSet<string> { get; set; }
        //var Password = new HashSet<int>(Password.Users.Select(char => c.UserID));

        //Revisit for better variable type to store location
        //public string Description { get; set; }
        //public DateTime LastUpdate { get; set; }
        //public int FollowerAccount { get; set; }     

        //Navigation properties.... "virtual" means it can be overridden
        public virtual ICollection<ApplicationUser> Following { get; set; }
        public virtual ICollection<ApplicationUser> Followers { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public string DisplayName { get; set; }

        //--------------------------------------------------------------------------------------------------------------------


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ApplicationUser>()
        //        .HasMany(x => x.Followers).WithMany(x => x.Following)
        //        .Map(x => x.ToTable("Followers")
        //            .MapLeftKey("UserId")// we dont have a userID
        //            .MapRightKey("FollowerId"));
        //    base.OnModelCreating(modelBuilder);
        //}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Chatter.Models.Chat> Chats { get; set; }
    }
}