using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ELibraryManagement.Models
{
    public class LoginView
    {
        [Required]
        public string? Name { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
