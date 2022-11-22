// Задача 3: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] CreateRandomArrayOfInt(int rows, int cols, int min, int max) // Создает двумерный массив с заданой размерностью и границами генерации целых чисел
{
    int[,] temp = new int[rows, cols];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            temp[i, j] = new Random().Next(min, max + 1);
        }
    }
    return temp;
}

void PrintArrayOfInt(int[,] array) // Печать двумерного массива целых чисел
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        System.Console.Write($"{array[i, 0]}\t");
        for (int j = 1; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i, j]}\t");
        }
        System.Console.WriteLine();
    }
}

int[] TakeRowFromArray(int[,] array, int row) // Выделяет конкретную строку в отдельный одномерный массив
{
    int[] temp = new int[array.GetLength(1)];
    for (int j = 0; j < array.GetLength(1); j++)
    {
        temp[j] = array[row, j];
    }
    return temp;
}

int[] TakeColumnFromArray(int[,] array, int col) // Выделяет конкретный столбец в отдельный одномерный массив
{
    int[] temp = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        temp[i] = array[i, col];
    }
    return temp;
}

int MultiplyArray(int[] row, int[] col) // Перемножает два одномерных массива одинаковой размерности
{
    int temp = 0;
    for (int i = 0; i < row.Length; i++)
    {
        temp += row[i] * col[i];
    }
    return temp;
}

int[,] MultiplyMatrix(int[,] arrayFirst, int[,] arraySecond) // Умножаем первую матрицу на вторую матрицу, условие возможности умножить учтено в константе - размеры не проверяем
{
    int[,] res = new int[arrayFirst.GetLength(0), arraySecond.GetLength(1)];
    for (int i = 0; i < arrayFirst.GetLength(0); i++)
    {
        for (int j = 0; j < arraySecond.GetLength(1); j++)
        {
            res[i,j] = MultiplyArray(TakeRowFromArray(arrayFirst, i), TakeColumnFromArray(arraySecond, j));
        }
    }
    return res;
}

void Execute() // Основное тело программы
{
    System.Console.Clear();
    System.Console.WriteLine("Данная программа генерирует 2 массива из целых чисел и находит их произведение.");

    // === Блок с константами для удобного управления параметрами массива ===
    const int countFirstColsAndSecondRows = 2; // Условие для того, чтобы матрицы можно было умножить
    const int rowsInFirst = 2;
    const int colsInSecond = 3;
    const int minOfRandom = 0;
    const int maxOfRandom = 5;
    // === Конец блока констант ===

    int[,] arrayFirst = CreateRandomArrayOfInt(rowsInFirst, countFirstColsAndSecondRows, minOfRandom, maxOfRandom);
    PrintArrayOfInt(arrayFirst);
    System.Console.WriteLine();
    int[,] arraySecond = CreateRandomArrayOfInt(countFirstColsAndSecondRows, colsInSecond, minOfRandom, maxOfRandom);
    PrintArrayOfInt(arraySecond);
    System.Console.WriteLine();
    int [,] arrayMultiplied = MultiplyMatrix(arrayFirst, arraySecond);
    PrintArrayOfInt(arrayMultiplied);
}

Execute();