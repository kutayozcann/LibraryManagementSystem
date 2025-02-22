using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers;

public class AuthorController : Controller
{
    // Manuel created Author List

    public static List<Author> Authors { get; } = new List<Author>()
    {
        new Author() { Id = 1, FirstName = "Frank", LastName = "Herbert", DateOfBirth = new DateTime(1920, 10, 8) },
        new Author() { Id = 2, FirstName = "Isaac", LastName = "Asimov", DateOfBirth = new DateTime(1920, 1, 2) },
        new Author() { Id = 3, FirstName = "Fyodor", LastName = "Dostoevsky", DateOfBirth = new DateTime(1821, 11, 11) }
    };

    //Show list of authors
    public IActionResult List()
    {
        var authorViewModel = Authors.Select(a => new AuthorViewModel
        {
            Id = a.Id,
            FirstName = a.FirstName,
            LastName = a.LastName,
            DateOfBirth = a.DateOfBirth
        }).ToList();

        return View(authorViewModel);
    }

    //Show details of an author
    public IActionResult Details(int id)
    {
        var author = Authors.FirstOrDefault(a => a.Id == id);
        if (author == null) return NotFound();

        var books = BookController.Books.Where(b => b.AuthorId == author.Id).Select(b => new BookViewModel
        {
            Id = b.Id,
            Title = b.Title,
            AuthorId = b.AuthorId,
            Genre = b.Genre,
            PublishDate = b.PublishDate,
            CopiesAvailable = b.CopiesAvailable,
            ISBN = b.ISBN
        }).ToList();

        var viewModel = new AuthorViewModel
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            DateOfBirth = author.DateOfBirth,
            Books = books
        };


        return View(viewModel);
    }

    //Show form for adding new authors
    public IActionResult Create()
    {
        return View();
    }

    //Adding new authors
    [HttpPost]
    public IActionResult Create(AuthorViewModel model)
    {
        if (ModelState.IsValid)
        {
            var newAuthor = new Author()
            {
                Id = Authors.Max(a => a.Id) + 1,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
            };

            Authors.Add(newAuthor);
            return RedirectToAction(nameof(List));
        }

        return View(model);
    }

    //Show form for editing an author
    public IActionResult Edit(int id)
    {
        var author = Authors.FirstOrDefault(a => a.Id == id);
        if (author == null) return NotFound();

        var viewModel = new AuthorViewModel()
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            DateOfBirth = author.DateOfBirth,
        };

        return View(viewModel);
    }

    //Editing an author
    [HttpPost]
    public IActionResult Edit(AuthorViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var existingAuthor = Authors.FirstOrDefault(a => a.Id == model.Id);
        if (existingAuthor == null) return NotFound();

        existingAuthor.FirstName = model.FirstName;
        existingAuthor.LastName = model.LastName;
        existingAuthor.DateOfBirth = model.DateOfBirth;

        return RedirectToAction(nameof(List));
    }

    //Show confirmation page for deleting an author
    public IActionResult Delete(int id)
    {
        var author = Authors.FirstOrDefault(a => a.Id == id);
        if (author == null) return NotFound();

        return View(new AuthorViewModel
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            DateOfBirth = author.DateOfBirth,
        });
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var author = Authors.FirstOrDefault(a => a.Id == id);
        if (author != null)
        {
            Authors.Remove(author);
        }

        return RedirectToAction(nameof(List));
    }
}