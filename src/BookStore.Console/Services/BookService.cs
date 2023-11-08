using BookStore.Console.Models;

namespace BookStore.Console.Services;

public class BookService
{
    private List<Book> books = new();
    public BookService()
    {
        books.AddRange(new[]
            {
                new Book()
                {
                    Title = "Harry Potter, I : Harry Potter à l'école des sorciers",
                    Author = "J.K. Rowling",
                    NbPages = 320,
                    ISBN = "2070584623"
                },
                new Book
                {
                    Title = "Le Seigneur des Anneaux, Tome 1 : La Fraternité de l'Anneau",
                    Author = "J. R. R. Tolkien",
                    NbPages = 528,
                    ISBN = "2267027003"
                },
                new Book
                {
                    Title = "Le Démon du passé",
                    Author = "Mary Higgins Clark",
                    NbPages = 354,
                    ISBN = "B00MEAFHXO"
                }
            });
    }

    public void Add(Book book)
    {
        if (books.Any(b => b.ISBN == book.ISBN))
        {
            throw new InvalidOperationException("Il n'est pas possible d'ajouter deux livres avec le même ISBN");
        }

        books.Add(book);
    }

    public void Update(Book book)
    {
        if (books.All(b => b.ISBN != book.ISBN)) return;
        books.RemoveAll(b => b.ISBN == book.ISBN);
        books.Add(book);
    }

    public void Delete(Book book)
        => books.RemoveAll(b => b.ISBN == book.ISBN);

    public IEnumerable<Book> List()
        => books.AsEnumerable();
}
