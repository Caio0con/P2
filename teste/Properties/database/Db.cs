using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NavarroProva.Properties.Model;

namespace teste.Properties.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString, options =>
                    options.EnableRetryOnFailure());
            }
        }

        public DbSet<usuario> Usuarios { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}