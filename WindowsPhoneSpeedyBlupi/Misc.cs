// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.Misc
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using static WindowsPhoneSpeedyBlupi.Def;


namespace WindowsPhoneSpeedyBlupi
{
    public static class Misc
    {
        public static Rectangle RotateAdjust(Rectangle rect, double angle)
        {
            TinyPoint tinyPoint = default;
            tinyPoint.X = rect.Width / 2;
            tinyPoint.Y = rect.Height / 2;
            TinyPoint p = tinyPoint;
            TinyPoint tinyPoint2 = RotatePointRad(angle, p);
            int num = tinyPoint2.X - p.X;
            int num2 = tinyPoint2.Y - p.Y;
            return new Rectangle(rect.Left - num, rect.Top - num2, rect.Width, rect.Height);
        }

        public static TinyPoint RotatePointRad(double angle, TinyPoint p)
        {
            return RotatePointRad(default, angle, p);
        }

        public static TinyPoint RotatePointRad(TinyPoint center, double angle, TinyPoint p)
        {
            TinyPoint tinyPoint = default;
            TinyPoint result = default;
            tinyPoint.X = p.X - center.X;
            tinyPoint.Y = p.Y - center.Y;
            double num = Math.Sin(angle);
            double num2 = Math.Cos(angle);
            result.X = (int)(tinyPoint.X * num2 - tinyPoint.Y * num);
            result.Y = (int)(tinyPoint.X * num + tinyPoint.Y * num2);
            result.X += center.X;
            result.Y += center.Y;
            return result;
        }

        public static double DegToRad(double angle)
        {
            return angle * Math.PI / 180.0;
        }

        public static int Approch(int actual, int final, int step)
        {
            if (actual < final)
            {
                actual = Math.Min(actual + step, final);
            }
            else if (actual > final)
            {
                actual = Math.Max(actual - step, final);
            }
            return actual;
        }

        public static int Speed(double speed, int max)
        {
            if (speed > 0.0)
            {
                return Math.Max((int)(speed * max), 1);
            }
            if (speed < 0.0)
            {
                return Math.Min((int)(speed * max), -1);
            }
            return 0;
        }

        public static TinyRect Inflate(TinyRect rect, int value)
        {
            TinyRect result = default;
            result.Left = rect.Left - value;
            result.Right = rect.Right + value;
            result.Top = rect.Top - value;
            result.Bottom = rect.Bottom + value;
            return result;
        }

        public static bool IsInside(TinyRect rect, TinyPoint p)
        {
            if (p.X >= rect.Left && p.X <= rect.Right && p.Y >= rect.Top)
            {
                return p.Y <= rect.Bottom;
            }
            return false;
        }

        public static bool IntersectRect(out TinyRect dst, TinyRect src1, TinyRect src2)
        {
            dst = default;
            dst.Left = Math.Max(src1.Left, src2.Left);
            dst.Right = Math.Min(src1.Right, src2.Right);
            dst.Top = Math.Max(src1.Top, src2.Top);
            dst.Bottom = Math.Min(src1.Bottom, src2.Bottom);
            return !IsRectEmpty(dst);
        }

        public static bool UnionRect(out TinyRect dst, TinyRect src1, TinyRect src2)
        {
            dst = default;
            dst.Left = Math.Min(src1.Left, src2.Left);
            dst.Right = Math.Max(src1.Right, src2.Right);
            dst.Top = Math.Min(src1.Top, src2.Top);
            dst.Bottom = Math.Max(src1.Bottom, src2.Bottom);
            return !IsRectEmpty(dst);
        }

        private static bool IsRectEmpty(TinyRect rect)
        {
            if (rect.Left < rect.Right)
            {
                return rect.Top >= rect.Bottom;
            }
            return true;
        }

    }
}