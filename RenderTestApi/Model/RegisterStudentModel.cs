using System.ComponentModel.DataAnnotations;

namespace RenderTestApi.Model
{
    public class RegisterStudentModel
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required]
        
        public int Age { get; set; }  
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
    }
}
