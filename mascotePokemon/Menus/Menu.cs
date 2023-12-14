using mascotePokemon.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mascotePokemon.Menus
{
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
            int opcaoEscolhida = int.Parse(Console.ReadLine()!);

            if (opcaoEscolhida > 0 && opcaoEscolhida < 4)
            {
                return opcaoEscolhida;
            }
            else Console.WriteLine("Opção Inválida"); return 0;
        }

        public static void AdotaMascote(List<MascotePokemon> ListaDePokemon)
        {
            Console.Clear();
            ExibirTituloDaOpcao("ADOTAR UM MASCOTE");

            Console.WriteLine("\nESCOLHA A ESPÉCIE:");
            var response = MethodGET.RequisicaoGet("https://pokeapi.co/api/v2/pokemon-species/");
            var EspeciesPokemon = JsonConvert.DeserializeObject<PokemonResult>(response.Content!);

            for (int i = 0; i < EspeciesPokemon!.Results.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{EspeciesPokemon.Results[i].Name.ToUpper()}");
            }

            Console.Write("\nESCOLHA: ");
            int pokemonEscolhido = int.Parse(Console.ReadLine()!);

            if (pokemonEscolhido > 0 && pokemonEscolhido < 20)
            {
                var especificacaoPokemon = MethodGET.RequisicaoGet($"https://pokeapi.co/api/v2/pokemon/{pokemonEscolhido}");
                MascotePokemon mascote = JsonConvert.DeserializeObject<MascotePokemon>(especificacaoPokemon.Content!)!;
                OpcoesMascote(mascote, ListaDePokemon);
            }
            else
            {
                Console.WriteLine("ESSE MASCOTE NÃO ESTÁ NA LISTA, TENTE NOVAMENTE");
                Thread.Sleep(2000);
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
            int opcaoEscolhida = int.Parse(Console.ReadLine()!);

            switch (opcaoEscolhida)
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
            else
            {
                Console.WriteLine("\n\nPUXA, LAMENTO MUITO SABER DISSO :(");
                Console.WriteLine("PRESSIONE UMA TECLA PARA VOLTAR AO MENU");
                Console.ReadKey();
                OpcoesMascote(mascote, ListaDePokemon);
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
}
