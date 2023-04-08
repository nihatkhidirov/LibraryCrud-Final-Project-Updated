using LibraryCrud.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCrud.DataModels
{
    public class Author:IIdentity,IEquatable<Author>
    {
        static int counter = 0;
  
        public Author()
        {
            counter++;
            this.id = counter;

        }
        public int id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public bool Equals(Author? other)
        {
            return this.id ==other.id;

        }

        public override string ToString()
        {
            return $"{id}.{Name} {Surname}";
        }
    }
}
