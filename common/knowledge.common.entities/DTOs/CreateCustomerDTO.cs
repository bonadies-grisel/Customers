using System.ComponentModel.DataAnnotations;

namespace knowledge.common.entities.DTOs
{
    public class CreateCustomerDTO
    {
        [Required(ErrorMessage = "Required field.")]
        [StringLength(100, ErrorMessage = "Value cannot be more than 100 characters.")]
        public string Names { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [StringLength(100, ErrorMessage = "Value cannot be more than 100 characters.")]
        public string Surnames { get; set; }

        public DateTime BirthDate { get; set; }
        
        [Required(ErrorMessage = "Required field.")]
        [StringLength(14, ErrorMessage = "Value cannot be more than 14 characters.")]
        [RegularExpression(@"^\d{2}-\d{7,9}-\d$", ErrorMessage = "Invalid CUIT format. Value must have a valid format (XX-XXXXXXXXX-X).")]
        public string CUIT { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [StringLength(100, ErrorMessage = "Value cannot be more than 100 characters.")]
        public string CellphoneNumber { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
        [StringLength(320, ErrorMessage = "Value cannot be more than 320 characters.")]
        public string Email { get; set; }

    }
}
