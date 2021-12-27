namespace Dio_Series
{
    public class FilmesOptionCRUD
    {

        private readonly static FilmesRepositorio repositoryFilme = new();

        private string inputTitle;
        private string inputDescription;
        private int inputGenders;
        private int inputYear;

        public List<Filme> GetFilmes => repositoryFilme.GetList;
        public void InsertOrUpdate_Filme(OptionsCRUD filmesTypeCRUD)
        {
            Console.WriteLine(Enum.GetName(typeof(OptionsCRUD), filmesTypeCRUD) + " Filme \n");

            int indexValue = 0;
            bool isUpdate = false;

            if (filmesTypeCRUD == OptionsCRUD.Atualizando)
            {
                if (repositoryFilme.GetList.Count == 0) { Console.WriteLine("Não há filmes para atualizar!"); return; }

                isUpdate = true;
                Console.Write("Informe o index: ");
                if (int.TryParse(Console.ReadLine(), out int value))
                    indexValue = value;
            }

            int index = isUpdate == true ? indexValue : repositoryFilme.NextId;

            foreach (int i in Enum.GetValues(typeof(Genders)))
            {
                Console.WriteLine($"{Enum.GetName(typeof(Genders), i)} - {i}");
            }

            Console.Write("Digite o gênero dentre as opções acima: ");
            if(int.TryParse(Console.ReadLine(), out int indexGenders))
                inputGenders = indexGenders;

            Console.Write("Digite o título do Filme: ");
            inputTitle = Console.ReadLine();
            if (string.IsNullOrEmpty(inputTitle)) { Console.WriteLine("\nTitulo do filme não pode ficar em branco."); return; }

            Console.Write("Digite o Ano de Início do Filme: ");
            if (int.TryParse(Console.ReadLine(), out int indextYear))
                inputYear = indextYear;

            Console.Write("Digite a descrição do Filme: ");
            inputDescription = Console.ReadLine();

            SwitchCaseFilme(filmesTypeCRUD, Convert.ToString(index));
        }
        public void View_FilmeOr_Delete(OptionsCRUD filmesTypeCRUD)
        {
            GetFilme(filmesTypeCRUD);
        }
        public void Listar_Filmes()
        {
            if (repositoryFilme.GetList.Count == 0) { Console.WriteLine("Não há filmes para listar!"); return; }
            Console.WriteLine("Listando filmes");
            foreach (var filme in repositoryFilme.GetList)
            {
                Console.WriteLine($"#ID {filme.GetId} - Nome: {filme.GetTitle} - Status: {(filme.IsDeleted ? "Excluído" : "Ativo")} ");
            }
        }
        private static Filme OptionsFilme(int id, int gender, string title, string description, int year)
        {
            Filme filme = new                (
                id: id,
                genders: (Genders)gender,
                title: title,
                description: description,
                year: year
                );
            return filme;
        }
        private void GetFilme(OptionsCRUD filmesTypeCRUD)
        {
            if (repositoryFilme.GetList.Count == 0) { Console.WriteLine("Não há filmes..."); return; }
            List<Filme> cacheList = new();
            Console.WriteLine("Filmes: \n");
            foreach (var item in repositoryFilme.GetList)
            {
                if (!item.IsDeleted)
                    Console.WriteLine($"ID:{item.GetId} - Name: {item.GetTitle}");
                else
                    cacheList.Add(item);
            }
            if (cacheList.Count == repositoryFilme.GetList.Count) { Console.WriteLine("Não há Filme ativo..."); return; }
            Console.Write("Digite o index do Filme que deseja Analisar: ");
            if (int.TryParse(Console.ReadLine(), out int value))
                SwitchCaseFilme(filmesTypeCRUD, Convert.ToString(value));
        }
        private void SwitchCaseFilme(OptionsCRUD FilmesType, string? id = null)
        {
            int cacheValue = 0;
            Console.Clear();
            if (int.TryParse(id, out int value))
                cacheValue = value;
            string insertFilme = $"\n----- Filme {inputTitle.ToUpper()} Inserido com sucesso! ------ \n";
            string updateFilme = $"\n----- Filme {inputTitle.ToUpper()} Atualizado com sucesso! ------\n";
            string deleteFilme = $"\n----- Filme {inputTitle.ToUpper()} Deletada! -----\n";

            switch (FilmesType)
            {
                case OptionsCRUD.Inserindo:
                    repositoryFilme.Insert(OptionsFilme(cacheValue, inputGenders, inputTitle, inputDescription, inputYear));
                    Console.WriteLine(insertFilme);
                    break;
                case OptionsCRUD.Atualizando:
                    repositoryFilme.Update(cacheValue, OptionsFilme(cacheValue, inputGenders, inputTitle, inputDescription, inputYear));
                    Console.WriteLine(updateFilme);
                    break;
                case OptionsCRUD.Deletando:
                    repositoryFilme.Delete(cacheValue);
                    Console.WriteLine(deleteFilme);
                    break;
                case OptionsCRUD.Lendo:
                    Console.WriteLine(repositoryFilme.GetId(cacheValue));
                    break;
            }
        }


    }
}
