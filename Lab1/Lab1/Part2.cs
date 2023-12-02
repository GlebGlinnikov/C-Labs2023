using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Part2
    {
        private int[,] matrix;
        private int size;

        public Part2(int size)
        {
            this.size = size;
            Random r = new Random();
            matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = r.Next(-10, 10);
                }
            }
        }

        public void print()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        public int sum_in_pos_rows()
        {
            int total = 0;
            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        sum = 0;
                        break;
                    }
                    sum += matrix[i, j];
                }
                total += sum;
                sum = 0;
            }
            return total;
        }
        public int min_sum()
        {
            int min = int.MaxValue;
            for (int i = 0; i < size-1; i++)
            {
                int dSum = 0;
                for (int j = 0; i+j < size; j++)
                {
                    dSum += matrix[i + j, j];
                }

                if (dSum < min)
                {
                    min = dSum;
                }
            }

            for (int j = 1; j < size - 1; j++)
            {
                int dSum = 0;
                for (int i = 0; i + j < size; i++)
                {
                    dSum += matrix[i, i + j];
                }

                if (dSum < min)
                {
                    min = dSum;
                }
            }

            return min;
        }

        public int[,] Matrix
        {
            get
            {
                return matrix;
            }
        }

        public int Size
        {
            get {
                return size;
            }
        }
    }
}

