using Optimize_RepositoryBase.API.Abstractions;
using Optimize_RepositoryBase.API.Applications.Interfaces;
using Optimize_RepositoryBase.API.Domain;

namespace Optimize_RepositoryBase.API.Applications.Implements
{
    public class StudentService : IStudentService
    {
        private readonly IRepositoryBase<Student, Guid> _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(
            IRepositoryBase<Student, Guid> studentRepository,
            IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public Student FindByCondition(Guid Id)
        {
            return _studentRepository.FindSingle(x => x.Id.Equals(Id));
        }

        public Student FindById(Guid Id)
        {
            return _studentRepository.FindById(Id);
        }

        // Check Case: AsNoTracking(); With No Include()
        public List<Student> GetStudents()
        {
            return _studentRepository
                .FindAll()
                .OrderBy(x => x.Name)
                .ToList();
        }

        // Check Case: AsNoTracking(); With Include() ==> splitQuery() 
        /// <summary>
        /// Get All student details and evaluation
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudentsDetail()
        {
            return _studentRepository
                .FindAll(x => x.StudentDetails, x => x.Evaluations)
                .OrderBy(x => x.Name)
                .ToList();
        }

        // Check Case: AsNoTracking(); With Include()==> splitQuery() 
        /// <summary>
        /// this case not found
        /// join before where
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudentsDetailById(string id)
        {
            return _studentRepository
                .FindAll(x => x.StudentDetails, x => x.Evaluations)
                .Where(x => x.Id.Equals(Guid.Parse(id)))
                .OrderBy(x => x.Name)
                .ToList();
        }
    }
}
