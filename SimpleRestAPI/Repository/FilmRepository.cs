using SimpleRestAPI.Models;

namespace SimpleRestAPI.Repository
{
    public class FilmRepository
    {

        private List<Film> _films { get; set; } 

        public FilmRepository() { _films = new List<Film>() { new Film() { Title="Best film", Categories=new List<Category>(), Genres=new List<Genre>(), StartTime=DateTime.Now, Id=0, Tickets=new List<Ticket>()} }; }


        public Film GetFilm(int id)
        {
            return _films.FirstOrDefault(v => v.Id == id);
        }

        public List<Film> GetAllFilms()
        {
            return _films;
        }
        public bool AddFilm(Film film)
        {
            int id = _films.Count;

            film.Id = id;

            _films.Add(film);

            return _films.Any(v => v.Id == id);

        }

        public bool RemoveFilm(int id)
        {
            Film film = _films.FirstOrDefault(v => v.Id == id);

            if (film!=null)
            {
                _films.Remove(film);
                return !_films.Any(v => v.Id == id);
            }

            return false;
        }

        
        public bool UpdateFilm(Film film)
        {
            int updatefilm = _films.FindIndex(v => v.Id == film.Id);

            if (updatefilm !=-1) {
                _films[updatefilm] = film;
                return true;
            }

            return false;
        }
    }
}
