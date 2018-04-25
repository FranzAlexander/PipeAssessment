using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;

namespace QuizAppClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "QuizPipe", PipeDirection.In))
            {
                Console.WriteLine("Waiting For Connection");
                pipeClient.Connect();

                Console.WriteLine("Connected to Pipe");
                Console.WriteLine("There are currently {0} pipe server instances open.", pipeClient.NumberOfServerInstances);
                Console.WriteLine("Current Time is.");

                using (StreamReader sr = new StreamReader(pipeClient))
                {
                    // Display the text to the console
                    string temp;
                    while ((temp = sr.ReadLine()) != null)
                    {
                        Console.WriteLine("Received from server: {0}", temp);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}

