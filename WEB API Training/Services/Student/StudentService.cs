using Microsoft.EntityFrameworkCore;
using WEB_API_Training.Data;
using WEB_API_Training.Models;

namespace WEB_API_Training.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _db;
        public StudentService(AppDbContext db) { _db = db; }

        //READ
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

        //CREATE
        public async Task CreateAsync(StudentInfoModel model)
        {
            try
            {
                var student = new StudentModel
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Cognome = model.Cognome,
                    Email = model.Email
                };

                _db.Students.Add(student);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Errore durante creazione", ex);
            }
        }

        //UPDATE
        public async Task UpdateAsync(Guid id, StudentInfoModel model)
        {
            var studentSearched = await _db.Students.FindAsync(id);
            if (studentSearched == null)
            {
                throw new KeyNotFoundException("Studente non trovato");
            }

            try
            {
                studentSearched.Nome = model.Nome;
                studentSearched.Cognome = model.Cognome;
                studentSearched.Email = model.Email;

                _db.Students.Update(studentSearched);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Errore durante la modifica", ex);
            }
        }

        //DELETE
        public async Task DeleteAsync(Guid id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null)
            {
                throw new KeyNotFoundException("Studente non trovato");
            }

            try
            {

                _db.Students.Remove(student);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Errore durante cancellazione", ex);
            }
        }
    }
}
