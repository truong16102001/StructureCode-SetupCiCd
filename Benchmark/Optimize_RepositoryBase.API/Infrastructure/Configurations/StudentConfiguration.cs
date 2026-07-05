using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optimize_RepositoryBase.API.Domain;

namespace Optimize_RepositoryBase.API.Infrastructure.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private List<Student> InitData()
        {
            var students = new List<Student>();

            for (int i = 1; i <= 1000; i++)
            {
                students.Add(new Student
                {
                    Id = Guid.Parse($"00000000-0000-0000-0000-{i.ToString("D12")}"),
                    Name = $"Student {i}",
                    Age = 18 + (i % 40),
                    IsRegularStudent = i % 2 == 0
                });
            }

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
