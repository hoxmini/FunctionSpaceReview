using System;

namespace FunctionSpace
{
    public class LinearFunction
    {
        protected double[] b;
        protected double c;

        public LinearFunction(double[] b, double c)
        {
            this.b = b;
            this.c = c;
        }

        public static LinearFunction operator +(LinearFunction f1, LinearFunction f2)
        {
            double[] newB = new double[f1.b.Length];
            for (int i = 0; i < f1.b.Length; i++)
            {
                newB[i] = f1.b[i] + f2.b[i];
            }
            return new LinearFunction(newB, f1.c + f2.c);
        }

        public static LinearFunction operator -(LinearFunction f1, LinearFunction f2)
        {
            double[] newB = new double[f1.b.Length];
            for (int i = 0; i < f1.b.Length; i++)
            {
                newB[i] = f1.b[i] - f2.b[i];
            }
            return new LinearFunction(newB, f1.c - f2.c);
        }

        public static LinearFunction operator *(double scalar, LinearFunction f)
        {
            double[] newB = new double[f.b.Length];
            for (int i = 0; i < f.b.Length; i++)
            {
                newB[i] = scalar * f.b[i];
            }
            return new LinearFunction(newB, scalar * f.c);
        }

        public static LinearFunction operator *(LinearFunction f, double scalar)
        {
            double[] newB = new double[f.b.Length];
            for (int i = 0; i < f.b.Length; i++)
            {
                newB[i] = scalar * f.b[i];
            }
            return new LinearFunction(newB, scalar * f.c);
        }

        public override string ToString()
        {
            string result = "f(x) = ";
            for (int i = 0; i < b.Length; i++)
            {
                result = result + b[i] + "*x" + (i + 1);
                if (i < b.Length - 1)
                {
                    result = result + " + ";
                }
            }
            result = result + " + " + c;
            return result;
        }

        public static LinearFunction Parse(string input)
        {
            string[] parts = input.Split(';');
            string[] bStrings = parts[0].Split(',');
            double[] b = new double[bStrings.Length];
            for (int i = 0; i < bStrings.Length; i++)
            {
                b[i] = double.Parse(bStrings[i]);
            }
            double c = double.Parse(parts[1]);
            return new LinearFunction(b, c);
        }

        public double Evaluate(double[] x)
        {
            double sum = 0;
            for (int i = 0; i < b.Length; i++)
            {
                sum = sum + b[i] * x[i];
            }
            return sum + c;
        }

        public double[] GetGradient()
        {
            return b;
        }
    }
