using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialMath
{
    public class Polynomial
    {
        private double[] coefficients;
        private int maxPower;

        public int MaxPower
        {
            get { return maxPower; }
        }

        public Polynomial(int maxPower)
        {
            int defaultMaxPower = 5;

            if (maxPower <= 0)
            {
                maxPower = defaultMaxPower;
            }

            this.maxPower = maxPower;
            coefficients = new double[maxPower + 1];
        }

        public double this[int power]
        {
            get
            {
                if (IsValidPower(power))
                {
                    return coefficients[power];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Power should me greater/equlas 0 and less/equals than polynom's power");
                }
            }
            set
            {
                if (IsValidPower(power))
                {
                    coefficients[power] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Power should me greater/equlas 0 and less/equals than polynom's power");
                }
            }
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder polynomial = new StringBuilder();

            for (int i = maxPower; i >= 0; i--)
            {
                if (coefficients[i] != default(double))
                {
                    char sign = coefficients[i] > 0 ? '+' : '-';

                    if (!(polynomial.Length == 0 && sign == '+'))
                    {
                        polynomial.Append(sign);
                    }

                    polynomial.AppendFormat("{0}*X^{1}", Math.Abs(coefficients[i]), i);
                }
            }

            return polynomial.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((Polynomial)obj);
        }

        public bool Equals(Polynomial p)
        {
            if ((object)p == null)
            {
                return false;
            }

            int maxPower = this.MaxPower > p.MaxPower ? this.MaxPower : p.MaxPower;
            double eps = 0.000001;

            for (int i = 0; i <= maxPower; i++)
            {
                if (this.IsValidPower(i) && p.IsValidPower(i) && Math.Abs(this[i] - p[i]) > eps)
                {
                    return false;
                }
                else if (this.IsValidPower(i) && !p.IsValidPower(i) && this[i] != default(double))
                {
                    return false;
                }
                else if (!this.IsValidPower(i) && p.IsValidPower(i) && p[i] != default(double))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Equals(Polynomial a, Polynomial b)
        {
            if ((object)a == null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static Polynomial Sum(Polynomial a, Polynomial b)
        {
            int power = a.MaxPower > b.MaxPower ? a.MaxPower : b.MaxPower;

            Polynomial sum = new Polynomial(power);

            for (int i = 0; i < sum.coefficients.Length; i++)
            {
                if (a.IsValidPower(i))
                {
                    sum[i] += a[i];
                }

                if (b.IsValidPower(i))
                {
                    sum[i] += b[i];
                }
            }

            return sum;
        }

        public static Polynomial Multiply(Polynomial a, Polynomial b)
        {
            int power = a.MaxPower + b.MaxPower;

            Polynomial result = new Polynomial(power);

            for (int i = 0; i < a.coefficients.Length; i++)
            {
                for (int j = 0; j < b.coefficients.Length; j++)
                {
                    result[i + j] += a[i] * b[j];
                }
            }

            return result;
        }

        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            return Sum(a, b);
        }

        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            return Multiply(a, b);
        }

        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            Polynomial reversedPolynomial = new Polynomial(b.MaxPower);

            for (int i = 0; i < reversedPolynomial.coefficients.Length; i++)
            {
                reversedPolynomial.coefficients[i] = -b.coefficients[i];
            }

            return Sum(a, reversedPolynomial);
        }

        public static bool operator ==(Polynomial a, Polynomial b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Polynomial a, Polynomial b)
        {
            return !Equals(a, b);
        }

        public bool IsValidPower(int power)
        {
            return power >= 0 && power < coefficients.Length;
        }
    }
}
