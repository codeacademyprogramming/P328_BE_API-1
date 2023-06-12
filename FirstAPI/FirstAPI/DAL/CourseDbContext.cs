using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.DAL
{
    public class CourseDbContext:DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options):base(options) { }

        public DbSet<Group> Groups { get; set; }
    }
}
