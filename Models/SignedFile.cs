using System.ComponentModel.DataAnnotations;

namespace DocxStorageApi.Models
{
    public class SignedFile
    {
        [Required]
        [FileExtensions(Extensions = ".docx")]
        public IFormFile File { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
