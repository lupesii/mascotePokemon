namespace mascotePokemon.Modelos;

internal class PokemonResult
{
    public int Count { get; set; }
    public string Next { get; set; }
    public string Previous { get; set; }
    public List<PokemonEspeciesResult>Results { get; set; }
}
