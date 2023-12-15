using mascotePokemon.Menus;
using mascotePokemon.Modelos;

namespace mascotePokemon.Controller;

internal class PokegotchiController
{

    List<MascotePokemon> ListaDePokemon = new();

    public void Jogar()
    {
        Console.Clear();
        Console.WriteLine(@"
██████╗░░█████╗░██╗░░██╗███████╗░██████╗░░█████╗░████████╗░█████╗░██╗░░██╗██╗
██╔══██╗██╔══██╗██║░██╔╝██╔════╝██╔════╝░██╔══██╗╚══██╔══╝██╔══██╗██║░░██║██║
██████╔╝██║░░██║█████═╝░█████╗░░██║░░██╗░██║░░██║░░░██║░░░██║░░╚═╝███████║██║
██╔═══╝░██║░░██║██╔═██╗░██╔══╝░░██║░░╚██╗██║░░██║░░░██║░░░██║░░██╗██╔══██║██║
██║░░░░░╚█████╔╝██║░╚██╗███████╗╚██████╔╝╚█████╔╝░░░██║░░░╚█████╔╝██║░░██║██║
╚═╝░░░░░░╚════╝░╚═╝░░╚═╝╚══════╝░╚═════╝░░╚════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝╚═╝");
        Console.WriteLine("Seja bem-vindo a loja seu mascote pokemon!!\n");
        Console.WriteLine("Para entrar na loja, pressione qualquer tecla");
        Console.ReadKey();

        int opcaoEscolhida = Menu.ExibirMenu();

        while (true)
        {
            switch (opcaoEscolhida)
            {
                case 1:
                    Menu.AdotaMascote(ListaDePokemon);
                    Jogar();
                    break;

                case 2:
                    Menu.MascotesAdotados(ListaDePokemon);
                    Jogar();
                    break;

                case 3:
                    Menu.Sair();
                    break;

                default:
                    Console.WriteLine("Opção Inválida");
                    Thread.Sleep(500);
                    Jogar();
                    break;
            }
        }
    }
}
