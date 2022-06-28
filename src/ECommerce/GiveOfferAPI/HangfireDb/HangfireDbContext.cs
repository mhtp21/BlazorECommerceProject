using Microsoft.EntityFrameworkCore;

namespace GiveOfferAPI.HangfireDb
{
    public class HangfireDbContext : DbContext
    {
        public HangfireDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
