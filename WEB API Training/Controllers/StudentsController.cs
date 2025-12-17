using Microsoft.AspNetCore.Authorization;
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

        //READ
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
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

        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create(StudentInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _student.CreateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore durante creazione (controller): {ex.Message}");
            }
        }

        //UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, StudentInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _student.UpdateAsync(id, model);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore durante update (controller): {ex.Message}");
            }
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _student.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore durante cancellazione (controller): {ex.Message}");
            }
        }
    }
}
