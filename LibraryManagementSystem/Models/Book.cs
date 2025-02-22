using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models;

public class Book
{
    public int Id { get; init; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public string Genre { get; set; }
    public DateTime PublishDate { get; set; }
    public string ISBN { get; set; }
    public int CopiesAvailable { get; set; }
}