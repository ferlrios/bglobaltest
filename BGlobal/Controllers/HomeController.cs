using BGlobal.Data;
using BGlobal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BGlobal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        //En el index listamos todos los vehiculos en la base de datos
        public async Task<IActionResult> Index()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return View(vehicles);
        }


        //GET
        public async Task<IActionResult> Create()
        {
            ViewBag.Dueños = await ConsumirApi();
            return View();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Patente, Marca, Modelo, Puertas, Dueño")] Vehicle newVehicle)
        {
            ViewBag.Dueños = await ConsumirApi();
            if (ModelState.IsValid)
            {
                _context.Add(newVehicle);
                await _context.SaveChangesAsync();
                return View("CreateSucceeded");
            }
            return View();
        }

        //Vista confirmando que la subida fue realizada
        public IActionResult CreateSucceeded()
        {
            return View();
        }

        //Devuelve los datos de la API en una Lista de "usuarios"(modelo data).
        public async Task<List<data>> ConsumirApi()
        {
            List<data> _dueños = new List<data>();
            for (var i = 1; i <= 3; i++)
            {
                string baseUrl = $"https://reqres.in/api/users?page={i}";
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync(baseUrl);
                    var posts = JsonConvert.DeserializeObject<Post>(response);
                    foreach (var item in posts.data)
                    {
                        _dueños.Add(item);
                    }
                }
            }
            return _dueños;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
