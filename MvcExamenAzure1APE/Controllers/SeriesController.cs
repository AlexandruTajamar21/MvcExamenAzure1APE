using Microsoft.AspNetCore.Mvc;
using MvcExamenAzure1APE.Models;
using MvcExamenAzure1APE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcExamenAzure1APE.Controllers
{
    public class SeriesController : Controller
    {
        private ServiceSeries service;

        public SeriesController(ServiceSeries service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Series()
        {
            List<Serie> series = await this.service.GetSeries();
            return View(series);
        }

        public async Task<IActionResult> Details(int idSerie)
        {
            Serie serie = await this.service.FindSerie(idSerie);
            return View(serie);
        }

        public async Task<IActionResult> Personajes(int idSerie)
        {
            List<Personaje> personajes = await this.service.GetPersonajesSerie(idSerie);
            return View(personajes);
        }

        public async Task<IActionResult> UpdateSerie(int idSerie)
        {
            Serie serie = await this.service.FindSerie(idSerie);
            return View(serie);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSerie(Serie serie)
        {
            await this.service.UpdateSerie(serie);
            return RedirectToAction("Series");
        }

        public IActionResult InsertPersonaje()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertPersonaje(Personaje personaje)
        {
            await this.service.InsertPersonaje(personaje);
            return RedirectToAction("Series");
        }
        public async Task<IActionResult> DeletePersonaje(int idPersonaje)
        {
            await this.service.DeletePersonaje(idPersonaje);
            return RedirectToAction("Series");
        }

    }
}
