// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.TinyPoint

namespace WindowsPhoneSpeedyBlupi
{
    public struct TinyPoint
    {
        public int X;

        public int Y;

        public override string ToString()
        {
            return string.Format("{0};{1}", X, Y);
        }
    }

}