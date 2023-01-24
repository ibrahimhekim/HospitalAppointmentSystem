
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities
{
    public class DatabaseContext : DbContext    //dbcontxt veri tabanı temsil
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }      //Users tabloyu temsil
    }
}
