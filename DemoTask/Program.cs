using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoTask
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Example();
                string rs = Console.ReadLine();
                Console.WriteLine("You typed:" + rs);
            }
        }

        static async void Example()
        {
            var src = new CancellationTokenSource();
            var token = src.Token;
            Thread.Sleep(500);
            int test = await Task.Run(() => Allocate(token), token);
            Thread.Sleep(1000);
            Console.WriteLine("Main::Cancel");
            src.Cancel();
            Thread.Sleep(100);
            Console.WriteLine("Compute:" + test);
        }

        static int Allocate(CancellationToken token)
        {
            int size = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int z = 0; z < 1000000; z++)
                {
                    if (token.IsCancellationRequested)
                    {
                        return size;
                    }
                    string value = z.ToString();
                    size += value.Length;
                }
            }
            return size;
        }
    }
}
