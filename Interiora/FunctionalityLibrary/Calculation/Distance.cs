﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FunctionalityLibrary.Drawing.Figures;

namespace FunctionalityLibrary.Calculation
{
    public static class Distance
    {
        public static int GetDistanceFromPoints(PointF p1, PointF p2)
        {
            return (int)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public static PointF GetIncrementBetweenPointF(PointF pt1, PointF pt2)
        {
            pt1.X = Math.Abs(pt1.X - pt2.X);
            pt1.Y = Math.Abs(pt1.Y - pt1.Y);
            return pt1;
        }

        public static bool IsAheadX(PointF master, PointF aheader)
        {
            if (Math.Abs(master.X - aheader.X) < 10)
                return true;
            return false;
        }

        public static bool IsAheadY(PointF master, PointF aheader)
        {
            if (Math.Abs(master.Y - aheader.Y) < 10.0)
                return true;
            return false;
        }

        /// <summary>
        ///     Функция вычисляет находиться ли число между двумя положительными границами
        /// </summary>
        /// <param name="number">Число</param>
        /// <param name="left">Левая граница</param>
        /// <param name="right">Правая Граница</param>
        /// <returns></returns>
        public static bool IsBetween(float number, float left, float right)
        {
            if (left > right)
            {
                var lr = left;
                left = right;
                right = lr;
            }

            return ((number <= right + 15) && (number >= left - 15));
        }

        public static bool IsNumbersBetween(float number, float left, float right)
        {
            if (left > right)
            {
                var lr = left;
                left = right;
                right = lr;
            }
            return number - left >= 0 && right - number >= 0;
        }

        public static bool IsPointFBetween(PointF p, PointF start, PointF end)
        {
            if (IsNumbersBetween(p.X, start.X, end.X) && IsNumbersBetween(p.Y, start.Y, end.Y))
                return true;
            return false;
        }

        /// <summary>
        ///     Функция перераспределяет координаты start и end для фигуры figure.
        /// </summary>
        /// <param name="figure">Фигура комнаты.</param>
        /// <param name="start">Начальная координата нового объекта.</param>
        /// <param name="end">Конечная координата нового объекта.</param>
        public static void CalculateAheadPoints(Figure figure, ref PointF start, ref PointF end)
        {
            if (IsBetween(end.Y, figure.FirstLocationPoint.Y, figure.SecondLocationPoint.Y))
            {
                if (IsAheadX(figure.FirstLocationPoint, end))
                    end.X = figure.FirstLocationPoint.X;
                if (IsAheadX(figure.SecondLocationPoint, end))
                    end.X = figure.SecondLocationPoint.X;
            }

            if (IsBetween(end.X, figure.FirstLocationPoint.X, figure.SecondLocationPoint.X))
            {
                if (IsAheadY(figure.FirstLocationPoint, end))
                    end.Y = figure.FirstLocationPoint.Y;
                if (IsAheadY(figure.SecondLocationPoint, end))
                    end.Y = figure.SecondLocationPoint.Y;
            }

            if (IsBetween(start.X, figure.FirstLocationPoint.X, figure.SecondLocationPoint.X))
            {
                if (IsAheadY(figure.FirstLocationPoint, start))
                    start.Y = figure.FirstLocationPoint.Y;
                if (IsAheadY(figure.SecondLocationPoint, start))
                    start.Y = figure.SecondLocationPoint.Y;
            }
            if (IsBetween(start.Y, figure.FirstLocationPoint.Y, figure.SecondLocationPoint.Y))
            {
                if (IsAheadX(figure.FirstLocationPoint, start))
                    start.X = figure.FirstLocationPoint.X;
                if (IsAheadX(figure.SecondLocationPoint, start))
                    start.X = figure.SecondLocationPoint.X;
            }
        }

        public static void CalculateBonders(ref PointF start, ref PointF end, PictureBox pictureBox1, float factor,
            List<Figure> history = null)
        {
            if (end.X * factor > pictureBox1.Width)
                end.X = pictureBox1.Width - 2;
            if (end.Y * factor > pictureBox1.Height)
                end.Y = pictureBox1.Height - 2;
            if (end.X * factor < 2)
                end.X = 1;
            if (end.Y * factor < 2)
                end.Y = 1;

            if (history == null) return;
            var rooms = history.Where(r => r is RoomFigure);

            foreach (var r in rooms)
                CalculateAheadPoints(r, ref start, ref end);
        }

        public static PointF GetPointFromSize(PointF start, float sizeW, float sizeH)
        {
            return new PointF(start.X + sizeW, start.Y + sizeH);
        }
    }
}