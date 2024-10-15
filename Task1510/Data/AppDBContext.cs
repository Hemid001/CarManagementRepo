using Microsoft.EntityFrameworkCore;
using Task1510.Data.Entity;

namespace Task1510.Data
{
    public class AppDBContext :DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
                
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<SpecialModel> SpecialModels { get; set; }
    }
}
