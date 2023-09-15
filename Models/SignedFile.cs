using System.ComponentModel.DataAnnotations;

namespace DocxStorageApi.Models
{
    public class SignedFile
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [FileExtensions(Extensions = "docx")]
		public string FileName { get; set; }
    }
}
