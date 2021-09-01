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
                Console.WriteLine($"Argumento lido: {arg}");
            }

            foreach (var item in args)
            {
                Console.WriteLine($"Argumento lido no foreach: {item}");
            }


            var loops2 = 0;
            while (loops2 < args.Length)
            {
                var argumento = args[loops2];
                Console.WriteLine($"Argumento lido no while: {argumento}");
                loops2++;
            }


            var loops3 = 0;
            do
            {
                var argumento = args[loops3];
                Console.WriteLine($"Argumento lido no dowhile: {argumento}");
                loops3++;
            } while (loops3 < args.Length);
        }
    }
}
