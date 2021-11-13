namespace DrivingJournal.Server.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }

}
