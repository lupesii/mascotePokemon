namespace mascotePokemon.Modelos;

internal class MascotePokemon
{
    public string Name { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public List<PokemonHabilidadesDetalhes> Abilities { get; set; }


    public static void ExibirEstatisticas(MascotePokemon mascote)
    { 
        Console.Clear();
        Console.WriteLine($"PARABÉNS, SUA ESCOLHA FOI {mascote.Name}!\nESPERO QUE SEJAM FELIZES JUNTOS");
        Console.WriteLine("Detalhes:");
        Console.WriteLine($"- Nome: {mascote.Name}");
        Console.WriteLine($"- Altura: {mascote.Height}");
        Console.WriteLine($"- Peso: {mascote.Weight}");
        Console.WriteLine("Habilidades do pokemon: ");

        foreach (var i in mascote.Abilities)
        {
            Console.WriteLine($"Nome da habilidade: {i.Ability.Name}");
        }
    }
}
