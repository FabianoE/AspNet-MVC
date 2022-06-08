using MVC.Repositories.Base.Interface;
using MVC.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repositories.Base
{
    public class CrudBase<T> : ICrudBase<T> where T : class
    {
        private readonly DataContext context; 
        public CrudBase(DataContext context)
        {
            this.context = context;
        }

        public void Add(T data)
        {
            context.Set<T>().Add(data);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public void Remove(T data)
        {
            context.Set<T>().Remove(data);
            context.SaveChanges();
        }

        public void Update(T data)
        {
            context.Set<T>().Update(data);
            context.SaveChanges();
        }
    }
}
