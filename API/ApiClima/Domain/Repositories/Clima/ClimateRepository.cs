using Domain.ClimaContext;
using Domain.Entities;
using Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Clima
{
    public class ClimateRepository: BaseRepository<Climate>,IClimateRepository
    {
        private readonly DbSet<Climate> _dbset;
        public ClimateRepository(MyContext context) : base(context)
        {
            _dbset = context.Set<Climate>();
        }

        public async Task<Climate> ObterClimaPorNomeCidade(string nomeCidade)
        {
            var query = await _dbset
                .AsNoTracking()
                .Include(t=>t.Temp)
                .OrderByDescending(d=>d.DateTime)
                .FirstOrDefaultAsync(c => c.NomeCidade == nomeCidade);
            return query;
        }
    }
}
