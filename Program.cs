class Program
    {
        static void Main()
        {
            LinearFunction f1 = new LinearFunction(new double[] { 2, 3 }, 5);
            LinearFunction f2 = new LinearFunction(new double[] { 1, 4 }, 2);

            Console.WriteLine("Линейная функция 1: " + f1);
            Console.WriteLine("Линейная функция 2: " + f2);
            Console.WriteLine("Сложение: " + (f1 + f2));
            Console.WriteLine("Вычитание: " + (f1 - f2));
            Console.WriteLine("Умножение на 3: " + (3 * f1));

            double[] point = { 1, 2 };
            Console.WriteLine("Значение f1 в точке (1,2): " + f1.Evaluate(point));

            double[] grad = f1.GetGradient();
            Console.WriteLine("Градиент f1: (" + grad[0] + ", " + grad[1] + ")");

            string str = "2,3,5;4";
            LinearFunction f3 = LinearFunction.Parse(str);
            Console.WriteLine("Парсинг строки '" + str + "': " + f3);

            Console.WriteLine();

            double[,] A = { { 1, 0 }, { 0, 1 } };
            double[] b = { 2, 3 };
            QuadraticFunction q1 = new QuadraticFunction(A, b, 5);
            QuadraticFunction q2 = new QuadraticFunction(A, b, 2);

            Console.WriteLine("Квадратичная функция 1: " + q1);
            Console.WriteLine("Квадратичная функция 2: " + q2);
            Console.WriteLine("Сложение: " + (q1 + q2));
            Console.WriteLine("Вычитание: " + (q1 - q2));
            Console.WriteLine("Умножение на 2: " + (2 * q1));

            Console.WriteLine("Значение q1 в точке (1,2): " + q1.Evaluate(point));

            string quadStr = "1,0,0,1;2,3;5";
            QuadraticFunction q3 = QuadraticFunction.Parse(quadStr);
            Console.WriteLine("Парсинг строки '" + quadStr + "': " + q3);
        }
    }
}
