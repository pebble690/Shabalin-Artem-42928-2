using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab8;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 form1 = new Form1();

            // Исходные данные для теста
            double[,] array = new double[3, 3]
            {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
            };

            // Ожидаемые значения (минимальные элементы каждого столбца).
            double expected = 42;


            // Вызов тестируемой функции.
            double actual = form1.searchScalarProizv(array, 3);

            Assert.AreEqual(actual, expected, "Ожидаемые значения минимальных элементов каждого столбца не получены.");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Form1 form1 = new Form1();

            // Исходные данные для теста
            double[,] array = new double[4, 4]
            {
            {-1, 245, 456, 6},
            {4, -9, 6, 2},
            {7, -8, 90, 30},
            {1, 2, 3, 4}
            };

            // Ожидаемые значения (минимальные элементы каждого столбца).
            double expected = 2316;


            // Вызов тестируемой функции.
            double actual = form1.searchScalarProizv(array, 4);

            Assert.AreEqual(actual, expected, "Ожидаемые значения минимальных элементов каждого столбца не получены.");
        }
    }
}
