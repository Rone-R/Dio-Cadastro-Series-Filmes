namespace Dio_Series
{

    public class SerieOptionCRUD
    {
        private readonly static SerieRepository repository = new ();

        private string inputTitle;
        private string inputDescription;
        private int inputGenders;
        private int inputYear;

        public List<Serie> GetSeries => repository.GetList;
        public void InsertOrUpdate_Serie(OptionsCRUD seriesTypeCRUD)
        {
            Console.WriteLine(Enum.GetName(typeof(OptionsCRUD), seriesTypeCRUD) + " Série \n");

            int indexValue = 0;
            bool isUpdate = false;

            if (seriesTypeCRUD == OptionsCRUD.Atualizando)
            {
                if (repository.GetList.Count == 0) { Console.WriteLine("Não há série para atualizar!"); return; }

                isUpdate = true;
                Console.Write("Informe o index: ");
                if(int.TryParse(Console.ReadLine(), out int value))
                    indexValue = value;
            }

            int index = isUpdate == true ? indexValue : repository.NextId;

            foreach (int i in Enum.GetValues(typeof(Genders)))
            {
                Console.WriteLine($"{Enum.GetName(typeof(Genders), i)} - {i}");
            }

            Console.Write("Digite o gênero dentre as opções acima: ");
            if (int.TryParse(Console.ReadLine(), out int indextGenders))
                inputGenders = indextGenders;

            Console.Write("Digite o título da Série: ");
            inputTitle = Console.ReadLine();
            if (string.IsNullOrEmpty(inputTitle)) { Console.WriteLine("\nTitulo do filme não pode ficar em branco."); return; }

            Console.Write("Digite o Ano de Início da Série: ");
            if (int.TryParse(Console.ReadLine(), out int indextYear))
                inputYear = indextYear;

            Console.Write("Digite a descrição da série: ");
            inputDescription = Console.ReadLine();

            SwitchCaseSerie(seriesTypeCRUD, Convert.ToString(index));
        }
        public void View_SerieOr_Delete(OptionsCRUD seriesTypeCRUD)
        {
            GetSerie(seriesTypeCRUD);
        }
        public static void Listar_Series()
        {
            if (repository.GetList.Count == 0) { Console.WriteLine("Não há série para listar!"); return; }
            Console.WriteLine("Listando séries");
            foreach (var serie in repository.GetList)
            {
                Console.WriteLine($"#ID {serie.GetId} - Nome: {serie.GetTitle} - Status: {(serie.IsDeleted ? "Excluído" : "Ativo")} ");
            }
        }
        private static Serie OptionsSerie(int id, int gender, string title, string description, int year)
        {
            Serie serie = new 
                (
                id: id,
                genders: (Genders)gender,
                title: title,
                description: description,
                year: year
                );
            return serie;
        }
        private void GetSerie(OptionsCRUD seriesTypeCRUD)
        {
            if (repository.GetList.Count == 0) { Console.WriteLine("Não há séries..."); return; }
            List<Serie> cacheList = new ();
            Console.WriteLine("Séries: \n");
            foreach (var item in repository.GetList)
            {
                if (!item.IsDeleted)
                    Console.WriteLine($"ID:{item.GetId} - Name: {item.GetTitle}");
                else
                    cacheList.Add(item);
            }
            if(cacheList.Count == repository.GetList.Count) { Console.WriteLine("Não há série ativa..."); return; }
            Console.Write("Digite o index da série que deseja Analisar: ");
            if (int.TryParse(Console.ReadLine(), out int value))
                SwitchCaseSerie(seriesTypeCRUD, Convert.ToString(value));
        }
        private void SwitchCaseSerie(OptionsCRUD seriesType, string? id = null)
        {
            int cacheValue = 0;
            Console.Clear();
            if (int.TryParse(id, out int value))
                cacheValue = value;
            string insertSerie = $"\n----- Série {inputTitle.ToUpper()} Inserida com sucesso! ------ \n";
            string updateSerie = $"\n----- Série {inputTitle.ToUpper()} Atualizada com sucesso! ------\n";
            string deleteSerie = $"\n----- Série {inputTitle.ToUpper()} Deletada! -----\n";

            switch (seriesType)
            {
                case OptionsCRUD.Inserindo:
                    repository.Insert(OptionsSerie(cacheValue, inputGenders, inputTitle, inputDescription, inputYear));
                    Console.WriteLine(insertSerie);
                    break;
                case OptionsCRUD.Atualizando:
                    repository.Update(cacheValue, OptionsSerie(cacheValue, inputGenders, inputTitle, inputDescription, inputYear));
                    Console.WriteLine(updateSerie);
                    break;
                case OptionsCRUD.Deletando:
                    repository.Delete(cacheValue);
                    Console.WriteLine(deleteSerie);
                    break;
                case OptionsCRUD.Lendo:
                    Console.WriteLine(repository.GetId(cacheValue));
                    break;
            }
        }
    }
}
