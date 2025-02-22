using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Controllers;

public class BookController : Controller
{
    //Manuel entered book list

    public static List<Book> Books { get; } = new List<Book>()
    {
        new Book()
        {
            Id = 1, Title = "Dune", Genre = "Science Fiction", ISBN = "9786053754794",
            PublishDate = new DateTime(1965, 08, 01), CopiesAvailable = 24, AuthorId = 1
        },
        new Book()
        {
            Id = 2, Title = "I, Robot", Genre = "Science Fiction", ISBN = "9780553294385",
            PublishDate = new DateTime(1950, 12, 2), CopiesAvailable = 50, AuthorId = 2
        },
        new Book()
        {
            Id = 3, Title = "Crime and Punishment", Genre = "Literary Fiction", ISBN = "9780553211757",
            PublishDate = new DateTime(1866, 01, 01), CopiesAvailable = 35, AuthorId = 3
        },
        new Book()
        {
            Id = 4, Title = "Children of Dune", Genre = "Science Fiction", ISBN = "9780593548455",
            PublishDate = new DateTime(1976, 4, 1), CopiesAvailable = 42, AuthorId = 1
        }
    };

    private static List<BookViewModel> GetBooks()
    {
        return Books.Select(book => new BookViewModel
        {
            Id = book.Id,
            Title = book.Title,
            Genre = book.Genre,
            ISBN = book.ISBN,
            PublishDate = book.PublishDate,
            CopiesAvailable = book.CopiesAvailable,
            AuthorId = book.AuthorId,
            AuthorFullName = AuthorController.Authors.FirstOrDefault(a => a.Id == book.AuthorId)?.FullName
        }).ToList();
    }

    //Show list of books
    public IActionResult List()
    {
        return View(GetBooks());
    }

    //Show details of a specific book
    public IActionResult Details(int id)
    {
        var book = Books.FirstOrDefault(b => b.Id == id);
        if (book == null) return NotFound();

        var author = AuthorController.Authors.FirstOrDefault(a => a.Id == book.AuthorId);

        var viewModel = new BookViewModel()
        {
            Id = book.Id,
            Title = book.Title,
            Genre = book.Genre,
            PublishDate = book.PublishDate,
            CopiesAvailable = book.CopiesAvailable,
            ISBN = book.ISBN,
            AuthorId = book.AuthorId,
            AuthorFullName = author?.FullName ?? "Unknown Author",
            AuthorDateOfBirth = author?.DateOfBirth
        };
        return View(viewModel);
    }

    //Show form to add a new book
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Authors = new SelectList(AuthorController.Authors, "Id", "FullName");
        return View(new BookViewModel());
    }

    //Create new book
    [HttpPost]
    public IActionResult Create(BookViewModel model)
    {
        if (string.IsNullOrEmpty(model.Title) || model.AuthorId == 0)
        {
            ModelState.AddModelError("", "Title and Author are required");
            ViewBag.Authors = new SelectList(AuthorController.Authors, "Id", "FullName");
            return View(model);
        }

        var newBook = new Book()
        {
            Id = Books.Any() ? Books.Max(b => b.Id) + 1 : 1,
            Title = model.Title,
            Genre = model.Genre,
            ISBN = model.ISBN,
            PublishDate = model.PublishDate,
            CopiesAvailable = model.CopiesAvailable,
            AuthorId = model.AuthorId
        };

        Books.Add(newBook);
        return RedirectToAction(nameof(List));
    }

    //Show form for editing a book
    public IActionResult Edit(int id)
    {
        var book = Books.FirstOrDefault(b => b.Id == id);
        if (book == null) return NotFound();

        var viewModel = new BookViewModel()
        {
            Id = book.Id,
            Title = book.Title,
            Genre = book.Genre,
            ISBN = book.ISBN,
            PublishDate = book.PublishDate,
            CopiesAvailable = book.CopiesAvailable,
            AuthorId = book.AuthorId,
        };

        ViewBag.Authors = new SelectList(AuthorController.Authors, "Id", "FullName");
        return View(viewModel);
    }

    //Book editing
    [HttpPost]
    public IActionResult Edit(BookViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Authors = new SelectList(AuthorController.Authors, "Id", "FullName");
            return View(model);
        }

        var existingBook = Books.FirstOrDefault(b => b.Id == model.Id);
        if (existingBook == null) return NotFound();

        existingBook.Title = model.Title;
        existingBook.Genre = model.Genre;
        existingBook.PublishDate = model.PublishDate;
        existingBook.CopiesAvailable = model.CopiesAvailable;
        existingBook.AuthorId = model.AuthorId;
        existingBook.ISBN = model.ISBN;

        return RedirectToAction(nameof(List));
    }

    //Show a confirmation form for deleting a book
    public IActionResult Delete(int id)
    {
        var book = Books.FirstOrDefault(b => b.Id == id);
        if (book == null) return NotFound();

        var viewModel = new BookViewModel()
        {
            Id = book.Id,
            Title = book.Title,
            Genre = book.Genre,
            ISBN = book.ISBN,
            PublishDate = book.PublishDate,
            CopiesAvailable = book.CopiesAvailable,
            AuthorId = book.AuthorId,
            AuthorFullName = AuthorController.Authors.FirstOrDefault(a => a.Id == book.AuthorId)?.FullName
        };
        return View(viewModel);
    }

    //Deleting a book
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var book = Books.FirstOrDefault(b => b.Id == id);
        if (book == null) return NotFound();
        Books.Remove(book);
        return RedirectToAction(nameof(List));
    }
}