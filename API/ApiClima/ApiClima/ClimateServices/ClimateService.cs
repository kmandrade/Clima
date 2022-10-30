using ApiClima.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Clima;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiClima.ClimateServices
{
    public class ClimateService : IClimateService
    {
        private readonly IClimateRepository _climateRepository;
        private readonly IMapper _mapper;

        public ClimateService(IClimateRepository climateRepository, IMapper mapper)
        {
            _climateRepository = climateRepository;
            _mapper = mapper;
        }


        public async Task<DTOClimate> ObterClimaPorNomeCidade(string nmCidade)
        {

            try
            {
                var resultClimateCache = await VerificaCacheClimaPorNomeCidade(nmCidade);
                if (resultClimateCache != null)
                {
                    var dtoClimate = _mapper.Map<DTOClimate>(resultClimateCache);
                    return dtoClimate;
                }
                var resultApiClima = await GetClimaApiExterna(nmCidade);
                var climate = new Climate
                {
                    DateTime = DateTime.Now,
                    NomeCidade = resultApiClima.Name,
                    Temp = new List<Temp>
                {
                    new Temp
                    {
                        temp_min = resultApiClima.Temp.temp_min,
                        temp_max = resultApiClima.Temp.temp_max,

                    }
                }
                };
                await _climateRepository.Inserir(climate);
                await _climateRepository.Salvar();
                return resultApiClima;
            }
            catch (Exception ex)
            {
                return null;
            }
            

        }

        public async Task<DTOClimate> GetClimaApiExterna(string nmCidade)
        {
            string numeric = "metric";
            try
            {
                HttpClient httpClient = new HttpClient();
                var response = await httpClient
                    .GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={nmCidade},BR-SE,BRA&lang=pt_br&units={numeric}&appid=3893b851afbe1f8519a3c774f2050bb8");
                var jsonSring = await response.Content.ReadAsStringAsync();

                DTOClimate jsonObjct = JsonConvert.DeserializeObject<DTOClimate>(jsonSring);
                if (((int)response.StatusCode) > 400)
                    return null;

                if (jsonObjct != null)
                {
                    return jsonObjct;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<Climate> VerificaCacheClimaPorNomeCidade(string nmCidade)
        {
            var climate = await _climateRepository.ObterClimaPorNomeCidade(nmCidade);
            if (climate == null)
            {
                return null;
            }
            var dataAtual = DateTime.Now;
            var result = climate.DateTime - dataAtual;
            var data = result.Minutes;
            if(data > -19)
            {
                return climate;
            }
            return null;
        }

    }
}
