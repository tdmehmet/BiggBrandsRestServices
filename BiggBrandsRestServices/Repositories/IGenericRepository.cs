using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BiggBrandsRestServices.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        DbSet<T> GetAll();
        List<T> FindAllItems();
        T FindById(Int64 id);
        bool CheckById(Int64 id);
        T FindByIdAsNoTracking(Int64 id);
        T Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
        T Update(T entity);
    }
}
