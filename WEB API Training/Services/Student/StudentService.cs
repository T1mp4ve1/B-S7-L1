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
            return await _db.Students.AsNoTracking().ToListAsync();
        }

        public async Task CreateAsync(StudentModel student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
        }
    }
}
