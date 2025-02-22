# Library Management System

This project is a simple library management system application that allows managing books and authors. It is built using ASP.NET Core MVC and supports basic CRUD (Create, Read, Update, Delete) operations.

## Project Structure

The project follows the Model-View-Controller (MVC) architecture. The main components are:

### Models
- **Book**: Represents book information (ID, Title, Author ID, Genre, Publish Date, ISBN, Copies Available).
- **Author**: Represents author information (ID, First Name, Last Name, Date of Birth).

### ViewModels
- **BookViewModel**: Used to display book details along with related author information.
- **AuthorViewModel**: Used to display author details along with their associated books.

### Controllers
- **BookController**: Manages listing books, displaying details, adding new books, updating, and deleting books.
- **AuthorController**: Manages listing authors, displaying details, adding new authors, updating, and deleting authors.

## Technologies Used
- **ASP.NET Core MVC**: The core framework for the web application.
- **C#**: The programming language used.
- **Razor Views**: Used for creating dynamic HTML pages.
- **Bootstrap**: Used for front-end styling.

## How to Run the Project

### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/LibraryManagementSystem.git
   ```
2. Navigate to the project directory:
   ```bash
   cd LibraryManagementSystem
   ```
3. Run the project:
   ```bash
   dotnet run
   ```
4. Open your browser and go to `https://localhost:5001` to view the application.

## Key Features
- **List Books**: View a list of all books.
- **Book Details**: View details of a specific book.
- **Add New Book**: Add a new book to the library.
- **Update Book**: Update details of an existing book.
- **Delete Book**: Remove a book from the library.
- **List Authors**: View a list of all authors.
- **Author Details**: View details of a specific author and their associated books.
- **Add New Author**: Add a new author to the system.
- **Update Author**: Update details of an existing author.
- **Delete Author**: Remove an author from the system.

## Views Structure

The project uses Razor Views for rendering the user interface. Below are the views associated with each controller:

### BookController Views
- **List.cshtml**: Displays a list of all books.
- **Details.cshtml**: Shows details of a specific book.
- **Create.cshtml**: Form for adding a new book.
- **Edit.cshtml**: Form for editing an existing book.
- **Delete.cshtml**: Confirmation page for deleting a book.

### AuthorController Views
- **List.cshtml**: Displays a list of all authors.
- **Details.cshtml**: Shows details of a specific author and their books.
- **Create.cshtml**: Form for adding a new author.
- **Edit.cshtml**: Form for editing an existing author.
- **Delete.cshtml**: Confirmation page for deleting an author.
  
