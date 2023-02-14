using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //chiedere una % di errori e genera una posizione random di tali errori

            Random random= new Random();
            int temp, lunghezza=7, percentErrori=30, x, y;
            string parola;
            int[,] tabella = new int[7, lunghezza];
            int[,] tabellaMod = new int[7, lunghezza];
            bool[,] Errori = new bool[7, lunghezza];

            int[] PosizioniDis = new int[7 * lunghezza];
            int max = 7 * lunghezza;

            for (int i = 0; i < max; i++)
            {
                PosizioniDis[i] = i;
            }

            int[] bit_paritaOr = new int[7];

            int[] bit_paritaVert = new int[lunghezza];

bool[] colonne = new bool[7];

            bool[] righe = new bool[lunghezza];


            tabella = tabellaMod;

            Console.WriteLine("Inserire una parola di 7 caratteri: ");

            parola = Console.ReadLine();

            while (parola.Length != lunghezza)
            {
                Console.WriteLine("La parola inserita non è di una lunghezza adeguata\nInserire una nuova parola: ");
                parola = Console.ReadLine();
            }


            //calcolo del valore in ASCII e binario e riempimento tabella
            for (int i = 0; i < lunghezza; i++)
            {
                temp = parola[i];

                for (int j = 0; j < lunghezza; j++)
                {
                    tabella[i, j] = temp % 2;
                    temp = temp / 2;
                }
            }

            bit_paritaOr = parityOr(tabella);
            bit_paritaVert = parityVert(tabella);


            //scrittura tabella
            for (int i = 0; i < lunghezza; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(tabella[i, j] + "\t");
                }
                //call e stampa bit di parità orizzontale
                Console.Write(bit_paritaOr[i] + "\n");
            }

           

            //call e stampa bit di parità verticale
            for (int i = 0; i < 7; i++)
            {
                Console.Write(bit_paritaVert[i]+"\t");
            }

            for (int i=0; i < lunghezza*7*percentErrori/100; i++) //lunghezza*7*percentErrori/100 = calcolo il numero di elementi nella tabella e trovo il numero corrispondente alla percentuale
            {
                //estraggo una delle posizioni disponibili
                temp = random.Next(0, max);

                x = PosizioniDis[temp] % 7;
                y = PosizioniDis[temp] / 7;

              righe[y]=true;
              colonne[x]=true;
                Errori[x, y] = true;

                if (tabellaMod[x, y] == 0)
                {
                    tabellaMod[x, y] = 1;
                }
                else
                {
                    tabellaMod[x, y] = 0;
                }

                //"cancello" dalle posizioni disponibili la posizione estratta
                for (int j = temp; j < max - 1; j++)
                {
                    PosizioniDis[i] = PosizioniDis[i+1];
                }

                //diminuisco il numero di posizioni disponibili
                max--;

                
            }

            Console.WriteLine("\n\n\n");

            //scrittura tabella modificata
            for (int i = 0; i < lunghezza; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (Errori[i, j] == true)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }

                    Console.Write(tabellaMod[i, j] + "\t");

                    Console.BackgroundColor= ConsoleColor.Black;
                }
                //call e stampa bit di parità orizzontale
                Console.Write(bit_paritaOr[i] + "\n");
            }

            //call e stampa bit di parità verticale
            for (int i = 0; i < 7; i++)
            {
                Console.Write(bit_paritaVert[i] + "\t");
            }



Console.WriteLine("\n");
          

          for (int i = 0; i < lunghezza; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (righe[i] == true ^ colonne[j]==true)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }

                    Console.Write(tabellaMod[i, j] + "\t");

                    Console.BackgroundColor= ConsoleColor.Black;
                }
                //call e stampa bit di parità orizzontale
                Console.Write(bit_paritaOr[i] + "\n");
            }

            //call e stampa bit di parità verticale
            for (int i = 0; i < 7; i++)
            {
                Console.Write(bit_paritaVert[i] + "\t");
            }
        }
    }
