using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity ObterPorId(int id);

        Task Inserir(TEntity climate);

        Task<int> Salvar();

        void Dispose();
    }
}
