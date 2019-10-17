using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace ProxyTwitter
{
    class Program
    {
        static void Main(string[] args)
        {
            LanguageFilter filter=LanguageFilter.English;
            int quantity = 0;
            string param;
            Console.WriteLine("Inserte el texto a buscar, si es un usuario escribalo de la forma @Usuario");
            param=Console.ReadLine();
            Console.Clear();

            while (true)
            {
                bool exit = true;
                Console.WriteLine("Inserte la cantidad de tweets que desea conseguir");
                try
                {
                    quantity = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("numero invalido");
                    exit = false;

                }

                if (exit) break;

            }
            var key=new ConsoleKeyInfo();
            while (true)
            {
                Console.Clear();

                bool exit = false;
                Console.WriteLine("Porfavor seleccione un lenguaje \n 1 - Ingles \n 2 - Espa~ol \n 3 - Aleman");

                key=Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        filter = LanguageFilter.English;
                        exit = true;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        filter = LanguageFilter.Spanish;
                        exit = true;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        filter = LanguageFilter.German;
                        exit = true;
                        break;
                }

                if (exit) break;
            }
            Console.Clear();

            Proxy proxy = new Proxy();
            var tweets = proxy.SearchTweets(param, filter, quantity);
            foreach (var line in tweets)
            {
                Console.Write(line);
            }



            Console.ReadKey();
        }
    }
}
