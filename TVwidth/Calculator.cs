using System;
using System.Windows;

namespace TVwidth
{
    public class Calculator
    {
        /// <summary>
        /// Коэффициент для преобразования дюймов в сантиметры
        /// </summary>
        const double rate = 2.54;

        /// <summary>
        /// Вычисляет ширину и высоту по диогонали
        /// </summary>
        /// <param name="diagonal">Диагональ</param>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        /// <returns>Размер</returns>
        public static Size Execute(int diagonal, int width, int height)
        {
            var size = new Size();
            var c2 = diagonal ^ 2;
            var k = Math.Sqrt(width * width + height * height);
            var x = diagonal / k;
            size.Width = width * x * rate;
            size.Height = height * x * rate;
            return size;
        }
    }
}
