using LibraryCrud.StableModels;
using LibraryCrud.Storage;

namespace LibraryCrud.DataModels
{
    public class Book:IIdentity
    {
        static int counter = 0;
        public Book()
        {
            counter++;
            this.id = counter;
        }
        public int id { get; private set; } 
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public Genre Genre { get; set; }
        public int PageNumber { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            return $"id:{id} \n Name:{Name}\n Genre:{Genre}\n Page Number:{PageNumber}\n Price:{Price} \n";

        }

    }
}
