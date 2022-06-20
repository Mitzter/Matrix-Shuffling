using System;
using System.Linq;

namespace Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            int row = int.Parse(n.Split()[0]);
            int col = int.Parse(n.Split()[1]);

            string[,]matrix = new string[row, col];

            FillMatrix(matrix);


            string command;
            int matrixRows = matrix.GetLength(0);
            int matrixCols = matrix.GetLength(1);

            while ((command = Console.ReadLine()) != "END")
            {
                string[] splitCommand = command.Split().ToArray();
                if (splitCommand[0] != "swap" || splitCommand.Length < 5 || splitCommand.Length > 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;

                }
                int originalRow = int.Parse(splitCommand[1]);
                int originalCol = int.Parse(splitCommand[2]);
                int newRow = int.Parse(splitCommand[3]);
                int newCol = int.Parse(splitCommand[4]);
                
                

                if (splitCommand[0] == "swap")
                {
                    string[,] newMatrix = matrix;
                    if (originalRow > matrixRows || originalCol > matrixCols || newRow > matrixRows || newCol > matrixCols)
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    (matrix[originalRow, originalCol], matrix[newRow, newCol]) = (matrix[newRow, newCol], matrix[originalRow, originalCol]);
                    PrintMatrix(matrix);
                }

                
            }

        }

        private static void PrintMatrix(string[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.WriteLine();
            }
            
        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }
    }
    
}
