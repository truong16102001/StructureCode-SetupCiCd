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
                    Id = Guid.NewGuid(),
                    StudentId = Guid.Parse("3cdd6589-2cb2-4794-a01f-f9c0c602d048"),
                    Address = "Ha Noi",
                    AdditionalInformation = "Senior Solution Architecture"
                },
                new StudentDetails()
                {
                    Id = Guid.NewGuid(),
                    StudentId = Guid.Parse("24051c09-df63-4f5f-8a9e-7c7cd9bdca2e"),
                    Address = "Ha Noi",
                    AdditionalInformation = "Senior Solution Architecture"
                },
                new StudentDetails()
                {
                    Id = Guid.NewGuid(),
                    StudentId = Guid.Parse("d4d06f82-f71c-49e3-9aaf-634ae7afc56b"),
                    Address = "Ha Noi",
                    AdditionalInformation = "Senior Solution Architecture"
                },
                new StudentDetails()
                {
                    Id = Guid.NewGuid(),
                    StudentId = Guid.Parse("5664f3e6-7098-4ea6-b4ee-27756654a6a3"),
                    Address = "Ha Noi",
                    AdditionalInformation = "Senior Solution Architecture"
                }
            );
        }

    }
}
