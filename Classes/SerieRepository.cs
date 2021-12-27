using Dio_Series.Interfaces;
namespace Dio_Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private readonly List<Serie> listSerie = new ();
        public void Insert(Serie entity) => listSerie.Add(entity);
        public List<Serie> GetList => listSerie;
        public void Delete(int id)
        {
            listSerie[id].Delete();
        }
        public void Update(int id, Serie objeto)
        {
            listSerie[id] = objeto;
        }
        public Serie GetId(int id)
        {
            return listSerie[id];
        }
        public int NextId => listSerie.Count;
    }
}