using mascotePokemon.Modelos;
using Newtonsoft.Json;
using RestSharp;
using System.Text.Json;

static void ExibirOpcoes()
{
    Console.WriteLine("Bem vindo ao seu mascote pokemon!!");
    Console.WriteLine("Escolha a espécie:");
    var response = MethodGET.RequisicaoGet("https://pokeapi.co/api/v2/pokemon-species/");
    var EspeciesPokemon = JsonConvert.DeserializeObject<PokemonResult>(response.Content!);
    
    for (int i = 0; i < EspeciesPokemon!.Results.Count; i++)
    {
        Console.WriteLine($"{i + 1}.{EspeciesPokemon.Results[i].Name}");
    }

    Console.Write("Digite sua respota: ");
    int pokemonEscolhido = int.Parse(Console.ReadLine()!);

    if (pokemonEscolhido <= EspeciesPokemon.Results.Count && pokemonEscolhido > 0)
    {
        var especificacaoPokemon = MethodGET.RequisicaoGet($"https://pokeapi.co/api/v2/pokemon/{pokemonEscolhido}");
        var mascote = JsonConvert.DeserializeObject<MascotePokemon>(especificacaoPokemon.Content!);
        MascotePokemon.ExibirEstatisticas(mascote!);
    }
    else
    {
        Console.WriteLine("\n Opção invalida");
    }
}

ExibirOpcoes();