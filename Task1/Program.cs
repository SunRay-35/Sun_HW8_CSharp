// Задача 1: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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

void SortRowInArray(int[,] array, int row, int direction) // Пузырьковая сортировка строки в массиве (direction (направление): 0 - по возрастанию, 1 - по убыванию)
{
    for (int k = 0; k < array.GetLength(1) - 1; k++) // Количество проходов
    {
        for (int j = 0; j < array.GetLength(1) - 1; j++) // Обход строки
        {
            if (direction == 0) // Определяем направление
            {
                if (array[row, j] > array[row, j + 1]) SwapElementsInRow(array, row, j, j + 1);
            }
            else
            {
                if (array[row, j] < array[row, j + 1]) SwapElementsInRow(array, row, j, j + 1);
            }
        }
    }
}

void SwapElementsInRow(int[,] array, int row, int colFirst, int colSecond) // Перестановка элементов местами
{
    (array[row, colFirst], array[row, colSecond]) = (array[row, colSecond], array[row, colFirst]);
}

void SortRowsInArray(int[,] array, int direction) // Обход массива по строкам и вызов метода сортировки
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        SortRowInArray(array, i, direction);
    }
}

void Execute() // Основное тело программы
{
    System.Console.Clear();
    System.Console.WriteLine("Данная программа генерирует массив из целых чисел и сортирует элементы внутри каждой строки по убыванию.");

    // === Блок с константами для удобного управления параметрами массива ===
    const int rowsInArray = 4;
    const int colsInArray = 3;
    const int minOfRandom = -5;
    const int maxOfRandom = 5;
    const int sortDirection = 1; // 0 - по возрастанию, 1 - по убыванию
    // === Конец блока констант ===

    int[,] arrayOfInt = CreateRandomArrayOfInt(rowsInArray, colsInArray, minOfRandom, maxOfRandom);
    PrintArrayOfInt(arrayOfInt);
    System.Console.WriteLine();
    SortRowsInArray(arrayOfInt, sortDirection);
    PrintArrayOfInt(arrayOfInt);
}

Execute();