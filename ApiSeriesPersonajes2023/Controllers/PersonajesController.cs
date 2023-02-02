using ApiSeriesPersonajes2023.Models;
using ApiSeriesPersonajes2023.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSeriesPersonajes2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {

        private RepositorySeries repo;
        public PersonajesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Personaje>> Personajes()
        {
            List<Personaje> personajes = this.repo.GetPersonajes();
            return personajes;
        }

        [HttpGet("{id}")]
        public ActionResult<Personaje> Personaje(int idpersonaje)
        {
            Personaje personaje = this.repo.FindPersonaje(idpersonaje);
            return personaje;
        }

        [HttpPost]
        public async Task InsertarPersonaje(Personaje personaje)
        {
            await this.repo.InsertPersonaje(personaje);
        }
    }
}
