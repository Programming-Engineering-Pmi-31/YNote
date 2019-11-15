using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNoteWPF.DAL.Interfaces
{
    public interface IRepository<T>  : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Create(T item);
        void Update(T item);
        void Delete(int id); // int or object? (UserEntity has property Guid Id)
        void Save();
    }
}
