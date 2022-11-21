// Задача 52: Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

int[,] GetRandomArray(int row, int column, int minValue, int maxValue)
{
    int[,] result = new int[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintBivariateArray(int[,] array)
{
    const int SIZE = 6;
    int indexBitDepth = BitDepth(array.GetLength(0));
    int rawLenght = (indexBitDepth + 2) + (SIZE + 2);
    int colomnCount = 0;
    while (rawLenght < Console.WindowWidth)
    {
        rawLenght += (SIZE + 2);
        colomnCount++;
    }
    int endRaw = colomnCount;
    for (int k = 0; k <= (array.GetLength(1)  - 1) / colomnCount; k++)
    {
        if (endRaw > array.GetLength(1)) endRaw = array.GetLength(1);
        for (int i = 0; i < indexBitDepth; i++) Console.Write("_");
        Console.Write("_|");
        for (int i = k * colomnCount; i < endRaw; i++)
        {
            for (int j = 0; j < SIZE - BitDepth(i); j++) Console.Write($"_");
            Console.Write($"{i}_|");
        }
        for (int i = 0; i < array.GetLength(0); i++)
        {
            Console.Write("\n");
            for (int l = 0; l < indexBitDepth - BitDepth(i); l++) Console.Write(" ");
            Console.Write($"{i} |");
            for (int j = k * colomnCount; j < endRaw; j++)
            {
                Console.Write($"{array[i, j],SIZE} |");
            }
        }
        endRaw += colomnCount;
        Console.WriteLine("\n");
    }
}

int BitDepth(int number)
{
    int result = 0;
    while (Math.Abs(number) > 0)
    {
        number /= 10;
        result++;
    }
    if (result == 0) result = 1;
    return result;
}

double[] ColomnAverage(int[,] array)
{
    double[] result = new double[array.GetLength(1)];
    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            result[i] += array[j, i];
        }
    }
    for (int i = 0; i < result.Length; i++)
    {
        result[i] /= array.GetLength(0);
    }
    return result;
}

int[,] randIntArr = GetRandomArray(15, 10, -1000, 1000);
PrintBivariateArray(randIntArr);
double[] average = ColomnAverage(randIntArr);
Console.Write("   ");
for (int i = 0; i < average.Length; i++)
{
    Console.Write($"{average[i],8:f}");
}