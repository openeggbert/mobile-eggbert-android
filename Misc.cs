// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.Misc
using System;
using Microsoft.Xna.Framework;
using WindowsPhoneSpeedyBlupi;
using static WindowsPhoneSpeedyBlupi.Def;


namespace WindowsPhoneSpeedyBlupi
{
    public static class Misc
    {
        public static Rectangle RotateAdjust(Rectangle rect, double angle)
        {
            TinyPoint tinyPoint = default(TinyPoint);
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
            return RotatePointRad(default(TinyPoint), angle, p);
        }

        public static TinyPoint RotatePointRad(TinyPoint center, double angle, TinyPoint p)
        {
            TinyPoint tinyPoint = default(TinyPoint);
            TinyPoint result = default(TinyPoint);
            tinyPoint.X = p.X - center.X;
            tinyPoint.Y = p.Y - center.Y;
            double num = Math.Sin(angle);
            double num2 = Math.Cos(angle);
            result.X = (int)((double)tinyPoint.X * num2 - (double)tinyPoint.Y * num);
            result.Y = (int)((double)tinyPoint.X * num + (double)tinyPoint.Y * num2);
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
                return Math.Max((int)(speed * (double)max), 1);
            }
            if (speed < 0.0)
            {
                return Math.Min((int)(speed * (double)max), -1);
            }
            return 0;
        }

        public static TinyRect Inflate(TinyRect rect, int value)
        {
            TinyRect result = default(TinyRect);
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
            dst = default(TinyRect);
            dst.Left = Math.Max(src1.Left, src2.Left);
            dst.Right = Math.Min(src1.Right, src2.Right);
            dst.Top = Math.Max(src1.Top, src2.Top);
            dst.Bottom = Math.Min(src1.Bottom, src2.Bottom);
            return !IsRectEmpty(dst);
        }

        public static bool UnionRect(out TinyRect dst, TinyRect src1, TinyRect src2)
        {
            dst = default(TinyRect);
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

        public static KeyboardPress intToKeyboardPress(int i) {
            switch (i)
            {
                case 0: return KeyboardPress.None;
                case 1: return KeyboardPress.Up;
                case 2: return KeyboardPress.Right;
                case 3: return KeyboardPress.Down;
                case 4: return KeyboardPress.Left;
                case 5: return KeyboardPress.LeftControl;
                case 6: return KeyboardPress.Space;
                case 7: return KeyboardPress.Escape;
                case 8: return KeyboardPress.Pause;
                default: return KeyboardPress.None; //throw new Exception("Unsupported number for KeyboardPress: " + i);
            }
        }
        public static int keyboardPressToInt(KeyboardPress kp)
        {
            switch (kp)
            {
                case KeyboardPress.None: return 0;
                case KeyboardPress.Up: return 1;
                case KeyboardPress.Right: return 2;
                case KeyboardPress.Down: return 3;
                case KeyboardPress.Left: return 4;
                case KeyboardPress.LeftControl: return 5;
                case KeyboardPress.Space: return 6;
                case KeyboardPress.Escape: return 7;
                case KeyboardPress.Pause: return 8;
                default: throw new Exception("Unsupported KeyboardPress: " + kp);
            }
        }
    }
}