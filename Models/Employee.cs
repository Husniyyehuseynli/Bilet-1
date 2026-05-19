using System.ComponentModel.DataAnnotations;

namespace Bilet_1.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<Member>? Members { get; set; }
    }
}
