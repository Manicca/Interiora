using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FunctionalityLibrary.Drawing;

namespace FunctionalityLibrary.Calulation
{
    public static class Distance
    {
        public static int GetFromPoints(Point p1, Point p2)
        {
            return (int)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private static bool IsAheadX(Point master, Point aheader)
        {
            if (Math.Abs(master.X - aheader.X) < 10)
                return true;
            return false;
        }

        private static bool IsAheadY(Point master, Point aheader)
        {
            if (Math.Abs(master.Y - aheader.Y) < 10)
                return true;
            return false;
        }
        /// <summary>
        /// Функция вычисляет находиться ли число между двумя положительными границами
        /// </summary>
        /// <param name="number">Число</param>
        /// <param name="left">Левая граница</param>
        /// <param name="right">Правая Граница</param>
        /// <returns></returns>
        public static bool IsBetween(int number, int left, int right)
        {
            if (left > right)
            {
                int lr = left;
                left = right;
                right = lr;
            }

            return ((number <= right+15) && (number >= left-15));

        }


        /// <summary>
        /// Функция перераспределяет координаты start и end. Для Фигуры f
        /// </summary>
        /// <param name="r">Фигура комнаты</param>
        /// <param name="start">Начальная координата нового объекта</param>
        /// <param name="end">Конечная координата нового объекта</param>
        private static void CalculateAheadPoints(Figure r, ref Point start, ref Point end)
        {
            if (IsBetween(end.Y, r.FirstLocationPoint.Y, r.SecondLocationPoint.Y))
            {
                if (IsAheadX(r.FirstLocationPoint, end))
                    end.X = r.FirstLocationPoint.X;
                if (IsAheadX(r.SecondLocationPoint, end))
                    end.X = r.SecondLocationPoint.X;
            }

            if (IsBetween(end.X, r.FirstLocationPoint.X, r.SecondLocationPoint.X))
            {
                if (IsAheadY(r.FirstLocationPoint, end))
                    end.Y = r.FirstLocationPoint.Y;
                if (IsAheadY(r.SecondLocationPoint, end))
                    end.Y = r.SecondLocationPoint.Y;
            }

            if (IsBetween(start.X, r.FirstLocationPoint.X, r.SecondLocationPoint.X))
            {
                if (IsAheadY(r.FirstLocationPoint, start))
                    start.Y = r.FirstLocationPoint.Y;
                if (IsAheadY(r.SecondLocationPoint, start))
                    start.Y = r.SecondLocationPoint.Y;
            }
            if (IsBetween(start.Y, r.FirstLocationPoint.Y, r.SecondLocationPoint.Y))
            {
                if (IsAheadX(r.FirstLocationPoint, start))
                    start.X = r.FirstLocationPoint.X;
                if (IsAheadX(r.SecondLocationPoint, start))
                    start.X = r.SecondLocationPoint.X;
            }
        }
        public static void CalculateBonders(ref Point start, ref Point end, PictureBox pictureBox1, List<KeyValuePair<Bitmap, Figure>> history = null)
        {
            if (end.X > pictureBox1.Width)
                end.X = pictureBox1.Width - 2;
            if (end.Y > pictureBox1.Height)
                end.Y = pictureBox1.Height - 2;
            if (end.X < 2)
                end.X = 1;
            if (end.Y < 2)
                end.Y = 1;

            if (history == null) return;
            var rooms = history.Where(r => r.Value is RoomFigure);

            foreach (var r in rooms)
                CalculateAheadPoints(r.Value, ref start, ref end);
        }

    }
}
