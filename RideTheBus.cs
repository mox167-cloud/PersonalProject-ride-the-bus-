using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgettoRideTheBus.Murizzi
{
    internal class Program
    {
        //generatore di carte
        static int carta(){
            Random random = new Random(1);
            int carta = random.Next(1,14);
            return carta;
        }
        //check della risposta alto/basso
        static bool checkaltobasso(int carta1, int carta2, string risposta)
        {
            if (risposta == "H" && carta2 >= carta1)
            {
                return true;
            }
            else if (risposta == "L" && carta2 <= carta1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool checkintervallo(int carta1, int carta2, int carta3, string intervallo)
        {
            if (carta3 <= carta2 && carta3 >= carta1 && (intervallo =="Y")== true)
            {
                return true;
            }
            else if (carta3 >= carta2 || carta3 <= carta1 && (intervallo == "N") == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //generatore di colore (usato nel primo round)
        static bool colore(int primocolore)
        {
            Random random = new Random(1);
            int colore = random.Next(1,3);
            if (primocolore == colore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //check della risposta Y/N
        static bool risposta(string risposta)
            {
            if (risposta == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            //introduzione e spiegazione del gioco
            Console.WriteLine("Benvenuto in Ride The Bus di Murizzi Simone\n" +
                "ecco alcune cose che devi sapere prima di continuare...\n" +
                "alcune numeri corrispondono a determinate figure, ecco a te la legenda:\n" +
                "A = 1\n" +
                "J = 11\n" +
                "Q = 12\n" +
                "K = 13\n" +
                "Vuoi giocare? Y/N");
            string richiesta1 = Console.ReadLine().ToUpper();
            if (risposta(richiesta1) == true)
            {
                //primo round: indovina il colore della prima carta e stampa valore carta
                Console.Clear();
                int valorecarta1 = carta();
                Console.Write($"Il valore della carta e' {valorecarta1}, ricordatelo!\n" +
                "Indovina il colore della prima carta\n" +
                "1 per il colore ROSSO\n" +
                "2 per il colore NERO\n" +
                "inserisci un numero: ");
                int primocolore = int.Parse(Console.ReadLine());
                bool primoround = colore(primocolore);
                if (primoround == true)
                {
                    Console.Write("Hai indovinato il colore della prima carta! Vuoi continuare? Y/N ");
                    string richiesta2 = Console.ReadLine().ToUpper();
                    // secondo round: indovina se la seconda carta e' piu' alta o piu' bassa della prima carta
                    if (risposta(richiesta2) == true)
                    {
                        Console.Clear();
                        Console.WriteLine("prima carta= " + valorecarta1);
                        int valorecarta2 = carta();
                        Console.Write("Indovina se la seconda carta e' piu' alta o piu' bassa della prima carta\n" +
                            "inserisci H per piu' alta\n" +
                            "inserisci L per piu' bassa\n" +
                            "inserisci la tua risposta: ");
                        string altobasso = Console.ReadLine().ToUpper();
                        Console.WriteLine("valore seconda carta= " + valorecarta2);
                        if (checkaltobasso(valorecarta1,valorecarta2,altobasso) == true)
                        {
                            Console.WriteLine("Hai indovinato! Complimenti, hai vinto!");
                            Thread.Sleep(2000);
                            Console.Clear();
                            Console.WriteLine("valore prima carta "+ valorecarta1);
                            Console.WriteLine("valore seconda carta " + valorecarta2);
                            string richiesta3 = Console.ReadLine();
                            Console.Write("Hai indovinato l'intervalo di valore della seconda carta! Vuoi continuare? Y/N ");
                            if (risposta(richiesta3) == true)
                            {
                                Console.Clear();
                                Console.WriteLine("valore prima carta " + valorecarta1);
                                Console.WriteLine("valore seconda carta " + valorecarta2);
                                int valorecarta3 = carta();
                                Console.Write("la terza carta e' compresa nell'intervallo delle prime due carte? Y/N ");
                                string intervallo = Console.ReadLine().ToUpper();
                                if (checkintervallo(valorecarta1, valorecarta2, valorecarta3,intervallo)== true)
                                {
                                    Console.WriteLine("Complimenti, hai indovinato! ");
                                }
                                else
                                {
                                    Console.WriteLine("hai perso");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    Console.WriteLine("hai perso");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("hai perso");
                            Thread.Sleep(2000);
                            Console.Clear();
                            Console.WriteLine("hai perso");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Grazie per aver giocato!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Console.WriteLine("Grazie per aver giocato!");
                    }
                }
                else
                {
                    Console.WriteLine("Non hai indovinato il colore della prima carta! hai perso");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("Non hai indovinato il colore della prima carta! hai perso");
                }
            }
            else
            {
                Console.WriteLine("Grazie per aver giocato!");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Grazie per aver giocato!");
            }
        }
    }
}
