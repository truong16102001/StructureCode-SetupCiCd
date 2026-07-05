using Optimize_RepositoryBase.API.Domain;

namespace Optimize_RepositoryBase.API.Applications.Interfaces
{
    public interface IStudentServiceGood
    {
        List<Student> GetStudentsDetail();

        List<Student> GetStudentsDetailById(string id); // test trong trường hợp Not Found

        List<Student> GetStudents();

        Task<Student> FindByIdAsync(Guid Id, CancellationToken cancellationToken = default);

        Task<Student> FindByConditionAsync(Guid Id, CancellationToken cancellationToken = default);
    }
}
