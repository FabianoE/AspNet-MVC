using MVC.Repositories.Base.Interface;
using MVC.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repositories.Repository
{
    public interface IContatoRepository : ICrudBase<ContatoModel>
    {
        public ContatoModel GetById(int id);
        bool DeleteById(int id);
    }
}
