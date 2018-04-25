using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;

namespace QuizAppServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting communication process.");

            using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("QuizPipe", PipeDirection.Out))
            {
                Console.WriteLine("Connection object has been created.");

                Console.WriteLine("Waiting for connection.");

                pipeServer.WaitForConnection();

                Console.WriteLine("Connection Complete.");
                try
                {
                    using (StreamWriter writer = new StreamWriter(pipeServer))
                    {
                        writer.AutoFlush = true;
                        writer.WriteLine(DateTime.Now.ToString("h:mm:ss"));
                    }
                }
                catch (IOException e) 
                {
                    Console.WriteLine("ERROR: {0}", e.Message);
                }
            }
        }
    }
}
