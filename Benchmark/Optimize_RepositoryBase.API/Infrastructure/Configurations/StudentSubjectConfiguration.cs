using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optimize_RepositoryBase.API.Domain;

namespace Optimize_RepositoryBase.API.Infrastructure.Configurations
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasKey(s => new {s.StudentId, s.SubjectId});

            // 1 StudentSubject chỉ thuộc về 1 Student, 1 Student có nhiều StudentSubject, liên kết với nhau bởi  StudentId
            builder.HasOne(ss => ss.Student).WithMany(s => s.StudentSubjects).HasForeignKey(ss => ss.StudentId);

            // 1 StudentSubject chỉ thuộc về 1 Subject, 1 Subject có nhiều StudentSubject, liên kết với nhau bởi  SubjectId
            builder.HasOne(ss => ss.Subject).WithMany(s => s.StudentSubjects).HasForeignKey(ss => ss.SubjectId);
        }
    }
}
