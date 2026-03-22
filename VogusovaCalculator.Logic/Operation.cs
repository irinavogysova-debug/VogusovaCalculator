using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VogusovaCalculator.Logic
{
    /// <summary>
    /// Перечисление поддерживаемых арифметических операций
    /// </summary>
    public enum Operation
    {
        None,       // Нет операции (начальное состояние)
        Add,        // Сложение (+)
        Subtract,   // Вычитание (-)
        Multiply,   // Умножение (*)
        Divide,     // Деление (/)
        Power       // Возведение в степень (^)
    }
}
