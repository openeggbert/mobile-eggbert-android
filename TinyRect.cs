// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.TinyRect

namespace WindowsPhoneSpeedyBlupi
{
    public struct TinyRect
    {
        public int Left;

        public int Right;

        public int Top;

        public int Bottom;

        public int Width
        {
            get
            {
                return Right - Left;
            }
        }

        public int Height
        {
            get
            {
                return Bottom - Top;
            }
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3}", Left, Top, Right, Bottom);
        }
    }

}