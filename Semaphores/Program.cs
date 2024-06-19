using System;
using System.Threading;

namespace Semaphores
{
    internal class Program
    {
        // Erstellen eines Arrays von 10 Threads
        static Thread[] threads = new Thread[10];

        // Erstellen eines Semaphors mit einer Anfangszahl von 3 und einer maximalen Anzahl von 3
        static Semaphore sem = new Semaphore(3, 3);

        // Methode, die von den Threads ausgeführt wird
        static void sharpcorner()
        {
            // Gibt aus, dass der aktuelle Thread in der Warteschlange steht
            Console.WriteLine(0 + " is waiting in line...", Thread.CurrentThread.Name);

            // Der Thread fordert den Zugang zum kritischen Abschnitt an
            sem.WaitOne();

            // Der Thread betritt den kritischen Abschnitt
            Console.WriteLine(0 + " enters the sharpcorner.com!", Thread.CurrentThread.Name);

            // Simulieren der Arbeit im kritischen Abschnitt durch Schlafen für 300 Millisekunden
            Thread.Sleep(300);

            // Der Thread verlässt den kritischen Abschnitt
            Console.WriteLine(0 + " is leaving the sharpcorner.com", Thread.CurrentThread.Name);

            // Der Semaphoreplatz wird freigegeben, sodass ein anderer wartender Thread eintreten kann
            sem.Release();
        }
        static void Main(string[] args)
        {
            // Erstellen und Starten von 10 Threads
            for (int i = 0; i < 10; i++)
            {
                // Initialisieren eines neuen Threads, der die Methode C_sharpcorner ausführt
                threads[i] = new Thread(sharpcorner);

                // Benennen des Threads
                threads[i].Name = "thread_" + i;

                // Starten des Threads
                threads[i].Start();
            }

            // Wartet auf eine Eingabe vom Benutzer, um das Programm zu beenden
            Console.Read();
        }
    }
}
