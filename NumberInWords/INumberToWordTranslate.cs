﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberInWords
{
    /// <summary>
    /// Представляет преобразователь числа в текст
    /// </summary>
    interface INumberToWordsTranslate
    {
        /// <summary>
        /// Получить текстовое представление числа
        /// </summary>
        /// <returns>Строка представляющая число</returns>
        string Translate();
        
        /// <summary>
        /// Целая часть числа
        /// </summary>
        long IntegralPart { get; }

        /// <summary>
        /// Дробная часть числа
        /// </summary>
        int FractionalPart { get; }

        /// <summary>
        /// Представляет наименьшее возможное значение для трансляции. Это поле является константой.
        /// </summary>
        decimal MinValue { get; }

        /// <summary>
        /// Представляет наибольшее возможное значение для трансляции. Это поле является константой.
        /// </summary>
        decimal MaxValue { get; }

    }
}
