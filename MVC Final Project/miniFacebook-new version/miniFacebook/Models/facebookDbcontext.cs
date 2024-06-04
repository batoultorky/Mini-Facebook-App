using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using miniFacebook.view_Models;

namespace miniFacebook.Models
{
    public class facebookDbcontext:IdentityDbContext<Applicationuser>
    {
        public virtual DbSet<Applicationuser> users {  get; set; }
        public virtual DbSet<Post> posts { get; set; }
        public facebookDbcontext(DbContextOptions option):base(option) 
        {

        }
        public DbSet<miniFacebook.view_Models.RegisterationModel> RegisterationModel { get; set; } = default!;
        public DbSet<miniFacebook.view_Models.LoginModel> LoginModel { get; set; } = default!;
        public DbSet<miniFacebook.view_Models.changePasswordModel> changePasswordModel { get; set; } = default!;
    }
}
