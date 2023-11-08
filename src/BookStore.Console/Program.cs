using BookStore.Console.Models;
using BookStore.Console.Services;

var service = new BookService();

string userData = "";

while (!userData.Equals("q", StringComparison.OrdinalIgnoreCase))
{
    Console.Clear();
    PrintMenu();
    userData = Console.ReadLine() ?? "";

    if (int.TryParse(userData, out int choice) && choice is > 0 and <= 4)
    {
        switch (choice)
        {
            case 2: AddBook(); break;
            case 3: UpdateBook(); break;
            case 4: DeleteBook(); break;
            default:
                PrintList();
                break;
        }
    }
}

void UpdateBook()
{
    Console.Clear();
    var isbn = SaisieString("Veuillez saisir l'ISBN du livre à éditer");
    var book = service.List().FirstOrDefault(b => b.ISBN == isbn);
    if (book is not null)
    {
        var editedBook = GetBook();
        editedBook.ISBN = isbn;
        service.Update(editedBook);
        Console.WriteLine("Le livre a été modifié");
    }
    else
    {
        Console.WriteLine("Le livre n'a pas été trouvé.");
    }
    Console.WriteLine("Appuyez sur n'importe quelle touche pour revenir au menu");
    Console.ReadLine();
}

void DeleteBook()
{
    Console.Clear();
    var isbn = SaisieString("Veuillez saisir l'ISBN du livre à supprimer");
    var book = service.List().FirstOrDefault(b => b.ISBN == isbn);
    if (book is not null)
    {
        service.Delete(book);
        Console.WriteLine("Le livre a été supprimé de la bibliothèque");
    }
    else
    {
        Console.WriteLine("Le livre n'a pas été trouvé.");
    }
    Console.WriteLine("Appuyez sur n'importe quelle touche pour revenir au menu");
    Console.ReadLine();
}

Book GetBook()
{
    // TODO il faut vérifier l'unicité de l'ISBN
    var title = SaisieString("Veuillez saisir le titre");
    var author = SaisieString("Veuillez saisir l'auteur");
    var nbPages = SaisieInt("Veuillez saisir le nombre de pages");
    return new Book()
    {
        Title = title,
        Author = author,
        NbPages = nbPages
    };
}

void AddBook()
{
    Console.Clear();
    var isbn = SaisieString("Veuillez saisir l'ISBN");
    var book = GetBook();
    book.ISBN = isbn;
    service.Add(book);
    Console.WriteLine("Le livre a été ajouté à la bibliothèque");
    Console.WriteLine("Appuyez sur n'importe quelle touche pour revenir au menu");
    Console.ReadLine();
}

int SaisieInt(string question)
{
    string value = "";
    var result = 0;
    while (!int.TryParse(value, out result))
    {
        Console.WriteLine(question);
        value = Console.ReadLine();
    }

    return result;
}

string SaisieString(string question)
{
    string value = "";
    while (string.IsNullOrWhiteSpace(value))
    {
        Console.WriteLine(question);
        value = Console.ReadLine();
    }
    return value;
}

void PrintList()
{
    Console.Clear();
    foreach (var book in service.List())
    {
        PrintBook(book);
    }

    Console.WriteLine("Appuyez sur n'importe quelle touche pour revenir au menu");
    Console.ReadLine();
}

void PrintBook(Book b)
{
    Console.WriteLine("Livre : " + b.Title);
    Console.WriteLine("\tAuteur: " + b.Author);
    Console.WriteLine("\tPages : " + b.NbPages);
    Console.WriteLine("\tISBN : " + b.ISBN);
}

void PrintMenu()
{
    Console.WriteLine("Bienvenue sur la gestion des livres");
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("Que voulez-vous faire ?");
    Console.WriteLine("1. Lister les livres");
    Console.WriteLine("2. Ajouter un livre");
    Console.WriteLine("3. Modifier un livre");
    Console.WriteLine("4. Supprimer un livre");
    Console.WriteLine("Tapez 'Q' pour quitter");
}