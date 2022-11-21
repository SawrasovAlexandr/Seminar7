// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.


void dataInput(out int row, out int column, out int minValue, out int maxValue)
{
    row = 10;
    column = 20;
    minValue = -1000;
    maxValue = 1000;
    string[] data = { "количество строк", "количество столбцов" };
    for (int i = 0; i < data.Length; i++)
    {
        Console.Clear();
        string[] text ={$"Будет создан двумерный массив размером {row} на {column}, заполненный",
                        $"случайными вещественными числами из диапозона ({minValue}, {maxValue}).",
                        $"- Что бы изменить {data[i].ToUpper()} массива введите новое значение;",
                        $"- Что бы оставить {data[i].ToUpper()} массива без изменений нажмите Enter"};
        for (int j = 0; j < text.Length; j++) Console.WriteLine(text[j]);
        string? input = Console.ReadLine();
        if (String.IsNullOrEmpty(input)) continue;
        if (i == 0) row = GetPositiveInt(input);
        if (i == 1) column = GetPositiveInt(input);
    }
    Console.Clear();
    Console.WriteLine($"Cоздан двумерный массив размером {row} на {column}, заполненный " +
                      $"случайными вещественными числами из диапозона ({minValue}, {maxValue})\n");
}

int GetPositiveInt(string? value)
{
    int number = 0;
    while (!int.TryParse(value, out number) || number <= 0)
    {
        Console.Write("Введенное выражение не является положительным целым числом. Повторите ввод: ");
        value = Console.ReadLine();
    }
    return number;
}

double[,] GetRandomDoubleArray(int row, int column, int minValue, int maxValue)
{
    double[,] result = new double[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue) + new Random().NextDouble();
        }
    }
    return result;
}

void PrintBivariateArray(double[,] array)
{
    const int SIZE = 8;
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
                Console.Write($"{array[i, j],SIZE:f} |");
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

dataInput(out int row, out int column, out int minValue, out int maxValue);
double[,] array = GetRandomDoubleArray(row, column, minValue, maxValue);
PrintBivariateArray(array);
