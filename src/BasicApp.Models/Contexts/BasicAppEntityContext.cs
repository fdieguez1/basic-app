using System.Data.Entity;

namespace BasicApp.Models.Contexts
{
    public class BasicAppEntityContext : DbContext
    {
        public DbSet<News> News { get; set; }
    }
}
