using System;
using System.Data.Entity;

namespace Repository.DataContext
{
    public interface IDataContext
    {

        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
        void ExecuteCommand(string command, params object[] parameters);
    }
}
