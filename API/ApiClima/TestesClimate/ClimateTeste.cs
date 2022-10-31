using ApiClima.ClimateServices;
using ApiClima.Models;
using ApiClima.Profiles;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Clima;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestesClimate
{
    public class ClimateTeste
    {

        private readonly IMapper _mapper;
        private readonly ClimateService _climateService;
        private readonly Mock<IClimateRepository> _climateRepository;

        public ClimateTeste()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ClimateProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

            _climateRepository = new Mock<IClimateRepository>();
            _climateService = new ClimateService(_climateRepository.Object, _mapper);
        }

        [Fact]
        public async Task BuscaClimatePorNome_ClimaNaoExiste_ReturnNull()
        {
            string nomeCidadeErrado = "CidadeError";
            _climateRepository.Setup(c => c.ObterClimaPorNomeCidade(nomeCidadeErrado)).ReturnsAsync(null as Climate);

            //ACT
            var resultado = await _climateService.ObterClimaPorNomeCidade(nomeCidadeErrado);

            //ASSERT
            Assert.Null(resultado);

        }


        [Fact]
        public async Task BuscaClimatePorNome_ClimaExiste_ReturnClimate()
        {
            string nomeCidadeErrado = "Aracaju";
            var climate = new Climate
            {
                NomeCidade = "Aracaju",
                Temp = new List<Temp>
                {
                    new Temp
                    {
                        temp_min = 22,
                        temp_max = 23
                    }
                }
            };
            _climateRepository.Setup(c => c.ObterClimaPorNomeCidade(nomeCidadeErrado)).ReturnsAsync(climate);

            //ACT
            var resultado = await _climateService.ObterClimaPorNomeCidade(nomeCidadeErrado);

            //ASSERT
            Assert.NotNull(resultado);

        }

        [Fact]
        public async Task VerificaCacheClimaPorNomeCidade_ClimaNaoExiste_Return_Null()
        {
            string nomeCidade = "Aracaju";
            _climateRepository.Setup(c => c.ObterClimaPorNomeCidade(nomeCidade)).ReturnsAsync(null as Climate);

            //ACT
            var resultado = await _climateService.VerificaCacheClimaPorNomeCidade(nomeCidade);
            //ASSERT
            Assert.Null(resultado);

        }


    }
}
