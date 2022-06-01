using System;
using Board;
using JogoInversao.Board.Exceptions;

namespace JogoInversao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro();
            char jogarNovamente = 's';

            do
            {
                tab.InterromperJogo = 0;
                tab.JogoTerminado = 0;
                tab.IniciarTabuleiro();
                Console.WriteLine("--JOGO DA INVERSÃO--");
                tab.MostrarTabuleiro();

                do
                {
                    Console.Write("Qual peça deseja mover? ");
                    int move = int.Parse(Console.ReadLine());
                    try
                    {
                        tab.MoverPeca(move);
                        tab.MostrarTabuleiro();
                    }

                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message.ToString());
                        Console.WriteLine();
                    }

                    tab.VerificarFim();
                } while (tab.InterromperJogo == 0 && tab.JogoTerminado == 0);


                if (tab.JogoTerminado == 1)
                {
                    Console.WriteLine(tab.ToString());
                }

                Console.Write("Deseja jogar novamente? (s/n): ");
                jogarNovamente = char.Parse(Console.ReadLine());

            } while (jogarNovamente == 's');
        }
    }
}
