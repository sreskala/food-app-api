using Microsoft.EntityFrameworkCore;
using food_tracker_api.Models;

namespace food_tracker_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }

        public DbSet<StoragePlace> StoragePlaces { get; set; }
    }
}