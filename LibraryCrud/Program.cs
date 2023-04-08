using LibraryCrud.DataModels;
using LibraryCrud.Helpers;
using LibraryCrud.StableModels;
using LibraryCrud.Storage;
using System.Runtime.CompilerServices;

namespace LibraryCrud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Stores

            var authorstore = new GenericStore<Author>();
            var bookStore = new GenericStore<Book>();
            #endregion
            int id = 0;
            Menu menu;
            Author author;
            Book book;
            bool allowforclear;


        l1:
            menu = Extension.PrintMenu();
            switch (menu)
            {
                case Menu.AuthorGetAll:
                    #region AuthorGetAll
                    Console.Clear();

                    if (authorstore.Length == 0)
                    {
                        Console.WriteLine("Muellif Adi Bosdur, Yeni Muellif Elave Edin...");
                        goto case Menu.AuthorAdd;
                    }
                    Console.WriteLine($"==================Author=================");

                    foreach (var item in authorstore)
                    {
                        Console.WriteLine($"{item.id} {item.Name}");
                    }
                    Console.WriteLine($"================= ========== ============");
                    goto l1;
                    
                #endregion
                case Menu.AuthorAdd:
                    #region AuthorAdd
                    Console.Clear();
                l6: Console.Write("Muellif Adini Daxil Edin:");
                    string name = Console.ReadLine();
                    Console.WriteLine($"Mueliffin Adi: {name}");
                    Author a = new Author();
                    a.Name = name;
                    authorstore.Add(a);
                    Console.WriteLine("Elave Olundu....");
                    goto l1;
                #endregion
                case Menu.AuthorFindByName:
                    Console.Clear();
                    Console.Write("Axtardiginiz Muellif Adini Daxil Edin: ");
                    string query = Console.ReadLine();
                    Console.WriteLine($"Axtar: '{query}':");
                    bool found = false;
                    foreach (var item in authorstore)
                    {
                        if (item.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"{item.id} {item.Name}");
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Muellif Tapilmadi...");
                    }
                    goto l1;

                    break;
                case Menu.AuthorGetById:
                    #region AuthorGetById
                    Console.Clear();
                    Console.WriteLine($"==================Author=================");

                    foreach (var item in authorstore)
                    {
                        Console.WriteLine($"{item.id} {item.Name}");
                    }

                    Console.WriteLine($"================= ========== ============");
                l2:
                    id = Extension.ReadInteger("Author id: ", true, authorstore.Min(x => x.id), authorstore.Max(x => x.id));
                    author = authorstore.Find(id);
                    if (author == null)
                    {
                        Console.WriteLine($"Bu Author Movcud Deyildir!");
                        goto l1;

                    }
                    Console.WriteLine($"Mueliffin Adi:{author}");
                    goto l1;
                #endregion

                case Menu.AuthorEdit:
                    #region AuthotEdit
                    Console.Clear();
                    Console.WriteLine($"==================Author=================");

                    foreach (var item in authorstore)
                    {
                        Console.WriteLine($"Muellif: {item.id} {item.Name}");
                    }
                    Console.WriteLine($"================= ========== ============");
                    id = Extension.ReadInteger("Author id: ", true, authorstore.Min(x => x.id), authorstore.Max(x => x.id));
                    author = authorstore.Find(id);
                    if (author == null)
                    {
                        goto case Menu.AuthorEdit;
                    }
                    author.Name = Extension.ReadString("Deyistireceyiniz Author Adini Daxil Edin:");

                    goto case Menu.AuthorGetAll;
                #endregion
                case Menu.AuthorRemove:
                    #region AuthorRemove
                    Console.Clear();
                    Console.WriteLine($"==================Author=================");

                    foreach (var item in authorstore)
                    {
                        Console.WriteLine($"{item.id} {item.Name}");
                    }
                    Console.WriteLine($"================= ========== ============");
                    id = Extension.ReadInteger("Author id: ", true, authorstore.Min(x => x.id), authorstore.Max(x => x.id));
                    author = authorstore.Find(id);
                    if (author == null)
                    {
                        goto case Menu.AuthorRemove;
                    }
                    authorstore.Remove(author);
                    goto case Menu.AuthorGetAll;
                    break;
                    #endregion

                case Menu.BookAdd:
                    #region BookAdd
                    Console.Clear();
                    //if (bookStore.Length == 0)
                    //{
                    //    allowforclear = false;
                    //    Console.WriteLine("Muellif Yoxdur, Ilk Once Muellif Qeyd Olunmalidir!");
                    //    goto l6;

                    //}
                    foreach (var item in authorstore)
                    {
                        Console.WriteLine($" {item.id} Muellif: {item.Name}");
                    }
                    book = new Book();
                    //ShowAllAuthors(false);
                l5: id = Extension.ReadInteger("Author id: ", true, authorstore.Min(x => x.id), authorstore.Max(x => x.id));
                    if (id == 0)
                    {
                        goto l5;
                    }
                    //book = bookStore.Find(id);
                    //if (book == null)
                    //{
                    //    goto l5;
                    //}
                    book.AuthorId = id;

                    if (id == 0)
                    {
                        goto l1;
                    }


                    book.Name = Extension.ReadString("Kitabin adi: ");
                    book.Genre = Extension.ReadEnum<Genre>("Janri: ");
                    book.PageNumber = Extension.ReadInteger("Sehife Sayi: ", true, 20);
                    book.Price = Extension.ReadDecimal("Qiymet: ", true, 3);
                    bookStore.Add(book);
                    Console.WriteLine("==================== =================== ============");


                    goto case Menu.BookGetAll;
                #endregion
                case Menu.BookGetAll:
                    #region BookGetAll
                    Console.Clear();

                    if (bookStore.Length == 0)
                    {
                        Console.WriteLine("Kitab Adi Bosdur, Yeni Kitab Elave Edin...");
                        goto case Menu.BookAdd;
                    }
                    Console.WriteLine($"==================Book=================");

                    //foreach(var item in authorstore)
                    //{
                    //    Console.WriteLine($" {item.id} Muellif: {item.Name}");
                    //}
                    foreach (var item in bookStore)
                    {
                        author = authorstore.Find(item.AuthorId);
                        Console.WriteLine($"{item} Muellifin adi: {author.Name} ");
                    }
                    Console.WriteLine($"================= ========== ============");
                    goto l1;
                    //ShowAllBook(true);

                    Console.Clear();

                    if (authorstore.Length == 0)
                    {
                        Console.WriteLine("Kitab Bosdur, Yeni Kitab Elave Edin...");
                        goto case Menu.BookAdd;
                    }
                    Console.WriteLine($"==================Book=================");

                    foreach (var item in authorstore)
                    {
                        Console.WriteLine(item);
                    }
                    foreach (var item in bookStore)
                    {
                        //Console.WriteLine($"{item.id} {item.Name}");
                        Console.WriteLine(item);
                    }
                    Console.WriteLine($"================= ========== ============");
                    goto l1;
                #endregion
                case Menu.BookFindByName:

                    #region BookFindByName
                    Console.Clear();
                    Console.Write("Axtardiginiz Kitab Adini Daxil Edin: ");
                    string query1 = Console.ReadLine();
                    Console.WriteLine($"Search: '{query1}':");
                    bool found1 = false;
                    foreach (var item in bookStore)
                    {
                        if (item.Name.Contains(query1, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"{item.Name}");
                            found = true;
                        }
                    }
                    if (!found1)
                    {
                        Console.WriteLine("Kitab Tapilmadi");
                    }
                    goto l1;
                #endregion
                case Menu.BookGetById:
                    #region BookGetById
                    Console.Clear();
                    Console.WriteLine($"==================Book=================");

                    foreach (var item in bookStore)
                    {
                        Console.WriteLine($"{item.id} {item.Name}");
                    }

                    Console.WriteLine($"================= ========== ============");

                    id = Extension.ReadInteger("Book id: ", true, bookStore.Min(x => x.id), bookStore.Max(x => x.id));
                    book = bookStore.Find(id);
                    if (book == null)
                    {
                        Console.WriteLine($"Bu Author Movcud Deyildir!");
                        goto l1;

                    }
                    Console.WriteLine(book);
                    goto l1;
                #endregion
                case Menu.BookEdit:
                    #region BookEdit
                    Console.Clear();
                    Console.WriteLine($"==================Book=================");

                    foreach (var item in bookStore)
                    {
                        Console.WriteLine($"{item.id} {item.Name}");
                    }
                    Console.WriteLine($"================= ========== ============");
                    id = Extension.ReadInteger("Book id: ", true, bookStore.Min(x => x.id), bookStore.Max(x => x.id));


                    book = bookStore.Find(id);
                    if (book == null)
                    {
                        goto case Menu.AuthorEdit;
                    }
                    book.Name = Extension.ReadString("Deyistireceyiniz Book Adini Daxil Edin:");
                    book.Genre = Extension.ReadEnum<Genre>("Deyistireceyiniz Janri Secin:");
                    book.PageNumber = Extension.ReadInteger("Deyistireceyiniz Sehife Sayini Daxil Edin: ", true, 20);
                    book.Price = Extension.ReadDecimal("Deyistireceyiniz Qiymeti Daxil Edin: ", true, 3);

                    goto case Menu.BookGetAll;
                #endregion
                case Menu.BookRemove:
                    #region BookRemove
                    Console.Clear();
                    Console.WriteLine("Silmek Istediyiniz Kitabi Daxil Edin:");
                    foreach (var item in bookStore)
                    {
                        Console.WriteLine(item);
                    }
                    id = Extension.ReadInteger("Kitab Id: ");

                    book = bookStore.Find(id);
                    if (book == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Id Duzgun Daxil Edilmemisdir!");
                        goto case Menu.AuthorRemove;

                    }
                    bookStore.Remove(book);
                    {
                        Console.Clear();
                        goto case Menu.BookGetAll;
                    }

                #endregion

                case Menu.ExitFromApp:
                    #region ExitFromApp
                    Console.WriteLine("Cixis Etmek Ucun Her Hansi Duymeni Sixin!");
                    Console.ReadKey();
                    #endregion
                    break;
                default:
                    break;
            }


        }

        private static void ShowAllBook(bool clearbefore)
        {
            if (clearbefore)
            {
                Console.Clear();
            }
            Console.WriteLine($"==================Kitablar=================");

            //foreach (var item in )
            //{
            //    Console.WriteLine($"{item.id} {item.Name}");
            //}
            Console.WriteLine($"================= ========== ============");
        }

        private static void ShowAllAuthors(bool v)
        {
            throw new NotImplementedException();
        }

    }

}
