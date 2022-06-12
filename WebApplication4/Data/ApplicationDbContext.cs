using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication4.Models.UserModel>? UserModel { get; set; }
        public DbSet<WebApplication4.Models.CompanyModel>? CompanyModel { get; set; }
        public DbSet<WebApplication4.Models.RequestModel>? RequestModel { get; set; }
    }
}