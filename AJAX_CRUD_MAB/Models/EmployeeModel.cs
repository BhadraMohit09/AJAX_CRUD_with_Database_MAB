using System.ComponentModel.DataAnnotations;

namespace AJAX_CRUD_MAB.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        [StringLength(50, ErrorMessage = "Position cannot be longer than 50 characters.")]
        public required string Position { get; set; }

        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100.")]
        public int Age { get; set; }

        [StringLength(200, ErrorMessage = "Department name cannot exceed 200 characters.")]
        public required string Department { get; set; }
    }
}
