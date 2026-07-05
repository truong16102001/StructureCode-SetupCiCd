using Microsoft.EntityFrameworkCore;
using Optimize_RepositoryBase.API.Domain;
using Optimize_RepositoryBase.API.Infrastructure.Configurations;

namespace Optimize_RepositoryBase.API.Infrastructure
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new StudentSubjectConfiguration());

            modelBuilder.Entity<StudentDetails>().HasData(
                new StudentDetails()
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    StudentId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Address = "Ha Noi",
                    AdditionalInformation = "Senior Solution Architecture"
                },
                new StudentDetails()
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    StudentId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Address = "Ha Noi",
                    AdditionalInformation = "Senior Solution Architecture"
                },
                new StudentDetails()
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    StudentId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Address = "Ha Noi",
                    AdditionalInformation = "Senior Solution Architecture"
                },
                new StudentDetails()
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    StudentId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Address = "Ha Noi",
                    AdditionalInformation = "Senior Solution Architecture"
                }
            );
        }


        public DbSet<Student> Students { get; set; }

        public DbSet<Evaluation> Evaluations { get; set; }

        public DbSet<StudentDetails> StudentDetails { get; set; }
    }
}
