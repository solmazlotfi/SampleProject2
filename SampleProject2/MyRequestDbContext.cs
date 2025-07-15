using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.RegularExpressions;

namespace SampleProject2
{
    public class MyRequestDbContext : DbContext
    {

        public DbSet<MyRequest> MyRequests { get; set; }
        public MyRequestDbContext(DbContextOptions<MyRequestDbContext> options)
        : base(options) { }
    }

}