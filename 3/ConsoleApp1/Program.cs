using System;

namespace dziedziczenie
{

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
    public class Book
    {
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public Author Author { get; set; }
        public Book(string title, int publicationYear, Author author)
        {
            Title = title;
            PublicationYear = publicationYear;
            Author = author;

        }
    }
    public class Author : Person
    {
        public List<Book> BooksList { get; set; }
        public Author(string firstName, string lastName) : base(firstName, lastName)
        {
            BooksList = new List<Book>();
        }
        public void AddBook(Book book)
        {
            BooksList.Add(book);
        }
        public void ShowBooks()
        {
            foreach (var book in BooksList)
            {
                Console.WriteLine(book.Title);
                Console.WriteLine(book.PublicationYear);
            }
        }
    }

    public class Reader : Person
    {
        public List<Book> BorrowedBooksList { get; set; }
        public Reader(string firstName, string lastName) : base(firstName, lastName)
        {
            BorrowedBooksList = new List<Book>();
        }
        public void BorrowBook(Book book)
        {
            BorrowedBooksList.Add(book);
        }
    }

    public class Library
    {
        public List<Book> BooksList { get; set; }
        public List<Reader> ReadersList { get; set; }
        public Library()
        {
            BooksList = new List<Book>();
            ReadersList = new List<Reader>();
        }
        public void AddBook(Book book)
        {
            BooksList.Add(book);
        }
        public void DisplayBooks()
        {
            foreach (var book in BooksList)
            {
                Console.WriteLine(book);
            }
        }
        public void AddReader(Reader reader)
        {
            ReadersList.Add(reader);
        }
        public void BorrowBook(Book book, Reader reader)
        {
            reader.BorrowBook(book);
        }
        public void DisplayAuthorsBooks(Author author)
        {
            foreach (var book in author.BooksList)
            {
                Console.WriteLine(book);
            }
        }
        public void DisplayBorrowedBooks()
        {
            foreach (var reader in ReadersList)
            {
                foreach (var book in reader.BorrowedBooksList)
                {
                    Console.WriteLine(book);
                }
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            List<Author> authors = new List<Author>();
            List<Reader> readers = new List<Reader>();
            Console.WriteLine("Witaj w bibliotece!");

            while (true)
            {
                Console.WriteLine("Wybierz co chcesz zrobić:");
                Console.WriteLine("1. Dodaj autora");
                Console.WriteLine("2. Dodaj książkę");
                Console.WriteLine("3. Dodaj czytelnika");
                Console.WriteLine("4. Wypożycz książkę");
                Console.WriteLine("5. Wyświetl wszystkie książki");
                Console.WriteLine("6. Wyświetl wszystkich autorów");
                Console.WriteLine("7. Wyświetl wypożyczone książki");
                Console.WriteLine("0. Wyjdź");
                Console.WriteLine("Wybierz opcję:");
                int wybor = int.Parse(Console.ReadLine());
                switch (wybor)
                {
                    case 1:
                        Console.WriteLine("Podaj imię autora:");
                        string imie = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko autora:");
                        string nazwisko = Console.ReadLine();
                        Author autor = new Author(imie, nazwisko);
                        Console.WriteLine("Autor został dodany");
                        authors.Add(autor);
                        break;
                    case 2:
                        Console.WriteLine("Podaj tytuł książki:");
                        string tytul = Console.ReadLine();
                        Console.WriteLine("Podaj rok wydania książki:");
                        int rok = int.Parse(Console.ReadLine());
                        Console.WriteLine("Podaj imię autora książki:");
                        string imieAutora = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko autora książki:");
                        string nazwiskoAutora = Console.ReadLine();
                        Author autorKsiazki = new Author(imieAutora, nazwiskoAutora);
                        Book ksiazka = new Book(tytul, rok, autorKsiazki);
                        library.AddBook(ksiazka);
                        break;
                    case 3:
                        Console.WriteLine("Podaj imię czytelnika:");
                        string imieCzytelnika = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko czytelnika:");
                        string nazwiskoCzytelnika = Console.ReadLine();
                        Reader czytelnik = new Reader(imieCzytelnika, nazwiskoCzytelnika);
                        library.AddReader(czytelnik);
                        break;
                    case 4:
                        Console.WriteLine("Podaj tytuł książki:");
                        string tytulKsiazki = Console.ReadLine();
                        Console.WriteLine("Podaj imię czytelnika:");
                        string imieCzytelnika1 = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko czytelnika:");
                        string nazwiskoCzytelnika1 = Console.ReadLine();
                        Reader czytelnik1 = new Reader(imieCzytelnika1, nazwiskoCzytelnika1);
                        foreach (var book in library.BooksList)
                        {
                            if (book.Title == tytulKsiazki)
                            {
                                library.BorrowBook(book, czytelnik1);
                            }
                        }
                        Console.WriteLine("Książka została wypożyczona");
                        break;
                    case 5:
                        library.DisplayBooks();
                        break;
                    case 6:
                        foreach (var author in authors)
                        {
                            Console.WriteLine(author.FirstName);
                        }
                        break;
                    case 7:
                        library.DisplayBorrowedBooks();
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór");
                        break;
                    case 0:
                        return;

                }
            }
        }
    }
}
