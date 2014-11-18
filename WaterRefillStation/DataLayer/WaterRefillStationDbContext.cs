using System.Data.Entity;
using WaterRefillStation.Model;

namespace WaterRefillStation.DataLayer
{
    public class WaterRefillStationDbContext : DbContext
    {
        private static WaterRefillStationDbContext _dbContext;
        public static WaterRefillStationDbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new WaterRefillStationDbContext();
                }
                return _dbContext;
            }
        }

        private WaterRefillStationDbContext() : base("WaterRefillStationDB") 
        { 
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
