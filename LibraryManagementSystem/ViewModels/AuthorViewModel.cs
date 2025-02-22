using System.ComponentModel.DataAnnotations;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.ViewModels;

public class AuthorViewModel
{
    //Author Details
    public int Id { get; init; }

    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; init; }

    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; init; }

    public string FullName => $"{FirstName} {LastName}";

    [Required(ErrorMessage = "Date of Birth is required")]
    public DateTime? DateOfBirth { get; init; }

    // Books for that Author (Details)
    public List<BookViewModel> Books { get; init; } = new List<BookViewModel>();
}