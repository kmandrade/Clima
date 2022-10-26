using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }
      
        public async Task Inserir(TEntity entity)
        {
            dbSet.Add(entity);
            await Salvar();
        }

        public TEntity ObterPorId(int id)
        {
            return dbSet.Find(id);
        }
        public IQueryable<TEntity> ObterTodos()
        {
            IQueryable<TEntity> query = dbSet;

            return query.AsQueryable();
        }

        public void Dispose()
        {
            context.Dispose();
        }
        public async Task<int> Salvar()
        {

            return await context.SaveChangesAsync();

        }

    }
}
