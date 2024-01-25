using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SnippersAPI.Models;

namespace SnippersAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Snippet> Snippets => Set<Snippet>();

        public DbSet<User> Users => Set<User>();
    }
}
