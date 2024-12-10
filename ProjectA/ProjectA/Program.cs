using LibraryDomain;

namespace ProjectA;

public class Program
{
    private static LibraryBranch _libraryBranch = new LibraryBranch { Name = "Городская", Location = "Книжная 12" };
    private static List<Author> _authors = new List<Author>();
    private static List<Category> _categories = new List<Category>();
    private static List<Reader> _readers = new List<Reader>();

    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Показать книги в библиотеке");
            Console.WriteLine("2. Добавить книгу в библиотеку");
            Console.WriteLine("3. Удалить книгу из библиотеки");
            Console.WriteLine("4. Обновить название книги");
            Console.WriteLine("5. Назначить категорию книге");
            Console.WriteLine("6. Клонировать книгу");
            Console.WriteLine("7. Одобрить заказ");
            Console.WriteLine("8. Отменить заказ");
            Console.WriteLine("9. Создать заказ для читателя");
            Console.WriteLine("10. Отменить заказ для читателя");
            Console.WriteLine("11. Показать все заказы и связанных с ними читателей");
            Console.WriteLine("12. Выйти");
            Console.Write("Выберите опцию: ");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ShowBooks();
                    break;
                case "2":
                    AddBook();
                    break;
                case "3":
                    RemoveBook();
                    break;
                case "4":
                    UpdateBookTitle();
                    break;
                case "5":
                    AssignCategoryToBook();
                    break;
                case "6":
                    CloneBook();
                    break;
                case "7":
                    ApproveOrder();
                    break;
                case "8":
                    CancelOrder();
                    break;
                case "9":
                    CreateOrderForReader();
                    break;
                case "10":
                    CancelOrderForReader();
                    break;
                case "11":
                    ShowAllOrders();
                    break;
                case "12":
                    return;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова.");
                    break;
            }
        }
    }

    private static void ShowBooks()
    {
        Console.WriteLine("Книги в библиотеке:");
        foreach (var book in _libraryBranch.AvailableBooks)
        {
            Console.WriteLine($"- Название: {book.Title}");
            Console.WriteLine($"  Автор: {book.Author.Name}");
            Console.WriteLine($"  Издатель: {book.Publisher.Name}");
            Console.WriteLine($"  Категория: {book.Category.Name}\n");
            Console.WriteLine($"  ID книги: {book.Id}");
            Console.WriteLine($"  ID автора: {book.Author.Id}");
            Console.WriteLine($"  ID издателя: {book.Publisher.Id}");
            Console.WriteLine($"  ID категории: {book.Category.Id}\n");
        }
    }

    private static void AddBook()
    {
        Console.Write("Введите название книги: ");
        var title = Console.ReadLine();

        Console.WriteLine("Доступные авторы:");
        for (int i = 0; i < _authors.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_authors[i].Name}");
        }
        Console.Write("Выберите автора (введите номер) или введите новое имя автора: ");
        var authorInput = Console.ReadLine();
        Author author;
        if (int.TryParse(authorInput, out int authorIndex) && authorIndex > 0 && authorIndex <= _authors.Count)
        {
            author = _authors[authorIndex - 1];
        }
        else
        {
            author = new Author { Name = authorInput };
            _authors.Add(author);
        }

        Console.WriteLine("Доступные категории:");
        for (int i = 0; i < _categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_categories[i].Name}");
        }
        Console.Write("Выберите категорию (введите номер) или введите новое имя категории: ");
        var categoryInput = Console.ReadLine();
        Category category;
        if (int.TryParse(categoryInput, out int categoryIndex) && categoryIndex > 0 && categoryIndex <= _categories.Count)
        {
            category = _categories[categoryIndex - 1];
        }
        else
        {
            category = new Category { Name = categoryInput };
            _categories.Add(category);
        }

        Console.Write("Введите название издателя: ");
        var publisherName = Console.ReadLine();
        var publisher = new Publisher { Name = publisherName };

        var book = new Book { Title = title, Author = author, Publisher = publisher, Category = category };

        _libraryBranch.AddBook(book);
        Console.WriteLine("Книга добавлена в библиотеку.");
    }

    private static void RemoveBook()
    {
        Console.Write("Введите название книги для удаления: ");
        var title = Console.ReadLine();
        var book = _libraryBranch.AvailableBooks.FirstOrDefault(b => b.Title == title);

        if (book != null && _libraryBranch.RemoveBook(book))
        {
            Console.WriteLine("Книга удалена из библиотеки.");
        }
        else
        {
            Console.WriteLine("Книга не найдена в библиотеке.");
        }
    }

    private static void UpdateBookTitle()
    {
        Console.Write("Введите текущее название книги: ");
        var currentTitle = Console.ReadLine();
        var book = _libraryBranch.AvailableBooks.FirstOrDefault(b => b.Title == currentTitle);

        if (book != null)
        {
            Console.Write("Введите новое название книги: ");
            var newTitle = Console.ReadLine();
            book.UpdateTitle(newTitle);
            Console.WriteLine("Название книги обновлено.");
        }
        else
        {
            Console.WriteLine("Книга не найдена в библиотеке.");
        }
    }

    private static void AssignCategoryToBook()
    {
        Console.Write("Введите название книги: ");
        var title = Console.ReadLine();
        var book = _libraryBranch.AvailableBooks.FirstOrDefault(b => b.Title == title);

        if (book != null)
        {
            Console.Write("Введите новую категорию книги: ");
            var categoryName = Console.ReadLine();
            var category = new Category { Name = categoryName };
            book.AssignCategory(category);
            Console.WriteLine("Категория назначена книге.");
        }
        else
        {
            Console.WriteLine("Книга не найдена в библиотеке.");
        }
    }

    private static void CloneBook()
    {
        Console.Write("Введите название книги для клонирования: ");
        var title = Console.ReadLine();
        var book = _libraryBranch.AvailableBooks.FirstOrDefault(b => b.Title == title);

        if (book != null)
        {
            var clonedBook = (Book)book.Clone();
            _libraryBranch.AddBook(clonedBook);
            Console.WriteLine($"Книга клонирована: {clonedBook.Title}");
        }
        else
        {
            Console.WriteLine("Книга не найдена в библиотеке.");
        }
    }

    private static void ApproveOrder()
    {
        Console.Write("Введите номер заказа: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Неверный номер заказа, попробуйте снова.");
        }

        var orders = _readers.SelectMany(r => r.Orders).ToList();

        var order = orders.Find(o => o.Id == id);

        if (order != null)
        {
            order.ApproveOrder();
            Console.WriteLine("Заказ одобрен.");
        }
        else
        {
            Console.WriteLine("Заказ не найден.");
        }
    }

    private static void CancelOrder()
    {
        Console.Write("Введите номер заказа: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Неверный номер заказа, попробуйте снова.");
        }
        var orders = _readers.SelectMany(r => r.Orders).ToList();
        var order = orders.Find(o => o.Id == id);

        if (order != null)
        {
            order.CancelOrder();
            Console.WriteLine("Заказ отменен.");
        }
        else
        {
            Console.WriteLine("Заказ не найден.");
        }
    }

    private static void CreateOrderForReader()
    {
        Console.WriteLine("Доступные читатели:");
        for (int i = 0; i < _readers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_readers[i].FullName}");
        }
        Console.Write("Выберите читателя (введите номер) или введите новое имя читателя: ");
        var readerInput = Console.ReadLine();
        Reader reader;
        if (int.TryParse(readerInput, out int readerIndex) && readerIndex > 0 && readerIndex <= _readers.Count)
        {
            reader = _readers[readerIndex - 1];
        }
        else
        {
            reader = new Reader { FullName = readerInput };
            _readers.Add(reader);
        }

        Console.Write("Введите название книги для заказа: ");
        var title = Console.ReadLine();
        var book = _libraryBranch.AvailableBooks.FirstOrDefault(b => b.Title == title);

        if (book != null)
        {
            var order = reader.CreateOrder(book);
            Console.WriteLine($"Заказ создан: {order.Id}");
        }
        else
        {
            Console.WriteLine("Книга не найдена в библиотеке.");
        }
    }

    private static void CancelOrderForReader()
    {
        Console.WriteLine("Доступные читатели:");
        for (int i = 0; i < _readers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_readers[i].FullName}");
        }
        Console.Write("Выберите читателя (введите номер) или введите новое имя читателя: ");
        var readerInput = Console.ReadLine();
        Reader reader;
        if (int.TryParse(readerInput, out int readerIndex) && readerIndex > 0 && readerIndex <= _readers.Count)
        {
            reader = _readers[readerIndex - 1];
        }
        else
        {
            Console.WriteLine("Читатель не найден.");
            return;
        }

        Console.Write("Введите ID заказа для отмены: ");
        if (int.TryParse(Console.ReadLine(), out int orderId))
        {
            var order = reader.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null && reader.CancelOrder(order))
            {
                Console.WriteLine("Заказ отменен.");
            }
            else
            {
                Console.WriteLine("Заказ не найден.");
            }
        }
        else
        {
            Console.WriteLine("Неверный ID заказа.");
        }
    }

    private static void ShowAllOrders()
    {
        Console.WriteLine("Все заказы и связанные с ними читатели:");
        foreach (var reader in _readers)
        {
            foreach (var order in reader.Orders)
            {
                Console.WriteLine($"Заказ ID: {order.Id}, Книга: {order.Book.Title}, Читатель: {reader.FullName}, Статус: {order.Status}");
            }
        }
    }
}
