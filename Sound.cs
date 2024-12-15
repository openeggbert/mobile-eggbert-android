// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.Sound
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Audio;
using WindowsPhoneSpeedyBlupi;

namespace WindowsPhoneSpeedyBlupi
{
    public class Sound
    {
        private class Play
        {
            private readonly SoundEffectInstance sei;

            private readonly int channel;

            public int Channel
            {
                get
                {
                    return channel;
                }
            }

            public bool IsFree
            {
                get
                {
                    return sei.State == SoundState.Stopped;
                }
            }

            public Play(SoundEffect se, int channel, double volume, double balance, double? pitch, bool isLooped)
            {
                this.channel = channel;
                int num = channel * 2;
                if (num >= 0 && num < tableVolumePitch.Length)
                {
                    volume *= tableVolumePitch[num];
                    pitch = tableVolumePitch[num + 1];
                }
                sei = se.CreateInstance();
                sei.Volume = (float)volume;
                sei.Pan = (float)balance;
                sei.Pitch = (float)(pitch ?? 0.0);
                sei.IsLooped = isLooped;
                sei.Play();
            }

            public void Stop()
            {
                sei.Stop();
            }
        }

        private static double[] tableVolumePitch = new double[200]
        {
        1.0, 0.0, 0.5, 1.0, 0.5, 1.0, 1.0, 0.2, 1.0, 0.2,
        1.0, 0.1, 1.0, 0.3, 1.0, 0.2, 1.0, 0.3, 1.0, 0.5,
        1.0, 0.2, 1.0, 0.2, 1.0, 0.1, 1.0, 0.2, 1.0, 0.2,
        1.0, 0.0, 1.0, 0.0, 1.0, 0.0, 1.0, 0.0, 1.0, 0.2,
        1.0, 0.2, 1.0, 0.2, 0.7, 0.2, 1.0, 0.1, 1.0, 0.1,
        1.0, 0.2, 1.0, 0.2, 1.0, 0.4, 1.0, 0.0, 1.0, 0.0,
        1.0, 0.0, 1.0, 0.0, 1.0, 0.2, 1.0, 0.2, 0.7, 0.4,
        1.0, 0.2, 1.0, 0.4, 1.0, 0.2, 0.5, 1.0, 0.5, 1.0,
        1.0, 0.4, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2,
        1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 0.6, 0.4, 0.8, 0.1,
        0.6, 0.5, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2,
        1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2,
        1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.0,
        1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.0,
        1.0, 0.2, 1.0, 0.2, 1.0, 0.0, 1.0, 0.0, 1.0, 0.2,
        1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2,
        1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 0.6, 0.4,
        1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2,
        1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2,
        1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2, 1.0, 0.2
        };

        public static readonly int MAXVOLUME = 20;

        private readonly Game1 game1;

        private readonly GameData gameData;

        private readonly List<SoundEffect> soundEffects;

        private readonly List<Play> plays;

        private double volume;

        public Sound(Game1 game1, GameData gameData)
        {
            this.game1 = game1;
            this.gameData = gameData;
            soundEffects = new List<SoundEffect>();
            plays = new List<Play>();
            volume = 1.0;
            SoundEffect.MasterVolume = 1f;
        }

        public void LoadContent()
        {
            if (Def.HasSound)
            {
                for (int i = 0; i <= 92; i++)
                {
                    string assetName = string.Format("sounds/sound{0}", i.ToString("d3"));
                    SoundEffect item = game1.Content.Load<SoundEffect>(assetName);
                    soundEffects.Add(item);
                }
            }
        }

        public bool Create()
        {
            return true;
        }

        public void SetState(bool bState)
        {
        }

        public void SetCDAudio(bool bAudio)
        {
        }

        public bool GetEnable()
        {
            return true;
        }

        public void SetAudioVolume(int volume)
        {
            this.volume = (double)volume / (double)MAXVOLUME;
        }

        public int GetAudioVolume()
        {
            return (int)(volume * (double)MAXVOLUME);
        }

        public void SetMidiVolume(int volume)
        {
        }

        public int GetMidiVolume()
        {
            return 0;
        }

        public void StopAll()
        {
            while (plays.Any())
            {
                plays[0].Stop();
                plays.RemoveAt(0);
            }
        }

        public bool PlayImage(int channel, TinyPoint pos)
        {
            return PlayImage(channel, pos, -1, false);
        }

        public bool PlayImage(int channel, TinyPoint pos, int rank, bool bLoop)
        {
            if (!gameData.Sounds)
            {
                return true;
            }
            if (channel >= 0 && channel < soundEffects.Count)
            {
                if (channel != 10 && plays.Where((Play x) => x.Channel == channel && !x.IsFree).Any())
                {
                    return true;
                }
                if (plays.Count >= 10)
                {
                    int num = 0;
                    while (num < plays.Count)
                    {
                        if (plays[num].IsFree)
                        {
                            plays.RemoveAt(num);
                        }
                        else
                        {
                            num++;
                        }
                    }
                }
                Play item = new Play(soundEffects[channel], channel, (float)GetVolume(pos), (float)GetBalance(pos), null, bLoop);
                plays.Add(item);
            }
            return true;
        }

        public bool PosImage(int channel, TinyPoint pos)
        {
            return true;
        }

        public bool Stop(int channel)
        {
            int num = 0;
            while (num < plays.Count)
            {
                if (plays[num].Channel == channel)
                {
                    plays[num].Stop();
                    plays.RemoveAt(num);
                }
                else
                {
                    num++;
                }
            }
            return true;
        }

        private double GetVolume(TinyPoint pos)
        {
            double val = 1.0;
            if (pos.X < 0)
            {
                val = 1.0 + (double)(pos.X / 640) * 2.0;
            }
            if (pos.X > 640)
            {
                pos.X -= 640;
                val = 1.0 - (double)(pos.X / 640) * 2.0;
            }
            val = Math.Max(val, 0.0);
            val = Math.Min(val, 1.0);
            double val2 = 1.0;
            if (pos.Y < 0)
            {
                val2 = 1.0 + (double)(pos.Y / 480) * 3.0;
            }
            if (pos.Y > 480)
            {
                pos.Y -= 480;
                val2 = 1.0 - (double)(pos.Y / 480) * 3.0;
            }
            val2 = Math.Max(val2, 0.0);
            val2 = Math.Min(val2, 1.0);
            return Math.Min(val, val2) * volume;
        }

        private double GetBalance(TinyPoint pos)
        {
            double val = (double)pos.X * 2.0 / 640.0 - 1.0;
            val = Math.Max(val, -1.0);
            return Math.Min(val, 1.0);
        }
    }
}