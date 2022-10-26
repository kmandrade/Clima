using modCLima.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net;

namespace modCLima.Controllers

{
    public class ClimaController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ObterClima(Clima model)
        {
            var clima = await ObterTemp(model);
            if (clima.Name != null)
            {
                return View("Index",clima);

            }
            return View("Index");

        }

        private async Task<Clima> ObterTemp(Clima clima)
        {
            string name = clima.Name;
            HttpClient httpClient = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback =
                (sender, certificate, chain, sslPolicyErrors) => true;
            var response = await httpClient
                    .GetAsync($"https://localhost:44378/Climate/ObterClimaPorNomeCidade/{name}");
            var jsonSring = await response.Content.ReadAsStringAsync();

            Clima jsonObjct = JsonConvert.DeserializeObject<Clima>(jsonSring);
            jsonObjct.HoraAtual = DateTime.Now;
            if (((int)response.StatusCode) > 400)
                return null;

            if (jsonObjct != null)
            {
                return jsonObjct;
            }
            return null;
        }
       
    }
}