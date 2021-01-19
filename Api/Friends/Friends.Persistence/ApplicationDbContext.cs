using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Friends.Persistence.Users;

namespace Friends.Persistence
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        #region Fields
        private readonly string? _connectionString;

        #endregion

        #region Ctor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Properties
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Mappings
            UserMapper.Map(modelBuilder);
        }

        #endregion
    }
}
