using AJAX_CRUD_MAB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AJAX_CRUD_MAB.Controllers
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILogger<ApplicationDbContext> _logger;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILogger<ApplicationDbContext> logger)
            : base(options)
        {
            _logger = logger;
        }

        //DbSet for Employee Database
        public DbSet<EmployeeModel> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Additional configurations if required!!
            modelBuilder.Entity<EmployeeModel>().ToTable("Employee");

            _logger.LogInformation("OnModelCreating was called for ApplicationDbContext.");
        }
    }
}
