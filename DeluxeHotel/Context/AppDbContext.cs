using Microsoft.EntityFrameworkCore;

namespace DeluxeHotel.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {  
        }


    }
}
