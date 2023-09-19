internal class Program
{
    private static void Main(string[] args)
    {
        int choice;

        do
        {
            Console.WriteLine("\nВыберите задачу для выполнения:\n1. Task 51\n2. Task 58\n3. Task 77\n4. Task 114\n5. Task 175\n0. Выйти\n");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        task51();
                        break;
                    case 2:
                        task58();
                        break;
                    case 3:
                        task77();
                        break;
                    case 4:
                        task114();
                        break;
                    case 5:
                        task175();
                        break;
                    case 0:
                        Console.WriteLine("Выход из программы.");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите числовое значение.");
            }
        } while (choice != 0);
    }


    /// <summary>
    /// Заполняет и выводит массив из N элементов с начальным значением заданным А[0]!=0, по принципу A[i]=A[i div 2] + A[i-1].
    /// </summary>
    static void task51()
    {
        Random random = new();
        int firstArrayNumber;
        const int N = 10;
        int[] arrayOfNumbers = new int[N];

        do
        {
            firstArrayNumber = random.Next(-5, 5);
        } while (firstArrayNumber == 0);
        arrayOfNumbers[0] = firstArrayNumber;

        Console.Write($"Итоговый массив: {arrayOfNumbers[0]}");
        for (int i = 1; i < N; i++)
        {
            arrayOfNumbers[i] = arrayOfNumbers[i >> 1] + arrayOfNumbers[i - 1];
            Console.Write($" {arrayOfNumbers[i]}");
        }
    }

    /// <summary>
    /// Упорядочивает по возрастанию два вектора {x_i}, {x_i}, где i=1, ..., 10. Объединяет их в один вектор {z_i}, i = 1, ..., 20, так чтобы сохранилась упорядоченность 
    /// (p.s. "так чтобы сохранилась упорядоченность" имеет два значения: 1. чтобы сохранилась упорядоченность двух векторов; 2. чтобы сохранилась упорядоченность вектора по возрастанию.).
    /// </summary>
    static void task58()
    {
        Random random = new();
        const byte N = 10;
        int[] vectorX = new int[N], vectorY = new int[N], vectorZ = new int[N << 1];

        for (int i = 0; i < N; i++)
        {
            vectorX[i] = random.Next(-10, 10);
            vectorY[i] = random.Next(-10, 10);
        }

        Array.Sort(vectorX);
        Array.Sort(vectorY);

        Console.WriteLine("Отсортированный вектор Х: ");
        for (int i = 0; i < N; i++)
        {
            Console.Write($"{vectorX[i]} ");
        }

        Console.WriteLine("\nОтсортированный вектор Y: ");
        for (int i = 0; i < N; i++)
        {
            Console.Write($"{vectorY[i]} ");
        }

        //1 интерпретация задания 
        Array.Copy(vectorX, vectorZ, N);
        Array.Copy(vectorY, 0, vectorZ, N, N);

        Console.WriteLine("\nИтоговый вектор Z (сохраненная упорядоченность двух векторов): ");
        for (int i = 0; i < vectorZ.Length; i++)
        {
            Console.Write($"{vectorZ[i]} ");
        }


        //2 интерпретация задания
        int elementNumberVectorX = 0, elementNumberVectorY = 0, elementNumberVectorZ = 0;

        while (elementNumberVectorX < N && elementNumberVectorY < N)
        {
            if (vectorX[elementNumberVectorX] < vectorY[elementNumberVectorY])
            {
                vectorZ[elementNumberVectorZ++] = vectorX[elementNumberVectorX++];
            }
            else
            {
                vectorZ[elementNumberVectorZ++] = vectorY[elementNumberVectorY++];
            }
        }

        while (elementNumberVectorX < N)
        {
            vectorZ[elementNumberVectorZ++] = vectorX[elementNumberVectorX++];
        }

        while (elementNumberVectorY < N)
        {
            vectorZ[elementNumberVectorZ++] = vectorY[elementNumberVectorY++];
        }

        Console.WriteLine("\nИтоговый вектор Z (сохраненная упорядоченность вектора по возрастанию): ");
        for (int i = 0; i < vectorZ.Length; i++)
        {
            Console.Write($"{vectorZ[i]} ");
        }
    }

    /// <summary>
    /// Дана непустая последовательность целых чисел, оканчивающаяся числом –1. Определяет, есть ли в последовательности хотя бы одно число, кратное 7. 
    /// В случае положительного ответа определяет порядковый номер первого из таких чисел.
    /// </summary>
    static void task77()
    {
        Random random = new();
        const byte N = 10;
        int multipleOfSevenFound = 0;
        int[] arrayIntegerNumbers = new int[N];

        for (int i = 0; i < N; i++)
        {
            arrayIntegerNumbers[i] = random.Next(-10, 10);

            Console.Write($"{arrayIntegerNumbers[i]} ");

            if (arrayIntegerNumbers[i] % 7 == 0 && multipleOfSevenFound == 0)
            {
                multipleOfSevenFound = i;
            }
        }
        arrayIntegerNumbers[N - 1] = -1;

        if (multipleOfSevenFound == 0)
        {
            Console.WriteLine("\nЗначения кратного семи в массиве нет.");
        }
        else
        {
            Console.WriteLine($"\nЗначение кратное семи найдено. Это {multipleOfSevenFound} значение в массиве.");
        }
    }

    /// <summary>
    /// На k-e место одномерного массива целых чисел вставить элемент, равный квадрату суммы 5-го и 10-го элементов .
    /// </summary>
    static void task114()
    {
        Random random = new();
        const byte N = 10;
        int[] arrayIntegerNumbers = new int[N];
        int k;

        for (int i = 0; i < N; i++)
        {
            arrayIntegerNumbers[i] = random.Next(-10, 10);
            Console.WriteLine($"{i}: {arrayIntegerNumbers[i]} ");
        }

        Console.WriteLine("Введите порядковый номер элемента k который будет равен квадрату суммы 5-го и 10-го элементов \n(4 и 9 если по порядковому номеру): ");

        do
        {
            k = Convert.ToInt32(Console.ReadLine());
            if (k > N - 1 || k < 0)
            {
                Console.WriteLine("Введите существующий номер элемента: ");
            }
        } while (k > N - 1 || k < 0);

        //Возведение во вторую степень умножением работает во много раз быстрее чем pow(), но правило быть ленивым тоже хорошее)
        arrayIntegerNumbers[k] = (arrayIntegerNumbers[4] + arrayIntegerNumbers[9]) * (arrayIntegerNumbers[4] + arrayIntegerNumbers[9]);

        Console.WriteLine("Итоговый вид массива: ");
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine($"{i}: {arrayIntegerNumbers[i]} ");
        }
    }

    /// <summary>
    /// С помощью датчика случайных чисел создать массив целых чисел, элементы которого отличаются от своих соседей по массиву на малую величину, например, не более, чем на 10 %. 
    /// Такие массивы находят применение, например, при создании проверочных тестов в задачах об изменении атмосферного давления или температуры воздуха по дням месяца и т. п.
    /// </summary>
    static void task175()
    {
        const byte N = 10;
        int[] arrayIntegerNumbers = new int[N];
        Random random = new();
        int range;

        arrayIntegerNumbers[0] = random.Next(-100, 100);
        Console.Write($"Итоговый массив имеет вид: {arrayIntegerNumbers[0]}");

        for (int i = 1; i < N; i++)
        {
            range = Math.Abs(arrayIntegerNumbers[i - 1] / 10);
            arrayIntegerNumbers[i] = random.Next(arrayIntegerNumbers[i - 1] - range, arrayIntegerNumbers[i - 1] + range);
            Console.Write($" {arrayIntegerNumbers[i]}");
        }
    }
}