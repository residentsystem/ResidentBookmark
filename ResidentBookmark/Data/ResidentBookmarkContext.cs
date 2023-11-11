namespace ResidentBookmark.Data
{
    public partial class ResidentBookmarkContext : DbContext
    {
        private IConfiguration _configuration;
        
        private IDatabaseService _database;

        public ResidentBookmarkContext(IConfiguration configuration, IDatabaseService database)
        {
            _configuration = configuration;
            _database = database;
        }

        // The context has two DbSet properties. The DbSet classes maps to a table in the database.
        public virtual DbSet<Website> Websites { get; set; }

        public virtual DbSet<Label> Labels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            // Bind the content of default configuration file "bookmarksettings.json" to an instance of DatabaseSettings. 
            //DatabaseEnvironment connectionstring = _configuration.GetSection("ConnectionString").Get<DatabaseEnvironment>();

            optionsBuilder.UseMySql(_database.GetConnectionString(), new MySqlServerVersion(new Version(8, 0, 19)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Label>(entity =>
            {
                entity.HasKey(e => e.LabelId).HasName("PRIMARY");

                entity.ToTable("labels");

                entity.Property(e => e.Description).HasMaxLength(60);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Website>(entity =>
            {
                entity.HasKey(e => e.WebsiteId).HasName("PRIMARY");

                entity.ToTable("websites");

                entity.HasIndex(e => e.LabelId, "Website_LabelId");

                entity.Property(e => e.Date).HasMaxLength(6);
                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Note).HasMaxLength(60);

                entity.HasOne(d => d.Label).WithMany(p => p.Websites)
                    .HasForeignKey(d => d.LabelId)
                    .HasConstraintName("FK_Websites_Labels_LabelId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}