using LibraryCrud.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCrud.Storage
{
    public class GenericStore<T> : IEnumerable<T>
        where T : IIdentity
    {
        T[] data = new T[0];
        public void Add(T entity)
        {
            int len = data.Length;
            len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;


        }
        public void Remove(T entity)
        {

           int index=  Array.IndexOf(data,entity);
            for (int i = index; i < data.Length - 1; i++)
            {
                data[i] = data[ i + 1];

            }
                Array.Resize(ref data, data.Length-1);


        }




        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal IEnumerable<object> GetAll()
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get
            {
                return data[index];

            }
        }
        public int Length
        {

            get
            {
                return data.Length;
            }

        }
        public T Find(int id)
        {
            return Array.Find(data, x => x.id == id);
        }
    }

    public interface IIdentity
    {
        public int id { get; }
    }
}
