using Dio_Series.Interfaces;
namespace Dio_Series
{
    public class FilmesRepositorio : IRepository<Filme>
    {
        private readonly List<Filme> listFilmes = new();
        public List<Filme> GetList => listFilmes;

        public int NextId => listFilmes.Count;

        public void Delete(int id)
        {
            listFilmes[id].Delete();
        }

        public Filme GetId(int id)
        {
            return listFilmes[id];
        }

        public void Insert(Filme entity)
        {
            listFilmes.Add(entity);
        }

        public void Update(int id, Filme objeto)
        {
            listFilmes[id] = objeto;  
        }
    }
}
