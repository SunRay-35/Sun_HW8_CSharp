// Задача 4. (*) Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int[,] CreateArrayOfInt(int rows, int cols) // Создает спирально заполненный двумерный массив с заданой размерностью
{
    int[,] temp = new int[rows, cols];
    int i = 0;
    int j = 0;
    int current = 1;
    int finish = rows * cols;
    bool isUp = false; // переменная проверяет движется ли спираль вверх и не дает сразу же повернуть направо
    while (current <= finish)
    {
        temp[i, j] = current;
        current++;
        if (j != cols - 1 && temp[i, j + 1] == 0 && !isUp) j++; // вправо
        else if (i != rows - 1 && temp[i + 1, j] == 0) i++; // вниз
        else if (j != 0 && temp[i, j - 1] == 0) j--; // влево
        else if (i != 0 && temp[i - 1, j] == 0) // вверх
        {
            i--;
            isUp = true;
        }
        else if (j != cols - 1 && temp[i, j + 1] == 0) // разворот направо
        {
            j++;
            isUp = false;
        }
    }
    return temp;
}

int WhatDigitCapacity(int number) // Определение количества разрядов числа
{
    int count = 0;
    while (number > 0)
    {
        number /= 10;
        count++;
    }
    return count;
}

void PrintArrayOfInt(int[,] array) // Печать двумерного массива целых чисел
{
    string format = $"D{WhatDigitCapacity(array.GetLength(0) * array.GetLength(1))}"; // Определяем необходимое количество нулей слева от цифры
    for (int i = 0; i < array.GetLength(0); i++)
    {
        System.Console.Write($"{array[i, 0].ToString(format)}\t");
        for (int j = 1; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i, j].ToString(format)}\t");
        }
        System.Console.WriteLine();
    }
}

void Execute() // Основное тело программы
{
    System.Console.Clear();
    System.Console.WriteLine("Данная программа генерирует спирально заполненный массив.");

    // === Блок с константами для удобного управления параметрами массива ===
    const int rowsInArray = 10;
    const int colsInArray = 10;
    // === Конец блока констант ===

    int[,] arrayOfInt = CreateArrayOfInt(rowsInArray, colsInArray);
    PrintArrayOfInt(arrayOfInt);
}

Execute();