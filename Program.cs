using System;

using EcologicalModelingLib;

namespace EcologicalModeling
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Ocean ocean = new Ocean(); 
            OceanConsoleViewer consoleViewer = new OceanConsoleViewer(ocean);

            consoleViewer.PrintOceanSize();

            OceanInitializer oceanInitializer;
            do
            {
                Console.Write("Input number of preys: ");
                int numOfPreys = int.Parse(Console.ReadLine());
                Console.Write("Input number of predators: ");
                int numOfPredators = int.Parse(Console.ReadLine());
                Console.Write("Input number of obstacle: ");
                int numOfObstacle = int.Parse(Console.ReadLine());
                try
                {
                    oceanInitializer = new OceanInitializer(ocean, numOfPreys,numOfPredators, numOfObstacle);
                }
                catch (InvalidEntitiesNumExeption ex)
                {
                    Console.WriteLine(ex.Message);
                    oceanInitializer = null;
                    Console.WriteLine("Try again\n");
                }

            } while (oceanInitializer == null);
            

            oceanInitializer.InitializeOcean();

            Process(consoleViewer, ocean);

            Console.ReadKey();

        }

        public static void Process(OceanConsoleViewer consoleViewer, Ocean ocean)       
        {
            int numOfSteps = consoleViewer.GetNumOfSteps();

            consoleViewer.PrintOcean();
            Console.WriteLine();
            consoleViewer.PrintStatus();
            Console.WriteLine();

            for (int i = 0; i < numOfSteps; i++)
            {
                Console.WriteLine("Step {0}\n", i + 1);

                if (!consoleViewer.IsOver())
                {
                    ocean.Run();
                    consoleViewer.PrintOcean();
                }
                else
                {
                    Console.WriteLine("Game is over!");

                    Console.WriteLine();
                    consoleViewer.PrintStatus();
                    return;
                }

                Console.WriteLine();
                consoleViewer.PrintStatus();

                Console.WriteLine();

                //Thread.Sleep(1000);
                //Console.Clear();
            }

            Console.WriteLine("Game is over!");

        }

    }
}
