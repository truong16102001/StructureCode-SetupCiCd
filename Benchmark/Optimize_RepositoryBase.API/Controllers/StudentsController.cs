using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Optimize_RepositoryBase.API.Applications.Interfaces;
using Optimize_RepositoryBase.API.Domain;

namespace Optimize_RepositoryBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        [HttpGet("student-with-details")]
        public IActionResult StudentDetails()
        {
            var result = _studentService.GetStudentsDetail();

            return Ok(result);
        }

        [HttpGet("student-with-details-by-id")]
        public IActionResult StudentDetailsById(string id)
        {
            var result = _studentService.GetStudentsDetailById(id);

            if (result is null)
                return Ok(new List<Student>());

            return Ok(result);
        }

        [HttpGet("students")]
        public IActionResult Students()
        {
            var result = _studentService.GetStudents();

            return Ok(result);
        }

        [HttpGet("students-by-id")]
        public IActionResult StudentsById(string id)
        {
            var result = _studentService.FindById(Guid.Parse(id));

            return Ok(result);
        }

        [HttpGet("students-by-condition")]
        public IActionResult StudentsByCondition(string id)
        {
            var result = _studentService.FindByCondition(Guid.Parse(id));
            return Ok(result);
        }
    }
}
