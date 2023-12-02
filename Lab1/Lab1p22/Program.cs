using System;
class Program
{
    static void Main()
    {
        //Получаем размер матрицы
        Console.Write("Enter matrix size: ");
        int size = int.Parse(Console.ReadLine());

        //Заполняем и выводим исходную матрицу
        Random r = new Random();
        int[,] matrix = new int[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = r.Next(-10, 10);
            }
        }

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }


        //Считаем сумму в положительный рядах
        int total = 0;
        int sum = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
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
        Console.WriteLine($"Sum in rows without negatives: {total}");

        // Считаем суммы всех диагоналей параллельных главной, выбираем минимум
        int min = int.MaxValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int dSum = 0;
            for (int j = 0; i + j < matrix.GetLength(0); j++)
            {
                dSum += matrix[i + j, j];
            }

            if (dSum < min)
            {
                min = dSum;
            }
        }
        Console.WriteLine($"Minimum sum: {min}");
    }
}


