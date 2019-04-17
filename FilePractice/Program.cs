using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FilePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> stat = new Dictionary<char, int>();

            Console.WriteLine("Введите путь к файлу:");
            string path = Console.ReadLine();
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] bytes = new byte[stream.Length];

                stream.Read(bytes, 0, bytes.Length);

                string data = System.Text.Encoding.UTF8.GetString(bytes);
                foreach (char symbol in data)
                {
                    if (stat.ContainsKey(symbol))
                    {
                        stat[symbol]++;
                    }
                    else
                    {
                        stat[symbol] = 0;
                    }
                }
                Console.WriteLine(data);
            }
            foreach (KeyValuePair<char, int> item in stat)
            {
                Console.WriteLine(item.Key + "\t\t" + item.Value);
            }
            Console.ReadLine();
        }
    }
}
