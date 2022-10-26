using ApiClima.ClimateServices;
using ApiClima.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Clima;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace ApiClima.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClimateController : ControllerBase
    {
        private readonly IClimateService _climateService;
        private readonly ILogger<ClimateController> _logger;


        public ClimateController(ILogger<ClimateController> logger, IClimateService climateService)
        {
            _logger = logger;
            _climateService = climateService;
        }


        [Route("ObterClimaPorNomeCidade/{nmCidade}")]
        [HttpGet]
        [ResponseType(typeof(DTOClimate))]
        public async Task<IActionResult> ObterClimaPorNomeCidade(string nmCidade)
        {
            try
            {
                var resultClimate = await _climateService.ObterClimaPorNomeCidade(nmCidade);
                
                if (resultClimate != null)
                {
                    return Ok(resultClimate);
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }


    }
}
