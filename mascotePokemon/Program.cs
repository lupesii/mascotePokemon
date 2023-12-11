using mascotePokemon.Modelos;
using Newtonsoft.Json;
using RestSharp;

void ExibirOpcoes()
{
    Console.WriteLine("Bem vindo ao seu mascote pokemon!!");
    Console.WriteLine("Escolha a espécie:");
    var response = MethodGET.RequisicaoGet("https://pokeapi.co/api/v2/pokemon-species/");
    var EspeciesPokemon = JsonConvert.DeserializeObject<PokemonResult>(response.Content);
    
    for (int i = 0; i < EspeciesPokemon.Results.Count; i++)
    {
        Console.WriteLine($"{i + 1}.{EspeciesPokemon.Results[i].Name}");
    }

    Console.Write("Digite sua respota: ");
    int pokemonEscolhido = int.Parse(Console.ReadLine()!);

    while (true)
    {
        if (pokemonEscolhido <= EspeciesPokemon.Results.Count)
        {
            var especificacaoPokemon = MethodGET.RequisicaoGet($"https://pokeapi.co/api/v2/pokemon/{pokemonEscolhido}");
            var especificacaoPokemonConvert = JsonConvert.DeserializeObject<PokemonEspeciesResult>(especificacaoPokemon.Content);
            Console.WriteLine(especificacaoPokemonConvert);
            break;
        }
        else
        {
            Console.WriteLine("\n Opção invalida");
        }
    }
}
ExibirOpcoes();