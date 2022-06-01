using System;
using JogoInversao.Board.Exceptions;

namespace Board
{
    internal class Tabuleiro
    {
        public char[] Tab { get; set; }
        public int NumMovimentos { get; set; }
        public int InterromperJogo { get; set; }
        public int JogoTerminado { get; set; }


        public Tabuleiro()
        {
            Tab = new char[9];
            NumMovimentos = 0;
            InterromperJogo = 0;
            JogoTerminado = 0;
        }

        public void IniciarTabuleiro()
        {
            for(int i = 0; i < 4; i++)
            {
                Tab[i] = 'A';
                Tab[i + 5] = 'B';
            }

            Tab[4] = '-';
        }

        public void MostrarTabuleiro()
        {
            Console.WriteLine();

            for (int i = 1; i <= Tab.Length; i++)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            for (int i = 0; i < Tab.Length; i++)
            {
                Console.Write($"{Tab[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

      
        public void MoverPeca(int posicao)
        {
            // testa se o movimento é válido
            if (posicao == 0)
            {
                InterromperJogo = 1;

                throw new TabuleiroException("Voce decidiu sair do jogo!");
            }
            
            if (posicao < 1 || posicao > 9)
            {
                throw new TabuleiroException("Número inválido! Digite um número entre 1 e 9!");
            }

            int vazio = 0;
            for (int i = 0; i < Tab.Length; i++)
            {
                if (Tab[i] == '-')
                {
                    vazio = i;
                }
            }

            if ((posicao-1) == vazio)
            {
                throw new TabuleiroException("Você selecionou a casa vazia, tente novamente!");
            }
                       
            if (Math.Abs(posicao-(vazio+1))>2)
            {
                throw new TabuleiroException("A distancia máxima é de duas casas!");
            }

            // faz o movimento
            Console.WriteLine($"Movimento de {posicao} para {vazio+1}");
            char aux = Tab[posicao -1];
            Tab[posicao -1] = '-';
            Tab[vazio] = aux;
            NumMovimentos++;
        }


        public void VerificarFim()
        {
            if (Tab[0] == 'B' && Tab[1] == 'B' && Tab[2] == 'B' && Tab[3] == 'B' && Tab[4] == '-')
            {
                JogoTerminado = 1;
            }
            
        }

        public override string ToString()
        {
            if (NumMovimentos < 24)
            {
                return "Parabens! você completou o jogo em " + NumMovimentos + " Movimentos. ";
                   
            }
            return "Você completou o jogo em " + NumMovimentos + " Movimentos. O ideal é conseguir em menos de 24!"; 
        }
    }
}
