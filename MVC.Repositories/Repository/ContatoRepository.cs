using MVC.Repositories.Base;
using MVC.Repositories.Base.Interface;
using MVC.Repositories.Data;
using MVC.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repositories.Repository
{
    public class ContatoRepository : CrudBase<ContatoModel>, IContatoRepository
    {
        private readonly DataContext context;
        public ContatoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public ContatoModel GetById(int id)
        {
            return context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public bool DeleteById(int id)
        {
            ContatoModel contatoDb = GetById(id);

            if (contatoDb == null)
                throw new Exception("Houve um erro na atualização");

            context.Remove(contatoDb);
            context.SaveChanges();
            return true;
        }
    }
}
