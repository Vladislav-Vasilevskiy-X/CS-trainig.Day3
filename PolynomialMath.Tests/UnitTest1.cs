using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomialMath;

namespace PolynomialMathTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ToStringDifferentSigns()
        {
            Polynomial polynomial = new Polynomial(10);
            polynomial[2] = 3.4;
            polynomial[5] = 4;
            polynomial[0] = -1;

            string expected = "4*X^5+3,4*X^2-1*X^0";
            string actual = polynomial.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sum()
        {
            Polynomial a = new Polynomial(12);
            a[12] = 3;
            a[5] = -4;

            Polynomial b = new Polynomial(6);
            b[6] = 6;
            b[5] = 8;

            Polynomial sum = new Polynomial(12);
            sum[12] = 3;
            sum[6] = 6;
            sum[5] = 4;

            Assert.AreEqual(sum, Polynomial.Sum(a, b));
        }

        [TestMethod]
        public void OperatorSubstract()
        {
            Polynomial a = new Polynomial(12);
            a[12] = 3;
            a[6] = 6;
            a[5] = 4;

            Polynomial b = new Polynomial(6);
            b[6] = 6;
            b[5] = 8;

            Polynomial c = new Polynomial(12);
            c[12] = 3;
            c[5] = -4;

            //Assert.AreEqual(expected, actual);
            Assert.AreEqual(c, a - b);
        }

        [TestMethod]
        public void Multiply()
        {
            Polynomial a = new Polynomial(8);
            a[6] = 3;
            a[4] = -4;

            Polynomial b = new Polynomial(6);
            b[4] = 6;
            b[3] = 8;

            Polynomial product = new Polynomial(12);
            product[10] = 18;
            product[9] = 24;
            product[8] = -24;
            product[7] = -32;

            Assert.AreEqual(product, Polynomial.Multiply(a, b));
        }

        [TestMethod]
        public void EqualsTheSameCoefficients()
        {
            Polynomial a = new Polynomial(8);
            a[6] = 3;
            a[4] = -4;

            Polynomial b = new Polynomial(6);
            b[6] = 3;
            b[4] = -4;

            Assert.AreEqual(true, Polynomial.Equals(a, b));
        }

        [TestMethod]
        public void EqualsDifferentCoefficients()
        {
            Polynomial a = new Polynomial(8);
            a[6] = 3;
            a[4] = -4;

            Polynomial b = new Polynomial(6);
            b[6] = 3;
            b[4] = -4;
            b[1] = 1;

            Assert.AreEqual(false, Polynomial.Equals(a, b));
        }

        [TestMethod]
        public void EqualsFirstParameterIsNull()
        {
            Polynomial a = null;

            Polynomial b = new Polynomial(6);
            b[6] = 3;
            b[4] = -4;

            Assert.AreEqual(false, Polynomial.Equals(a, b));
        }

        [TestMethod]
        public void EqualsSecondParameterIsNull()
        {
            Polynomial a = new Polynomial(8);
            a[6] = 3;
            a[4] = -4;

            Polynomial b = null;

            Assert.AreEqual(false, Polynomial.Equals(a, b));
        }
    }
}
