using Microsoft.EntityFrameworkCore;

public class GradesDbContext : DbContext
{
    public GradesDbContext(DbContextOptions<GradesDbContext> options) : base(options) 
    { 
        
    }

    public DbSet<Grade> Grades { get; set; }
}
