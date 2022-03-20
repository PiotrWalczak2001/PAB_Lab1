using System;
using System.IO;
using System.Text;

namespace Lab1_ex1_ex2_ex6
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1.Napisz program konsolowy za pomocą, którego można wyświetlić plik w konsoli (użyj: FileInputStream, try-with-resources)
            // 2.Napisz program konsolowy za pomocą, którego można zapisać plik używając danych wprowadzonych w konsoli (użyj: FileOutputStream, try-with-resources)
            // 6.Napisz program rozbijający plik na osobne linie. Wypisz je w konsoli, dodając numery. (https://dirask.com/posts/JavaScript-split-string-by-new-line-character-k1wEQp)
            Console.WriteLine("Lab1 Ex1 / Ex2 / Ex6");
            if (!File.Exists("newFile.txt"))
            {
                var fs = File.Create("newFile.txt");
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("1 2 3");
                sw.WriteLine("line 2");
                sw.WriteLine("line 3");
                sw.Close();
                fs.Close();
            }
            byte[] bytes = File.ReadAllBytes("newFile.txt");
            Console.WriteLine(Encoding.UTF8.GetString(bytes));

            var lines = File.ReadAllLines("newFile.txt");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
