// Задача 50: Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
//             и возвращает значение этого элемента или же указание, что такого элемента нет.

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
    const int SIZE = 5;
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

int GetPositiveInt(string? value)
{
    int number = 0;
    while (!int.TryParse(value, out number) || number < 0)
    {
        Console.Write("Введенное выражение не является положительным целым числом. Повторите ввод: ");
        value = Console.ReadLine();
    }
    return number;
}

int[,] array = GetRandomArray(10, 15, -1000, 1000);
PrintBivariateArray(array);
Console.Write("Введите номер строки искомого элемента массива: ");
int raw = GetPositiveInt(Console.ReadLine());
Console.Write("Введите номер столбца искомого элемента массива: ");
int column = GetPositiveInt(Console.ReadLine());
Console.Write(raw > array.GetLength(0) || column > array.GetLength(1) ?
"В массиве отсутствует элемент с введенным индексом\n" : $"Значение элемента с введенным индексом равно: {array[raw, column]}\n\n");