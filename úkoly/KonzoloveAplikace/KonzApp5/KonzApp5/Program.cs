using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static Queue<char> pismena = new Queue<char>();
        static int pocetZnaku = 0;

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Nedostatečný počet argumentů");
                return;
            }
            string path = args[0];
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);

                using (StreamWriter writer = new StreamWriter(args[1], false))
                {
                    while (!reader.EndOfStream)
                    {
                        char pismeno = (char)reader.Read();
                        pismena.Enqueue(pismeno);
                        pocetZnaku++;
                        writer.WriteLine($"{pismena.Dequeue()}");
                    }
                    writer.WriteLine($"Počet znaků je: {pocetZnaku}");
                }
            }
        }
    }
}