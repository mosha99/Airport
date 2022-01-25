
#nullable disable

namespace Airport.DataBase
{
    public class AirplantContext : DbContext
    {
        public AirplantContext()
        {
        }

        public AirplantContext(DbContextOptions options)
            : base(options)
        {
        }


        public virtual DbSet<Pasenger> Pasengers { get; set; }
        public virtual DbSet<Airplans> Airplans { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<Flighpass> Flighpasses { get; set; }
        public virtual DbSet<FlightsInfo> FlightsInfo { get; set; }
        public virtual DbSet<AirPort> AirPorts { get; set; }




        protected DbSting seting
        {
            get
            {
                string path = @"DBS.json";
                DbSting seting;
                using (StreamReader writer = new StreamReader(path, true))
                {
                    var x = writer.ReadToEnd();
                    seting = JsonSerializer.Deserialize<DbSting>(x);

                }
                return seting;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer($"Data Source={seting.DataDase};Initial Catalog={seting.DataBaseName};User ID={seting.UserName};Password={seting.PassWord}");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flighpass>(entity =>
            {
                entity.HasOne(x => x.Pasenger).WithMany(y => y.Flights);
                entity.HasOne(x => x.Flight).WithMany(y => y.PasengerList);
            });

            modelBuilder.Entity<AirPort>(entity =>
            {
                entity.HasMany(x => x.InputFlights).WithOne(y => y.EndLocation);
                entity.HasMany(x => x.OutputFlights).WithOne(y => y.StartLocation);
            });



            base.OnModelCreating(modelBuilder);
        }

    }
}
