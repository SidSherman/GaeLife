using System;
using System.Runtime.CompilerServices;

namespace CSharpTask
{
    class CSharpTask2
    {
        static void Main()
        {

            while (true)
            {

                // Выбор задания

                Console.Clear();

                Console.WriteLine("Задание 1: Ввод значений матрицы с клавиатуры и подсчет суммы элементов");
                Console.WriteLine("Задание 2: Сумма двух матриц");
                Console.WriteLine("Задание 3: Игра 'Жизнь'");


                Console.WriteLine("Введите номер задания или 0, чтобы выйти: ");

                int taskNumber = -1;
                if (!int.TryParse(Console.ReadLine(), out taskNumber))
                {
                    Console.WriteLine("Введено недопустимое значение, нажмите Enter");
                    Console.ReadLine();
                    continue;
                }

                if(taskNumber == 1)
                {
                    EnterTheMarix();
                }
                if (taskNumber == 2)
                {
                    int[,] matrix1 = new int[3,3];
                    GenerateMatrix(matrix1);
                    int[,] matrix2 = new int[3, 3];
                    GenerateMatrix(matrix2);
                    SumMatrix(matrix1, matrix2);

                }
                if (taskNumber == 3)
                {
                    GameLife();
                }

                if (taskNumber == 0)
                {
                    break;
                }


            }

        }

