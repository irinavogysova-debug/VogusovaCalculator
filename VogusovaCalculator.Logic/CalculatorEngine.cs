using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VogusovaCalculator.Logic 
{

    /// <summary>
    /// Основной класс, реализующий математическую логику калькулятора
    /// </summary>
    public class CalculatorEngine
    {
        /// <summary>
        /// Универсальный метод для выполнения операции
        /// </summary>
        public double Calculate(double a, double b, Operation op)
        {
            switch (op)
            {
                case Operation.Add:
                    return Add(a, b);
                case Operation.Subtract:
                    return Subtract(a, b);
                case Operation.Multiply:
                    return Multiply(a, b);
                case Operation.Divide:
                    return Divide(a, b);
                case Operation.Power:
                    return Power(a, b);
                default:
                    throw new InvalidOperationException($"Операция '{op}' не поддерживается.");
            }
        }

        /// <summary>
        /// Сложение
        /// </summary>
        public double Add(double a, double b) => a + b;

        /// <summary>
        /// Вычитание
        /// </summary>
        public double Subtract(double a, double b) => a - b;

        /// <summary>
        /// Умножение
        /// </summary>
        public double Multiply(double a, double b) => a * b;

        /// <summary>
        /// Деление с проверкой деления на ноль
        /// </summary>
        public double Divide(double a, double b)
        {
            if (Math.Abs(b) < 1e-10)
                throw new DivideByZeroException("Деление на ноль невозможно.");
            return a / b;
        }

        /// <summary>
        /// Возведение в степень
        /// </summary>
        public double Power(double a, double b) => Math.Pow(a, b);
    }
}