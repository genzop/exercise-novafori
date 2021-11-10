using Microsoft.EntityFrameworkCore;

namespace PerfectChannel.WebApi.Models
{
    public class PerfectChannelContext : DbContext
    {
        public PerfectChannelContext(DbContextOptions<PerfectChannelContext> options) : base(options)
        {

        }

        public DbSet<Task> Task { get; set; }
    }
}
