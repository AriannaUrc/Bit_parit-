using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static int[] parityOr(int[,] binario)
        {
            int[] bit_parità = new int[7];
            int somma;

            for (int i = 0; i < 7; i++)
            {
                somma = 0;
                for (int j = 0; j < 7; j++)
                {
                    somma = somma + binario[i, j];
                }
                if (somma % 2 == 0)
                {
                    bit_parità[i] = 1;
                }
                else
                {
                    bit_parità[i] = 0;
                }

            }

            return bit_parità;
        }

        public static int[] parityVert(int[,] binario)
        {
            int[] bit_parità = new int[7];
            int somma;

            for (int i = 0; i < 7; i++)
            {
                somma = 0;
                for (int j = 0; j < 7; j++)
                {
                    somma = somma + binario[j, i];
                }
                if (somma % 2 == 0)
                {
                    bit_parità[i] = 1;
                }
                else
                {
                    bit_parità[i] = 0;
                }

            }

            return bit_parità;
        }

        public static void visualizzazione(int[] binario)
        {
            Console.WriteLine("Inserire una parola di 7 caratteri: ");

        }

        static void Main(string[] args)
        {
            int temp;
            string parola;
            int[,] tabella = new int[7, 7];
            int[] bit_paritaOr = new int[7];
            int[] bit_paritaVert = new int[7];

            Console.WriteLine("Inserire una parola di 7 caratteri: ");

            parola = Console.ReadLine();

            while (parola.Length != 7)
            {
                Console.WriteLine("La parola inserita non è di una lunghezza adeguata\nInserire una nuova parola: ");
                parola = Console.ReadLine();
            }



            for (int i = 0; i < 7; i++)
            {
                temp = parola[i];

                for (int j = 0; j < 7; j++)
                {
                    tabella[i, j] = temp % 2;
                    temp = temp / 2;
                }
            }

            bit_paritaOr = parityOr(tabella);
            bit_paritaVert = parityVert(tabella);

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(tabella[i, j] + "\t");
                }
                Console.Write(bit_paritaOr[i] + "\n");
            }

            for (int i = 0; i < 7; i++)
            {
                Console.Write(bit_paritaVert[i]+"\t");
            }
        }
    }
}