using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab7;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 form1 = new Form1();

            // Исходные данные для теста.
            double[] array =   {  0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            // Ожидаемое значение
            string experted = "0 1 2 3 4 5 6 7 8 9 ";

            double razn = 0, srZnach = 0;

            // Вызов тестируемой функции.
            string actual = form1.SearchNumber(array, srZnach, razn);

            Assert.AreEqual(experted, actual, "Ожидаемый индексы небыли получены!");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Form1 form1 = new Form1();

            // Исходные данные для теста.
            double[] array = { 8, -1, 2, -3.641, 4, -5, 6, -7.7614, 0.4, -9 };

            // Ожидаемое значение
            string experted = "8 ";

            double razn = -1.00024, srZnach = -0.60024;

            // Вызов тестируемой функции.
            string actual = form1.SearchNumber(array, srZnach, razn);

            Assert.AreEqual(experted, actual, "Ожидаемый индексы небыли получены!");
        }
    }
}