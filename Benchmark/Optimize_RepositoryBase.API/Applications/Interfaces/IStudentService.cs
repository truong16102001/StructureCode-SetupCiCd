using Optimize_RepositoryBase.API.Domain;

namespace Optimize_RepositoryBase.API.Applications.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetStudentsDetail();

        List<Student> GetStudentsDetailById(string id); // test trong trường hợp Not Found

        List<Student> GetStudents();

        Student FindById(Guid Id);

        Student FindByCondition(Guid Id);
    }
}
