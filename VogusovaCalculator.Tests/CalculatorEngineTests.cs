using Microsoft.VisualStudio.TestTools.UnitTesting;
using VogusovaCalculator.Logic;
using System;

namespace VogusovaCalculator.Tests
{
    [TestClass]
    public class CalculatorEngineTests
    {
        private CalculatorEngine _engine = null!;

        [TestInitialize]
        public void Setup()
        {
            _engine = new CalculatorEngine();
        }

        // ========== ТЕСТЫ ДЛЯ СЛОЖЕНИЯ ==========
        [TestMethod]
        public void Add_PositiveNumbers_ReturnsSum()
        {
            double result = _engine.Add(5, 3);
            Assert.AreEqual(8, result, 0.001);
        }

        [TestMethod]
        public void Add_NegativeNumbers_ReturnsNegativeSum()
        {
            double result = _engine.Add(-5, -3);
            Assert.AreEqual(-8, result, 0.001);
        }

        [TestMethod]
        public void Add_PositiveAndNegative_ReturnsCorrectSum()
        {
            double result = _engine.Add(5, -3);
            Assert.AreEqual(2, result, 0.001);
        }

        [TestMethod]
        public void Add_Zero_ReturnsSameNumber()
        {
            double result = _engine.Add(5, 0);
            Assert.AreEqual(5, result, 0.001);
        }

        // ========== ТЕСТЫ ДЛЯ ВЫЧИТАНИЯ ==========
        [TestMethod]
        public void Subtract_PositiveNumbers_ReturnsDifference()
        {
            double result = _engine.Subtract(10, 4);
            Assert.AreEqual(6, result, 0.001);
        }

        [TestMethod]
        public void Subtract_NegativeNumbers_ReturnsCorrectDifference()
        {
            double result = _engine.Subtract(-5, -3);
            Assert.AreEqual(-2, result, 0.001);
        }

        // ========== ТЕСТЫ ДЛЯ УМНОЖЕНИЯ ==========
        [TestMethod]
        public void Multiply_PositiveNumbers_ReturnsProduct()
        {
            double result = _engine.Multiply(4, 5);
            Assert.AreEqual(20, result, 0.001);
        }

        [TestMethod]
        public void Multiply_ByZero_ReturnsZero()
        {
            double result = _engine.Multiply(5, 0);
            Assert.AreEqual(0, result, 0.001);
        }

        // ========== ТЕСТЫ ДЛЯ ДЕЛЕНИЯ ==========
        [TestMethod]
        public void Divide_DivideByNonZero_ReturnsQuotient()
        {
            double result = _engine.Divide(10, 2);
            Assert.AreEqual(5, result, 0.001);
        }

        [TestMethod]
        public void Divide_DivideByZero_ThrowsException()
        {
            bool exceptionThrown = false;

            try
            {
                _engine.Divide(5, 0);
            }
            catch (DivideByZeroException)
            {
                exceptionThrown = true;
            }

            if (!exceptionThrown)
            {
                Assert.Fail("Ожидалось исключение DivideByZeroException, но оно не было выброшено");
            }
        }

        // ========== ТЕСТЫ ДЛЯ СТЕПЕНИ ==========
        [TestMethod]
        public void Power_PositiveExponent_ReturnsPower()
        {
            double result = _engine.Power(2, 3);
            Assert.AreEqual(8, result, 0.001);
        }

        [TestMethod]
        public void Power_ZeroExponent_ReturnsOne()
        {
            double result = _engine.Power(5, 0);
            Assert.AreEqual(1, result, 0.001);
        }

        [TestMethod]
        public void Power_NegativeExponent_ReturnsFraction()
        {
            double result = _engine.Power(2, -1);
            Assert.AreEqual(0.5, result, 0.001);
        }

        // ========== ТЕСТЫ УНИВЕРСАЛЬНОГО МЕТОДА CALCULATE ==========
        [TestMethod]
        public void Calculate_ValidAddOperation_ReturnsCorrectResult()
        {
            double result = _engine.Calculate(6, 2, Operation.Add);
            Assert.AreEqual(8, result, 0.001);
        }

        [TestMethod]
        public void Calculate_ValidSubtractOperation_ReturnsCorrectResult()
        {
            double result = _engine.Calculate(6, 2, Operation.Subtract);
            Assert.AreEqual(4, result, 0.001);
        }

        [TestMethod]
        public void Calculate_ValidMultiplyOperation_ReturnsCorrectResult()
        {
            double result = _engine.Calculate(6, 2, Operation.Multiply);
            Assert.AreEqual(12, result, 0.001);
        }

        [TestMethod]
        public void Calculate_ValidDivideOperation_ReturnsCorrectResult()
        {
            double result = _engine.Calculate(6, 2, Operation.Divide);
            Assert.AreEqual(3, result, 0.001);
        }

        [TestMethod]
        public void Calculate_ValidPowerOperation_ReturnsCorrectResult()
        {
            double result = _engine.Calculate(2, 3, Operation.Power);
            Assert.AreEqual(8, result, 0.001);
        }

        [TestMethod]
        public void Calculate_InvalidOperation_ThrowsException()
        {
            bool exceptionThrown = false;

            try
            {
                _engine.Calculate(5, 3, (Operation)999);
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }

            if (!exceptionThrown)
            {
                Assert.Fail("Ожидалось исключение InvalidOperationException, но оно не было выброшено");
            }
        }

        // ========== ПАРАМЕТРИЗОВАННЫЕ ТЕСТЫ ==========
        [TestMethod]
        [DataRow(5, 3, 8)]
        [DataRow(0, 0, 0)]
        [DataRow(-5, 3, -2)]
        [DataRow(1.5, 2.5, 4.0)]
        [DataRow(-1, -2, -3)]
        public void Add_MultipleValues_ReturnsCorrectSum(double a, double b, double expected)
        {
            double actual = _engine.Add(a, b);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        [DataRow(2, 3, 8)]
        [DataRow(4, 0.5, 2)]
        [DataRow(9, 0.5, 3)]
        [DataRow(16, 0.5, 4)]
        [DataRow(2, -1, 0.5)]
        public void Power_MultipleValues_ReturnsCorrectPower(double a, double b, double expected)
        {
            double actual = _engine.Power(a, b);
            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}