using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        void SoftDeleteAndSubmit(T entity);
        void DeleteAndSubmit(T entity);
        IEnumerable<T> GetAll();
        void UpdateAndSubmit(T entity);
        void InsertAndSubmit(T entity);
        T GetById(int id);
    }
}
