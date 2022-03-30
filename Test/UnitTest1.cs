using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_4;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Исходные данные для теста.
            Double[] myArray = { 2, 4, 5, 3 };

            // Ожидаемое значение 4032
            Double experted = 4032;

            // Вызов тестируемой функции.
            Form1 form1 = new Form1();
            Double actual = form1.searchY(myArray);

            Assert.AreEqual(experted, actual, 0.00, "Ожидаемое среднее арифметическое положительных элементов массива не было получено!");
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Исходные данные для теста.
            Double[] myArray = { 5, 2, 1, 7, 3 };

            // Ожидаемое значение 77220
            Double experted = 77220;

            // Вызов тестируемой функции.
            Form1 form1 = new Form1();
            Double actual = form1.searchY(myArray);

            Assert.AreEqual(experted, actual, 0.00, "Ожидаемое среднее арифметическое положительных элементов массива не было получено!");
        }


    }
}
