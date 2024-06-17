using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarrosMVC.Models;

namespace CarrosMVC.Controllers
{
    public class LojasController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public LojasController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();

            try
            {
                var response = await client.GetAsync("http://localhost:5171/api/Lojas");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var lojas = JsonConvert.DeserializeObject<List<Loja>>(content);

                    // Retorna uma view HTML com os dados das lojas
                    return View(lojas);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Failed to retrieve lojas from the external API.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
