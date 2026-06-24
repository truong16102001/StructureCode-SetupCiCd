using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optimize_RepositoryBase.API.Domain;

namespace Optimize_RepositoryBase.API.Infrastructure.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private List<Student> InitData()
        {
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Id = Guid.Parse("3cdd6589-2cb2-4794-a01f-f9c0c602d048"),
                    Name = "John Doe1",
                    Age = 10
                },
                new Student()
                {
                    Id = Guid.Parse("24051c09-df63-4f5f-8a9e-7c7cd9bdca2e"),
                    Name = "John Doe2",
                    Age = 20
                },
                new Student()
                {
                    Id = Guid.Parse("d4d06f82-f71c-49e3-9aaf-634ae7afc56b"),
                    Name = "John Doe3",
                    Age = 30
                },
                new Student()
                {
                    Id = Guid.Parse("5664f3e6-7098-4ea6-b4ee-27756654a6a3"),
                    Name = "John Doe4",
                    Age = 40
                }
            };
            return students;
        }

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.Property(s => s.Age)
                   .IsRequired(false);

            builder.Property(s => s.IsRegularStudent)
                   .HasDefaultValue(true);

            builder.HasData(InitData());

            builder.HasMany(e => e.Evaluations)
                   .WithOne(s => s.Student)
                   .HasForeignKey(s => s.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
