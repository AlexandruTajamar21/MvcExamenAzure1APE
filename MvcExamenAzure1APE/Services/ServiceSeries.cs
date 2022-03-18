using MvcExamenAzure1APE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MvcExamenAzure1APE.Services
{
    public class ServiceSeries
    {
        private Uri UriApi;
        private MediaTypeWithQualityHeaderValue Header;
        public ServiceSeries(string url)
        {
            this.UriApi = new Uri(url);
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<Serie> FindSerie(int idSerie)
        {
            string request = "/api/series/" + idSerie;
            Serie serie =
                await this.CallApiAsync<Serie>(request);
            return serie;
        }

        public async Task<List<Serie>> GetSeries()
        {
            string request = "/api/series";
            List<Serie> series =
                await this.CallApiAsync<List<Serie>>(request);
            return series;
        }

        public async Task DeleteSerie(int idSerie)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/series/" + idSerie;
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                await client.DeleteAsync(request);
            }
        }
        public async Task DeletePersonaje(int idPersonaje)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/personajes/" + idPersonaje;
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response = await client.DeleteAsync(request);
            }
        }

        public async Task<List<Personaje>> GetPersonajesSerie(int idSerie)
        {
            string request = "/api/personajes/" + idSerie;
            List<Personaje> personajes =
                await this.CallApiAsync<List<Personaje>>(request);
            return personajes;
        }

        public async Task UpdateSerie(Serie nombreserie)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/series";
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                Serie serie = await FindSerie(nombreserie.IdSerie);
                serie.NombreSerie = nombreserie.NombreSerie;
                serie.Imagen = nombreserie.Imagen;
                serie.Puntuacion = nombreserie.Puntuacion;
                serie.Año = nombreserie.Año;
                string json = JsonConvert.SerializeObject(serie);
                StringContent content = new StringContent
                    (json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PutAsync(request, content);
            }
        }

        public async Task InsertPersonaje(Personaje personaje)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/Personajes";
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                Personaje per = new Personaje()
                {
                    IdPersonaje = personaje.IdPersonaje,
                    IdSerie = personaje.IdSerie,
                    NombrePersonaje = personaje.NombrePersonaje,
                    Imagen = personaje.Imagen
                };
                string json = JsonConvert.SerializeObject(per);
                StringContent content = new StringContent
                    (json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(request, content);
            }
        }

    }
}
