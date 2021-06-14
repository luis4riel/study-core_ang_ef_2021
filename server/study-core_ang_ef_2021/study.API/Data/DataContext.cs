using Microsoft.EntityFrameworkCore;
using study.API.Models;

namespace study.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Event> Events { get; set; }
    }
}