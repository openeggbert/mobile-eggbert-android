// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.GameData
using System;

namespace WindowsPhoneSpeedyBlupi
{

    public class GameData
    {
        private static readonly int HeaderLength = 10;

        private static readonly int DoorsLength = 200;

        private static readonly int GamerLength = 10 + DoorsLength;

        private static readonly int MaxGamer = 3;

        private static readonly int TotalLength = HeaderLength + GamerLength * MaxGamer;

        private readonly byte[] data;

        public int SelectedGamer
        {
            get
            {
                return data[2];
            }
            set
            {
                data[2] = (byte)value;
            }
        }

        public bool Sounds
        {
            get
            {
                return data[3] == 1;
            }
            set
            {
                data[3] = (byte)(value ? 1u : 0u);
            }
        }

        public bool JumpRight
        {
            get
            {
                return data[4] == 1;
            }
            set
            {
                data[4] = (byte)(value ? 1u : 0u);
            }
        }

        public bool AutoZoom
        {
            get
            {
                return data[5] == 1;
            }
            set
            {
                data[5] = (byte)(value ? 1u : 0u);
            }
        }

        public bool AccelActive
        {
            get
            {
                return data[6] == 1;
            }
            set
            {
                data[6] = (byte)(value ? 1u : 0u);
            }
        }

        public double AccelSensitivity
        {
            get
            {
                return data[7] / 100.0;
            }
            set
            {
                value = Math.Max(value, 0.0);
                value = Math.Min(value, 1.0);
                data[7] = (byte)(value * 100.0);
            }
        }

        public int NbVies
        {
            get
            {
                return data[GamerOffset];
            }
            set
            {
                data[GamerOffset] = (byte)value;
            }
        }

        public int LastWorld
        {
            get
            {
                return data[GamerOffset + 1];
            }
            set
            {
                data[GamerOffset + 1] = (byte)value;
            }
        }

        private int GamerOffset
        {
            get
            {
                return GetGamerOffset(SelectedGamer);
            }
        }

        public GameData()
        {
            data = new byte[TotalLength];
            Initialize();
        }

        public void Read()
        {
            Worlds.ReadGameData(data);
        }

        public void Write()
        {
            Worlds.WriteGameData(data);
        }

        public void Reset()
        {
            Initialize(SelectedGamer);
        }

        public void GetDoors(int[] doors)
        {
            for (int i = 0; i < DoorsLength; i++)
            {
                doors[i] = data[GamerOffset + 10 + i];
            }
        }

        public void SetDoors(int[] doors)
        {
            for (int i = 0; i < DoorsLength; i++)
            {
                data[GamerOffset + 10 + i] = (byte)doors[i];
            }
        }

        public void GetGamerInfo(int gamer, out int nbVies, out int mainDoors, out int secondaryDoors)
        {
            nbVies = data[GetGamerOffset(gamer)];
            secondaryDoors = 0;
            for (int i = 0; i < 180; i++)
            {
                if (data[GetGamerOffset(gamer) + 10 + i] == 1)
                {
                    secondaryDoors++;
                }
            }
            mainDoors = 0;
            for (int j = 180; j < 200; j++)
            {
                if (data[GetGamerOffset(gamer) + 10 + j] == 1)
                {
                    mainDoors++;
                }
            }
        }

        private void Initialize()
        {
            data[0] = 1;
            data[1] = 1;
            data[2] = 0;
            data[3] = 1;
            data[4] = 1;
            data[5] = 1;
            data[6] = 0;
            data[7] = 50;
            SelectedGamer = 0;
            for (int i = 0; i < MaxGamer; i++)
            {
                Initialize(i);
            }
        }

        private void Initialize(int gamer)
        {
            data[GetGamerOffset(gamer)] = 3;
            data[GetGamerOffset(gamer) + 1] = 1;
            for (int i = 0; i < DoorsLength; i++)
            {
                data[GetGamerOffset(gamer) + 10 + i] = 0;
            }
        }

        private int GetGamerOffset(int gamer)
        {
            return HeaderLength + GamerLength * gamer;
        }
    }

}