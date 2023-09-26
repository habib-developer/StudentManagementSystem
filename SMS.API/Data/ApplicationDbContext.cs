using Microsoft.EntityFrameworkCore;
using SMS.API.DomainModels;

namespace SMS.API.Data
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            :base(dbContextOptions)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
