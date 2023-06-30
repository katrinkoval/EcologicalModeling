using System;

using EcologicalModelingLib;

namespace EcologicalModeling
{
    class OceanConsoleViewer
    {
        private IOceanView _ocean;

        public OceanConsoleViewer(IOceanView ocean)
        {
            _ocean = ocean;
        }

        public void PrintOcean()
        {
            PrintTopOfTable(_ocean.NumberOfColumns * 2);

            for (int i = 0; i < _ocean.NumberOfRows; i++)
            {
                Console.Write((char)TableItem.VerticalLine);

                for (int j = 0; j < _ocean.NumberOfColumns; j++)
                {
                    if(_ocean.IsEmpty(i, j))  
                    {
                        Console.Write((char)Image.EmptyCell);
                        Console.Write(" ");
                        continue;
                    }

                    Console.Write((char)_ocean.GetCell(i, j).CellImage);
                    Console.Write(" ");
                }

                Console.Write((char)TableItem.VerticalLine);
                Console.WriteLine();
            }

            PrintBottomOfTable(_ocean.NumberOfColumns * 2);

        }

        private void PrintTopOfTable(int length)
        {
            //Console.Write("   ");
            Console.Write((char)TableItem.LeftTopCorner);

            for (int p = 0; p < length; p++)
            {
                Console.Write((char)TableItem.HorizontalLine);
            }

            Console.Write((char)TableItem.RightTopCorner);
            Console.WriteLine();
        }

        private void PrintBottomOfTable(int length)
        {
            //Console.Write("   ");
            Console.Write((char)TableItem.LeftBottomCorner);

            for (int i = 0; i < length; i++)
            {
                Console.Write((char)TableItem.HorizontalLine);
            }

            Console.Write((char)TableItem.RightBottomCorner);
        }

        public void PrintStatus()
        {
            Console.WriteLine();
            Console.WriteLine("Number of preys: {0}, number of predators: {1}."
                                , GetNumOfEntity(Image.Prey), GetNumOfEntity(Image.Predator));            
        }

        public int GetNumOfSteps()
        {
            Console.Write("Input number of steps: ");

            return int.Parse(Console.ReadLine());
        }

        private int GetNumOfEntity(Image image)
        {
            int count = 0;

            for (int i = 0; i < _ocean.NumberOfRows; i++)
            {
                for (int j = 0; j < _ocean.NumberOfColumns; j++)
                {
                    if(_ocean.GetCell(i, j) != null && _ocean.GetCell(i, j).CellImage == image)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public bool IsOver()
        {
            return GetNumOfEntity(Image.Prey) == 0 || GetNumOfEntity(Image.Predator) == 0;
        }

        public void PrintOceanSize()
        {
            Console.WriteLine("Number of rows: {0}", _ocean.NumberOfRows);
            Console.WriteLine("Number of columns: {0}", _ocean.NumberOfColumns);
        }

    }
}
