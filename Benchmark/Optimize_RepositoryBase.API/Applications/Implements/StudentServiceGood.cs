using Optimize_RepositoryBase.API.Abstractions;
using Optimize_RepositoryBase.API.Applications.Interfaces;
using Optimize_RepositoryBase.API.Domain;

namespace Optimize_RepositoryBase.API.Applications.Implements
{
    public class StudentServiceGood : IStudentServiceGood
    {
        private readonly IRepositoryBaseGood<Student, Guid> _studentRepositoryGood;
        private readonly IUnitOfWork _unitOfWork;

        public StudentServiceGood(
            IRepositoryBaseGood<Student, Guid> studentRepositoryGood,
            IUnitOfWork unitOfWork)
        {
            _studentRepositoryGood = studentRepositoryGood;
            _unitOfWork = unitOfWork;
        }

        public async Task<Student> FindByConditionAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            return await _studentRepositoryGood.FindSingleAsync(
                x => x.Id.Equals(Id),
                cancellationToken);
        }

        public async Task<Student> FindByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            return await _studentRepositoryGood.FindByIdAsync(Id, cancellationToken);
        }

        /// <summary>
        /// check case: AsNoTracking(); With No Include()
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Student> GetStudents()
        {
            return _studentRepositoryGood.FindAll().OrderBy(x => x.Name).ToList();
        }

        /// <summary>
        /// check case: AsNoTracking(); With Include()
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Student> GetStudentsDetail()
        {
            return _studentRepositoryGood.FindAll(x => x.StudentDetails, x=> x.Evaluations).OrderBy(x => x.Name).ToList();
        }

        /// <summary>
        /// this case not found
        /// where before, if found do where syntax
        /// check case: AsNoTracking(); With Include()
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Student> GetStudentsDetailById(string id)
        {
            return _studentRepositoryGood.FindAll(x => x.StudentDetails, x => x.Evaluations)
                .Where(x => x.Id.Equals(Guid.Parse(id)))
                .OrderBy(x => x.Name)
                .ToList();
        }
    }
}
