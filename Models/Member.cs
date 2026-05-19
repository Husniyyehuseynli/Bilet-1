using System.ComponentModel.DataAnnotations;

namespace Bilet_1.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        public string? ImageUrl { get; set; }

   
        public int EmployeeId { get; set; }

        public Employee? Employee { get; set; }
    }
}