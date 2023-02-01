using ApiSeriesPersonajes2023.Data;
using ApiSeriesPersonajes2023.Models;

namespace ApiSeriesPersonajes2023.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;
        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        #region TABLA SERIES
        public List<Serie> GetSeries()
        {
            var consulta = from datos in this.context.Series select datos;
            return consulta.ToList();
        }

        public Serie FindSerie(int idserie)
        {
            var consulta = from datos in this.context.Series where datos.IdSerie == idserie select datos;
            return consulta.FirstOrDefault();
        }

        #endregion

        #region TABLA PERSONAJES
        public List<Personaje> GetPersonajesSerie(int idserie)
        {
            var consulta = from datos in this.context.Personajes where datos.IdSerie == idserie select datos;
            return consulta.ToList();
        }

        public List<Personaje> GetPersonajes()
        {
            var consulta = from datos in this.context.Personajes select datos;
            return consulta.ToList();
        }

        public Personaje FindPersonaje(int idpersonaje)
        {
            var consulta= from datos in this.context.Personajes where datos.IdPersonaje == idpersonaje select datos;
            return consulta.FirstOrDefault();
        }

        //Cambiar un personaje de serie
        public async Task UpdatePersonajeSerie(int idpersonaje, int idserie)
        {
            Personaje personaje = this.FindPersonaje(idpersonaje);
            personaje.IdSerie = idserie;
            await this.context.SaveChangesAsync();
        }

        //Insertar personaje
        public async Task InsertPersonaje(Personaje per)
        {
            Personaje personaje = new Personaje();
            personaje = per;
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }
        #endregion








    }
}
