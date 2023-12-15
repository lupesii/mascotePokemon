using mascotePokemon.Modelos;
using mascotePokemon.Service;
using Newtonsoft.Json;

namespace mascotePokemon.Menus;

internal class Menu
{
    public static void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo.ToUpper());
        Console.WriteLine(asteriscos + "\n");
    }

    public static int ExibirMenu()
    {
        Console.Clear();
        Menu.ExibirTituloDaOpcao("MENU");

        Console.WriteLine("\n1 - ADOTAR UM MASCOTE VIRTUAL");
        Console.WriteLine("2 - VER SEUS MASCOTES ADOTADOS");
        Console.WriteLine("3 - SAIR");
        Console.Write("\nRESPOSTA: ");
        string opcaoEscolhida = Console.ReadLine()!;
        int opcaoEscolhidaNumero;

        if (int.TryParse(opcaoEscolhida, out opcaoEscolhidaNumero) && opcaoEscolhidaNumero > 0 && opcaoEscolhidaNumero < 4)
        {
            return opcaoEscolhidaNumero;
        }
        else return 0;
    }

    public static void AdotaMascote(List<MascotePokemon> ListaDePokemon)
    {
        Console.Clear();
        ExibirTituloDaOpcao("ADOTAR UM MASCOTE");

        Console.WriteLine("\nESCOLHA A ESPÉCIE:");
        var response = PokemonAPI.RequisicaoGet("https://pokeapi.co/api/v2/pokemon-species/");
        var EspeciesPokemon = JsonConvert.DeserializeObject<PokemonResult>(response.Content!);

        for (int i = 0; i < EspeciesPokemon!.Results.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{EspeciesPokemon.Results[i].Name.ToUpper()}");
        }

        Console.Write("\nESCOLHA: ");
        string pokemonEscolhido = Console.ReadLine()!;
        int pokemonEscolhidoNumero;

        if (int.TryParse(pokemonEscolhido, out pokemonEscolhidoNumero))
        {
            var especificacaoPokemon = PokemonAPI.RequisicaoGet($"https://pokeapi.co/api/v2/pokemon/{pokemonEscolhido}");
            MascotePokemon mascote = JsonConvert.DeserializeObject<MascotePokemon>(especificacaoPokemon.Content!)!;
            OpcoesMascote(mascote, ListaDePokemon);
        }
        else
        {
            AdotaMascote(ListaDePokemon);
        }


    }

    public static void OpcoesMascote(MascotePokemon mascote, List<MascotePokemon> ListaDePokemon)
    {
        Console.Clear();
        Console.WriteLine("VOCÊ DESEJA: ");
        Console.WriteLine($"1 - SABER MAIS SOBRE O {mascote.Name.ToUpper()}");
        Console.WriteLine($"2 - ADOTAR {mascote.Name.ToUpper()}");
        Console.WriteLine("3 - VOLTAR");

        Console.Write("\nESCOLHA: ");
        string opcaoEscolhida = Console.ReadLine()!;
        int opcaoEscolhidaNumero;

        if (int.TryParse(opcaoEscolhida, out opcaoEscolhidaNumero))
        {
            switch (opcaoEscolhidaNumero)
            {
                case 1:
                    Console.Clear();
                    MascotePokemon.ExibirEstatisticas(mascote);
                    Console.WriteLine("\nDIGITE UMA TECLA PARA VOLTAR");
                    Console.ReadKey();
                    OpcoesMascote(mascote, ListaDePokemon);
                    break;

                case 2:
                    AdotarUmPokemon(mascote, ListaDePokemon);
                    break;

                case 3:
                    AdotaMascote(ListaDePokemon);
                    break;

                default:
                    Console.WriteLine("Opção Inválida, tente novamente");
                    Thread.Sleep(2000);
                    Console.Clear();
                    OpcoesMascote(mascote, ListaDePokemon);
                    break;
            }
        }
        else
        {
            OpcoesMascote(mascote, ListaDePokemon);
        }
    }

    public static void AdotarUmPokemon(MascotePokemon mascote, List<MascotePokemon> ListaDePokemon)
    {
        Console.Clear();
        MascotePokemon.ExibirEstatisticas(mascote);
        Console.Write("\nDESEJA ADOTAR ESSE POKEMON? (s/n): ");
        string resposta = Console.ReadLine()!.ToLower();

        if (resposta == "s")
        {
            Console.Write($"\n\nPARABÉNS, SUA ESCOLHA FOI {mascote.Name.ToUpper()}!\nESPERO QUE SEJAM FELIZES JUNTOS");
            ListaDePokemon.Add(mascote);

            Thread.Sleep(2000);
        }
        else if(resposta == "n")
        {
            Console.WriteLine("\n\nPUXA, LAMENTO MUITO SABER DISSO :(");
            Console.WriteLine("PRESSIONE UMA TECLA PARA VOLTAR AO MENU");
            Console.ReadKey();
            OpcoesMascote(mascote, ListaDePokemon);
        }
        else
        {
            AdotarUmPokemon(mascote, ListaDePokemon);
        }
    }

    public static void MascotesAdotados(List<MascotePokemon> ListaDePokemon)
    {
        Console.Clear();
        ExibirTituloDaOpcao("MASCOTES ADOTADOS");
        Console.WriteLine("\nLista dos mascotes adotados:");

        int indice = 1;

        foreach (MascotePokemon i in ListaDePokemon)
        {
            Console.WriteLine($"POKEMON {indice}: ");
            MascotePokemon.ExibirEstatisticas(i);
            Console.WriteLine("\n\n");
            indice++;
        }
        Console.WriteLine("\nPRESSIONE UMA TECLA PARA VOLTAR...");
        Console.ReadLine();
    }

    public static void Sair()
    { 
        Console.WriteLine("Espero que tenha gostado!!");
    }
}
