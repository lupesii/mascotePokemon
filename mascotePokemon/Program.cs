using mascotePokemon.Modelos;
using mascotePokemon.Menus;
using Newtonsoft.Json;
using RestSharp;
using System.Text.Json;

List<MascotePokemon> ListaDePokemon = new();

void ExibirOpcoes()

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

    switch (opcaoEscolhida)
    {
        case 1:
            Menu.AdotaMascote(ListaDePokemon);
            ExibirOpcoes();
            break;

        case 2:
            Menu.MascotesAdotados(ListaDePokemon);
            ExibirOpcoes();
            break;

        case 3:
            Menu.Sair();
            break;

        default:
            Console.WriteLine("Opção Inválida");
            break;
    }

}

ExibirOpcoes();