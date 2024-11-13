using Microsoft.EntityFrameworkCore;
using APIDemoB.Models;

namespace APIDemoB.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UP3IQU6\\ALEXANDER; Database=APIDemoB; Integrated Security=True;Trust Server Certificate=True ");
        }
        public DbSet<APIDemoB.Models.Student> Student { get; set; } = default!;
    }
}
