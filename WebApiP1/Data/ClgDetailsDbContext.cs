using Microsoft.EntityFrameworkCore;
using WebApiP1.Models.Domain;

namespace WebApiP1.Data
{
    /*Dbcontext class is a class that represents a session with a DB and provides set of 
    set of APIs for performing Database operations.  
    used to connect with db. contoller -> DbContextclass -> Database */
    public class ClgDetailsDbContext : DbContext
    {
        public ClgDetailsDbContext(DbContextOptions dbContextOptions): base(dbContextOptions) 
        {

            
        }
        public DbSet<Branch> Branches { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }
    }

}