        static void EnterTheMarix()
        {


            int rows;
            int collumns;
            int[,] matrix;

            Console.WriteLine("Введите количество строк: ");
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out rows))
                {
                    Console.WriteLine("Введено недопустимое значение, нажмите Enter");
                    Console.ReadLine();
                    continue;
                }
                else break;
            }

            Console.WriteLine("Введите количество столбцов: ");
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out collumns))
                {
                    Console.WriteLine("Введено недопустимое значение, нажмите Enter");
                    Console.ReadLine();
                    continue;
                }
                else break;
            }

            matrix = new int[rows, collumns];

            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Введдите значения элементов строки {i + 1} через Enter");
                for (int j = 0; j < collumns; j++)
                {
                    if (!int.TryParse(Console.ReadLine(), out matrix[i, j]))
                    {
                        Console.WriteLine("Введено недопустимое значение, нажмите Enter");
                        Console.ReadLine();
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        sum += matrix[i, j];

                    }
                }
            }

            ShowMarix(matrix, "MARTIX");

            Console.WriteLine($"Сумма элементов матрицы: {sum}");

        }

        static void SumMatrix(int[,] matrix1, int[,] matrix2)
        {

            int rows;
            int collumns;
            if(matrix1.GetLength(0) == matrix2.GetLength(0))
            {
                rows = matrix1.GetLength(0);
            }
            else
            {
                Console.WriteLine("Матрицы имеют разное количество строк");
                return;
            }

            if (matrix1.GetLength(1) == matrix2.GetLength(1))
            {
                collumns = matrix1.GetLength(1);
            }
            else
            {
                Console.WriteLine("Матрицы имеют разное количество столбцов");
                return;
            }

            int[,] resultMatrix = new int[rows, collumns];

            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j< collumns; j++)
                {
                    resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            ShowMarix(resultMatrix, "Сумма матриц");

        }

        static void ShowMarix(int[,] matrix, string matrixName)
        {

            int rows = matrix.GetLength(0);
            int collumns = matrix.GetLength(1);

            Console.WriteLine(matrixName);
            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < collumns; j++)
                {

                    Console.Write($"{matrix[i, j]} ");

                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }

        static void ShowMarix(bool[,] matrix, string matrixName)
        {

            int rows = matrix.GetLength(0);
            int collumns = matrix.GetLength(1);

            Console.WriteLine(matrixName);
            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < collumns; j++)
                {

                    if (matrix[i, j])
                    {
                        Console.Write("1 ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }

                }
                Console.WriteLine("");
            }
        }

        static void GenerateMatrix(int[,] matrix)
        {
            Random rand = new Random();


            int rows = matrix.GetLength(0);
            int collumns = matrix.GetLength(1);

           
            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < collumns; j++)
                {

                    matrix[i, j] = rand.Next(0,100);
                }
            }
            ShowMarix(matrix, "Сгенерированная матрица");
        }

        static void GenerateMatrix(bool[,] matrix, int probability)
        {
   

            int rows = matrix.GetLength(0);
            int collumns = matrix.GetLength(1);

            Random rand = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < collumns; j++)
                {
                    int value = rand.Next(0, 100);
                    if (value > probability)
                    {
                        matrix[i, j] = false;
                    }
                    else
                    {
                        matrix[i, j] = true;
                    }
                }
            }

           // ShowMarix(matrix, "Сгенерированная матрица");
        }


        static void GameLife()
        {

            int probability = 30;
            bool isPeriodic = false;
            bool[,] bacterries;

            #region input values

            while (true)
            {
                Console.WriteLine("Введите 0 для запуска с обычными правилами, 1 для запуска с периодическими правилами (учитаваются клетки с другой стороны массива)");

                int input;
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Введено недопустимое значение, нажмите Enter"); 
                    Console.ReadLine();
                }
                else
                {
                    if (input == 0)
                    {
                        isPeriodic = false;
                    }
                    else if (input == 1)
                    {
                        isPeriodic = true;
                    }
                    else
                    {
                        Console.WriteLine("Введено недопустимое значение, нажмите Enter");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                }

            }

            while (true)
            {
                Console.WriteLine("Введите вероятность появления жизни в клетке - число от 0 до 100");

                if (!int.TryParse(Console.ReadLine(), out probability))
                {
                    Console.WriteLine("Введено недопустимое значение, нажмите Enter");
                    Console.ReadLine();
                }
                else
                {
                    if(probability < 0 || probability > 100)
                    {
                        Console.WriteLine("Введено недопустимое значение, нажмите Enter");
                        Console.ReadLine();
                        continue;
                    }
                }
                    break;
                }



            Console.WriteLine("Введите длину чашки Петри");
            int rows = -1;
            int collumns = -1;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out rows))
                {
                    Console.WriteLine("Введено недопустимое значение, нажмите Enter");
                    Console.ReadLine();
                }
                else
                {
                    break;
                }
                
            }

            Console.WriteLine("Введите ширину чашки Петри");

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out collumns))
                {
                    Console.WriteLine("Введено недопустимое значение, нажмите Enter");
                    Console.ReadLine();
                }
                else
                {
                    break;
                }

            }

            #endregion

            bacterries = new bool[rows, collumns];

            // set arrays values
            GenerateMatrix(bacterries, probability);

            // Show Origin Array
            ShowMarix(bacterries, "Первое поколение");

            Console.WriteLine();

            int gen = 1;

            while (true)
            {
                gen++;

                bool[,] bacterriesTemp = new bool[bacterries.GetLength(0), bacterries.GetLength(1)];

                for (int i = 0; i < bacterries.GetLength(0); i++ )
                {
                    for (int j = 0; j < bacterries.GetLength(1); j++)
                    { 

                        int aliveCellsCount = 0;

                        int currentX;
                        int currentY;

                        // calculate values

                        if(isPeriodic)
                        {
                            for (int k = 0; k < 3; k++)
                            {

                                for (int t = 0; t < 3; t++)
                                {
                                    currentX = i - 1 + k;
                                    currentY = j - 1 + t;

                                    if (i - 1 + k < 0)
                                    {
                                        currentX = bacterries.GetLength(0) + (i - 1 + k);
                                    }
                                    if (j - 1 + t < 0)
                                    {
                                        currentY = bacterries.GetLength(1) + (j - 1 + t);
                                    }
                                    if (i - 1 + k >= bacterries.GetLength(0))
                                    {
                                        currentX = i - 1 + k - bacterries.GetLength(0);
                                    }
                                    if (j - 1 + t >= bacterries.GetLength(0))
                                    {
                                        currentY = j - 1 + t - bacterries.GetLength(1);
                                    }

                                    if (currentX != i || currentY != j)
                                    {
                                        if (bacterries[currentX, currentY] == true)
                                        {
                                            aliveCellsCount++;
                                        }
                                    }

                                }
                            }
                        }
                        else
                        {
                            for (int k = 0; k < 3; k++)
                            {

                                for (int t = 0; t < 3; t++)
                                {

                                    currentX = i - 1 + k;
                                    currentY = j - 1 + t;

                                    if ((currentX >= 0 && currentX < bacterries.GetLength(0)) &&
                                        (currentY >= 0 && currentY < bacterries.GetLength(1)) &&
                                        (currentX != i || currentY != j))
                                    {
                                        if (bacterries[currentX, currentY] == true)
                                        {
                                            aliveCellsCount++;
                                        }
                                    }

                                }

                            }

                        }

                        // count aliveCells
                        if (aliveCellsCount > 3)
                        {
                            bacterriesTemp[i, j] = true;
                        }
                        else if(aliveCellsCount < 2)
                        {
                            bacterriesTemp[i, j] = false;
                        }
                    }

                }

                Array.Copy(bacterriesTemp, bacterries, bacterries.Length);

                ShowMarix(bacterries, "Поколение " + gen );

                Console.WriteLine();

                Console.WriteLine("Нажмиет Enter, чтобы продолжить, введите 0, чтобы закончить");

                int input = -1;
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    continue;
                }
                else if (input == 0)
                {
                    break;
                }


            }    

        }
    }
}