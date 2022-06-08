using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repositories.Base.Interface
{
    public interface ICrudBase<T> where T : class
    {
        public void Add(T data);
        public void Update(T data);
        public void Remove(T data);
        public List<T> GetAll();
    }
}
