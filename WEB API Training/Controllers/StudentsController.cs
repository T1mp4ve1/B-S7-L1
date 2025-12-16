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
            try
            {
                var students = await _student.GetAllAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore durante recupero dati (controller): {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
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
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore durante creazione (controller): {ex.Message}");
            }
        }
    }
}
