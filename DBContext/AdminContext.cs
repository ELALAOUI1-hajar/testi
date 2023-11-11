using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testi.Models;  
namespace testi.DBContext
{
    public class AdminContext : IdentityDbContext<Admin>
    {
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {
        }
    }
}
