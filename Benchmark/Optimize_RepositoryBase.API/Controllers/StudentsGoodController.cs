using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Optimize_RepositoryBase.API.Applications.Implements;
using Optimize_RepositoryBase.API.Applications.Interfaces;
using Optimize_RepositoryBase.API.Domain;

namespace Optimize_RepositoryBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsGoodController : ControllerBase
    {
        private readonly IStudentServiceGood _studentServiceGood;

        public StudentsGoodController(IStudentServiceGood studentServiceGood)
        {
            _studentServiceGood = studentServiceGood;
        }

        [HttpGet("student-with-details-good")]
        public IActionResult StudentDetails()
        {
            var result = _studentServiceGood.GetStudentsDetail();

            return Ok(result);
        }

        [HttpGet("student-with-details-by-id-good")]
        public IActionResult StudentDetailsById(string id)
        {
            var result = _studentServiceGood.GetStudentsDetailById(id);

            if (result is null)
                return Ok(new List<Student>());

            return Ok(result);
        }

        [HttpGet("students-good")]
        public IActionResult Students()
        {
            var result = _studentServiceGood.GetStudents();

            return Ok(result);
        }

        [HttpGet("students-by-id-good")]
        public async Task<IActionResult> StudentsById(string id)
        {
            var result = await _studentServiceGood.FindByIdAsync(Guid.Parse(id));

            return Ok(result);
        }

        [HttpGet("students-by-condition-good")]
        public async Task<IActionResult> StudentsByCondition(string id)
        {
            var result = await _studentServiceGood.FindByConditionAsync(Guid.Parse(id));

            return Ok(result);
        }
    }
}
