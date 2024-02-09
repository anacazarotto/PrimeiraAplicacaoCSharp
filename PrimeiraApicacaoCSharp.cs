using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace Alura_TrilhaDev
{
    class Program
    {
        static void Main(string[] args)
        {
            //screensound

            //List<string> ListaBandas = new List<string> {"Black Pink", "One Direction", "BTS"};

            Dictionary<string, List<int>> BandasRegistradas = new Dictionary<string, List<int>>();
            BandasRegistradas.Add("Linkin Park", new List<int> { 10, 10, 10 });
            BandasRegistradas.Add("Panic! At The Disco", new List<int> { 10, 10, 10 });


            void Exibir()
            {
                string mensagem = "\nBoas vindas ao ScreenSound";
                Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");

                Console.WriteLine(mensagem);

            }

            void ExibirMenu()
            {
                Console.WriteLine("\nDigite 1 para registrar uma banda");
                Console.WriteLine("\nDigite 2 para mostrar todas as bandas");
                Console.WriteLine("\nDigite 3 para avaliar uma banda");
                Console.WriteLine("\nDigite 4 para exibir média de uma banda");
                Console.WriteLine("\nDigite -1 para sair");

                Console.Write("\nDigite a sua opção: ");
                string OpcaoEscolhida = Console.ReadLine()!;
                int OpcaoEscolhidaNumerica = int.Parse(OpcaoEscolhida);

                switch (OpcaoEscolhidaNumerica)
                {
                    case 1: RegistrarBandas();
                        break;
                    case 2: MostrarBandas();
                        break;
                    case 3: AvaliarBanda() ;
                        break;
                    case 4: CalcularMedia(); 
                        break;
                    case -1: Console.WriteLine("Tchau! :)");
                        break;
                    default: Console.WriteLine("Opção inválida, escolha outro número.");
                        Thread.Sleep(4000);
                        Console.Clear();
                        Exibir();
                        ExibirMenu();

                        break;
                }
            }

            void RegistrarBandas()
            {
                TitulosOpcoes("Registro de bandas");
                //Console.Clear();
                //Console.WriteLine("Registro de Bandas");
                //Console.Write("Digite o nome da banda que deseja registar: ");
                string NomeBanda = Console.ReadLine()!;
                BandasRegistradas.Add(NomeBanda, new List<int>());
                //ListaBandas.Add(NomeBanda);
                Console.WriteLine($"A banda {NomeBanda} foi registrada com sucesso.");
                Thread.Sleep(2000);
                Console.Clear();
                Exibir();
                ExibirMenu();
            }

            void MostrarBandas() 
            {
                Console.Clear();
                TitulosOpcoes("Exibindo bandas registradas");
                //Console.WriteLine("***************************\n");
                //Console.WriteLine("Exibindo bandas registradas");
                //Console.WriteLine("***************************\n");
                //for (int i = 0; i < ListaBandas.Count; i++) 
                //{
                    //Console.WriteLine($"Banda Registrada: {ListaBandas[i]}");
                //}

                foreach(string Banda in BandasRegistradas.Keys) 
                {
                    Console.WriteLine($"Banda Registrada: {Banda}");
                }

                Console.WriteLine("\nPressione uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                Exibir(); 
                ExibirMenu();
            }

            void TitulosOpcoes(string Titulo)
            {
                int QuantidadeLetras = Titulo.Length;
                string Asteriscos = string.Empty.PadLeft(QuantidadeLetras);
                Console.WriteLine(Asteriscos);
                Console.WriteLine(Titulo + "\n");
            }

            void CalcularMedia()
            {
                Console.Clear();
                TitulosOpcoes("Calcular média da banda");
                Console.Write("Digite nome da banda que deseja ver a média: ");
                string NomeBanda = Console.ReadLine()!;
                if (BandasRegistradas.ContainsKey(NomeBanda))
                {
                    List<int> NotasBanda = BandasRegistradas[NomeBanda];
                    Console.WriteLine($"A média da banda {NomeBanda} é {NotasBanda.Average()}.");
                    Thread.Sleep(4000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"A {NomeBanda} não está registrada");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                    Exibir();
                    ExibirMenu();
                }
            }

            void AvaliarBanda()
            {
                Console.Clear();
                TitulosOpcoes("Avaliar banda");
                Console.Write("Digite nome da banda que deseja avaliar: ");
                string NomeBanda = Console.ReadLine()!;
                if (BandasRegistradas.ContainsKey(NomeBanda))
                {
                    Console.Write($"Qual a nota que a {NomeBanda} merece: ");
                    int nota = int.Parse(Console.ReadLine()!);
                    BandasRegistradas[NomeBanda].Add(nota);
                    Console.WriteLine($"A {nota} foi registrada com sucesso para a banda.");
                    Thread.Sleep(4000);
                    Console.Clear();
                    Exibir();
                    ExibirMenu();

                }
                else
                {
                    Console.WriteLine($"A {NomeBanda} não está registrada");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                    Exibir();
                    ExibirMenu();
                };
            }

            Exibir();

            ExibirMenu();

        }
    }
}
