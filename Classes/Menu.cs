using System.Collections.Generic;
namespace Dio_Series
{
    public class Menu
    {
        static SerieOptionCRUD SerieOptionCRUD = new();
        static FilmesOptionCRUD FilmesOptionCRUD = new();
        public static void OptionCategoria()
        {
            Console.Clear();
            string optionCategoria = InputUserOption.OptionCategoria();
            if (optionCategoria == "1")
            {
                OptionsFilmes();
            }
            else if (optionCategoria == "2")
            {
                OptionsSeries();
            }
            else if (optionCategoria == "3")
            {
                ListViewsSeriesFilmes();
            }
            else if (optionCategoria != "X")
            {
                Console.Clear();
                OptionCategoria();
            }
            else
                Console.WriteLine("Até breve.");
        }

        private static void ListViewsSeriesFilmes()
        {
            Console.Clear();
            if (FilmesOptionCRUD.GetFilmes.Count == 0)
            {
                Console.WriteLine("\n Ops! Nenhum filme foi encontrado :(...");
            }
            else
            {
                Console.WriteLine("\n----- Lista de Filmes -----");
                foreach (var filmes in FilmesOptionCRUD.GetFilmes)
                {
                    Console.WriteLine($"Name: {filmes.GetTitle} - Ano:{filmes.GetYear}");
                }
            }
            Console.WriteLine("\n---------------------------\n");
            if (SerieOptionCRUD.GetSeries.Count == 0)
            {
                Console.WriteLine("\n Ops! Nenhuma série foi encontrada :(..."); return;
            }
            else
            {
                Console.WriteLine("----- Lista de Series -----");
                foreach (var series in SerieOptionCRUD.GetSeries)
                {
                    Console.WriteLine($"Name: {series.GetTitle} - Ano:{series.GetYear}");
                }
            }
            string optionBack = InputUserOption.OptionBack();
            if (optionBack == "1")
            {
                Console.Clear();
                OptionCategoria();
            }
            else
                Console.WriteLine("Volte sempre!!!");
        }

        public static void OptionsSeries()
        {
            Console.Clear();
            string optionSeries = InputUserOption.OptionSeries();
            while (optionSeries != "X" && optionSeries != "R")
            {
                Console.Clear();
                switch (optionSeries)
                {
                    case "1":
                        SerieOptionCRUD.Listar_Series();
                        break;
                    case "2":
                        SerieOptionCRUD.InsertOrUpdate_Serie(OptionsCRUD.Inserindo);
                        break;
                    case "3":
                        SerieOptionCRUD.InsertOrUpdate_Serie(OptionsCRUD.Atualizando);
                        break;
                    case "4":
                        SerieOptionCRUD.View_SerieOr_Delete(OptionsCRUD.Deletando);
                        break;
                    case "5":
                        SerieOptionCRUD.View_SerieOr_Delete(OptionsCRUD.Lendo);
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Entrada invalida!!!");
                        break;
                }

                optionSeries = InputUserOption.OptionSeries();
            }
            if (optionSeries == "X")
            {
                Console.WriteLine("Obrigado por utilizar nossos serviços.");
            }
            else
            {
                if (optionSeries == "R")
                {
                    Console.Clear();
                    OptionCategoria();

                }
            }
        }
        public static void OptionsFilmes()
        {
            Console.Clear();
            string optionFilmes = InputUserOption.OptionFilme();
            while (optionFilmes != "X" && optionFilmes != "R")
            {
                Console.Clear();
                switch (optionFilmes)
                {
                    case "1":
                        FilmesOptionCRUD.Listar_Filmes();
                        break;
                    case "2":
                        FilmesOptionCRUD.InsertOrUpdate_Filme(OptionsCRUD.Inserindo);
                        break;
                    case "3":
                        FilmesOptionCRUD.InsertOrUpdate_Filme(OptionsCRUD.Atualizando);
                        break;
                    case "4":
                        FilmesOptionCRUD.View_FilmeOr_Delete(OptionsCRUD.Deletando);
                        break;
                    case "5":
                        FilmesOptionCRUD.View_FilmeOr_Delete(OptionsCRUD.Lendo);
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Entrada invalida!!!");
                        break;
                }
                optionFilmes = InputUserOption.OptionFilme();
            }
            if (optionFilmes == "X")
            {
                Console.WriteLine("Obrigado por utilizar nossos serviços.");
            }
            else if (optionFilmes == "R")
            {
                Console.Clear();
                OptionCategoria();
            }
        }
    }
}
