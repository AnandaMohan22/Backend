using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.dbcontext
{
    public class AppDbContext :DbContext

    {
       public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {
        }
           
        
        public DbSet<Employee> Quotes { get; set; }
        
    }
}
