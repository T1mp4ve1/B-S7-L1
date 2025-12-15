using Microsoft.AspNetCore.Mvc;
using WEB_API_Training.Models;
using WEB_API_Training.Services.Student;

namespace WEB_API_Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _student;
        public StudentsController(IStudentService student) { _student = student; }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _student.GetAllAsync();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentInfoModel model)
        {
            var student = new StudentModel
            {
                Id = Guid.NewGuid(),
                Nome = model.Nome,
                Cognome = model.Cognome,
                Email = model.Email
            };
            await _student.CreateAsync(student);
            return Ok();
        }
    }
}
