using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Loja novaLoja)
        {
            var client = _clientFactory.CreateClient();

            try
            {
                var json = JsonConvert.SerializeObject(novaLoja);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:5171/api/Lojas", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Failed to create new loja.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = _clientFactory.CreateClient();

            try
            {
                var response = await client.GetAsync($"http://localhost:5171/api/Lojas/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var loja = JsonConvert.DeserializeObject<Loja>(content);

                    return View(loja);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Failed to retrieve loja from the external API.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Loja loja)
        {
            if (id != loja.Id)
            {
                return BadRequest("ID mismatch.");
            }

            var client = _clientFactory.CreateClient();

            try
            {
                var json = JsonConvert.SerializeObject(loja);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"http://localhost:5171/api/Lojas/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Failed to update loja.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
