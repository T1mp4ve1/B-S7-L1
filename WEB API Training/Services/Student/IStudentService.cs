using WEB_API_Training.Models;

namespace WEB_API_Training.Services.Student
{
    public interface IStudentService
    {
        Task<List<StudentModel>> GetAllAsync();
        Task CreateAsync(StudentModel student);
    }
}
