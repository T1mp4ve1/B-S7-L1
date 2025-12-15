using System.ComponentModel.DataAnnotations;

namespace WEB_API_Training.Models
{
    public class StudentInfoModel
    {
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cognome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
