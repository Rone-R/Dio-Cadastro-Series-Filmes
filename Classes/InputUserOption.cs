#nullable enable
namespace Dio_Series
{
    public class InputUserOption
    {
        public static string OptionCategoria()
        {
            Console.WriteLine();
            Console.WriteLine("----- DioFlix ao seu dispor -----");
            Console.WriteLine("\nO que deseja realizar?\n");
            Console.WriteLine("1 - Filmes!?");
            Console.WriteLine("2 - Séries!?");
            Console.WriteLine("3 - Ver lista de Séries e Filmes!?\n");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string optionUser = Console.ReadLine()!.ToUpper();
            Console.WriteLine();
            return optionUser;
        }
        public static string OptionBack()
        {
            Console.WriteLine();
            Console.WriteLine("----- DioFlix ao seu dispor -----");
            Console.WriteLine("\n1 - Voltar");
            Console.WriteLine("\nAperte qualquer tecla para sair.");

            string optionBack = Console.ReadLine()!.ToUpper();
            Console.WriteLine();
            return optionBack.ToUpper();
        }
        public static string OptionSeries()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries a seu dispor!!!\n");
            Console.WriteLine("Informe uma opção");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - limpar tela");
            Console.WriteLine("R - Voltar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string optionUserSeries = Console.ReadLine()!.ToUpper();
            Console.WriteLine();
            return optionUserSeries;
        }
        public static string OptionFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Filmes a seu dispor!!!\n");
            Console.WriteLine("Informe uma opção");
            Console.WriteLine("1 - Listar Filmes");
            Console.WriteLine("2 - Inserir novo filme");
            Console.WriteLine("3 - Atualizar filme");
            Console.WriteLine("4 - Excluir filme");
            Console.WriteLine("5 - Visualizar filme");
            Console.WriteLine("C - limpar tela");
            Console.WriteLine("R - Voltar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string optionUserFilmes = Console.ReadLine()!.ToUpper();
            Console.WriteLine();
            return optionUserFilmes;
        }
    }
}