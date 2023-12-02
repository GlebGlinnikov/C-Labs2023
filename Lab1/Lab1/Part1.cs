using System;
using System.Collections.Generic;

namespace Lab1
{
    public class Part1
    {
        private double[] arr;
        public Part1(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }
            arr = new double[size];
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = r.NextDouble() * 20 - 10;
            }
        }

        public double product_of_neg()
        {
            double product = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0) 
                {
                    product *= arr[i];
                }
            }
            return product;
        }
        public double sum_of_pos()
        {
            double max = arr[0];
            int maxIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }

            double sum = 0;
            for (int i = 0; i < maxIndex; i++)
            {
                if (arr[i] > 0)
                {
                    sum += arr[i];
                }
            }
            return sum; 
        }

        public void reverse()
        {
            Array.Reverse(arr);
        }

        public void print()
        {
            Console.WriteLine("Array:");
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        public double[] Vector
        {
            get
            {
                return arr;
            }
        }
    }
}
