using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class EstruturaDeRepeticao
    {
        static void Main(string[] args)
        {
            for(var i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                Console.WriteLine($"Argumento: {arg}");
            }
        }
    }
}
