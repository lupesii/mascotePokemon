using mascotePokemon.Menus;

namespace mascotePokemon.Modelos;

internal class MascotePokemon
{
    public string Name { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public List<PokemonHabilidadesDetalhes> Abilities { get; set; }


    public static void ExibirEstatisticas(MascotePokemon mascote)
    { 
        Console.WriteLine("DETALHES DO POKEMON:");
        Console.WriteLine($"- NOME: {mascote.Name}");
        Console.WriteLine($"- ALTURA: {mascote.Height}");
        Console.WriteLine($"- PESO: {mascote.Weight}");
        Console.WriteLine("HABILIDADES DO POKEMON: ");

        foreach (var i in mascote.Abilities)
        {
            Console.WriteLine($"NOME DA HABILIDADE: {i.Ability.Name}");
        }
    }
}
internal class PokemonResult
{
    public int Count { get; set; }
    public string Next { get; set; }
    public string Previous { get; set; }
    public List<PokemonEspeciesResult> Results { get; set; }
}

internal class PokemonEspeciesResult
{
    public string Name { get; set; }
    public string Url { get; set; }
}

