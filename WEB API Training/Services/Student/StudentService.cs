using Microsoft.EntityFrameworkCore;
using WEB_API_Training.Data;
using WEB_API_Training.Models;

namespace WEB_API_Training.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _db;
        public StudentService(AppDbContext db) { _db = db; }

        public async Task<List<StudentModel>> GetAllAsync()
        {
            try
            {
                return await _db.Students.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Errore durante recupero dati", ex);
            }

        }

        public async Task CreateAsync(StudentModel student)
        {
            try
            {
                student.Id = Guid.NewGuid();
                _db.Students.Add(student);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Errore durante creazione", ex);
            }
        }
    }
}
