using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
        a: Console.Write("请选择章节：");
            var simple = new Simples();
            Console.Write("1 -- " + simple.chapKeys.Length + "\n");
            var cha = Console.Read();
            if(cha >= 49) simple.Start(cha -49);

            Console.WriteLine("Continue input :[y]");
            string key = Console.ReadLine();
            if (key.ToUpper() == "Y")
            {
                goto a;
            }
        }
    }
}
