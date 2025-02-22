using System.ComponentModel.DataAnnotations;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.ViewModels;

public class BookViewModel
{
    //Book Details
    public int Id { get; init; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; init; }

    [Required(ErrorMessage = "Genre is required")]
    public string Genre { get; init; }

    [Required(ErrorMessage = "Publish Date is required")]
    public DateTime PublishDate { get; init; }

    [Required(ErrorMessage = "ISBN is required")]
    public string ISBN { get; init; }

    [Required(ErrorMessage = "Copies Available is required")]
    public int CopiesAvailable { get; init; }

    //Author Details
    [Required(ErrorMessage = "Author is required")]
    public int AuthorId { get; init; }

    public string? AuthorFullName { get; init; } // Full name of author (List and Details)
    public DateTime? AuthorDateOfBirth { get; init; } // (Details)

    // dropdown for author selection (Create and Edit)
    public List<SelectListItem> Authors { get; init; } = new List<SelectListItem>();
}