using LibraryDomain;

namespace ProjectA;

public class Program
{
    private static Library _libraryBranch = new Library();
    private static List<Author> _authors = new List<Author>();
    private static List<Category> _categories = new List<Category>();
    private static List<Reader> _readers = new List<Reader>();

    // приклад власного делегату
    // для обробки замовлень
    public delegate void OrderHandler(Order order);

    private static void Main(string[] args)
    {
        // Action делегат для виведення повідомлень
        Action<string> displayMessage = (message) => Console.WriteLine(message);

        _libraryBranch.BookAdded += OnBookAdded;

        while (true)
        {
            displayMessage("Меню:");
            displayMessage("1. Показать книги в библиотеке");
            displayMessage("2. Добавить книгу в библиотеку");
            displayMessage("3. Удалить книгу из библиотеки");
            displayMessage("4. Обновить название книги");
            displayMessage("5. Назначить категорию книге");
            displayMessage("6. Клонировать книгу");
            displayMessage("7. Одобрить заказ");
            displayMessage("8. Отменить заказ");
            displayMessage("9. Создать заказ для читателя");
            displayMessage("10. Показать все заказы и связанных с ними читателей");
            displayMessage("11. Выйти");
            Console.Write("Выберите опцию: \n");

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
                    ShowAllOrders();
                    break;
                case "11":
                    return;
                default:
                    displayMessage("Неверный выбор, попробуйте снова.\n");
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
        Console.Write("\nВведите название книги: \n");
        var title = Console.ReadLine();

        Console.WriteLine("\nДоступные авторы:\n");
        for (int i = 0; i < _authors.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_authors[i].Name}");
        }
        Console.Write("\nВыберите автора (введите номер) или введите новое имя автора: \n");
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

        Console.WriteLine("\nДоступные категории:");
        for (int i = 0; i < _categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_categories[i].Name}");
        }
        Console.Write("\nВыберите категорию (введите номер) или введите новое имя категории: ");
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

        Console.Write("\nВведите название издателя: ");
        var publisherName = Console.ReadLine();
        var publisher = new Publisher { Name = publisherName };

        var book = new Book { Title = title, Author = author, Publisher = publisher, Category = category };

        _libraryBranch.AddBook(book);
        Console.WriteLine("\nКнига добавлена в библиотеку.");
    }

    private static void RemoveBook()
    {
        Console.Write("\nВведите название книги для удаления: ");
        var title = Console.ReadLine();

        // Predicate для пошуку книги по назві
        Predicate<Book> findBookByTitle = b => b.Title == title;

        var book = _libraryBranch.AvailableBooks.Find(findBookByTitle);

        if (book != null && _libraryBranch.RemoveBook(book))
        {
            Console.WriteLine("\nКнига удалена из библиотеки.");
        }
        else
        {
            Console.WriteLine("\nКнига не найдена в библиотеке.");
        }
    }

    private static void UpdateBookTitle()
    {
        Console.Write("\nВведите текущее название книги: ");
        var currentTitle = Console.ReadLine();
        var book = _libraryBranch.AvailableBooks.FirstOrDefault(b => b.Title == currentTitle);

        if (book != null)
        {
            Console.Write("\nВведите новое название книги: ");
            var newTitle = Console.ReadLine();
            book.UpdateTitle(newTitle);
            Console.WriteLine("\nНазвание книги обновлено.");
        }
        else
        {
            Console.WriteLine("\nКнига не найдена в библиотеке.");
        }
    }

    private static void AssignCategoryToBook()
    {
        Console.Write("\nВведите название книги: ");
        var title = Console.ReadLine();
        var book = _libraryBranch.AvailableBooks.FirstOrDefault(b => b.Title == title);

        if (book != null)
        {
            Console.Write("\nВведите новую категорию книги: ");
            var categoryName = Console.ReadLine();
            var category = new Category { Name = categoryName };
            book.ChangeCategory(category);
            Console.WriteLine("\nКатегория назначена книге.");
        }
        else
        {
            Console.WriteLine("\nКнига не найдена в библиотеке.");
        }
    }

    private static void CloneBook()
    {
        Console.Write("\nВведите название книги для клонирования: ");
        var title = Console.ReadLine();
        var book = _libraryBranch.AvailableBooks.FirstOrDefault(b => b.Title == title);

        if (book != null)
        {
            var clonedBook = (Book)book.Clone();
            _libraryBranch.AddBook(clonedBook);
            Console.WriteLine($"\nКнига клонирована: {clonedBook.Title}");
        }
        else
        {
            Console.WriteLine("\nКнига не найдена в библиотеке.");
        }
    }

    private static void ApproveOrder()
    {
        Console.Write("\nВведите номер заказа: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("\nНеверный номер заказа, попробуйте снова.");
        }

        var orders = _readers.SelectMany(r => r.Orders).ToList();

        var order = orders.Find(o => o.Id == id);

        if (order != null)
        {
            // 1 приклад використання власного делегату
            OrderHandler approveOrderHandler = (o) => o.ApproveOrder();

            approveOrderHandler(order);

            Console.WriteLine("\nЗаказ одобрен.");
        }
        else
        {
            Console.WriteLine("\nЗаказ не найден.");
        }
    }

    private static void CancelOrder()
    {
        Console.Write("\nВведите номер заказа: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("\nНеверный номер заказа, попробуйте снова.");
        }
        var orders = _readers.SelectMany(r => r.Orders).ToList();
        var order = orders.Find(o => o.Id == id);

        if (order != null)
        {
            // 2 приклад використання власного делегату

            OrderHandler cancelOrderHandler = (o) => o.CancelOrder();

            cancelOrderHandler(order);

            Console.WriteLine("\nЗаказ отменен.");
        }
        else
        {
            Console.WriteLine("\nЗаказ не найден.");
        }
    }

    private static void CreateOrderForReader()
    {
        Console.WriteLine("\nДоступные читатели:");
        for (int i = 0; i < _readers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_readers[i].FullName}");
        }
        Console.Write("\nВыберите читателя (введите номер) или введите новое имя читателя: ");
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

        Console.Write("\nВведите название книги для заказа: ");
        var title = Console.ReadLine();
        var book = _libraryBranch.AvailableBooks.FirstOrDefault(b => b.Title == title);

        if (book != null)
        {
            var order = reader.CreateOrder(book);

            order.OrderApproved += OnOrderApproved;
            order.OrderCanceled += OnOrderCancelled;

            Console.WriteLine($"\nЗаказ создан: {order.Id}");
        }
        else
        {
            Console.WriteLine("\nКнига не найдена в библиотеке.");
        }
    }

    private static void ShowAllOrders()
    {
        Console.WriteLine("\nВсе заказы и связанные с ними читатели:");
        foreach (var reader in _readers)
        {
            foreach (var order in reader.Orders)
            {
                Console.WriteLine($"Заказ ID: {order.Id}, Книга: {order.Book.Title}, Читатель: {reader.FullName}, Статус: {order.Status}");
            }
        }
    }

    public static void OnBookAdded(object sender, Book book)
    {
        Console.WriteLine($"\nКнига добавлена: {book.Title}");
    }

    public static void OnOrderApproved(object sender, int orderId)
    {
        Console.WriteLine($"\nЗаказ {orderId} подтвержден");
    }

    public static void OnOrderCancelled(object sender, int orderId)
    {
        Console.WriteLine($"\nЗаказ {orderId} отменен");
    }
}
