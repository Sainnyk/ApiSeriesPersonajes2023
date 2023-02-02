using ApiSeriesPersonajes2023.Models;
using ApiSeriesPersonajes2023.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSeriesPersonajes2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositorySeries repo;
        public SeriesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Serie>> GetSeries()
        {
            List<Serie> series = this.repo.GetSeries();
            return series;
        }

        [HttpGet("id")]
        public ActionResult<Serie> GetSerieId(int idserie)
        {
            Serie serie = this.repo.FindSerie(idserie);
            return serie;
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<List<Personaje>> PersonajesSerie(int idserie)
        {
            List<Personaje> personajes = this.repo.GetPersonajesSerie(idserie);
            return personajes;
        }

     
    }

}

