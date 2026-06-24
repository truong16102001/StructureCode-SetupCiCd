using Optimize_RepositoryBase.API.Abstractions;
using Optimize_RepositoryBase.API.Applications.Interfaces;
using Optimize_RepositoryBase.API.Domain;

namespace Optimize_RepositoryBase.API.Applications.Implements
{
    public class StudentServiceGood : IStudentServiceGood
    {

        private readonly IRepositoryBaseGood<Student, Guid> _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public async Task<Student> FindByConditionAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            return await _studentRepository.FindSingleAsync(
                x => x.Id.Equals(Id),
                cancellationToken);
        }

        public async Task<Student> FindByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            return await _studentRepository.FindByIdAsync(Id, cancellationToken);
        }

        public List<Student> GetStudents()
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentsDetail()
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentsDetailById()
        {
            throw new NotImplementedException();
        }
    }
}
