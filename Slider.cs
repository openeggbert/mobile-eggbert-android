// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.Slider
using System;
using WindowsPhoneSpeedyBlupi;

namespace WindowsPhoneSpeedyBlupi
{
    public class Slider
    {
        public TinyPoint TopLeftCorner { get; set; }

        public double Value { get; set; }

        private int PosLeft
        {
            get
            {
                return TopLeftCorner.X + 22;
            }
        }

        private int PosRight
        {
            get
            {
                return TopLeftCorner.X + 248 - 22;
            }
        }

        public void Draw(Pixmap pixmap)
        {
            TinyPoint tinyPoint = default(TinyPoint);
            tinyPoint.X = TopLeftCorner.X - pixmap.Origin.X;
            tinyPoint.Y = TopLeftCorner.Y - pixmap.Origin.Y;
            TinyPoint dest = tinyPoint;
            TinyRect tinyRect = default(TinyRect);
            tinyRect.Left = 0;
            tinyRect.Right = 124;
            tinyRect.Top = 0;
            tinyRect.Bottom = 22;
            TinyRect rect = tinyRect;
            pixmap.DrawPart(5, dest, rect, 2.0);
            int num = (int)((double)(PosRight - PosLeft) * Value);
            int num2 = TopLeftCorner.Y + 22;
            int num3 = 94;
            TinyRect tinyRect2 = default(TinyRect);
            tinyRect2.Left = PosLeft + num - num3 / 2;
            tinyRect2.Right = PosLeft + num + num3 / 2;
            tinyRect2.Top = num2 - num3 / 2;
            tinyRect2.Bottom = num2 + num3 / 2;
            rect = tinyRect2;
            pixmap.DrawIcon(14, 1, rect, 1.0, false);
            TinyRect tinyRect3 = default(TinyRect);
            tinyRect3.Left = TopLeftCorner.X - 65;
            tinyRect3.Right = TopLeftCorner.X - 65 + 60;
            tinyRect3.Top = TopLeftCorner.Y - 10;
            tinyRect3.Bottom = TopLeftCorner.Y - 10 + 60;
            rect = tinyRect3;
            pixmap.DrawIcon(10, 37, rect, 1.0, false);
            TinyRect tinyRect4 = default(TinyRect);
            tinyRect4.Left = TopLeftCorner.X + 248 + 5;
            tinyRect4.Right = TopLeftCorner.X + 248 + 5 + 60;
            tinyRect4.Top = TopLeftCorner.Y - 10;
            tinyRect4.Bottom = TopLeftCorner.Y - 10 + 60;
            rect = tinyRect4;
            pixmap.DrawIcon(10, 38, rect, 1.0, false);
        }

        public bool Move(TinyPoint pos)
        {
            TinyRect tinyRect = default(TinyRect);
            tinyRect.Left = TopLeftCorner.X - 50;
            tinyRect.Right = TopLeftCorner.X + 248 + 50;
            tinyRect.Top = TopLeftCorner.Y - 50;
            tinyRect.Bottom = TopLeftCorner.Y + 44 + 50;
            TinyRect rect = tinyRect;
            if (Misc.IsInside(rect, pos))
            {
                double val = ((double)pos.X - (double)PosLeft) / (double)(PosRight - PosLeft);
                val = Math.Max(val, 0.0);
                val = Math.Min(val, 1.0);
                if (Value != val)
                {
                    Value = val;
                    return true;
                }
            }
            return false;
        }
    }

}