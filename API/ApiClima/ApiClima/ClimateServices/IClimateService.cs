using ApiClima.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClima.ClimateServices
{
    public interface IClimateService
    {
        Task<DTOClimate> ObterClimaPorNomeCidade(string nmCidade);
    }
}
