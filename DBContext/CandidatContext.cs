using Microsoft.EntityFrameworkCore;
using testi.Models;

namespace testi.DBContext
{
    public class CandidatContext : DbContext
    {

        public CandidatContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Candidat> Candidat { get; set; }
    }
}
