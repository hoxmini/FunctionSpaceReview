public class QuadraticFunction : LinearFunction
    {
        protected double[,] A;

        public QuadraticFunction(double[,] A, double[] b, double c) : base(b, c)
        {
            this.A = A;
        }

        public static QuadraticFunction operator +(QuadraticFunction f1, QuadraticFunction f2)
        {
            int n = f1.A.GetLength(0);
            double[,] newA = new double[n, n];
            double[] newB = new double[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    newA[i, j] = f1.A[i, j] + f2.A[i, j];
                }
                newB[i] = f1.b[i] + f2.b[i];
            }
            return new QuadraticFunction(newA, newB, f1.c + f2.c);
        }

        public static QuadraticFunction operator -(QuadraticFunction f1, QuadraticFunction f2)
        {
            int n = f1.A.GetLength(0);
            double[,] newA = new double[n, n];
            double[] newB = new double[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    newA[i, j] = f1.A[i, j] - f2.A[i, j];
                }
                newB[i] = f1.b[i] - f2.b[i];
            }
            return new QuadraticFunction(newA, newB, f1.c - f2.c);
        }

        public static QuadraticFunction operator *(double scalar, QuadraticFunction f)
        {
            int n = f.A.GetLength(0);
            double[,] newA = new double[n, n];
            double[] newB = new double[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    newA[i, j] = scalar * f.A[i, j];
                }
                newB[i] = scalar * f.b[i];
            }
            return new QuadraticFunction(newA, newB, scalar * f.c);
        }

        public static QuadraticFunction operator *(QuadraticFunction f, double scalar)
        {
            int n = f.A.GetLength(0);
            double[,] newA = new double[n, n];
            double[] newB = new double[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    newA[i, j] = scalar * f.A[i, j];
                }
                newB[i] = scalar * f.b[i];
            }
            return new QuadraticFunction(newA, newB, scalar * f.c);
        }

        public override string ToString()
        {
            string result = "f(x) = ";
            int n = A.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result = result + A[i, j] + "*x" + (i + 1) + "*x" + (j + 1) + " + ";
                }
            }
            for (int i = 0; i < n; i++)
            {
                result = result + b[i] + "*x" + (i + 1) + " + ";
            }
            result = result + c;
            return result;
        }

        public new static QuadraticFunction Parse(string input)
        {
            string[] parts = input.Split(';');
            string[] aStrings = parts[0].Split(',');
            int n = (int)Math.Sqrt(aStrings.Length);
            double[,] A = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = double.Parse(aStrings[i * n + j]);
                }
            }
            string[] bStrings = parts[1].Split(',');
            double[] b = new double[n];
            for (int i = 0; i < n; i++)
            {
                b[i] = double.Parse(bStrings[i]);
            }
            double c = double.Parse(parts[2]);
            return new QuadraticFunction(A, b, c);
        }

        // Переопределяем Evaluate с учётом квадратичной части
        public override double Evaluate(double[] x)
        {
            double sum = 0;
            int n = A.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum = sum + A[i, j] * x[i] * x[j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                sum = sum + b[i] * x[i];
            }
            return sum + c;
        }

        // Переопределяем градиент: ∇f(x) = (A + Aᵀ)x + b
        public override double[] GetGradient(double[] x)
        {
            int n = A.GetLength(0);
            double[] grad = new double[n];
            for (int i = 0; i < n; i++)
            {
                grad[i] = b[i];
                for (int j = 0; j < n; j++)
                {
                    grad[i] += (A[i, j] + A[j, i]) * x[j];
                }
            }
            return grad;
        }
    }
