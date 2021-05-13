using System;
using System.Collections.Generic;

namespace Task_1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            //SortMatrixByNorm();
            DivideMatrix();
        }

        private static void SortMatrixByNorm()
        {
            int[][] matrix = new int[4][];
            Dictionary<double, int[]> rowsDict = new Dictionary<double, int[]>();
            double[] rows = new Double[matrix.Length];
            matrix[0] = new[] { 1, 2, 3 };
            matrix[1] = new[] { 4, 5, 6 };
            matrix[2] = new[] { 7, 8, 9 };
            matrix[3] = new[] { 3, 5, 7 };
            foreach (var t in matrix)
            {
                int sum = 0;
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    sum += (int)Math.Pow(t[j], 2);
                }

                rowsDict.Add(Math.Sqrt(sum), t);
            }

            int k = 0;
            foreach (KeyValuePair<double, int[]> row in rowsDict)
            {
                rows[k] = row.Key;
                k++;
            }

            for (k = 0; k < matrix.Length; k++)
            {
                matrix[k] = rowsDict[SortInAscendingOrder(rows)[k]];
            }

            foreach (var t in matrix)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Console.Write(t[j]);
                }
                Console.WriteLine();
            }
        }

        private static double[] SortInAscendingOrder(double[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        double temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        private static void DivideMatrix()
        {
            int[][] arrays = new int[3][];
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 1, 2, 3 }, { 4, 5, 6 } };
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;
            string[] newFiles = { "file1", "file2", "file3" };

            for (int i = 0; i < columns; i++)
            {
                int[] column = new int[rows];
                for (int j = 0; j < rows; j++)
                {
                    column[j] = matrix[j, i];
                }

                arrays[i] = column;
                //WriteNewArrayIntoFile(newFiles[i], column);

            }

            foreach (int[] row in arrays)
            {
                foreach (int number in row)
                {
                    Console.Write(number);
                }
                Console.WriteLine();
            }
        }
    }
}
