using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace NUnitTests
{
    public class Class1
    {

        [Test]
        public void SumOfTwoNumbers_1()
            //1-ожидаемое
            //2-то что получилось
        {
            Assert.AreEqual(10.0,calculator.summ(5.0, 5.0));

        }
        [Test]
        public void SumOfTwoNumbers_2()
        {
            Assert.AreEqual(0.0, calculator.summ(-5.0, 5.0));

        }
        [Test]
        public void SumOfTwoNumbers_3()
        {
            Assert.AreEqual(-10.0, calculator.summ(-5.0, -5.0));

        }

        [Test]
        public void SumOfTwoNumbers_4()
        {
            Assert.AreEqual(0.0, calculator.summ(0.0, 0.0));

        }

        [Test]
        public void SumOfTwoNumbers_5()
       {
            Assert.AreEqual(5.0, calculator.summ(5.0, 0.0));

        }



        ///////////////////////////////////////////////
        [Test]
        public void minusOfTwoNumbers_1()
        //1-ожидаемое
        //2-то что получилось
        {
            Assert.AreEqual(0.0, calculator.minus(5.0, 5.0));

        }
        [Test]
        public void minusOfTwoNumbers_2()
        {
            Assert.AreEqual(-10.0, calculator.minus(-5.0, 5.0));

        }
        [Test]
        public void minusOfTwoNumbers_3()
        {
            Assert.AreEqual(0.0, calculator.minus(-5.0, -5.0));

        }

        [Test]
        public void minusOfTwoNumbers_4()
        {
            Assert.AreEqual(0.0, calculator.minus(0.0, 0.0));

        }

        [Test]
        public void minusOfTwoNumbers_5()
        {
            Assert.AreEqual(5.0, calculator.minus(5.0, 0.0));

        }
        //////////////////////////////////////////////
        [Test]
        public void multiplicationOfTwoNumbers_1()
        //1-ожидаемое
        //2-то что получилось
        {
            Assert.AreEqual(25.0, calculator.multiplication(5.0, 5.0));

        }
        [Test]
        public void multiplicationOfTwoNumbers_2()
        {
            Assert.AreEqual(-25.0, calculator.multiplication(-5.0, 5.0));

        }
        [Test]
        public void multiplicationOfTwoNumbers_3()
        {
            Assert.AreEqual(25.0, calculator.multiplication(-5.0, -5.0));

        }

        [Test]
        public void multiplicationOfTwoNumbers_4()
        {
            Assert.AreEqual(0.0, calculator.multiplication(0.0, 0.0));

        }

        [Test]
        public void multiplicationOfTwoNumbers_5()
        {
            Assert.AreEqual(0.0, calculator.multiplication(5.0, 0.0));

        }
        /////////////////////////////////////////////////////////

        [Test]
        public void differenceOfTwoNumbers_1()
        //1-ожидаемое
        //2-то что получилось
        {
            Assert.AreEqual(1.0, calculator.difference(5.0, 5.0));

        }
        [Test]
        public void differenceOfTwoNumbers_2()
        {
            Assert.AreEqual(-1.0, calculator.difference(-5.0, 5.0));

        }
        [Test]
        public void differenceOfTwoNumbers_3()
        {
            Assert.AreEqual(1.0, calculator.difference(-5.0, -5.0));

        }

        [Test]
        public void differenceOfTwoNumbers_4()
        {
            Assert.IsNaN(calculator.difference(0.0, 0.0));

        }

        [Test]
        public void differenceOfTwoNumbers_5()
        {
            Assert.IsNotNull(calculator.difference(5.0, 0.0));

        }
    }
}
