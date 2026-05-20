using System.ComponentModel.DataAnnotations;

public class RegisterVM
{

    [Required(ErrorMessage = "Name is required")]
    [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
    public string Name { get; set; }


    [Required(ErrorMessage = "Surname is required")]
    [StringLength(30, ErrorMessage = "Surname cannot exceed 30 characters")]
    [MinLength(2, ErrorMessage = "Surname must be at least 2 characters long")]
    public string Surname { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }



    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    public string Password { get; set; }


    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    public string RepeatPassword { get; set; }
}
