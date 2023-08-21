using Internship2023_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Internship2023_backend.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
            : base(options){}
    

        public DbSet<User> Users { get; set; }
    }
}
