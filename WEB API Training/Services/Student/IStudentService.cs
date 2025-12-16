using WEB_API_Training.Models;

namespace WEB_API_Training.Services.Student
{
    public interface IStudentService
    {
        Task<List<StudentModel>> GetAllAsync();
        Task CreateAsync(StudentInfoModel student);
        Task UpdateAsync(Guid id, StudentInfoModel model);
        Task DeleteAsync(Guid id);
    }
}