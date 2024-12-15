// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.Decor
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;
using WindowsPhoneSpeedyBlupi;
using static System.Net.Mime.MediaTypeNames;


namespace WindowsPhoneSpeedyBlupi
{
    public class Decor
    {
        private struct Cellule
        {
            public int icon;
        }

        private struct MoveObject
        {
            public int type;

            public int stepAdvance;

            public int stepRecede;

            public int timeStopStart;

            public int timeStopEnd;

            public TinyPoint posStart;

            public TinyPoint posEnd;

            public TinyPoint posCurrent;

            public int step;

            public int time;

            public int phase;

            public int channel;

            public int icon;
        }

        private class ByeByeObject
        {
            public int channel;

            public int icon;

            public double posX;

            public double posY;

            public double rotation;

            public double phase;

            public double animationSpeed;

            public double rotationSpeed;

            public double speedX;
        }

        private static readonly int MAXMOVEOBJECT = 200;

        private static readonly int MAXQUART = 441;

        private static readonly int SCROLL_SPEED = 8;

        private static readonly int SCROLL_MARGX = 80;

        private static readonly int SCROLL_MARGY = 40;

        private static readonly int BLUPIFLOOR = 2;

        private static readonly int BLUPIOFFY = 4 + BLUPIFLOOR;

        private static readonly int BLUPISURF = 12;

        private static readonly int BLUPISUSPEND = 12;

        private static readonly int OVERHEIGHT = 80;

        private Sound m_sound;

        private Pixmap m_pixmap;

        private GameData m_gameData;

        private Cellule[,] m_decor = new Cellule[100, 100];

        private Cellule[,] m_bigDecor = new Cellule[100, 100];

        private int[] m_balleTraj = new int[1300];

        private int[] m_moveTraj = new int[1300];

        private MoveObject[] m_moveObject = new MoveObject[MAXMOVEOBJECT];

        private int m_keyPress;

        private int m_lastKeyPress;

        private TinyPoint m_posDecor;

        private TinyPoint m_dimDecor;

        private int m_term;

        private int m_music;

        private int m_region;

        private int m_time;

        private bool m_bPause;

        private TinyRect m_drawBounds;

        private int m_nbRankCaisse;

        private int[] m_rankCaisse = new int[MAXMOVEOBJECT];

        private int m_nbLinkCaisse;

        private int[] m_linkCaisse = new int[MAXMOVEOBJECT];

        private TinyPoint m_blupiPos;

        private TinyPoint m_blupiLastPos;

        private TinyPoint m_blupiValidPos;

        private int m_blupiAction;

        private int m_blupiDir;

        private int m_blupiPhase;

        private double m_blupiVitesseX;

        private double m_blupiVitesseY;

        private int m_blupiIcon;

        private int m_blupiSec;

        private int m_blupiChannel;

        private TinyPoint m_blupiVector;

        private int m_blupiTransport;

        private bool m_blupiFocus;

        private bool m_blupiAir;

        private bool m_blupiHelico;

        private bool m_blupiOver;

        private bool m_blupiJeep;

        private bool m_blupiTank;

        private bool m_blupiSkate;

        private bool m_blupiNage;

        private bool m_blupiSurf;

        private bool m_blupiVent;

        private bool m_blupiSuspend;

        private bool m_blupiJumpAie;

        private bool m_blupiShield;

        private bool m_blupiPower;

        private bool m_blupiCloud;

        private bool m_blupiHide;

        private bool m_blupiInvert;

        private bool m_blupiBalloon;

        private bool m_blupiEcrase;

        private bool m_blupiMotorHigh;

        private int m_blupiMotorSound;

        private TinyPoint m_blupiPosHelico;

        private TinyPoint m_blupiPosMagic;

        private bool m_blupiRestart;

        private bool m_blupiFront;

        private int m_blupiBullet;

        private int m_blupiCle;

        private int m_blupiPerso;

        private int m_blupiDynamite;

        private int m_blupiNoBarre;

        private int m_blupiTimeShield;

        private int m_blupiTimeFire;

        private int m_blupiTimeNoAsc;

        private int m_blupiTimeMockery;

        private int m_blupiTimeOuf;

        private int m_blupiActionOuf;

        private int m_blupiFifoNb;

        private TinyPoint[] m_blupiFifoPos = new TinyPoint[10];

        private TinyPoint m_blupiStartPos;

        private int m_blupiStartDir;

        private double m_blupiSpeedX;

        private double m_blupiSpeedY;

        private double m_blupiLastSpeedX;

        private double m_blupiLastSpeedY;

        private Jauge[] m_jauges = new Jauge[2];

        private int m_blupiLevel;

        private bool m_bFoundCle;

        private bool m_bPrivate;

        private bool m_bCheatDoors;

        private bool m_bSuperBlupi;

        private bool m_bDrawSecret;

        private bool m_buildOfficialMissions;

        private int m_mission;

        private int[] m_doors = new int[200];

        private int m_nbVies;

        private int m_nbTresor;

        private int m_totalTresor;

        private int m_goalPhase;

        private int m_detectIcon;

        private TinyPoint m_sucettePos;

        private int m_sucetteType;

        private int m_blupiLogicRotation;

        private int m_blupiRealRotation;

        private int m_blupiOffsetY;

        private TinyPoint m_scrollPoint;

        private TinyPoint m_scrollAdd;

        private int m_voyageIcon;

        private int m_voyageChannel;

        private int m_voyagePhase;

        private int m_voyageTotal;

        private TinyPoint m_voyageStart;

        private TinyPoint m_voyageEnd;

        private int m_decorAction;

        private int m_decorPhase;

        private int[] m_lastDecorIcon = new int[200];

        private double m_hotSpotFinalZoom;

        private double m_hotSpotFinalX;

        private double m_hotSpotFinalY;

        private double m_hotSpotCurrentZoom;

        private double m_hotSpotCurrentX;

        private double m_hotSpotCurrentY;

        private double m_hotSpotStepZoom;

        private double m_hotSpotStepX;

        private double m_hotSpotStepY;

        private double m_hotSpotOutLag;

        private Random m_random;

        private List<ByeByeObject> byeByeObjects;

        public TinyRect DrawBounds
        {
            get
            {
                return m_drawBounds;
            }
            set
            {
                m_drawBounds = value;
            }
        }

        public Def.ButtonGlygh ButtonPressed { get; set; }

        private static void MoveObjectCopy(ref MoveObject dst, MoveObject src)
        {
            dst.type = src.type;
            dst.stepAdvance = src.stepAdvance;
            dst.stepRecede = src.stepRecede;
            dst.timeStopStart = src.timeStopStart;
            dst.timeStopEnd = src.timeStopEnd;
            dst.posStart = src.posStart;
            dst.posEnd = src.posEnd;
            dst.posCurrent = src.posCurrent;
            dst.step = src.step;
            dst.time = src.time;
            dst.phase = src.phase;
            dst.channel = src.channel;
            dst.icon = src.icon;
        }

        public Decor()
        {
            for (int i = 0; i < 200; i++)
            {
                m_lastDecorIcon[i] = 0;
            }
            m_drawBounds.Left = 0;
            m_drawBounds.Right = 640;
            m_drawBounds.Top = 0;
            m_drawBounds.Bottom = 480;
            m_time = 0;
            m_bCheatDoors = false;
            m_bSuperBlupi = false;
            m_bDrawSecret = false;
            m_buildOfficialMissions = false;
            m_hotSpotFinalZoom = 1.0;
            m_hotSpotFinalX = 320.0;
            m_hotSpotFinalY = 240.0;
            m_hotSpotCurrentZoom = 1.0;
            m_hotSpotCurrentX = 320.0;
            m_hotSpotCurrentY = 240.0;
            m_random = new Random();
            byeByeObjects = new List<ByeByeObject>();
        }

        public void Create(Sound sound, Pixmap pixmap, GameData gameData)
        {
            m_sound = sound;
            m_pixmap = pixmap;
            m_gameData = gameData;
            m_keyPress = 0;
            m_lastKeyPress = 0;
            m_blupiMotorSound = 0;
            InitDecor();
            TinyPoint pos = default(TinyPoint);
            pos.X = 90;
            pos.Y = 450;
            m_jauges[0] = new Jauge();
            m_jauges[0].Create(m_pixmap, m_sound, pos, 1, false);
            m_jauges[0].SetHide(true);
            pos.X = 90;
            pos.Y = 428;
            m_jauges[1] = new Jauge();
            m_jauges[1].Create(m_pixmap, m_sound, pos, 3, false);
            m_jauges[1].SetHide(true);
        }

        public bool LoadImages()
        {
            string name = string.Format("decor{0}", m_region.ToString("d3"));
            m_pixmap.BackgroundCache(name);
            return true;
        }

        private void InitDecor()
        {
            m_posDecor.X = 0;
            m_posDecor.Y = 0;
            m_dimDecor.X = 100;
            m_dimDecor.Y = 100;
            m_music = 1;
            m_region = 2;
            m_decorAction = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    m_decor[i, j].icon = -1;
                    m_bigDecor[i, j].icon = -1;
                }
            }
            m_decor[1, 4].icon = 40;
            m_decor[2, 4].icon = 38;
            m_decor[3, 4].icon = 38;
            m_decor[4, 4].icon = 38;
            m_decor[5, 4].icon = 38;
            m_decor[6, 4].icon = 38;
            m_decor[7, 4].icon = 39;
            for (int k = 0; k < MAXMOVEOBJECT; k++)
            {
                m_moveObject[k].type = 0;
            }
            FlushBalleTraj();
            FlushMoveTraj();
            m_moveObject[0].type = 5;
            m_moveObject[0].stepAdvance = 1;
            m_moveObject[0].stepRecede = 1;
            m_moveObject[0].timeStopStart = 0;
            m_moveObject[0].timeStopEnd = 0;
            m_moveObject[0].posStart.X = 258;
            m_moveObject[0].posStart.Y = 196;
            m_moveObject[0].posEnd = m_moveObject[0].posStart;
            m_moveObject[0].posCurrent = m_moveObject[0].posStart;
            m_moveObject[0].phase = 0;
            m_moveObject[0].step = 1;
            m_moveObject[0].time = 0;
            m_moveObject[0].channel = 10;
            m_moveObject[0].icon = 0;
            m_moveObject[1].type = 7;
            m_moveObject[1].stepAdvance = 1;
            m_moveObject[1].stepRecede = 1;
            m_moveObject[1].timeStopStart = 0;
            m_moveObject[1].timeStopEnd = 0;
            m_moveObject[1].posStart.X = 450;
            m_moveObject[1].posStart.Y = 196;
            m_moveObject[1].posEnd = m_moveObject[1].posStart;
            m_moveObject[1].posCurrent = m_moveObject[1].posStart;
            m_moveObject[1].phase = 0;
            m_moveObject[1].step = 1;
            m_moveObject[1].time = 0;
            m_moveObject[1].channel = 10;
            m_moveObject[1].icon = 29;
            m_blupiStartPos.X = 66;
            m_blupiStartPos.Y = 192 + BLUPIOFFY;
            m_blupiStartDir = 2;
            m_blupiAction = 1;
            m_blupiPhase = 0;
            m_blupiIcon = 0;
            m_blupiChannel = 2;
            m_blupiFocus = true;
            m_blupiAir = false;
            m_blupiHelico = false;
            m_blupiOver = false;
            m_blupiJeep = false;
            m_blupiTank = false;
            m_blupiSkate = false;
            m_blupiNage = false;
            m_blupiSurf = false;
            m_blupiSuspend = false;
            m_blupiJumpAie = false;
            m_blupiShield = false;
            m_blupiPower = false;
            m_blupiCloud = false;
            m_blupiHide = false;
            m_blupiInvert = false;
            m_blupiBalloon = false;
            m_blupiEcrase = false;
            m_blupiMotorHigh = false;
            m_blupiPosHelico.X = -1;
            m_blupiActionOuf = 0;
            m_blupiTimeNoAsc = 0;
            m_blupiTimeMockery = 0;
            m_blupiVitesseX = 0.0;
            m_blupiVitesseY = 0.0;
            m_blupiValidPos = m_blupiStartPos;
            m_blupiFront = false;
            m_blupiBullet = 0;
            m_blupiCle = 0;
            m_blupiPerso = 0;
            m_blupiDynamite = 0;
            m_nbTresor = 0;
            m_totalTresor = 1;
            m_goalPhase = 0;
            m_scrollPoint = m_blupiStartPos;
            m_scrollAdd.X = 0;
            m_scrollAdd.Y = 0;
            m_term = 0;
            byeByeObjects.Clear();
        }

        public void PlayPrepare(bool bTest)
        {
            if (bTest)
            {
                m_nbVies = 3;
            }
            m_blupiPos = m_blupiStartPos;
            m_blupiDir = m_blupiStartDir;
            if (m_blupiDir == 1)
            {
                m_blupiIcon = 4;
            }
            else
            {
                m_blupiIcon = 0;
            }
            m_blupiAction = 1;
            m_blupiPhase = 0;
            m_blupiFocus = true;
            m_blupiAir = false;
            m_blupiHelico = false;
            m_blupiOver = false;
            m_blupiJeep = false;
            m_blupiTank = false;
            m_blupiNage = false;
            m_blupiSurf = false;
            m_blupiSuspend = false;
            m_blupiJumpAie = false;
            m_blupiShield = false;
            m_blupiPower = false;
            m_blupiCloud = false;
            m_blupiHide = false;
            m_blupiInvert = false;
            m_blupiBalloon = false;
            m_blupiEcrase = false;
            m_blupiMotorHigh = false;
            m_blupiActionOuf = 0;
            m_blupiTimeNoAsc = 0;
            m_blupiTimeMockery = 0;
            m_blupiValidPos = m_blupiPos;
            m_blupiBullet = 0;
            m_blupiCle = 0;
            m_blupiPerso = 0;
            m_blupiDynamite = 0;
            m_nbTresor = 0;
            m_totalTresor = 0;
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type == 5)
                {
                    m_totalTresor++;
                }
                m_moveObject[i].posCurrent = m_moveObject[i].posStart;
                m_moveObject[i].step = 1;
                m_moveObject[i].phase = 0;
                m_moveObject[i].time = 0;
                if (m_moveObject[i].type == 5 || m_moveObject[i].type == 6 || m_moveObject[i].type == 25 || m_moveObject[i].type == 26 || m_moveObject[i].type == 40 || m_moveObject[i].type == 2 || m_moveObject[i].type == 3 || m_moveObject[i].type == 96 || m_moveObject[i].type == 97)
                {
                    m_moveObject[i].phase = m_random.Next(23);
                }
                if (m_moveObject[i].type == 23)
                {
                    m_moveObject[i].type = 0;
                }
            }
            m_goalPhase = 0;
            MoveObjectSort();
            m_scrollPoint = m_blupiPos;
            m_scrollAdd.X = 0;
            m_scrollAdd.Y = 0;
            m_blupiPosHelico.X = -1;
            m_blupiMotorSound = 0;
            m_blupiFront = false;
            m_blupiNoBarre = 0;
            m_blupiValidPos = m_blupiPos;
            m_blupiFifoNb = 0;
            m_blupiTimeFire = 0;
            m_voyageIcon = -1;
            m_jauges[0].SetHide(true);
            m_jauges[1].SetHide(true);
            m_bFoundCle = false;
            m_term = 0;
            m_time = 0;
            m_bPause = false;
            MoveStep();
            m_scrollPoint.X = m_blupiPos.X + 30 + m_scrollAdd.X;
            m_scrollPoint.Y = m_blupiPos.Y + 30 + m_scrollAdd.Y;
        }

        private void BuildPrepare()
        {
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                m_moveObject[i].posCurrent = m_moveObject[i].posStart;
                m_moveObject[i].step = 1;
                m_moveObject[i].time = 0;
                m_moveObject[i].phase = 0;
                if (m_moveObject[i].type == 23)
                {
                    m_moveObject[i].type = 0;
                }
            }
            m_voyageIcon = -1;
            m_time = 0;
            m_bPause = false;
        }

        public int IsTerminated()
        {
            return m_term;
        }

        public void MoveStep()
        {
            try
            {
                MoveObjectStep();
                ByeByeStep();
                BlupiStep();
                MoveHotSpot();
                AdaptMotorVehicleSound();
            }
            catch
            {
            }
        }

        private void ResetHotSpot()
        {
            m_pixmap.SetHotSpot(1.0, DrawBounds.Width / 2, DrawBounds.Height / 2);
        }

        private void MoveHotSpot()
        {
            bool flag = false;
            if (m_blupiSpeedX != 0.0)
            {
                flag = true;
            }
            if (!m_blupiFocus)
            {
                flag = false;
            }
            if (m_blupiHelico || m_blupiPower)
            {
                flag = false;
            }
            if (!m_gameData.AutoZoom)
            {
                flag = false;
            }
            if (flag)
            {
                m_hotSpotOutLag = 30.0;
            }
            else if (m_hotSpotOutLag > 0.0)
            {
                if (!m_blupiFocus || m_blupiSpeedY != 0.0)
                {
                    m_hotSpotOutLag = 0.0;
                }
                else
                {
                    m_hotSpotOutLag -= 1.0;
                }
                if (m_hotSpotOutLag > 0.0)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                m_hotSpotFinalZoom = 1.3;
                m_hotSpotFinalX = m_blupiPos.X + 30 - m_posDecor.X;
                m_hotSpotFinalY = m_blupiPos.Y + 30 - m_posDecor.Y;
            }
            else
            {
                m_hotSpotFinalZoom = 1.0;
                m_hotSpotFinalX = DrawBounds.Width / 2;
                m_hotSpotFinalY = DrawBounds.Height / 2;
            }
            m_hotSpotStepZoom = 1.0 / 30.0;
            m_hotSpotStepX = 10.0;
            m_hotSpotStepY = 10.0;
            if (m_hotSpotCurrentZoom < m_hotSpotFinalZoom)
            {
                m_hotSpotCurrentZoom = Math.Min(m_hotSpotCurrentZoom + m_hotSpotStepZoom, m_hotSpotFinalZoom);
            }
            if (m_hotSpotCurrentZoom > m_hotSpotFinalZoom)
            {
                m_hotSpotCurrentZoom = Math.Max(m_hotSpotCurrentZoom - m_hotSpotStepZoom, m_hotSpotFinalZoom);
            }
            if (m_hotSpotCurrentX < m_hotSpotFinalX)
            {
                m_hotSpotCurrentX = Math.Min(m_hotSpotCurrentX + m_hotSpotStepX, m_hotSpotFinalX);
            }
            if (m_hotSpotCurrentX > m_hotSpotFinalX)
            {
                m_hotSpotCurrentX = Math.Max(m_hotSpotCurrentX - m_hotSpotStepX, m_hotSpotFinalX);
            }
            m_pixmap.SetHotSpot(m_hotSpotCurrentZoom, m_hotSpotCurrentX, m_hotSpotCurrentY);
        }

        private bool BlitzActif(int celx, int cely)
        {
            TinyPoint pos = default(TinyPoint);
            pos.X = celx * 64;
            pos.Y = cely * 64;
            int num = m_time % 100;
            if (m_decor[celx, cely - 1].icon == 304 && (num == 0 || num == 7 || num == 18 || num == 25 || num == 33 || num == 44) && cely > 0)
            {
                PlaySound(69, pos);
            }
            if (num % 2 == 0)
            {
                return num < 50;
            }
            return false;
        }

        public void Build()
        {
            TinyPoint posDecor = DecorNextAction();
            TinyPoint pos = default(TinyPoint);
            pos.X = posDecor.X * 2 / 3;
            pos.Y = posDecor.Y * 2 / 3;
            int num = 1;
            TinyPoint tinyPoint = default(TinyPoint);
            tinyPoint.X = m_drawBounds.Left;
            TinyRect rect = default(TinyRect);
            rect.Left = pos.X % 640;
            rect.Right = 640;
            for (int i = 0; i < 3; i++)
            {
                tinyPoint.Y = m_drawBounds.Top;
                rect.Top = pos.Y % 480;
                rect.Bottom = 480;
                for (int j = 0; j < 2; j++)
                {
                    m_pixmap.DrawPart(3, tinyPoint, rect);
                    tinyPoint.Y += rect.Height - num;
                    rect.Top = 0;
                    rect.Bottom = 480;
                }
                tinyPoint.X += rect.Width - num;
                rect.Left = 0;
                rect.Right = 640;
                if (tinyPoint.X > m_drawBounds.Right)
                {
                    break;
                }
            }
            tinyPoint.X = m_drawBounds.Left - posDecor.X % 64 - 64;
            for (int i = posDecor.X / 64 - 1; i < posDecor.X / 64 + m_drawBounds.Width / 64 + 3; i++)
            {
                tinyPoint.Y = m_drawBounds.Top - posDecor.Y % 64 + 2 - 64;
                for (int j = posDecor.Y / 64 - 1; j < posDecor.Y / 64 + m_drawBounds.Height / 64 + 2; j++)
                {
                    if (i >= 0 && i < 100 && j >= 0 && j < 100)
                    {
                        int num2 = m_bigDecor[i, j].icon;
                        int channel = 9;
                        if (num2 != -1)
                        {
                            pos.X = tinyPoint.X;
                            pos.Y = tinyPoint.Y;
                            if (num2 == 203)
                            {
                                num2 = Tables.table_marine[m_time / 3 % 11];
                                channel = 1;
                            }
                            if (num2 >= 66 && num2 <= 68)
                            {
                                pos.Y -= 13;
                            }
                            if (num2 >= 87 && num2 <= 89)
                            {
                                pos.Y -= 2;
                            }
                            m_pixmap.QuickIcon(channel, num2, pos);
                        }
                    }
                    tinyPoint.Y += 64;
                }
                tinyPoint.X += 64;
            }
            tinyPoint.X = m_drawBounds.Left - posDecor.X % 64;
            for (int i = posDecor.X / 64; i < posDecor.X / 64 + m_drawBounds.Width / 64 + 2; i++)
            {
                tinyPoint.Y = m_drawBounds.Top - posDecor.Y % 64;
                for (int j = posDecor.Y / 64; j < posDecor.Y / 64 + m_drawBounds.Height / 64 + 2; j++)
                {
                    if (i >= 0 && i < 100 && j >= 0 && j < 100 && m_decor[i, j].icon != -1)
                    {
                        int num2 = m_decor[i, j].icon;
                        if (num2 == 384 || num2 == 385)
                        {
                            m_pixmap.QuickIcon(1, num2, tinyPoint);
                        }
                    }
                    tinyPoint.Y += 64;
                }
                tinyPoint.X += 64;
            }
            m_blupiSec = 0;
            if (!m_blupiFront)
            {
                double rotation = 0.0;
                if (m_blupiNage || m_blupiSurf || m_blupiHelico || m_blupiJeep)
                {
                    rotation = m_blupiRealRotation;
                }
                tinyPoint.X = m_drawBounds.Left + m_blupiPos.X - posDecor.X;
                tinyPoint.Y = m_drawBounds.Top + m_blupiPos.Y - posDecor.Y;
                if (m_blupiJeep)
                {
                    tinyPoint.Y += m_blupiOffsetY;
                }
                if (m_blupiShield)
                {
                    m_blupiSec = 1;
                    if (m_blupiTimeShield > 25 || m_time % 4 < 2)
                    {
                        int num2 = Tables.table_shield_blupi[m_time / 2 % 16];
                        tinyPoint.Y -= 2;
                        m_pixmap.QuickIcon(10, num2, tinyPoint);
                        tinyPoint.Y += 2;
                        num2 = Tables.table_shieldloop[m_time / 2 % 5];
                        m_pixmap.QuickIcon(10, num2, tinyPoint);
                    }
                    m_pixmap.QuickIcon(m_blupiChannel, m_blupiIcon, tinyPoint, 1.0, rotation);
                }
                else if (m_blupiPower)
                {
                    m_blupiSec = 2;
                    if (m_blupiTimeShield > 25 || m_time % 4 < 2)
                    {
                        int num2 = Tables.table_magicloop[m_time / 2 % 5];
                        m_pixmap.QuickIcon(10, num2, tinyPoint);
                    }
                    m_pixmap.QuickIcon(m_blupiChannel, m_blupiIcon, tinyPoint, 1.0, rotation);
                }
                else if (m_blupiCloud)
                {
                    m_blupiSec = 3;
                    if (m_blupiTimeShield > 25 || m_time % 4 < 2)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            int num2 = 48 + (m_time + k) / 1 % 6;
                            pos.X = tinyPoint.X - 34;
                            pos.Y = tinyPoint.Y - 34;
                            m_pixmap.QuickIcon(9, num2, pos);
                        }
                    }
                    m_pixmap.QuickIcon(m_blupiChannel, m_blupiIcon, tinyPoint, 1.0, rotation);
                }
                else if (m_blupiHide)
                {
                    m_blupiSec = 4;
                    if (m_blupiTimeShield > 25 || m_time % 4 < 2)
                    {
                        m_pixmap.QuickIcon(m_blupiChannel, m_blupiIcon, tinyPoint, 0.3, rotation);
                    }
                    else
                    {
                        m_pixmap.QuickIcon(m_blupiChannel, m_blupiIcon, tinyPoint, 1.0, rotation);
                    }
                }
                else
                {
                    m_pixmap.QuickIcon(m_blupiChannel, m_blupiIcon, tinyPoint, 1.0, rotation);
                }
            }
            for (int num3 = MAXMOVEOBJECT - 1; num3 >= 0; num3--)
            {
                if (m_moveObject[num3].type != 0 && m_moveObject[num3].posCurrent.X >= posDecor.X - 64 && m_moveObject[num3].posCurrent.Y >= posDecor.Y - 64 && m_moveObject[num3].posCurrent.X <= posDecor.X + m_drawBounds.Width && m_moveObject[num3].posCurrent.Y <= posDecor.Y + m_drawBounds.Height && (m_moveObject[num3].type < 8 || m_moveObject[num3].type > 11) && (m_moveObject[num3].type < 90 || m_moveObject[num3].type > 95) && (m_moveObject[num3].type < 98 || m_moveObject[num3].type > 100) && m_moveObject[num3].type != 53 && m_moveObject[num3].type != 1 && m_moveObject[num3].type != 47 && m_moveObject[num3].type != 48)
                {
                    tinyPoint.X = m_drawBounds.Left + m_moveObject[num3].posCurrent.X - posDecor.X;
                    tinyPoint.Y = m_drawBounds.Top + m_moveObject[num3].posCurrent.Y - posDecor.Y;
                    if (m_moveObject[num3].type == 4 || m_moveObject[num3].type == 32 || m_moveObject[num3].type == 33)
                    {
                        tinyPoint.X += 2;
                        tinyPoint.Y += BLUPIOFFY;
                    }
                    if (m_moveObject[num3].type == 54)
                    {
                        tinyPoint.Y += BLUPIOFFY;
                    }
                    double opacity = 1.0;
                    if (m_moveObject[num3].type == 58)
                    {
                        opacity = (double)(20 - m_moveObject[num3].phase) * 0.3 / 20.0;
                    }
                    m_pixmap.QuickIcon(m_moveObject[num3].channel, m_moveObject[num3].icon, tinyPoint, opacity, 0.0);
                    if (m_moveObject[num3].type == 30)
                    {
                        for (int l = 0; l < Tables.table_drinkoffset.Length; l++)
                        {
                            int num4 = (m_time + Tables.table_drinkoffset[l]) % 50;
                            int rank = Tables.table_drinkeffect[num4 % 5];
                            TinyPoint tinyPoint2 = default(TinyPoint);
                            tinyPoint2.X = tinyPoint.X + 2;
                            tinyPoint2.Y = tinyPoint.Y - num4 * 3;
                            TinyPoint pos2 = tinyPoint2;
                            double opacity2 = (50.0 - (double)num4) / 50.0;
                            m_pixmap.QuickIcon(10, rank, pos2, opacity2, 0.0);
                        }
                    }
                    if (m_bDrawSecret && m_moveObject[num3].type == 12 && m_moveObject[num3].icon != 32 && m_moveObject[num3].icon != 33 && m_moveObject[num3].icon != 34)
                    {
                        m_pixmap.QuickIcon(1, 214, tinyPoint);
                    }
                }
            }
            tinyPoint.X = m_drawBounds.Left - posDecor.X % 64;
            for (int i = posDecor.X / 64; i < posDecor.X / 64 + m_drawBounds.Width / 64 + 2; i++)
            {
                tinyPoint.Y = m_drawBounds.Top - posDecor.Y % 64;
                for (int j = posDecor.Y / 64; j < posDecor.Y / 64 + m_drawBounds.Height / 64 + 2; j++)
                {
                    if (i >= 0 && i < 100 && j >= 0 && j < 100 && m_decor[i, j].icon != -1)
                    {
                        int num2 = m_decor[i, j].icon;
                        pos.X = tinyPoint.X;
                        pos.Y = tinyPoint.Y;
                        if ((num2 >= 107 && num2 <= 109) || num2 == 157)
                        {
                            pos.Y -= 7;
                        }
                        if (num2 == 211)
                        {
                            num2 = Tables.table_ressort[(m_time / 2 + i * 7) % 8];
                        }
                        if (num2 == 214 && !m_bDrawSecret)
                        {
                            num2 = -1;
                        }
                        if (num2 == 364)
                        {
                            pos.Y -= 2;
                        }
                        switch (num2)
                        {
                            default:
                                m_pixmap.QuickIcon(1, num2, pos);
                                break;
                            case 68:
                            case 91:
                            case 92:
                            case 110:
                            case 111:
                            case 112:
                            case 113:
                            case 114:
                            case 115:
                            case 116:
                            case 117:
                            case 118:
                            case 119:
                            case 120:
                            case 121:
                            case 122:
                            case 123:
                            case 124:
                            case 125:
                            case 126:
                            case 127:
                            case 128:
                            case 129:
                            case 130:
                            case 131:
                            case 132:
                            case 133:
                            case 134:
                            case 135:
                            case 136:
                            case 137:
                            case 305:
                            case 317:
                            case 324:
                            case 373:
                            case 378:
                            case 384:
                            case 385:
                            case 404:
                            case 410:
                                break;
                        }
                    }
                    tinyPoint.Y += 64;
                }
                tinyPoint.X += 64;
            }
            for (int num3 = 0; num3 < MAXMOVEOBJECT; num3++)
            {
                if ((m_moveObject[num3].type == 1 || m_moveObject[num3].type == 47 || m_moveObject[num3].type == 48) && m_moveObject[num3].posCurrent.X >= posDecor.X - 64 && m_moveObject[num3].posCurrent.Y >= posDecor.Y - 64 && m_moveObject[num3].posCurrent.X <= posDecor.X + m_drawBounds.Width && m_moveObject[num3].posCurrent.Y <= posDecor.Y + m_drawBounds.Height)
                {
                    tinyPoint.X = m_drawBounds.Left + m_moveObject[num3].posCurrent.X - posDecor.X;
                    tinyPoint.Y = m_drawBounds.Top + m_moveObject[num3].posCurrent.Y - posDecor.Y;
                    m_pixmap.QuickIcon(m_moveObject[num3].channel, m_moveObject[num3].icon, tinyPoint);
                }
            }
            tinyPoint.X = m_drawBounds.Left - posDecor.X % 64;
            for (int i = posDecor.X / 64; i < posDecor.X / 64 + m_drawBounds.Width / 64 + 2; i++)
            {
                tinyPoint.Y = m_drawBounds.Top - posDecor.Y % 64;
                for (int j = posDecor.Y / 64; j < posDecor.Y / 64 + m_drawBounds.Height / 64 + 2; j++)
                {
                    if (i >= 0 && i < 100 && j >= 0 && j < 100 && m_decor[i, j].icon != -1)
                    {
                        int num2 = m_decor[i, j].icon;
                        pos = tinyPoint;
                        if (num2 == 68)
                        {
                            num2 = Tables.table_decor_lave[(i * 13 + j * 7 + m_time / 2) % 8];
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 373)
                        {
                            num2 = ((!m_blupiFocus) ? Tables.table_decor_piege2[(i * 13 + j * 7 + m_time / 2) % 4] : Tables.table_decor_piege1[(i * 13 + j * 7 + m_time / 4) % 16]);
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 404 || num2 == 410)
                        {
                            num2 = Tables.table_decor_goutte[(i * 13 + j * 7 + m_time / 2) % 48];
                            pos.Y -= 9;
                            m_pixmap.QuickIcon(1, num2, pos);
                            if (num2 >= 404 && num2 <= 407)
                            {
                                m_decor[i, j].icon = 404;
                            }
                            else
                            {
                                m_decor[i, j].icon = 410;
                            }
                        }
                        if (num2 == 317)
                        {
                            num2 = Tables.table_decor_ecraseur[m_time / 3 % 10];
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 378)
                        {
                            num2 = Tables.table_decor_scie[(i * 13 + j * 7 + m_time / 1) % 6];
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 324)
                        {
                            num2 = Tables.table_decor_temp[m_time / 4 % 20];
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 92)
                        {
                            num2 = Tables.table_decor_eau1[(i * 13 + j * 7 + m_time / 3) % 6];
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 91)
                        {
                            int num5 = 3 + (i * 17 + j * 13) % 3;
                            num2 = Tables.table_decor_eau2[(i * 11 + j * 7 + m_time / num5) % 6];
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 305 && BlitzActif(i, j))
                        {
                            num2 = m_random.Next(305, 308);
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 110)
                        {
                            num2 = Tables.table_decor_ventg[m_time / 1 % 4];
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 114)
                        {
                            num2 = Tables.table_decor_ventd[m_time / 1 % 4];
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 118)
                        {
                            num2 = Tables.table_decor_venth[m_time / 1 % 4];
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 122)
                        {
                            num2 = Tables.table_decor_ventb[m_time / 1 % 4];
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 126)
                        {
                            num2 = Tables.table_decor_ventillog[m_time / 2 % 3];
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 129)
                        {
                            num2 = Tables.table_decor_ventillod[m_time / 2 % 3];
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 132)
                        {
                            num2 = Tables.table_decor_ventilloh[m_time / 2 % 3];
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                        if (num2 == 135)
                        {
                            num2 = Tables.table_decor_ventillob[m_time / 2 % 3];
                            m_pixmap.QuickIcon(1, num2, pos);
                        }
                    }
                    tinyPoint.Y += 64;
                }
                tinyPoint.X += 64;
            }
            ByeByeDraw(posDecor);
            for (int num3 = 0; num3 < MAXMOVEOBJECT; num3++)
            {
                if (m_moveObject[num3].type != 0 && m_moveObject[num3].posCurrent.X >= posDecor.X - 64 && m_moveObject[num3].posCurrent.Y >= posDecor.Y - 64 && m_moveObject[num3].posCurrent.X <= posDecor.X + m_drawBounds.Width && m_moveObject[num3].posCurrent.Y <= posDecor.Y + m_drawBounds.Height && ((m_moveObject[num3].type >= 8 && m_moveObject[num3].type <= 11) || (m_moveObject[num3].type >= 90 && m_moveObject[num3].type <= 95) || (m_moveObject[num3].type >= 98 && m_moveObject[num3].type <= 100) || m_moveObject[num3].type == 53))
                {
                    tinyPoint.X = m_drawBounds.Left + m_moveObject[num3].posCurrent.X - posDecor.X;
                    tinyPoint.Y = m_drawBounds.Top + m_moveObject[num3].posCurrent.Y - posDecor.Y;
                    m_pixmap.QuickIcon(m_moveObject[num3].channel, m_moveObject[num3].icon, tinyPoint);
                }
            }
            if (m_blupiFront)
            {
                tinyPoint.X = m_drawBounds.Left + m_blupiPos.X - posDecor.X;
                tinyPoint.Y = m_drawBounds.Top + m_blupiPos.Y - posDecor.Y;
                m_pixmap.QuickIcon(m_blupiChannel, m_blupiIcon, tinyPoint);
            }
            DrawInfo();
            VoyageDraw();
            m_time++;
        }

        private void DrawInfo()
        {
            TinyPoint pos = default(TinyPoint);
            pos.X = 210;
            pos.Y = 417;
            for (int i = 0; i < m_nbVies; i++)
            {
                m_pixmap.HudIcon(2, 48, pos);
                pos.X += 16;
            }
            pos.X = 570;
            pos.Y = 442;
            for (int i = 0; i < m_blupiBullet; i++)
            {
                m_pixmap.HudIcon(10, 176, pos);
                pos.X += 4;
            }
            if (m_blupiPerso > 0)
            {
                pos.X = 0;
                pos.Y = 438;
                m_pixmap.HudIcon(4, 108, pos);
                string text = string.Format("= {0}", m_blupiPerso.ToString());
                pos.X = 32;
                pos.Y = 452;
                Text.DrawText(m_pixmap, pos, text, 0.7);
            }
            if (m_blupiDynamite > 0)
            {
                pos.X = 505;
                pos.Y = 414;
                m_pixmap.HudIcon(10, 252, pos);
            }
            if (((uint)m_blupiCle & (true ? 1u : 0u)) != 0)
            {
                pos.X = 520;
                pos.Y = 418;
                m_pixmap.HudIcon(10, 215, pos);
            }
            if (((uint)m_blupiCle & 2u) != 0)
            {
                pos.X = 530;
                pos.Y = 418;
                m_pixmap.HudIcon(10, 222, pos);
            }
            if (((uint)m_blupiCle & 4u) != 0)
            {
                pos.X = 540;
                pos.Y = 418;
                m_pixmap.HudIcon(10, 229, pos);
            }
            if ((m_mission != 1 && m_mission % 10 != 0) || m_bPrivate)
            {
                TinyRect tinyRect = default(TinyRect);
                tinyRect.Left = 410 + m_pixmap.Origin.X;
                tinyRect.Right = 510 + m_pixmap.Origin.X;
                tinyRect.Top = 445;
                tinyRect.Bottom = 480;
                TinyRect rect = tinyRect;
                m_pixmap.DrawIcon(14, 15, rect, 0.6, false);
                string text = string.Format("{0}/{1}", m_nbTresor.ToString(), m_totalTresor.ToString());
                pos.X = 460;
                pos.Y = 450;
                Text.DrawTextCenter(m_pixmap, pos, text, 1.0);
            }
            for (int i = 0; i < 2; i++)
            {
                if (!m_jauges[i].GetHide())
                {
                    m_jauges[i].Draw();
                }
            }
            int[] array = null;
            if (m_mission == 11)
            {
                array = Tables.table_training1;
            }
            if (m_mission == 12)
            {
                array = Tables.table_training2;
            }
            if (m_mission == 13)
            {
                array = Tables.table_training3;
            }
            if (m_mission == 14)
            {
                array = Tables.table_training4;
            }
            if (array == null || m_bPrivate)
            {
                return;
            }
            int num = (m_blupiPos.X + 30) / 64;
            int num2 = (m_blupiPos.Y + 30) / 64;
            for (int i = 0; array[i] != -1; i += 6)
            {
                if (num >= array[i] && num <= array[i + 1] && num2 >= array[i + 2] && num2 <= array[i + 3] && IsDisplayInfo(array[i + 4]))
                {
                    int num3 = 0;
                    if (m_gameData.AccelActive)
                    {
                        num3 = 10000;
                    }
                    string text = MyResource.LoadString(array[i + 5] + num3);
                    if (!string.IsNullOrEmpty(text))
                    {
                        TinyRect drawBounds = m_pixmap.DrawBounds;
                        TinyRect tinyRect2 = default(TinyRect);
                        tinyRect2.Left = 0;
                        tinyRect2.Right = drawBounds.Width;
                        tinyRect2.Top = 0;
                        tinyRect2.Bottom = 40;
                        TinyRect rect2 = tinyRect2;
                        m_pixmap.DrawIcon(14, 15, rect2, 1.0, false);
                        double num4 = Text.GetTextWidth(text, 1.0);
                        double num5 = Math.Min(640.0 / num4, 1.0);
                        pos.X = 320;
                        pos.Y = 5 + (int)((1.0 - num5) * 35.0 * 0.6);
                        Text.DrawTextCenter(m_pixmap, pos, text, num5);
                    }
                    break;
                }
            }
        }

        private bool IsDisplayInfo(int tableTresor)
        {
            if (tableTresor >= 0)
            {
                return m_nbTresor == tableTresor;
            }
            switch (tableTresor)
            {
                case -2:
                    if (!m_blupiHelico && !m_blupiSkate && !m_blupiTank)
                    {
                        return !m_blupiJeep;
                    }
                    return false;
                case -3:
                    if (!m_blupiHelico && !m_blupiSkate && !m_blupiTank)
                    {
                        return m_blupiJeep;
                    }
                    return true;
                case -4:
                    return m_blupiDynamite == 0;
                case -5:
                    return m_blupiDynamite > 0;
                default:
                    return true;
            }
        }

        private TinyPoint DecorNextAction()
        {
            int i = 0;
            if (m_decorAction == 0 || m_bPause)
            {
                return m_posDecor;
            }
            TinyPoint posDecor = m_posDecor;
            for (; Tables.table_decor_action[i] != 0; i += 2 + Tables.table_decor_action[i + 1] * 2)
            {
                if (m_decorAction != Tables.table_decor_action[i])
                {
                    continue;
                }
                if (m_decorPhase < Tables.table_decor_action[i + 1])
                {
                    posDecor.X += 3 * Tables.table_decor_action[i + 2 + m_decorPhase * 2];
                    posDecor.Y += 3 * Tables.table_decor_action[i + 2 + m_decorPhase * 2 + 1];
                    int num = ((m_dimDecor.X != 0) ? (6400 - m_drawBounds.Width) : 0);
                    if (posDecor.X < 0)
                    {
                        posDecor.X = 0;
                    }
                    if (posDecor.X > num)
                    {
                        posDecor.X = num;
                    }
                    num = ((m_dimDecor.Y != 0) ? (6400 - m_drawBounds.Height) : 0);
                    if (posDecor.Y < 0)
                    {
                        posDecor.Y = 0;
                    }
                    if (posDecor.Y > num)
                    {
                        posDecor.Y = num;
                    }
                    m_decorPhase++;
                }
                else
                {
                    m_decorAction = 0;
                }
                break;
            }
            return posDecor;
        }

        public void SetSpeedX(double speed)
        {
            if (m_blupiInvert)
            {
                speed = 0.0 - speed;
            }
            m_blupiSpeedX = speed;
        }

        public void SetSpeedY(double speed)
        {
            m_blupiSpeedY = speed;
        }

        public void KeyChange(int keyPress)
        {
            m_keyPress = keyPress;
        }

        private void GetBlupiInfo(out bool bHelico, out bool bJeep, out bool bSkate, out bool bNage)
        {
            bHelico = m_blupiHelico;
            bJeep = m_blupiJeep | m_blupiTank;
            bSkate = m_blupiSkate;
            bNage = m_blupiNage | m_blupiSurf;
        }

        private int SoundEnviron(int sound, int obstacle)
        {
            if ((obstacle >= 32 && obstacle <= 34) || (obstacle >= 41 && obstacle <= 47) || (obstacle >= 139 && obstacle <= 143))
            {
                switch (sound)
                {
                    case 4:
                        return 79;
                    case 3:
                        return 78;
                }
            }
            if ((obstacle >= 1 && obstacle <= 28) || (obstacle >= 78 && obstacle <= 90) || (obstacle >= 250 && obstacle <= 260) || (obstacle >= 311 && obstacle <= 316) || (obstacle >= 324 && obstacle <= 329))
            {
                switch (sound)
                {
                    case 4:
                        return 81;
                    case 3:
                        return 80;
                }
            }
            if ((obstacle >= 284 && obstacle <= 303) || obstacle == 338)
            {
                switch (sound)
                {
                    case 4:
                        return 83;
                    case 3:
                        return 82;
                }
            }
            if (obstacle >= 341 && obstacle <= 363)
            {
                switch (sound)
                {
                    case 4:
                        return 85;
                    case 3:
                        return 84;
                }
            }
            if (obstacle >= 215 && obstacle <= 234)
            {
                switch (sound)
                {
                    case 4:
                        return 87;
                    case 3:
                        return 86;
                }
            }
            if (obstacle >= 246 && obstacle <= 249)
            {
                switch (sound)
                {
                    case 4:
                        return 89;
                    case 3:
                        return 88;
                }
            }
            if (obstacle >= 107 && obstacle <= 109)
            {
                switch (sound)
                {
                    case 4:
                        return 91;
                    case 3:
                        return 90;
                }
            }
            return sound;
        }

        private void PlaySound(int sound, TinyPoint pos)
        {
            if (!m_blupiHide || (sound != 1 && sound != 2 && sound != 3 && sound != 4 && sound != 5 && sound != 6 && sound != 7 && sound != 20 && sound != 21 && sound != 22 && sound != 23 && sound != 24 && sound != 25 && sound != 27 && sound != 32 && sound != 34 && sound != 35 && sound != 36 && sound != 37 && sound != 38 && sound != 39 && sound != 40 && sound != 46 && sound != 47 && sound != 48 && sound != 49 && sound != 64 && sound != 65 && sound != 78 && sound != 79 && sound != 80 && sound != 81 && sound != 82 && sound != 83 && sound != 84 && sound != 85 && sound != 86 && sound != 87 && sound != 88 && sound != 89 && sound != 90 && sound != 91))
            {
                pos.X -= m_posDecor.X;
                pos.Y -= m_posDecor.Y;
                m_sound.PlayImage(sound, pos);
            }
        }

        public void StopSound()
        {
            m_blupiMotorSound = 0;
            m_sound.StopAll();
        }

        public void StartSound()
        {
            AdaptMotorVehicleSound();
        }

        private void StopSound(int sound)
        {
            m_sound.Stop(sound);
        }

        private void AdaptMotorVehicleSound()
        {
            int num = 0;
            int channel = 0;
            int channel2 = 0;
            if (m_blupiHelico)
            {
                num = (m_blupiMotorHigh ? 16 : 18);
                channel = 15;
                channel2 = 17;
            }
            else if (m_blupiJeep || m_blupiOver || m_blupiTank)
            {
                num = (m_blupiMotorHigh ? 29 : 31);
                channel = 28;
                channel2 = 30;
            }
            if (m_blupiMotorSound != num)
            {
                TinyPoint blupiPos = m_blupiPos;
                blupiPos.X -= m_posDecor.X;
                blupiPos.Y -= m_posDecor.Y;
                if (m_blupiMotorSound == 0 && num != 0)
                {
                    m_sound.PlayImage(channel, blupiPos);
                }
                if (m_blupiMotorSound != 0 && num == 0)
                {
                    m_sound.PlayImage(channel2, blupiPos);
                }
                if (m_blupiMotorSound != 0)
                {
                    m_sound.Stop(m_blupiMotorSound);
                }
                m_blupiMotorSound = num;
                if (m_blupiMotorSound != 0)
                {
                    m_sound.PlayImage(m_blupiMotorSound, blupiPos, -1, true);
                }
            }
        }

        private void PosSound(TinyPoint pos)
        {
            if (m_blupiMotorSound != 0)
            {
                pos.X -= m_posDecor.X;
                pos.Y -= m_posDecor.Y;
                m_sound.PosImage(m_blupiMotorSound, pos);
            }
        }

        private int GetRegion()
        {
            return m_region;
        }

        private void SetRegion(int region)
        {
            m_region = region;
        }

        private int GetMusic()
        {
            return m_music;
        }

        private void SetMusic(int music)
        {
            m_music = music;
        }

        public TinyPoint GetDim()
        {
            return m_dimDecor;
        }

        public void SetDim(TinyPoint dim)
        {
            m_dimDecor = dim;
        }

        public int GetMission()
        {
            return m_mission;
        }

        public void SetMission(int mission)
        {
            m_mission = mission;
        }

        public int GetNbVies()
        {
            return m_nbVies;
        }

        public void SetNbVies(int nbVies)
        {
            m_nbVies = nbVies;
        }

        public void InitializeDoors(GameData gameData)
        {
            gameData.GetDoors(m_doors);
        }

        public void MemorizeDoors(GameData gameData)
        {
            gameData.SetDoors(m_doors);
        }

        public static string GetCheatTinyText(Def.ButtonGlygh glyph)
        {
            switch (glyph)
            {
                case Def.ButtonGlygh.Cheat1:
                    return "D";
                case Def.ButtonGlygh.Cheat2:
                    return "B";
                case Def.ButtonGlygh.Cheat3:
                    return "S";
                case Def.ButtonGlygh.Cheat4:
                    return "E";
                case Def.ButtonGlygh.Cheat5:
                    return "R";
                case Def.ButtonGlygh.Cheat6:
                    return "T";
                case Def.ButtonGlygh.Cheat7:
                    return "C";
                case Def.ButtonGlygh.Cheat8:
                    return "T";
                case Def.ButtonGlygh.Cheat9:
                    return "G";
                default:
                    return "";
            }
        }

        public void CheatAction(Tables.CheatCodes cheat)
        {
            if (cheat == Tables.CheatCodes.OpenDoors)
            {
                m_bCheatDoors = !m_bCheatDoors;
                AdaptDoors(m_bPrivate);
            }
            if (cheat == Tables.CheatCodes.ShowSecret)
            {
                m_bDrawSecret = !m_bDrawSecret;
            }
            if (cheat == Tables.CheatCodes.SuperBlupi)
            {
                m_bSuperBlupi = !m_bSuperBlupi;
            }
            if (cheat == Tables.CheatCodes.LayEgg)
            {
                m_nbVies = 9;
            }
            if (cheat == Tables.CheatCodes.CleanAll)
            {
                for (int i = 0; i < MAXMOVEOBJECT; i++)
                {
                    if (m_moveObject[i].type == 2 || m_moveObject[i].type == 3 || m_moveObject[i].type == 96 || m_moveObject[i].type == 97 || m_moveObject[i].type == 4 || m_moveObject[i].type == 16 || m_moveObject[i].type == 17 || m_moveObject[i].type == 20 || m_moveObject[i].type == 44 || m_moveObject[i].type == 54 || m_moveObject[i].type == 32 || m_moveObject[i].type == 33)
                    {
                        m_decorAction = 1;
                        m_decorPhase = 0;
                        m_moveObject[i].type = 8;
                        m_moveObject[i].phase = 0;
                        m_moveObject[i].posCurrent.X -= 34;
                        m_moveObject[i].posCurrent.Y -= 34;
                        m_moveObject[i].posStart = m_moveObject[i].posCurrent;
                        m_moveObject[i].posEnd = m_moveObject[i].posCurrent;
                        MoveObjectStepIcon(i);
                        PlaySound(10, m_moveObject[i].posCurrent);
                    }
                }
            }
            if (cheat == Tables.CheatCodes.Skate)
            {
                m_blupiAir = false;
                m_blupiHelico = false;
                m_blupiOver = false;
                m_blupiJeep = false;
                m_blupiTank = false;
                m_blupiSkate = true;
                m_blupiNage = false;
                m_blupiSurf = false;
                m_blupiVent = false;
                m_blupiSuspend = false;
                StopSound(16);
                StopSound(18);
                StopSound(29);
                StopSound(31);
            }
            if (cheat == Tables.CheatCodes.Copter)
            {
                m_blupiAir = false;
                m_blupiHelico = true;
                m_blupiOver = false;
                m_blupiJeep = false;
                m_blupiTank = false;
                m_blupiSkate = false;
                m_blupiNage = false;
                m_blupiSurf = false;
                m_blupiVent = false;
                m_blupiSuspend = false;
            }
            if (cheat == Tables.CheatCodes.Jeep)
            {
                m_blupiAir = false;
                m_blupiHelico = false;
                m_blupiOver = false;
                m_blupiJeep = true;
                m_blupiTank = false;
                m_blupiSkate = false;
                m_blupiNage = false;
                m_blupiSurf = false;
                m_blupiVent = false;
                m_blupiSuspend = false;
                m_blupiCloud = false;
                m_blupiHide = false;
            }
            if (cheat == Tables.CheatCodes.AllTreasure)
            {
                for (int i = 0; i < MAXMOVEOBJECT; i++)
                {
                    if (m_moveObject[i].type == 5)
                    {
                        m_moveObject[i].type = 0;
                        m_nbTresor++;
                        OpenDoorsTresor();
                        PlaySound(11, m_moveObject[i].posCurrent);
                    }
                }
            }
            if (cheat == Tables.CheatCodes.EndGoal)
            {
                for (int i = 0; i < MAXMOVEOBJECT; i++)
                {
                    if (m_moveObject[i].type != 7 && m_moveObject[i].type != 21)
                    {
                        continue;
                    }
                    m_blupiPos = m_moveObject[i].posCurrent;
                    if (m_nbTresor >= m_totalTresor)
                    {
                        if (m_moveObject[i].type == 21)
                        {
                            m_bFoundCle = true;
                        }
                        StopSound(16);
                        StopSound(18);
                        StopSound(29);
                        StopSound(31);
                        PlaySound(14, m_moveObject[i].posCurrent);
                        m_blupiAction = 13;
                        m_blupiPhase = 0;
                        m_blupiFocus = false;
                        m_blupiFront = true;
                        m_blupiAir = false;
                        m_blupiHelico = false;
                        m_blupiOver = false;
                        m_blupiJeep = false;
                        m_blupiTank = false;
                        m_blupiSkate = false;
                        m_blupiNage = false;
                        m_blupiSurf = false;
                        m_blupiVent = false;
                        m_blupiSuspend = false;
                        m_blupiShield = false;
                        m_blupiPower = false;
                        m_blupiCloud = false;
                        m_blupiHide = false;
                        m_blupiInvert = false;
                        m_blupiBalloon = false;
                        m_blupiEcrase = false;
                    }
                    else
                    {
                        PlaySound(13, m_moveObject[i].posCurrent);
                    }
                    m_goalPhase = 50;
                }
            }
            if (cheat == Tables.CheatCodes.RoundShield)
            {
                PlaySound(42, m_blupiPos);
                m_blupiShield = true;
                m_blupiPower = false;
                m_blupiCloud = false;
                m_blupiHide = false;
                m_blupiTimeShield = 100;
                m_blupiPosMagic = m_blupiPos;
                m_jauges[1].SetHide(false);
            }
            if (cheat == Tables.CheatCodes.Lollipop)
            {
                m_blupiAction = 49;
                m_blupiPhase = 0;
                m_blupiHelico = false;
                m_blupiOver = false;
                m_blupiJeep = false;
                m_blupiTank = false;
                m_blupiSkate = false;
                m_blupiShield = false;
                m_blupiPower = false;
                m_blupiCloud = false;
                m_blupiHide = false;
                m_blupiFocus = false;
                PlaySound(50, m_blupiPos);
            }
            if (cheat == Tables.CheatCodes.Bombs)
            {
                m_blupiPerso = 10;
                PlaySound(60, m_blupiPos);
            }
            if (cheat == Tables.CheatCodes.BirdLime)
            {
                m_blupiBullet = 10;
            }
            if (cheat == Tables.CheatCodes.Tank)
            {
                m_blupiAir = false;
                m_blupiHelico = false;
                m_blupiOver = false;
                m_blupiJeep = false;
                m_blupiTank = true;
                m_blupiSkate = false;
                m_blupiNage = false;
                m_blupiSurf = false;
                m_blupiVent = false;
                m_blupiSuspend = false;
                m_blupiCloud = false;
                m_blupiHide = false;
            }
            if (cheat == Tables.CheatCodes.PowerCharge)
            {
                m_blupiAction = 56;
                m_blupiPhase = 0;
                m_blupiHelico = false;
                m_blupiOver = false;
                m_blupiJeep = false;
                m_blupiTank = false;
                m_blupiSkate = false;
                m_blupiShield = false;
                m_blupiPower = false;
                m_blupiCloud = false;
                m_blupiHide = false;
                m_blupiJumpAie = false;
                m_blupiFocus = false;
                PlaySound(58, m_blupiPos);
            }
            if (cheat == Tables.CheatCodes.Drink)
            {
                m_blupiAction = 55;
                m_blupiPhase = 0;
                m_blupiHelico = false;
                m_blupiOver = false;
                m_blupiJeep = false;
                m_blupiTank = false;
                m_blupiSkate = false;
                m_blupiShield = false;
                m_blupiPower = false;
                m_blupiCloud = false;
                m_blupiHide = false;
                m_blupiJumpAie = false;
                m_blupiFocus = false;
                PlaySound(57, m_blupiPos);
            }
            if (cheat == Tables.CheatCodes.Overcraft)
            {
                m_blupiAir = false;
                m_blupiHelico = false;
                m_blupiOver = true;
                m_blupiJeep = false;
                m_blupiTank = false;
                m_blupiSkate = false;
                m_blupiNage = false;
                m_blupiSurf = false;
                m_blupiVent = false;
                m_blupiSuspend = false;
            }
            if (cheat == Tables.CheatCodes.Dynamite)
            {
                m_blupiDynamite = 1;
                PlaySound(60, m_blupiPos);
            }
            if (cheat == Tables.CheatCodes.WeelKeys)
            {
                m_blupiCle |= 7;
            }
            if (!m_blupiShield && !m_blupiHide && !m_blupiCloud && !m_blupiPower)
            {
                m_jauges[1].SetHide(true);
            }
            if (!m_blupiHelico && !m_blupiOver)
            {
                StopSound(16);
                StopSound(18);
            }
            if (!m_blupiJeep && !m_blupiTank)
            {
                StopSound(29);
                StopSound(31);
            }
        }

        private void SetBuildOfficialMissions(bool bMode)
        {
            m_buildOfficialMissions = bMode;
        }

        private void BlupiSearchIcon()
        {
            int i = 0;
            int num = 2;
            int num2 = m_blupiAction;
            if (m_blupiVent && !m_blupiHelico && !m_blupiOver)
            {
                if (num2 == 1)
                {
                    num2 = 8;
                }
                if (num2 == 2)
                {
                    num2 = 14;
                }
            }
            if (m_blupiHelico)
            {
                if (num2 == 1)
                {
                    num2 = 15;
                }
                if (num2 == 2)
                {
                    num2 = 16;
                }
                if (num2 == 3)
                {
                    num2 = 17;
                }
                if (num2 == 10)
                {
                    num2 = 15;
                }
                if (num2 == 9)
                {
                    num2 = 15;
                }
                m_blupiRealRotation = (int)(m_blupiVitesseX * 2.0);
            }
            if (m_blupiOver)
            {
                if (num2 == 1)
                {
                    num2 = 67;
                }
                if (num2 == 2)
                {
                    num2 = 68;
                }
                if (num2 == 3)
                {
                    num2 = 69;
                }
                if (num2 == 10)
                {
                    num2 = 67;
                }
                if (num2 == 9)
                {
                    num2 = 67;
                }
            }
            if (m_blupiJeep)
            {
                if (num2 == 1)
                {
                    num2 = 25;
                }
                if (num2 == 2)
                {
                    num2 = 26;
                }
                if (num2 == 10)
                {
                    num2 = 26;
                }
                if (num2 == 3)
                {
                    num2 = 27;
                }
            }
            if (m_blupiTank)
            {
                if (num2 == 1)
                {
                    num2 = 50;
                }
                if (num2 == 2)
                {
                    num2 = 51;
                }
                if (num2 == 10)
                {
                    num2 = 51;
                }
                if (num2 == 3)
                {
                    num2 = 52;
                }
            }
            if (m_blupiSkate)
            {
                if (num2 == 1)
                {
                    num2 = 37;
                }
                if (num2 == 2)
                {
                    num2 = 38;
                }
                if (num2 == 10)
                {
                    num2 = 38;
                }
                if (num2 == 3)
                {
                    num2 = 39;
                }
                if (num2 == 59)
                {
                    num2 = 39;
                }
                if (num2 == 4)
                {
                    num2 = 40;
                }
                if (num2 == 5)
                {
                    num2 = 41;
                }
                if (num2 == 38 && m_blupiSpeedX == 0.0 && Math.Abs(m_blupiVitesseX) > 5.0)
                {
                    num2 = 85;
                }
            }
            if (m_blupiNage)
            {
                if (num2 == 1)
                {
                    num2 = 18;
                }
                if (num2 == 2)
                {
                    num2 = 19;
                }
                if (num2 == 3)
                {
                    num2 = 20;
                }
                int num3 = 0;
                int num4 = 0;
                if (m_blupiPos.X > m_blupiLastPos.X)
                {
                    num3 = 1;
                }
                if (m_blupiPos.X < m_blupiLastPos.X)
                {
                    num3 = -1;
                }
                if (m_blupiPos.Y > m_blupiLastPos.Y)
                {
                    num4 = 1;
                }
                if (m_blupiPos.Y < m_blupiLastPos.Y)
                {
                    num4 = -1;
                }
                int num5 = ((num4 >= 0 || num3 != 0) ? ((num4 < 0 && num3 != 0) ? 45 : ((num4 == 0 && num3 != 0) ? 90 : ((num4 > 0 && num3 != 0) ? 135 : ((num4 > 0 && num3 == 0) ? 180 : 0)))) : 0);
                num5 += 15;
                if (num2 == 20)
                {
                    num5 = 90;
                }
                m_blupiLogicRotation = Misc.Approch(m_blupiLogicRotation, num5, 10);
                if (m_blupiDir == 2)
                {
                    m_blupiRealRotation = m_blupiLogicRotation - 90;
                }
                else
                {
                    m_blupiRealRotation = 90 - m_blupiLogicRotation;
                }
                m_blupiRealRotation += (int)(Math.Sin((double)m_time / 6.0) * 20.0);
            }
            if (m_blupiSurf)
            {
                if (num2 == 1)
                {
                    num2 = 21;
                }
                if (num2 == 2)
                {
                    num2 = 22;
                }
                if (num2 == 3)
                {
                    num2 = 23;
                }
                m_blupiLogicRotation = Misc.Approch(m_blupiLogicRotation, 0, 10);
                m_blupiRealRotation = m_blupiLogicRotation;
                m_blupiRealRotation += (int)(Math.Sin((double)m_time / 10.0) * 10.0);
            }
            if (m_blupiSuspend)
            {
                if (num2 == 1)
                {
                    num2 = 31;
                }
                if (num2 == 2)
                {
                    num2 = 32;
                }
                if (num2 == 3)
                {
                    num2 = 33;
                }
                if (num2 == 4)
                {
                    num2 = 34;
                }
            }
            if (m_blupiBalloon)
            {
                num2 = 66;
            }
            if (m_blupiEcrase)
            {
                if (num2 == 1)
                {
                    num2 = 72;
                }
                if (num2 == 2)
                {
                    num2 = 73;
                }
                if (num2 == 3)
                {
                    num2 = 73;
                }
            }
            if (num2 == 1 && (m_blupiPhase % 330 == 125 || m_blupiPhase % 330 == 129 || m_blupiPhase % 330 == 135 || m_blupiPhase % 330 == 139 || m_blupiPhase % 330 == 215 || m_blupiPhase % 330 == 219 || m_blupiPhase % 330 == 225 || m_blupiPhase % 330 == 229 || m_blupiPhase % 330 == 235 || m_blupiPhase % 330 == 239 || m_blupiPhase % 330 == 245 || m_blupiPhase % 330 == 249 || m_blupiPhase % 330 == 255 || m_blupiPhase % 330 == 259 || m_blupiPhase % 330 == 265 || m_blupiPhase % 330 == 269))
            {
                PlaySound(37, m_blupiPos);
            }
            if (num2 == 31 && (m_blupiPhase % 328 == 118 || m_blupiPhase % 328 == 230 || m_blupiPhase % 328 == 278))
            {
                PlaySound(36, m_blupiPos);
            }
            if ((num2 == 21 || num2 == 22) && m_blupiPhase % 12 == 0 && m_blupiSurf)
            {
                MoveObjectTiplouf(m_blupiPos);
            }
            int num6 = m_blupiPhase;
            if (!m_blupiHelico && ((m_blupiSpeedX > 0.1 && m_blupiSpeedX < 0.75) || (m_blupiSpeedX < -0.1 && m_blupiSpeedX > -0.75)))
            {
                num6 /= 2;
            }
            for (; Tables.table_blupi[i] != 0; i += Tables.table_blupi[i + 1] + 3)
            {
                if (num2 == Tables.table_blupi[i])
                {
                    int num7 = ((Tables.table_blupi[i + 2] == 0 || num6 <= Tables.table_blupi[i + 2]) ? (num6 % Tables.table_blupi[i + 1]) : Tables.table_blupi[i + 2]);
                    num = Tables.table_blupi[i + 3 + num7];
                    break;
                }
            }
            if (num2 == 11 || num2 == 75 || num2 == 76 || num2 == 54 || (num2 == 57 && num < 266))
            {
                m_blupiChannel = 10;
            }
            else
            {
                m_blupiChannel = 2;
            }
            int num8 = m_blupiDir;
            if (m_blupiInvert)
            {
                if (m_blupiDir == 2)
                {
                    num8 = 1;
                }
                if (m_blupiDir == 1)
                {
                    num8 = 2;
                }
            }
            if (num8 == 1 && m_blupiChannel == 2)
            {
                if (num2 == 31)
                {
                    if (num == 144)
                    {
                        num = 158;
                    }
                    if (num == 143)
                    {
                        num = 145;
                    }
                    if (num == 151)
                    {
                        num = 146;
                    }
                }
                if (num >= 0 && num < 335)
                {
                    num = Tables.table_mirror[num];
                }
            }
            if (num8 == 1 && m_blupiChannel == 10 && num >= 168 && num <= 171)
            {
                num += 4;
            }
            m_blupiIcon = num;
            m_blupiPhase++;
        }

        private bool BlupiIsGround()
        {
            if (m_blupiTransport == -1)
            {
                TinyRect rect = BlupiRect(m_blupiPos);
                rect.Top = m_blupiPos.Y + 60 - 2;
                rect.Bottom = m_blupiPos.Y + 60 - 1;
                return DecorDetect(rect);
            }
            return false;
        }

        private TinyRect BlupiRect(TinyPoint pos)
        {
            TinyRect result = default(TinyRect);
            if (m_blupiNage || m_blupiSurf)
            {
                result.Left = pos.X + 12;
                result.Right = pos.X + 60 - 12;
                if (m_blupiAction == 1)
                {
                    result.Top = pos.Y + 5;
                    result.Bottom = pos.Y + 60 - 10;
                }
                else
                {
                    result.Top = pos.Y + 15;
                    result.Bottom = pos.Y + 60 - 10;
                }
            }
            else if (m_blupiJeep)
            {
                result.Left = pos.X + 2;
                result.Right = pos.X + 60 - 2;
                result.Top = pos.Y + 10;
                result.Bottom = pos.Y + 60 - 2;
            }
            else if (m_blupiTank)
            {
                result.Left = pos.X + 2;
                result.Right = pos.X + 60 - 2;
                result.Top = pos.Y + 10;
                result.Bottom = pos.Y + 60 - 2;
            }
            else if (m_blupiOver)
            {
                result.Left = pos.X + 2;
                result.Right = pos.X + 60 - 2;
                result.Top = pos.Y + 2;
                result.Bottom = pos.Y + 60 - 2;
            }
            else if (m_blupiBalloon)
            {
                result.Left = pos.X + 10;
                result.Right = pos.X + 60 - 10;
                result.Top = pos.Y + 5;
                result.Bottom = pos.Y + 60 - 2;
            }
            else if (m_blupiEcrase)
            {
                result.Left = pos.X + 5;
                result.Right = pos.X + 60 - 5;
                result.Top = pos.Y + 39;
                result.Bottom = pos.Y + 60 - 2;
            }
            else
            {
                result.Left = pos.X + 12;
                result.Right = pos.X + 60 - 12;
                result.Top = pos.Y + 11;
                result.Bottom = pos.Y + 60 - 2;
            }
            return result;
        }

        private void BlupiAdjust()
        {
            TinyRect tinyRect = BlupiRect(m_blupiPos);
            if (!DecorDetect(tinyRect))
            {
                return;
            }
            for (int i = 0; i < 50; i++)
            {
                TinyRect rect = tinyRect;
                rect.Bottom = rect.Top + 2;
                rect.Left = m_blupiPos.X + 12;
                rect.Right = m_blupiPos.X + 60 - 12;
                if (!DecorDetect(rect))
                {
                    break;
                }
                tinyRect.Top += 2;
                tinyRect.Bottom += 2;
                m_blupiPos.Y += 2;
            }
            for (int i = 0; i < 50; i++)
            {
                TinyRect rect = tinyRect;
                rect.Right = rect.Left + 2;
                rect.Top = m_blupiPos.Y + 11;
                rect.Bottom = m_blupiPos.Y + 60 - 2;
                if (!DecorDetect(rect))
                {
                    break;
                }
                tinyRect.Left += 2;
                tinyRect.Right += 2;
                m_blupiPos.X += 2;
            }
            for (int i = 0; i < 50; i++)
            {
                TinyRect rect = tinyRect;
                rect.Left = rect.Right - 2;
                rect.Top = m_blupiPos.Y + 11;
                rect.Bottom = m_blupiPos.Y + 60 - 2;
                if (!DecorDetect(rect))
                {
                    break;
                }
                tinyRect.Left -= 2;
                tinyRect.Right -= 2;
                m_blupiPos.X -= 2;
            }
            for (int i = 0; i < 50; i++)
            {
                TinyRect rect = tinyRect;
                rect.Right = rect.Left + 2;
                if (!DecorDetect(rect))
                {
                    break;
                }
                tinyRect.Left += 2;
                tinyRect.Right += 2;
                m_blupiPos.X += 2;
            }
            for (int i = 0; i < 50; i++)
            {
                TinyRect rect = tinyRect;
                rect.Left = rect.Right - 2;
                if (!DecorDetect(rect))
                {
                    break;
                }
                tinyRect.Left -= 2;
                tinyRect.Right -= 2;
                m_blupiPos.X -= 2;
            }
        }

        private bool BlupiBloque(TinyPoint pos, int dir)
        {
            TinyRect rect = BlupiRect(pos);
            rect.Top = rect.Bottom - 20;
            rect.Bottom -= 2;
            if (dir > 0)
            {
                rect.Left = rect.Right - 2;
            }
            if (dir < 0)
            {
                rect.Right = rect.Left + 2;
            }
            return DecorDetect(rect);
        }

        private void BlupiStep()
        {
            TinyPoint celSwitch = default(TinyPoint);
            TinyPoint celBridge = default(TinyPoint);
            BlupiAdjust();
            m_blupiLastPos = m_blupiPos;
            TinyPoint end = m_blupiPos;
            bool flag = m_blupiAir;
            int blupiAction = m_blupiAction;
            bool bVertigoLeft = false;
            bool bVertigoRight = false;
            end.X += m_blupiVector.X;
            end.Y += m_blupiVector.Y;
            if (m_blupiFocus && (end.Y + 30) / 64 >= 99)
            {
                BlupiDead(75, -1);
                m_blupiRestart = true;
                m_blupiAir = true;
                m_blupiPos.Y = m_blupiPos.Y / 64 * 64 + BLUPIOFFY;
                PlaySound(8, m_blupiPos);
                return;
            }
            TinyRect rect = default(TinyRect);
            if (m_blupiVector.X != 0 || m_blupiVector.Y != 0)
            {
                rect = BlupiRect(m_blupiPos);
                rect.Top = m_blupiPos.Y + 11;
                rect.Bottom = m_blupiPos.Y + 60 - 2;
                TestPath(rect, m_blupiPos, ref end);
            }
            m_blupiVent = false;
            int icon;
            if (m_blupiTransport == -1 && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && m_blupiFocus)
            {
                icon = m_decor[(end.X + 30) / 64, (end.Y + 30) / 64].icon;
                if (icon == 110)
                {
                    end.X -= 9;
                }
                if (icon == 114)
                {
                    end.X += 9;
                }
                if (icon == 118)
                {
                    end.Y -= 20;
                }
                if (icon == 122)
                {
                    end.Y += 20;
                }
                if (icon >= 110 && icon <= 125)
                {
                    m_blupiVent = true;
                    rect.Left = m_blupiPos.X + 12;
                    rect.Right = m_blupiPos.X + 60 - 12;
                    rect.Top = m_blupiPos.Y + 11;
                    rect.Bottom = m_blupiPos.Y + 60 - 2;
                    TestPath(rect, m_blupiPos, ref end);
                }
            }
            bool flag2;
            if (m_blupiTransport == -1)
            {
                rect = BlupiRect(end);
                rect.Top = end.Y + 60 - 2;
                rect.Bottom = end.Y + 60 - 1;
                flag2 = !DecorDetect(rect);
            }
            else
            {
                flag2 = false;
            }
            rect = BlupiRect(end);
            rect.Top = end.Y + 10;
            rect.Bottom = end.Y + 20;
            bool flag3 = DecorDetect(rect);
            int detectIcon = m_detectIcon;
            if (!m_blupiAir && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && flag2 && m_blupiFocus)
            {
                if (m_blupiFocus)
                {
                    m_blupiAction = 5;
                    m_blupiPhase = 0;
                }
                m_blupiVitesseY = 1.0;
                m_blupiAir = true;
                flag = true;
            }
            if (!m_blupiNage && !m_blupiSurf && !m_blupiSuspend && !m_blupiAir && IsRessort(end))
            {
                if ((m_blupiHelico || m_blupiOver) && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi)
                {
                    m_blupiHelico = false;
                    m_blupiOver = false;
                    celSwitch.X = end.X - 34;
                    celSwitch.Y = end.Y - 34;
                    ObjectStart(celSwitch, 9, 0);
                    m_decorAction = 1;
                    m_decorPhase = 0;
                    StopSound(16);
                    StopSound(18);
                    StopSound(29);
                    StopSound(31);
                    PlaySound(10, m_blupiPos);
                }
                if (m_blupiJeep && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi)
                {
                    m_blupiJeep = false;
                    celSwitch.X = end.X - 34;
                    celSwitch.Y = end.Y - 34;
                    ObjectStart(celSwitch, 9, 0);
                    m_decorAction = 1;
                    m_decorPhase = 0;
                    StopSound(16);
                    StopSound(18);
                    StopSound(29);
                    StopSound(31);
                    PlaySound(10, m_blupiPos);
                }
                if (m_blupiTank && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi)
                {
                    m_blupiTank = false;
                    celSwitch.X = end.X - 34;
                    celSwitch.Y = end.Y - 34;
                    ObjectStart(celSwitch, 9, 0);
                    m_decorAction = 1;
                    m_decorPhase = 0;
                    StopSound(16);
                    StopSound(18);
                    StopSound(29);
                    StopSound(31);
                    PlaySound(10, m_blupiPos);
                }
                if (m_blupiSkate && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi)
                {
                    m_blupiSkate = false;
                    celSwitch.X = end.X - 34;
                    celSwitch.Y = end.Y - 34;
                    ObjectStart(celSwitch, 9, 0);
                    m_decorAction = 1;
                    m_decorPhase = 0;
                    StopSound(16);
                    StopSound(18);
                    StopSound(29);
                    StopSound(31);
                    PlaySound(10, m_blupiPos);
                }
                if (m_blupiFocus && m_blupiAction != 11 && m_blupiAction != 75 && m_blupiAction != 76 && m_blupiAction != 77 && m_blupiAction != 78 && m_blupiAction != 79 && m_blupiAction != 80 && m_blupiAction != 81)
                {
                    m_blupiAction = 5;
                    m_blupiPhase = 0;
                }
                if (((uint)m_keyPress & (true ? 1u : 0u)) != 0 && m_blupiFocus)
                {
                    m_blupiVitesseY = (m_blupiPower ? (-25) : (-19));
                }
                else
                {
                    m_blupiVitesseY = (m_blupiPower ? (-16) : (-10));
                }
                m_blupiAir = true;
                flag = true;
                PlaySound(41, end);
            }
            if (((uint)m_keyPress & (true ? 1u : 0u)) != 0 && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
            {
                if (m_blupiAction != 4 && m_blupiAction != 3 && !m_blupiAir)
                {
                    m_blupiAction = 4;
                    m_blupiPhase = 0;
                }
                if (m_blupiAction == 4 && m_blupiPhase == 3)
                {
                    m_blupiAction = 5;
                    m_blupiPhase = 0;
                    if (m_blupiSkate)
                    {
                        PlaySound(1, end);
                        m_blupiVitesseY = (m_blupiPower ? (-17) : (-13));
                    }
                    else
                    {
                        PlaySound(1, end);
                        if (IsNormalJump(end))
                        {
                            m_blupiVitesseY = (m_blupiPower ? (-26) : (-16));
                        }
                        else
                        {
                            m_blupiVitesseY = (m_blupiPower ? (-16) : (-12));
                        }
                    }
                    m_blupiAir = true;
                    flag = true;
                }
            }
            if (m_blupiAir)
            {
                if (flag3 && m_blupiVitesseY < 0.0)
                {
                    if (m_blupiVitesseY < -14.0 && m_blupiAction != 11 && m_blupiAction != 75 && m_blupiAction != 76 && m_blupiAction != 77 && m_blupiAction != 78 && m_blupiAction != 79 && m_blupiAction != 80 && m_blupiAction != 81 && !m_blupiSkate)
                    {
                        m_blupiJumpAie = true;
                        PlaySound(40, end);
                    }
                    else
                    {
                        PlaySound(SoundEnviron(4, detectIcon), end);
                    }
                    m_blupiVitesseY = 1.0;
                }
                end.Y += (int)(m_blupiVitesseY * 2.0);
                if (m_blupiVitesseY < 20.0)
                {
                    m_blupiVitesseY += 2.0;
                }
                rect = BlupiRect(end);
                rect.Top = end.Y + 60 - 30;
                rect.Bottom = end.Y + 60 - 1;
                if (m_blupiVitesseY >= 0.0 && DecorDetect(rect))
                {
                    end.Y = end.Y / 32 * 32 + BLUPIOFFY;
                    if (!IsRessort(end))
                    {
                        PlaySound(SoundEnviron(3, m_detectIcon), end);
                    }
                    if (m_blupiFocus)
                    {
                        if (m_blupiVitesseY > 20.0)
                        {
                            m_blupiAction = 61;
                        }
                        else
                        {
                            m_blupiAction = 61;
                        }
                        m_blupiPhase = 0;
                    }
                    m_blupiAir = false;
                    if (m_blupiJumpAie)
                    {
                        m_blupiJumpAie = false;
                        m_blupiAction = 36;
                        m_blupiPhase = 0;
                    }
                }
                rect.Left = end.X + 20;
                rect.Right = end.X + 60 - 20;
                rect.Top = end.Y + 60 - 33;
                rect.Bottom = end.Y + 60 - 1;
                icon = AscenseurDetect(rect, m_blupiPos, end);
                if (m_blupiVitesseY >= 0.0 && icon != -1)
                {
                    m_blupiTransport = icon;
                    flag2 = false;
                    PlaySound(3, end);
                    end.Y = m_moveObject[icon].posCurrent.Y - 64 + BLUPIOFFY;
                    if (m_blupiFocus)
                    {
                        if (m_blupiVitesseY > 20.0)
                        {
                            m_blupiAction = 61;
                        }
                        else
                        {
                            m_blupiAction = 61;
                        }
                        m_blupiPhase = 0;
                    }
                    m_blupiAir = false;
                    if (m_blupiJumpAie)
                    {
                        m_blupiJumpAie = false;
                        m_blupiAction = 36;
                        m_blupiPhase = 0;
                    }
                }
            }
            if (m_blupiAction == 36 && m_blupiPhase == 30)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
                m_blupiFocus = true;
            }
            if (m_blupiAction == 56 && m_blupiPhase == 64)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
                m_blupiFocus = true;
                m_blupiCloud = true;
                m_blupiTimeShield = 100;
                m_jauges[1].SetHide(false);
                PlaySound(55, end);
            }
            if (m_blupiAction == 58)
            {
                if (m_blupiPhase == 8)
                {
                    celSwitch.X = m_blupiPos.X;
                    celSwitch.Y = m_blupiPos.Y + 40;
                    if (m_blupiVitesseY > 0.0)
                    {
                        celSwitch.Y += (int)(m_blupiVitesseY * 4.0);
                    }
                    m_blupiVitesseY -= 10.0;
                    if (ObjectStart(celSwitch, 23, 55) != -1)
                    {
                        PlaySound(52, m_blupiPos);
                        m_blupiTimeFire = 10;
                        m_blupiBullet--;
                    }
                }
                if (m_blupiPhase == 14)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiFocus = true;
                }
            }
            if ((m_blupiAction == 44 || m_blupiAction == 45) && m_blupiPhase == 29)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
                m_blupiFocus = true;
            }
            if (m_blupiAction == 46 && m_blupiPhase == 32)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
                m_blupiFocus = true;
            }
            if (m_blupiAction == 47 && m_blupiPhase == 34)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
                m_blupiFocus = true;
            }
            bool bNear;
            if (m_blupiAction == 48 && m_blupiPhase == 40)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
                m_blupiFocus = true;
                icon = MoveObjectDetect(end, out bNear);
                if (icon != -1 && !bNear && end.Y - BLUPIFLOOR == m_moveObject[icon].posCurrent.Y)
                {
                    if (m_blupiDir == 2 && end.X < m_moveObject[icon].posCurrent.X)
                    {
                        celSwitch.X = end.X - 16;
                        celSwitch.Y = end.Y;
                        int num = MoveObjectDetect(celSwitch, out bNear);
                        if (num == -1)
                        {
                            m_blupiAction = 9;
                            m_blupiPhase = 0;
                        }
                    }
                    if (m_blupiDir == 1 && end.X > m_moveObject[icon].posCurrent.X)
                    {
                        celSwitch.X = end.X + 16;
                        celSwitch.Y = end.Y;
                        int num = MoveObjectDetect(celSwitch, out bNear);
                        if (num == -1)
                        {
                            m_blupiAction = 9;
                            m_blupiPhase = 0;
                        }
                    }
                }
            }
            if (m_blupiAction == 65)
            {
                if (m_blupiPhase == 4)
                {
                    PlaySound(47, m_blupiPos);
                }
                if (m_blupiPhase == 44)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiFocus = true;
                }
            }
            if (m_blupiAction == 63)
            {
                if (m_blupiPhase == 1)
                {
                    PlaySound(65, m_blupiPos);
                    m_blupiTimeMockery = 300;
                }
                if (m_blupiPhase == 92)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiFocus = true;
                }
            }
            if (m_blupiAction == 64)
            {
                if (m_blupiPhase == 6)
                {
                    PlaySound(65, m_blupiPos);
                    m_blupiTimeMockery = 300;
                }
                if (m_blupiPhase == 104)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiFocus = true;
                }
            }
            if (m_blupiAction == 83)
            {
                if (m_blupiPhase == 4)
                {
                    PlaySound(47, m_blupiPos);
                }
                if (m_blupiPhase == 60)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiFocus = true;
                }
            }
            if (m_blupiAction == 84 && m_blupiPhase == 18)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
                m_blupiFocus = true;
            }
            if (m_blupiAction == 60 && m_blupiPhase == 3)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
            }
            if (m_blupiAction == 61 && m_blupiPhase == 5)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
            }
            if (m_blupiAction == 62 && m_blupiPhase == 2)
            {
                m_blupiAction = 5;
                m_blupiPhase = 0;
                m_blupiVitesseY = -12.0;
                m_blupiAir = true;
                flag = true;
            }
            if (m_blupiAction == 49 && m_blupiPhase == 32)
            {
                ObjectStart(m_sucettePos, m_sucetteType, 0);
                m_blupiAction = 1;
                m_blupiPhase = 0;
                m_blupiFocus = true;
                m_blupiPower = true;
                m_blupiTimeShield = 100;
                m_blupiPosMagic = m_blupiPos;
                m_jauges[1].SetHide(false);
                PlaySound(44, end);
            }
            if (m_blupiAction == 55 && m_blupiPhase == 36)
            {
                ObjectStart(m_sucettePos, m_sucetteType, 0);
                m_blupiAction = 1;
                m_blupiPhase = 0;
                m_blupiFocus = true;
                m_blupiHide = true;
                m_blupiTimeShield = 100;
                m_blupiPosMagic = m_blupiPos;
                m_jauges[1].SetHide(false);
                PlaySound(62, end);
            }
            if (m_blupiSpeedY < 0.0 && m_blupiLastSpeedY == 0.0 && m_blupiAction != 3 && m_blupiAction != 4 && m_blupiAction != 5 && m_blupiAction != 8 && m_blupiAction != 10 && m_blupiAction != 9 && !m_blupiAir && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
            {
                m_blupiAction = 7;
                m_blupiPhase = 0;
            }
            if (m_blupiSpeedY == 0.0 && m_blupiLastSpeedY < 0.0 && m_blupiAction != 3 && m_blupiAction != 4 && m_blupiAction != 5 && m_blupiAction != 8 && m_blupiAction != 10 && m_blupiAction != 9 && !m_blupiAir && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
            }
            if (m_blupiSpeedY > 0.0 && m_blupiLastSpeedY == 0.0 && m_blupiAction != 3 && m_blupiAction != 4 && m_blupiAction != 5 && m_blupiAction != 6 && m_blupiAction != 28 && m_blupiAction != 8 && m_blupiAction != 10 && m_blupiAction != 9 && !m_blupiAir && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
            {
                m_blupiAction = 6;
                m_blupiPhase = 0;
            }
            if (m_blupiSpeedY > 0.0 && m_blupiSpeedX == 0.0 && (m_keyPress & 1) == 0 && m_blupiAction != 3 && m_blupiAction != 4 && m_blupiAction != 5 && m_blupiAction != 6 && m_blupiAction != 28 && m_blupiAction != 8 && m_blupiAction != 10 && m_blupiAction != 9 && !m_blupiAir && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
            {
                m_blupiAction = 6;
                m_blupiPhase = 0;
            }
            if (m_blupiSpeedY == 0.0 && m_blupiLastSpeedY > 0.0 && m_blupiAction != 3 && m_blupiAction != 4 && m_blupiAction != 5 && m_blupiAction != 8 && m_blupiAction != 10 && m_blupiAction != 9 && !m_blupiAir && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
            }
            if (m_blupiAction == 7 && m_blupiPhase == 4)
            {
                m_scrollAdd.Y = -150;
                PlaySound(21, end);
            }
            if (m_blupiAction == 6 && m_blupiPhase == 4)
            {
                m_scrollAdd.Y = 150;
                PlaySound(7, end);
            }
            if (!m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
            {
                if (m_blupiSpeedY > 0.0 && m_blupiSpeedX == 0.0 && (m_keyPress & 1) == 0 && m_blupiAction != 28 && m_blupiDir == 1 && (icon = CaisseInFront()) != -1)
                {
                    end.X = m_moveObject[icon].posCurrent.X + 64 - 5;
                    m_blupiAction = 28;
                    m_blupiPhase = 0;
                    m_scrollAdd.Y = 0;
                    PlaySound(39, end);
                }
                if (m_blupiSpeedY > 0.0 && m_blupiSpeedX > 0.0 && (m_keyPress & 1) == 0 && m_blupiAction != 29 && m_blupiDir == 1 && (icon = CaisseInFront()) != -1)
                {
                    m_blupiAction = 29;
                    m_blupiPhase = 0;
                    m_scrollAdd.Y = 0;
                    PlaySound(39, end);
                }
                if (m_blupiSpeedY > 0.0 && m_blupiSpeedX == 0.0 && (m_keyPress & 1) == 0 && m_blupiAction != 28 && m_blupiDir == 2 && (icon = CaisseInFront()) != -1)
                {
                    end.X = m_moveObject[icon].posCurrent.X - 60 + 5;
                    m_blupiAction = 28;
                    m_blupiPhase = 0;
                    m_scrollAdd.Y = 0;
                    PlaySound(39, end);
                }
                if (m_blupiSpeedY > 0.0 && m_blupiSpeedX < 0.0 && (m_keyPress & 1) == 0 && m_blupiAction != 29 && m_blupiDir == 2 && (icon = CaisseInFront()) != -1)
                {
                    m_blupiAction = 29;
                    m_blupiPhase = 0;
                    m_scrollAdd.Y = 0;
                    PlaySound(39, end);
                }
                if (m_blupiAction == 29 && m_blupiActionOuf != 47)
                {
                    m_blupiActionOuf = 47;
                    m_blupiTimeOuf = 0;
                }
            }
            if (m_blupiAction != 28 && m_blupiAction != 29 && m_blupiFocus)
            {
                if (m_blupiSpeedX < 0.0 && m_blupiLastSpeedX == 0.0 && !m_blupiAir && m_blupiSpeedY != 0.0)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                }
                if (m_blupiSpeedX == 0.0 && m_blupiLastSpeedX < 0.0 && m_blupiSpeedY != 0.0)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                }
                if (m_blupiSpeedX > 0.0 && m_blupiLastSpeedX == 0.0 && !m_blupiAir && m_blupiSpeedY != 0.0)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                }
                if (m_blupiSpeedX == 0.0 && m_blupiLastSpeedX > 0.0 && m_blupiSpeedY != 0.0)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                }
            }
            int num2;
            int num3;
            if (m_blupiSpeedX < 0.0 && m_blupiFocus)
            {
                if (m_blupiDir == 2 && m_blupiAction != 3 && m_blupiAction != 59 && m_blupiAction != 7 && m_blupiAction != 6 && m_blupiAction != 29 && ((!m_blupiJeep && !m_blupiTank && !m_blupiSkate) || Math.Abs(m_blupiVitesseX) <= 8.0))
                {
                    if (m_blupiAir)
                    {
                        PlaySound(5, end);
                        m_blupiAction = 59;
                        m_blupiPhase = 0;
                        m_blupiDir = 1;
                    }
                    else
                    {
                        PlaySound(5, end);
                        m_blupiAction = 3;
                        m_blupiPhase = 0;
                    }
                }
                if (m_blupiDir == 1 && m_blupiAction != 2 && m_blupiAction != 14 && m_blupiAction != 4 && m_blupiAction != 7 && m_blupiAction != 6 && m_blupiAction != 29 && !m_blupiAir)
                {
                    m_blupiAction = 2;
                    m_blupiPhase = 0;
                }
                if (m_blupiDir == 1 && m_blupiAction != 3 && m_blupiAction != 4 && m_blupiAction != 7 && m_blupiAction != 6 && m_blupiAction != 29 && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend)
                {
                    if (m_blupiAction == 14)
                    {
                        end.X -= CaisseGetMove(5);
                    }
                    else
                    {
                        num2 = m_blupiPhase;
                        if (num2 > 3 || m_blupiAir)
                        {
                            num2 = 3;
                        }
                        num3 = Tables.table_vitesse_march[num2];
                        if (m_blupiPower)
                        {
                            num3 *= 3;
                            num3 /= 2;
                        }
                        end.X += Misc.Speed(m_blupiSpeedX, num3);
                    }
                }
                if (m_blupiDir == 2 && m_blupiAction == 29)
                {
                    end.X -= CaisseGetMove(3);
                }
            }
            if (m_blupiSpeedX > 0.0 && m_blupiFocus)
            {
                if (m_blupiDir == 1 && m_blupiAction != 3 && m_blupiAction != 59 && m_blupiAction != 7 && m_blupiAction != 6 && m_blupiAction != 29 && ((!m_blupiJeep && !m_blupiTank && !m_blupiSkate) || Math.Abs(m_blupiVitesseX) <= 8.0))
                {
                    if (m_blupiAir)
                    {
                        PlaySound(5, end);
                        m_blupiAction = 59;
                        m_blupiPhase = 0;
                        m_blupiDir = 2;
                    }
                    else
                    {
                        PlaySound(5, end);
                        m_blupiAction = 3;
                        m_blupiPhase = 0;
                    }
                }
                if (m_blupiDir == 2 && m_blupiAction != 2 && m_blupiAction != 14 && m_blupiAction != 4 && m_blupiAction != 7 && m_blupiAction != 6 && m_blupiAction != 29 && !m_blupiAir)
                {
                    m_blupiAction = 2;
                    m_blupiPhase = 0;
                }
                if (m_blupiDir == 2 && m_blupiAction != 3 && m_blupiAction != 4 && m_blupiAction != 7 && m_blupiAction != 6 && m_blupiAction != 29 && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend)
                {
                    if (m_blupiAction == 14)
                    {
                        end.X += CaisseGetMove(5);
                    }
                    else
                    {
                        num2 = m_blupiPhase;
                        if (num2 > 3 || m_blupiAir)
                        {
                            num2 = 3;
                        }
                        num3 = Tables.table_vitesse_march[num2];
                        if (m_blupiPower)
                        {
                            num3 *= 3;
                            num3 /= 2;
                        }
                        end.X += Misc.Speed(m_blupiSpeedX, num3);
                    }
                }
                if (m_blupiDir == 1 && m_blupiAction == 29)
                {
                    end.X += CaisseGetMove(3);
                }
            }
            if (m_blupiHelico)
            {
                if (m_blupiAction == 3 && m_blupiPhase == 10)
                {
                    m_blupiAction = 2;
                    if (m_blupiDir == 1)
                    {
                        m_blupiDir = 2;
                    }
                    else
                    {
                        m_blupiDir = 1;
                    }
                }
            }
            else if (m_blupiOver)
            {
                if (m_blupiAction == 3 && m_blupiPhase == 7)
                {
                    m_blupiAction = 2;
                    if (m_blupiDir == 1)
                    {
                        m_blupiDir = 2;
                    }
                    else
                    {
                        m_blupiDir = 1;
                    }
                }
            }
            else if (m_blupiJeep)
            {
                if (m_blupiAction == 3 && m_blupiPhase == 7)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    if (m_blupiDir == 1)
                    {
                        m_blupiDir = 2;
                    }
                    else
                    {
                        m_blupiDir = 1;
                    }
                }
            }
            else if (m_blupiTank)
            {
                if (m_blupiAction == 3 && m_blupiPhase == 12)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    if (m_blupiDir == 1)
                    {
                        m_blupiDir = 2;
                    }
                    else
                    {
                        m_blupiDir = 1;
                    }
                }
            }
            else if (m_blupiSkate)
            {
                if (m_blupiAction == 3 && m_blupiPhase == 14)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    if (m_blupiDir == 1)
                    {
                        m_blupiDir = 2;
                    }
                    else
                    {
                        m_blupiDir = 1;
                    }
                }
            }
            else if (m_blupiNage || m_blupiSurf)
            {
                if (m_blupiAction == 3 && m_blupiPhase == 10)
                {
                    m_blupiAction = 2;
                    if (m_blupiDir == 1)
                    {
                        m_blupiDir = 2;
                    }
                    else
                    {
                        m_blupiDir = 1;
                    }
                }
            }
            else if (m_blupiSuspend)
            {
                if (m_blupiAction == 3 && m_blupiPhase == 10)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    if (m_blupiDir == 1)
                    {
                        m_blupiDir = 2;
                    }
                    else
                    {
                        m_blupiDir = 1;
                    }
                }
            }
            else
            {
                if (m_blupiAction == 3 && m_blupiPhase == 6)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    if (m_blupiDir == 1)
                    {
                        m_blupiDir = 2;
                    }
                    else
                    {
                        m_blupiDir = 1;
                    }
                }
                if (m_blupiAction == 59 && m_blupiPhase == 6)
                {
                    m_blupiAction = 5;
                    m_blupiPhase = 0;
                }
            }
            if (!m_blupiSuspend && m_blupiAction == 4 && m_blupiPhase == 3)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
            }
            if (m_blupiSpeedX == 0.0 && m_blupiSpeedY == 0.0 && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && m_blupiFocus)
            {
                if (m_blupiAction == 14 || m_blupiAction == 7)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                }
                if (m_blupiAction == 2)
                {
                    if (m_blupiSuspend || m_blupiPhase < 10)
                    {
                        m_blupiAction = 1;
                    }
                    else
                    {
                        m_blupiAction = 60;
                    }
                    m_blupiPhase = 0;
                }
                if (m_blupiAction == 6)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    PlaySound(20, end);
                }
                m_scrollAdd.Y = 0;
                if (blupiAction == 14)
                {
                    StopSound(38);
                }
                if (blupiAction == 29 || blupiAction == 28)
                {
                    StopSound(39);
                }
            }
            if (!m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && m_blupiFocus)
            {
                if (m_blupiAction == 9 && m_blupiDir == 1)
                {
                    end.X += 4;
                }
                if (m_blupiAction == 9 && m_blupiDir == 2)
                {
                    end.X -= 4;
                }
                if (m_blupiAction == 10 && m_blupiDir == 1)
                {
                    end.X -= 4;
                }
                if (m_blupiAction == 10 && m_blupiDir == 2)
                {
                    end.X += 4;
                }
            }
            if ((m_keyPress & -3) == 0 && m_blupiSpeedX == 0.0 && m_blupiSpeedY == 0.0 && (m_blupiJeep || m_blupiTank || m_blupiSkate) && m_blupiFocus)
            {
                if (m_blupiAction == 10 && m_blupiDir == 1)
                {
                    end.X -= 5;
                }
                if (m_blupiAction == 10 && m_blupiDir == 2)
                {
                    end.X += 5;
                }
            }
            if ((m_keyPress & -3) == 0 && m_blupiSpeedX == 0.0 && m_blupiSpeedY == 0.0 && m_blupiNage && m_blupiFocus && m_blupiAction == 2)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
            }
            if ((m_keyPress & -3) == 0 && m_blupiSpeedX == 0.0 && m_blupiSpeedY == 0.0 && m_blupiSurf && m_blupiFocus && m_blupiAction == 2)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
            }
            if (m_blupiHelico && (m_blupiFocus || m_blupiAction == 58))
            {
                if (((uint)m_keyPress & 2u) != 0 && m_blupiTimeFire == 0 && m_blupiAction != 3 && m_blupiAction != 58 && flag2)
                {
                    if (m_blupiBullet == 0)
                    {
                        PlaySound(53, m_blupiPos);
                    }
                    else
                    {
                        m_blupiAction = 58;
                        m_blupiPhase = 0;
                        m_blupiFocus = false;
                    }
                }
                m_blupiMotorHigh = flag2;
                if (m_blupiAction != 3 && m_blupiAction != 58)
                {
                    if (flag2)
                    {
                        m_blupiAction = 2;
                    }
                    else
                    {
                        m_blupiAction = 1;
                        m_blupiPhase = 0;
                        m_blupiVitesseY = 0.0;
                    }
                }
                if (Def.EasyMove)
                {
                    if (m_blupiSpeedY <= -1.0 || ((uint)m_keyPress & (true ? 1u : 0u)) != 0)
                    {
                        if (m_blupiVitesseY > -7.0)
                        {
                            m_blupiVitesseY -= 0.5;
                        }
                        if (m_blupiVitesseY == -0.5)
                        {
                            m_blupiVitesseY = -1.0;
                        }
                    }
                    else if (m_blupiSpeedY >= 1.0)
                    {
                        if (m_blupiVitesseY < 8.0)
                        {
                            m_blupiVitesseY += 0.5;
                        }
                    }
                    else
                    {
                        if (m_blupiVitesseY > 1.0)
                        {
                            m_blupiVitesseY -= 1.0;
                        }
                        if (m_blupiVitesseY < 1.0)
                        {
                            m_blupiVitesseY += 1.0;
                        }
                    }
                    end.Y += (int)m_blupiVitesseY;
                }
                else
                {
                    if (m_blupiSpeedY <= -1.0 || ((uint)m_keyPress & (true ? 1u : 0u)) != 0)
                    {
                        if (m_blupiVitesseY > -10.0)
                        {
                            m_blupiVitesseY -= 0.5;
                        }
                    }
                    else if (m_blupiSpeedY >= 1.0)
                    {
                        if (m_blupiVitesseY < 12.0)
                        {
                            m_blupiVitesseY += 0.5;
                        }
                    }
                    else
                    {
                        if (m_blupiVitesseY > 1.0)
                        {
                            m_blupiVitesseY -= 1.0;
                        }
                        if (m_blupiVitesseY < 1.0)
                        {
                            m_blupiVitesseY += 1.0;
                        }
                    }
                    end.Y += (int)m_blupiVitesseY;
                }
                if (Def.EasyMove)
                {
                    if (m_blupiSpeedX <= -1.0)
                    {
                        int num4 = (int)(m_blupiSpeedX * 12.0);
                        if (m_blupiVitesseX > (double)num4)
                        {
                            m_blupiVitesseX -= 0.5;
                        }
                        celSwitch.X = end.X + (int)m_blupiVitesseX;
                        celSwitch.Y = end.Y;
                        if (BlupiBloque(celSwitch, -1))
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                    else if (m_blupiSpeedX >= 1.0)
                    {
                        int num5 = (int)(m_blupiSpeedX * 12.0);
                        if (m_blupiVitesseX < (double)num5)
                        {
                            m_blupiVitesseX += 0.5;
                        }
                        celSwitch.X = end.X + (int)m_blupiVitesseX;
                        celSwitch.Y = end.Y;
                        if (BlupiBloque(celSwitch, 1))
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                    else
                    {
                        if (m_blupiVitesseX > 0.0)
                        {
                            m_blupiVitesseX -= 2.0;
                            if (m_blupiVitesseX < 0.0)
                            {
                                m_blupiVitesseX = 0.0;
                            }
                        }
                        if (m_blupiVitesseX < 0.0)
                        {
                            m_blupiVitesseX += 2.0;
                            if (m_blupiVitesseX > 0.0)
                            {
                                m_blupiVitesseX = 0.0;
                            }
                        }
                    }
                    end.X += (int)m_blupiVitesseX;
                }
                else
                {
                    if (m_blupiSpeedX <= -1.0)
                    {
                        int num6 = (int)(m_blupiSpeedX * 16.0);
                        if (m_blupiVitesseX > (double)num6)
                        {
                            m_blupiVitesseX -= 1.0;
                        }
                        celSwitch.X = end.X + (int)m_blupiVitesseX;
                        celSwitch.Y = end.Y;
                        if (BlupiBloque(celSwitch, -1))
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                    else if (m_blupiSpeedX >= 1.0)
                    {
                        int num7 = (int)(m_blupiSpeedX * 16.0);
                        if (m_blupiVitesseX < (double)num7)
                        {
                            m_blupiVitesseX += 1.0;
                        }
                        celSwitch.X = end.X + (int)m_blupiVitesseX;
                        celSwitch.Y = end.Y;
                        if (BlupiBloque(celSwitch, 1))
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                    else
                    {
                        if (m_blupiVitesseX > 0.0)
                        {
                            m_blupiVitesseX -= 2.0;
                            if (m_blupiVitesseX < 0.0)
                            {
                                m_blupiVitesseX = 0.0;
                            }
                        }
                        if (m_blupiVitesseX < 0.0)
                        {
                            m_blupiVitesseX += 2.0;
                            if (m_blupiVitesseX > 0.0)
                            {
                                m_blupiVitesseX = 0.0;
                            }
                        }
                    }
                    end.X += (int)m_blupiVitesseX;
                }
                MoveObjectPollution();
                if (ButtonPressed == Def.ButtonGlygh.PlayAction && !flag2 && m_blupiTransport == -1)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    rect.Left = m_blupiPos.X + 20;
                    rect.Right = m_blupiPos.X + 22;
                    rect.Top = m_blupiPos.Y + 60 - 2;
                    rect.Bottom = m_blupiPos.Y + 60;
                    bVertigoLeft = !DecorDetect(rect);
                    rect.Left = m_blupiPos.X + 60 - 22;
                    rect.Right = m_blupiPos.X + 60 - 20;
                    rect.Top = m_blupiPos.Y + 60 - 2;
                    rect.Bottom = m_blupiPos.Y + 60;
                    bVertigoRight = !DecorDetect(rect);
                    if (!bVertigoLeft && !bVertigoRight)
                    {
                        celSwitch.X = m_blupiPos.X;
                        celSwitch.Y = m_blupiPos.Y - BLUPIFLOOR;
                        ObjectStart(celSwitch, 13, 0);
                        m_blupiHelico = false;
                        m_blupiAction = 1;
                        m_blupiPhase = 0;
                        m_blupiPosHelico = m_blupiPos;
                        m_blupiFocus = true;
                        StopSound(16);
                        StopSound(18);
                        PlaySound(17, m_blupiPos);
                    }
                }
            }
            if (m_blupiOver && (m_blupiFocus || m_blupiAction == 58))
            {
                m_blupiMotorHigh = flag2;
                if (m_blupiAction != 3)
                {
                    if (flag2)
                    {
                        m_blupiAction = 2;
                    }
                    else
                    {
                        if (m_blupiAction != 1)
                        {
                            m_blupiAction = 1;
                            m_blupiPhase = 0;
                        }
                        m_blupiVitesseY = 0.0;
                    }
                }
                rect = BlupiRect(end);
                rect.Top = end.Y + 60 - 2;
                rect.Bottom = end.Y + 60 + OVERHEIGHT - 1;
                bool flag4 = !DecorDetect(rect);
                icon = MoveAscenseurDetect(m_blupiPos, OVERHEIGHT);
                if (icon != -1)
                {
                    flag4 = false;
                }
                if ((m_blupiSpeedY < 0.0 || ((uint)m_keyPress & (true ? 1u : 0u)) != 0) && !flag4)
                {
                    if (m_blupiVitesseY == 0.0 && icon != -1)
                    {
                        m_blupiVitesseY = -5.0;
                    }
                    else if (m_blupiVitesseY > -5.0)
                    {
                        m_blupiVitesseY -= 1.0;
                    }
                }
                else if (m_blupiSpeedY > 0.0)
                {
                    if (m_blupiVitesseY < 12.0)
                    {
                        m_blupiVitesseY += 5.0;
                    }
                }
                else if (m_blupiVitesseY < 12.0 && m_time % 2 == 0)
                {
                    m_blupiVitesseY += 1.0;
                }
                end.Y += (int)m_blupiVitesseY;
                if (m_blupiSpeedX < 0.0 && flag2)
                {
                    int num8 = (int)(m_blupiSpeedX * 12.0);
                    if (m_blupiVitesseX > (double)num8)
                    {
                        m_blupiVitesseX -= 1.0;
                    }
                    celSwitch.X = end.X + (int)m_blupiVitesseX;
                    celSwitch.Y = end.Y;
                    if (BlupiBloque(celSwitch, -1))
                    {
                        m_blupiVitesseX = 0.0;
                    }
                }
                else if (m_blupiSpeedX > 0.0 && flag2)
                {
                    int num9 = (int)(m_blupiSpeedX * 12.0);
                    if (m_blupiVitesseX < (double)num9)
                    {
                        m_blupiVitesseX += 1.0;
                    }
                    celSwitch.X = end.X + (int)m_blupiVitesseX;
                    celSwitch.Y = end.Y;
                    if (BlupiBloque(celSwitch, 1))
                    {
                        m_blupiVitesseX = 0.0;
                    }
                }
                else
                {
                    if (m_blupiVitesseX > 0.0)
                    {
                        m_blupiVitesseX -= 1.0;
                    }
                    if (m_blupiVitesseX < 0.0)
                    {
                        m_blupiVitesseX += 1.0;
                    }
                }
                end.X += (int)m_blupiVitesseX;
                MoveObjectPollution();
                if (ButtonPressed == Def.ButtonGlygh.PlayAction && !flag2 && m_blupiTransport == -1)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    rect.Left = m_blupiPos.X + 20;
                    rect.Right = m_blupiPos.X + 22;
                    rect.Top = m_blupiPos.Y + 60 - 2;
                    rect.Bottom = m_blupiPos.Y + 60;
                    bVertigoLeft = !DecorDetect(rect);
                    rect.Left = m_blupiPos.X + 60 - 22;
                    rect.Right = m_blupiPos.X + 60 - 20;
                    rect.Top = m_blupiPos.Y + 60 - 2;
                    rect.Bottom = m_blupiPos.Y + 60;
                    bVertigoRight = !DecorDetect(rect);
                    if (!bVertigoLeft && !bVertigoRight)
                    {
                        celSwitch.X = m_blupiPos.X;
                        celSwitch.Y = m_blupiPos.Y - BLUPIFLOOR;
                        ObjectStart(celSwitch, 46, 0);
                        m_blupiOver = false;
                        m_blupiAction = 1;
                        m_blupiPhase = 0;
                        m_blupiPosHelico = m_blupiPos;
                        m_blupiFocus = true;
                        StopSound(16);
                        StopSound(18);
                        PlaySound(17, m_blupiPos);
                    }
                }
            }
            if (m_blupiBalloon && m_blupiFocus)
            {
                if (m_blupiSpeedY < 0.0 || ((uint)m_keyPress & (true ? 1u : 0u)) != 0)
                {
                    if (m_blupiVitesseY > -5.0 && m_time % 6 == 0)
                    {
                        m_blupiVitesseY -= 1.0;
                    }
                }
                else if (m_blupiSpeedY > 0.0)
                {
                    if (m_blupiVitesseY < 0.0 && m_time % 6 == 0)
                    {
                        m_blupiVitesseY += 1.0;
                    }
                }
                else if (m_blupiVitesseY > -3.0 && m_time % 6 == 0)
                {
                    m_blupiVitesseY -= 1.0;
                }
                end.Y += (int)m_blupiVitesseY;
                if (m_blupiSpeedX < 0.0)
                {
                    int num10 = (int)(m_blupiSpeedX * 10.0);
                    if (m_blupiVitesseX > (double)num10)
                    {
                        m_blupiVitesseX -= 1.0;
                    }
                    celSwitch.X = end.X + (int)m_blupiVitesseX;
                    celSwitch.Y = end.Y;
                    if (BlupiBloque(celSwitch, -1))
                    {
                        m_blupiVitesseX = 0.0;
                    }
                }
                else if (m_blupiSpeedX > 0.0)
                {
                    int num11 = (int)(m_blupiSpeedX * 10.0);
                    if (m_blupiVitesseX < (double)num11)
                    {
                        m_blupiVitesseX += 1.0;
                    }
                    celSwitch.X = end.X + (int)m_blupiVitesseX;
                    celSwitch.Y = end.Y;
                    if (BlupiBloque(celSwitch, 1))
                    {
                        m_blupiVitesseX = 0.0;
                    }
                }
                else
                {
                    if (m_blupiVitesseX > 0.0)
                    {
                        m_blupiVitesseX -= 2.0;
                        if (m_blupiVitesseX < 0.0)
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                    if (m_blupiVitesseX < 0.0)
                    {
                        m_blupiVitesseX += 2.0;
                        if (m_blupiVitesseX > 0.0)
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                }
                end.X += (int)m_blupiVitesseX;
            }
            if (m_blupiEcrase && m_blupiFocus)
            {
                if (flag2)
                {
                    if (m_blupiVitesseY < 2.0)
                    {
                        m_blupiVitesseY += 1.0;
                    }
                }
                else
                {
                    m_blupiVitesseY = 0.0;
                }
                end.Y += (int)m_blupiVitesseY;
                num2 = ((!flag2) ? 4 : 7);
                num2 = (int)((double)num2 * m_blupiSpeedX);
                if (m_blupiSpeedX < 0.0)
                {
                    if (m_blupiVitesseX > (double)num2)
                    {
                        m_blupiVitesseX -= 1.0;
                    }
                    celSwitch.X = end.X + (int)m_blupiVitesseX;
                    celSwitch.Y = end.Y;
                    if (BlupiBloque(celSwitch, -1))
                    {
                        m_blupiVitesseX = 0.0;
                    }
                }
                else if (m_blupiSpeedX > 0.0)
                {
                    if (m_blupiVitesseX < (double)num2)
                    {
                        m_blupiVitesseX += 1.0;
                    }
                    celSwitch.X = end.X + (int)m_blupiVitesseX;
                    celSwitch.Y = end.Y;
                    if (BlupiBloque(celSwitch, 1))
                    {
                        m_blupiVitesseX = 0.0;
                    }
                }
                else
                {
                    if (m_blupiVitesseX > 0.0)
                    {
                        m_blupiVitesseX -= 2.0;
                        if (m_blupiVitesseX < 0.0)
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                    if (m_blupiVitesseX < 0.0)
                    {
                        m_blupiVitesseX += 2.0;
                        if (m_blupiVitesseX > 0.0)
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                }
                if (m_blupiVitesseX == 0.0 && !flag2)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                }
                end.X += (int)m_blupiVitesseX;
            }
            if (m_blupiJeep && m_blupiFocus)
            {
                if (m_blupiVitesseX == 0.0 && m_blupiAction == 2)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                }
                m_blupiMotorHigh = m_blupiAction != 1;
                rect = BlupiRect(end);
                rect.Right -= 40;
                rect.Top = end.Y + 60 - 2;
                rect.Bottom = end.Y + 60 - 1;
                bool flag5 = !DecorDetect(rect);
                rect.Left += 40;
                rect.Right += 40;
                bool flag6 = !DecorDetect(rect);
                if (flag2)
                {
                    if (m_blupiVitesseY < 50.0)
                    {
                        m_blupiVitesseY += 5.0;
                    }
                }
                else
                {
                    if (m_blupiVitesseY != 0.0)
                    {
                        PlaySound(3, m_blupiPos);
                    }
                    m_blupiVitesseY = 0.0;
                }
                end.Y += (int)m_blupiVitesseY;
                if (m_blupiTransport == -1)
                {
                    rect.Left = end.X + 20;
                    rect.Right = end.X + 60 - 20;
                    rect.Top = end.Y + 60 - 35;
                    rect.Bottom = end.Y + 60 - 1;
                    icon = AscenseurDetect(rect, m_blupiPos, end);
                    if (m_blupiVitesseY >= 0.0 && icon != -1)
                    {
                        m_blupiTransport = icon;
                        flag2 = false;
                        PlaySound(3, end);
                        end.Y = m_moveObject[icon].posCurrent.Y - 64 + BLUPIOFFY;
                    }
                }
                if (flag5 && !flag6)
                {
                    int num12 = -20;
                    if (m_blupiVitesseX > (double)num12)
                    {
                        m_blupiVitesseX -= 1.0;
                    }
                }
                else if (!flag5 && flag6)
                {
                    int num13 = 20;
                    if (m_blupiVitesseX < (double)num13)
                    {
                        m_blupiVitesseX += 1.0;
                    }
                }
                else if (m_blupiSpeedX < 0.0)
                {
                    int num14 = (int)(m_blupiSpeedX * 20.0);
                    if (m_blupiVitesseX > (double)num14)
                    {
                        m_blupiVitesseX -= 1.0;
                    }
                }
                else if (m_blupiSpeedX > 0.0)
                {
                    int num15 = (int)(m_blupiSpeedX * 20.0);
                    if (m_blupiVitesseX < (double)num15)
                    {
                        m_blupiVitesseX += 1.0;
                    }
                }
                else
                {
                    if (m_blupiVitesseX > 0.0)
                    {
                        m_blupiVitesseX -= 2.0;
                        if (m_blupiVitesseX < 0.0)
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                    if (m_blupiVitesseX < 0.0)
                    {
                        m_blupiVitesseX += 2.0;
                        if (m_blupiVitesseX > 0.0)
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                }
                if (m_blupiAction == 3)
                {
                    m_blupiVitesseX = 0.0;
                }
                end.X += (int)m_blupiVitesseX;
                if (flag5 && !flag6)
                {
                    m_blupiRealRotation = Misc.Approch(m_blupiRealRotation, -45, 5);
                }
                else if (!flag5 && flag6)
                {
                    m_blupiRealRotation = Misc.Approch(m_blupiRealRotation, 45, 5);
                }
                else if (!flag2)
                {
                    m_blupiRealRotation = 0;
                }
                m_blupiOffsetY = Math.Abs(m_blupiRealRotation / 2);
                MoveObjectPollution();
                if (ButtonPressed == Def.ButtonGlygh.PlayAction && !flag2 && m_blupiTransport == -1)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    celSwitch.X = m_blupiPos.X;
                    celSwitch.Y = m_blupiPos.Y - BLUPIFLOOR;
                    ObjectStart(celSwitch, 19, 0);
                    m_blupiJeep = false;
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiPosHelico = m_blupiPos;
                    StopSound(29);
                    StopSound(31);
                    PlaySound(30, m_blupiPos);
                }
            }
            if (m_blupiTank && m_blupiFocus)
            {
                if (m_blupiAction == 53 && m_blupiPhase == 6)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                }
                if (((uint)m_keyPress & 2u) != 0 && m_blupiTimeFire == 0 && m_blupiAction != 3)
                {
                    if (m_blupiBullet == 0)
                    {
                        PlaySound(53, m_blupiPos);
                    }
                    else
                    {
                        if (m_blupiDir == 1)
                        {
                            celSwitch.X = m_blupiPos.X - 35;
                            celSwitch.Y = m_blupiPos.Y;
                            num3 = -5;
                            m_blupiVitesseX += 12.0;
                        }
                        else
                        {
                            celSwitch.X = m_blupiPos.X + 35;
                            celSwitch.Y = m_blupiPos.Y;
                            num3 = 5;
                            m_blupiVitesseX -= 12.0;
                        }
                        if (ObjectStart(celSwitch, 23, num3) != -1)
                        {
                            m_blupiAction = 53;
                            m_blupiPhase = 0;
                            PlaySound(52, m_blupiPos);
                            m_blupiTimeFire = 10;
                            m_blupiBullet--;
                        }
                    }
                }
                if (m_blupiVitesseX == 0.0 && m_blupiAction == 2)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                }
                m_blupiMotorHigh = m_blupiAction != 1;
                if (flag2)
                {
                    if (m_blupiVitesseY < 50.0)
                    {
                        m_blupiVitesseY += 5.0;
                    }
                }
                else
                {
                    if (m_blupiVitesseY != 0.0)
                    {
                        PlaySound(3, m_blupiPos);
                    }
                    m_blupiVitesseY = 0.0;
                }
                end.Y += (int)m_blupiVitesseY;
                if (m_blupiTransport == -1)
                {
                    rect.Left = end.X + 20;
                    rect.Right = end.X + 60 - 20;
                    rect.Top = end.Y + 60 - 35;
                    rect.Bottom = end.Y + 60 - 1;
                    icon = AscenseurDetect(rect, m_blupiPos, end);
                    if (m_blupiVitesseY >= 0.0 && icon != -1)
                    {
                        m_blupiTransport = icon;
                        flag2 = false;
                        PlaySound(3, end);
                        end.Y = m_moveObject[icon].posCurrent.Y - 64 + BLUPIOFFY;
                    }
                }
                if (m_blupiSpeedX < 0.0)
                {
                    int num16 = (int)(m_blupiSpeedX * 12.0);
                    if (m_blupiVitesseX > (double)num16)
                    {
                        m_blupiVitesseX -= 1.0;
                    }
                }
                else if (m_blupiSpeedX > 0.0)
                {
                    int num17 = (int)(m_blupiSpeedX * 12.0);
                    if (m_blupiVitesseX < (double)num17)
                    {
                        m_blupiVitesseX += 1.0;
                    }
                }
                else
                {
                    if (m_blupiVitesseX > 0.0)
                    {
                        m_blupiVitesseX -= 3.0;
                        if (m_blupiVitesseX < 0.0)
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                    if (m_blupiVitesseX < 0.0)
                    {
                        m_blupiVitesseX += 3.0;
                        if (m_blupiVitesseX > 0.0)
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                }
                if (m_blupiAction == 3)
                {
                    m_blupiVitesseX = 0.0;
                }
                end.X += (int)m_blupiVitesseX;
                MoveObjectPollution();
                if (ButtonPressed == Def.ButtonGlygh.PlayAction && !flag2 && m_blupiTransport == -1)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    celSwitch.X = m_blupiPos.X;
                    celSwitch.Y = m_blupiPos.Y;
                    ObjectStart(celSwitch, 28, 0);
                    m_blupiTank = false;
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiPosHelico = m_blupiPos;
                    StopSound(29);
                    StopSound(31);
                    PlaySound(30, m_blupiPos);
                }
            }
            if (m_blupiSkate && m_blupiFocus)
            {
                if (m_blupiVitesseX == 0.0 && m_blupiAction == 2)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                }
                if (m_blupiSpeedX < 0.0)
                {
                    int num18 = (int)(m_blupiSpeedX * 15.0);
                    if (m_blupiVitesseX > (double)num18)
                    {
                        m_blupiVitesseX -= 1.0;
                    }
                }
                else if (m_blupiSpeedX > 0.0)
                {
                    int num19 = (int)(m_blupiSpeedX * 15.0);
                    if (m_blupiVitesseX < (double)num19)
                    {
                        m_blupiVitesseX += 1.0;
                    }
                }
                else
                {
                    if (m_blupiVitesseX > 0.0)
                    {
                        m_blupiVitesseX -= 1.0;
                        if (m_blupiVitesseX < 0.0)
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                    if (m_blupiVitesseX < 0.0)
                    {
                        m_blupiVitesseX += 1.0;
                        if (m_blupiVitesseX > 0.0)
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                }
                if (m_blupiAction == 3)
                {
                    m_blupiVitesseX = 0.0;
                }
                end.X += (int)m_blupiVitesseX;
                if (ButtonPressed == Def.ButtonGlygh.PlayAction && !flag2 && !m_blupiAir && m_blupiTransport == -1 && m_blupiVitesseX < 8.0)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    m_blupiSkate = false;
                    m_blupiAction = 43;
                    m_blupiPhase = 0;
                    m_blupiFocus = false;
                    m_blupiPosHelico = m_blupiPos;
                }
            }
            if (m_blupiAction == 42)
            {
                if (m_blupiPhase == 8)
                {
                    icon = MoveObjectDetect(m_blupiPos, out bNear);
                    if (icon != -1)
                    {
                        ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    }
                }
                if (m_blupiPhase == 20)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiFocus = true;
                }
            }
            if (m_blupiAction == 43)
            {
                if (m_blupiPhase == 12)
                {
                    celSwitch.X = m_blupiPos.X;
                    celSwitch.Y = m_blupiPos.Y - BLUPIFLOOR + 1;
                    ObjectStart(celSwitch, 24, 0);
                }
                if (m_blupiPhase == 20)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiFocus = true;
                }
            }
            if (m_blupiNage && m_blupiFocus)
            {
                if (m_blupiTransport == -1)
                {
                    if (m_blupiSpeedY < 0.0 || ((uint)m_keyPress & (true ? 1u : 0u)) != 0)
                    {
                        if (m_blupiVitesseY > -5.0)
                        {
                            m_blupiVitesseY -= 1.0;
                        }
                    }
                    else if (m_blupiSpeedY > 0.0)
                    {
                        if (m_blupiVitesseY < 5.0)
                        {
                            m_blupiVitesseY += 1.0;
                        }
                    }
                    else
                    {
                        num2 = ((m_blupiAction == 1) ? (-1) : 0);
                        if (m_blupiVitesseY > (double)num2)
                        {
                            m_blupiVitesseY -= 1.0;
                        }
                        if (m_blupiVitesseY < (double)num2)
                        {
                            m_blupiVitesseY += 1.0;
                        }
                    }
                    end.Y += (int)m_blupiVitesseY;
                }
                if (m_blupiSpeedX < 0.0)
                {
                    int num20 = (int)(m_blupiSpeedX * 8.0);
                    if (m_blupiVitesseX > (double)num20)
                    {
                        m_blupiVitesseX -= 1.0;
                    }
                }
                else if (m_blupiSpeedX > 0.0)
                {
                    int num21 = (int)(m_blupiSpeedX * 8.0);
                    if (m_blupiVitesseX < (double)num21)
                    {
                        m_blupiVitesseX += 1.0;
                    }
                }
                else
                {
                    if (m_blupiVitesseX > 0.0)
                    {
                        m_blupiVitesseX -= 2.0;
                        if (m_blupiVitesseX < 0.0)
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                    if (m_blupiVitesseX < 0.0)
                    {
                        m_blupiVitesseX += 2.0;
                        if (m_blupiVitesseX > 0.0)
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                }
                icon = Tables.table_vitesse_nage[m_blupiPhase % 14 / 2];
                end.X += (int)(m_blupiVitesseX * (double)icon / 7.0);
                if (m_time % 70 == 0 || m_time % 70 == 28)
                {
                    MoveObjectBlup(end);
                }
                if (m_time % 5 == 0)
                {
                    if (!m_blupiShield && !m_blupiHide && !m_bSuperBlupi)
                    {
                        m_blupiLevel--;
                    }
                    if (m_blupiLevel == 25)
                    {
                        m_jauges[0].SetMode(1);
                    }
                    m_jauges[0].SetLevel(m_blupiLevel);
                    if (m_blupiLevel == 0)
                    {
                        m_blupiAction = 24;
                        m_blupiPhase = 0;
                        m_blupiFocus = false;
                        m_blupiHelico = false;
                        m_blupiOver = false;
                        m_blupiJeep = false;
                        m_blupiTank = false;
                        m_blupiSkate = false;
                        m_blupiNage = false;
                        m_blupiSurf = false;
                        m_blupiSuspend = false;
                        m_blupiJumpAie = false;
                        m_blupiShield = false;
                        m_blupiPower = false;
                        m_blupiCloud = false;
                        m_blupiHide = false;
                        m_blupiInvert = false;
                        m_blupiBalloon = false;
                        m_blupiEcrase = false;
                        m_blupiAir = false;
                        m_blupiRestart = true;
                        m_blupiActionOuf = 0;
                        m_jauges[0].SetHide(true);
                        m_jauges[1].SetHide(true);
                        PlaySound(26, end);
                    }
                }
            }
            if (m_blupiSurf && m_blupiFocus)
            {
                if (m_blupiTransport == -1)
                {
                    if (m_blupiSpeedY < 0.0 || ((uint)m_keyPress & (true ? 1u : 0u)) != 0)
                    {
                        if (m_blupiVitesseY > -5.0)
                        {
                            m_blupiVitesseY -= 1.0;
                        }
                    }
                    else if (m_blupiSpeedY > 0.0)
                    {
                        if (m_blupiVitesseY < 5.0)
                        {
                            m_blupiVitesseY += 1.0;
                        }
                    }
                    else
                    {
                        if (m_blupiVitesseY > -2.0)
                        {
                            m_blupiVitesseY -= 1.0;
                        }
                        if (m_blupiVitesseY < -2.0)
                        {
                            m_blupiVitesseY += 1.0;
                        }
                    }
                    end.Y += (int)m_blupiVitesseY;
                    end.Y += BLUPISURF;
                    if (end.Y % 64 > 30)
                    {
                        end.Y += 64 - end.Y % 64;
                    }
                    end.Y -= BLUPISURF;
                }
                if (m_blupiSpeedX < 0.0)
                {
                    int num22 = (int)(m_blupiSpeedX * 8.0);
                    if (m_blupiVitesseX > (double)num22)
                    {
                        m_blupiVitesseX -= 1.0;
                    }
                }
                else if (m_blupiSpeedX > 0.0)
                {
                    int num23 = (int)(m_blupiSpeedX * 8.0);
                    if (m_blupiVitesseX < (double)num23)
                    {
                        m_blupiVitesseX += 1.0;
                    }
                }
                else
                {
                    if (m_blupiVitesseX > 0.0)
                    {
                        m_blupiVitesseX -= 2.0;
                        if (m_blupiVitesseX < 0.0)
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                    if (m_blupiVitesseX < 0.0)
                    {
                        m_blupiVitesseX += 2.0;
                        if (m_blupiVitesseX > 0.0)
                        {
                            m_blupiVitesseX = 0.0;
                        }
                    }
                }
                icon = Tables.table_vitesse_surf[m_blupiPhase % 12 / 2];
                end.X += (int)(m_blupiVitesseX * (double)icon / 10.0);
            }
            TinyPoint tinyPoint = default(TinyPoint);
            if (m_blupiSuspend && m_blupiFocus)
            {
                if (m_blupiSpeedX < 0.0 && m_blupiAction == 2)
                {
                    int num24 = (int)(m_blupiSpeedX * 5.0);
                    end.X += num24;
                }
                if (m_blupiSpeedX > 0.0 && m_blupiAction == 2)
                {
                    int num25 = (int)(m_blupiSpeedX * 5.0);
                    end.X += num25;
                }
                icon = GetTypeBarre(end);
                if (icon == 2)
                {
                    tinyPoint.X = end.X;
                    tinyPoint.Y = end.Y / 64 * 64 + BLUPIOFFY;
                    rect = BlupiRect(tinyPoint);
                    if (!DecorDetect(rect, true))
                    {
                        m_blupiSuspend = false;
                        m_blupiAction = 1;
                        m_blupiPhase = 0;
                        end = (m_blupiPos = tinyPoint);
                    }
                }
                if ((m_blupiSpeedY > 0.0 && m_blupiPhase > 5) || icon == 0)
                {
                    m_blupiSuspend = false;
                    m_blupiAir = true;
                    m_blupiAction = 5;
                    end.Y = end.Y;//Todo : check : Assignment made to same variable; did you mean to assign something else?
                    m_blupiVitesseY = 0.0;
                    m_blupiNoBarre = 5;
                    m_blupiActionOuf = 65;
                    m_blupiTimeOuf = 0;
                }
                if ((((uint)m_keyPress & (true ? 1u : 0u)) != 0 || m_blupiSpeedY < 0.0) && m_blupiAction != 4 && m_blupiAction != 3)
                {
                    m_blupiAction = 4;
                    m_blupiPhase = 0;
                }
                if ((m_keyPress & 1) == 0 && m_blupiSpeedY == 0.0 && m_blupiAction == 4)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                }
                if (m_blupiAction == 4 && m_blupiPhase == 10)
                {
                    m_blupiSuspend = false;
                    m_blupiAir = true;
                    m_blupiAction = 5;
                    m_blupiPhase = 0;
                    end.Y -= 2;
                    m_blupiVitesseY = -11.0;
                    m_blupiNoBarre = 5;
                    PlaySound(35, end);
                }
            }
            if (ButtonPressed == Def.ButtonGlygh.PlayAction && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiTank && !m_blupiJeep && !m_blupiSkate && !flag2 && m_blupiTransport == -1 && m_blupiFocus)
            {
                if (m_blupiDynamite > 0)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    rect.Left = end.X + 18;
                    rect.Right = end.X + 20;
                    rect.Top = end.Y + 60 - 2;
                    rect.Bottom = end.Y + 60;
                    bVertigoLeft = !DecorDetect(rect);
                    rect.Left = end.X + 60 - 20;
                    rect.Right = end.X + 60 - 18;
                    rect.Top = end.Y + 60 - 2;
                    rect.Bottom = end.Y + 60;
                    bVertigoRight = !DecorDetect(rect);
                    if (!bVertigoLeft && !bVertigoRight && ObjectStart(end, 56, 0) != -1)
                    {
                        m_blupiAction = 87;
                        m_blupiPhase = 0;
                        m_blupiFocus = false;
                        PlaySound(61, end);
                        m_blupiDynamite--;
                    }
                }
                else if (m_blupiPerso > 0)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    icon = MoveObjectDetect(end, out bNear);
                    if (icon == -1 || m_moveObject[icon].type != 200)
                    {
                        rect.Left = end.X + 18;
                        rect.Right = end.X + 20;
                        rect.Top = end.Y + 60 - 2;
                        rect.Bottom = end.Y + 60;
                        bVertigoLeft = !DecorDetect(rect);
                        rect.Left = end.X + 60 - 20;
                        rect.Right = end.X + 60 - 18;
                        rect.Top = end.Y + 60 - 2;
                        rect.Bottom = end.Y + 60;
                        bVertigoRight = !DecorDetect(rect);
                        icon = MoveChargeDetect(end);
                        if (icon == -1 && !bVertigoLeft && !bVertigoRight && ObjectStart(end, 200, 0) != -1)
                        {
                            m_blupiAction = 46;
                            m_blupiPhase = 0;
                            m_blupiFocus = false;
                            PlaySound(61, end);
                            m_blupiPerso--;
                        }
                    }
                    if (m_blupiFocus)
                    {
                        m_blupiAction = 47;
                        m_blupiPhase = 0;
                        PlaySound(27, end);
                    }
                }
            }
            rect = BlupiRect(m_blupiPos);
            tinyPoint = end;
            TestPath(rect, m_blupiPos, ref end);
            if (flag && m_blupiPos.X == end.X && m_blupiPos.X != tinyPoint.X)
            {
                end.Y = tinyPoint.Y;
                TestPath(rect, m_blupiPos, ref end);
            }
            if (m_blupiVent && m_blupiPos.Y == end.Y && m_blupiPos.Y != tinyPoint.Y)
            {
                end.X = tinyPoint.X;
                TestPath(rect, m_blupiPos, ref end);
            }
            if (m_blupiTransport != -1 && m_blupiPos.X == end.X && m_blupiPos.X != tinyPoint.X)
            {
                end.Y = tinyPoint.Y;
                TestPath(rect, m_blupiPos, ref end);
            }
            if (m_blupiHelico || m_blupiOver || m_blupiBalloon || m_blupiEcrase || m_blupiJeep || m_blupiTank || m_blupiSkate || m_blupiNage)
            {
                if (m_blupiPos.X == end.X && m_blupiPos.X != tinyPoint.X)
                {
                    end.Y = tinyPoint.Y;
                    TestPath(rect, m_blupiPos, ref end);
                }
                else if (m_blupiPos.Y == end.Y && m_blupiPos.Y != tinyPoint.Y)
                {
                    end.X = tinyPoint.X;
                    TestPath(rect, m_blupiPos, ref end);
                }
            }
            TinyPoint blupiPos = m_blupiPos;
            m_blupiPos = end;
            if ((m_blupiAction == 1 || m_blupiAction == 60 || m_blupiAction == 7 || m_blupiAction == 6) && !m_blupiAir && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
            {
                if (m_blupiTransport != -1)
                {
                    AscenseurVertigo(m_blupiTransport, out bVertigoLeft, out bVertigoRight);
                }
                else
                {
                    rect.Left = end.X + 24;
                    rect.Right = end.X + 26;
                    rect.Top = end.Y + 60 - 2;
                    rect.Bottom = end.Y + 60;
                    bVertigoLeft = !DecorDetect(rect);
                    rect.Left = end.X + 60 - 26;
                    rect.Right = end.X + 60 - 24;
                    rect.Top = end.Y + 60 - 2;
                    rect.Bottom = end.Y + 60;
                    bVertigoRight = !DecorDetect(rect);
                }
                if (m_blupiDir == 1 && bVertigoLeft && !bVertigoRight)
                {
                    if (m_blupiHelico || m_blupiOver || AscenseurShift(m_blupiTransport))
                    {
                        m_blupiAction = 9;
                        m_blupiPhase = 0;
                    }
                    else
                    {
                        PlaySound(6, end);
                        m_blupiAction = 8;
                        m_blupiPhase = 0;
                    }
                }
                if (m_blupiDir == 2 && !bVertigoLeft && bVertigoRight)
                {
                    if (m_blupiHelico || m_blupiOver || AscenseurShift(m_blupiTransport))
                    {
                        m_blupiAction = 9;
                        m_blupiPhase = 0;
                    }
                    else
                    {
                        PlaySound(6, end);
                        m_blupiAction = 8;
                        m_blupiPhase = 0;
                    }
                }
                if (m_blupiAction != 8 && m_blupiAction != 10 && m_blupiAction != 9 && (bVertigoLeft || bVertigoRight))
                {
                    if (!m_blupiHelico && !m_blupiOver)
                    {
                        PlaySound(6, end);
                    }
                    m_blupiAction = 10;
                    m_blupiPhase = 0;
                }
            }
            if (m_blupiAction == 1 && m_blupiJeep && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
            {
                if (m_blupiTransport != -1)
                {
                    AscenseurVertigo(m_blupiTransport, out bVertigoLeft, out bVertigoRight);
                }
                else
                {
                    rect.Left = end.X + 2;
                    rect.Right = end.X + 18;
                    rect.Top = end.Y + 60 - 2;
                    rect.Bottom = end.Y + 60;
                    bVertigoLeft = !DecorDetect(rect);
                    rect.Left = end.X + 60 - 18;
                    rect.Right = end.X + 60 - 2;
                    rect.Top = end.Y + 60 - 2;
                    rect.Bottom = end.Y + 60;
                    bVertigoRight = !DecorDetect(rect);
                }
                if (bVertigoLeft && !bVertigoRight)
                {
                    m_blupiAction = 10;
                    m_blupiPhase = 0;
                }
                if (bVertigoRight && !bVertigoLeft)
                {
                    m_blupiAction = 10;
                    m_blupiPhase = 0;
                }
            }
            if (m_blupiAction == 1 && m_blupiTank && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
            {
                if (m_blupiTransport != -1)
                {
                    AscenseurVertigo(m_blupiTransport, out bVertigoLeft, out bVertigoRight);
                }
                else
                {
                    rect.Left = end.X + 2;
                    rect.Right = end.X + 18;
                    rect.Top = end.Y + 60 - 2;
                    rect.Bottom = end.Y + 60;
                    bVertigoLeft = !DecorDetect(rect);
                    rect.Left = end.X + 60 - 18;
                    rect.Right = end.X + 60 - 2;
                    rect.Top = end.Y + 60 - 2;
                    rect.Bottom = end.Y + 60;
                    bVertigoRight = !DecorDetect(rect);
                }
                if (bVertigoLeft && !bVertigoRight)
                {
                    m_blupiAction = 10;
                    m_blupiPhase = 0;
                }
                if (bVertigoRight && !bVertigoLeft)
                {
                    m_blupiAction = 10;
                    m_blupiPhase = 0;
                }
            }
            if (m_blupiAction == 1 && m_blupiSkate && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
            {
                if (m_blupiTransport != -1)
                {
                    AscenseurVertigo(m_blupiTransport, out bVertigoLeft, out bVertigoRight);
                }
                else
                {
                    rect.Left = end.X + 12;
                    rect.Right = end.X + 19;
                    rect.Top = end.Y + 60 - 2;
                    rect.Bottom = end.Y + 60;
                    bVertigoLeft = !DecorDetect(rect);
                    rect.Left = end.X + 60 - 19;
                    rect.Right = end.X + 60 - 12;
                    rect.Top = end.Y + 60 - 2;
                    rect.Bottom = end.Y + 60;
                    bVertigoRight = !DecorDetect(rect);
                }
                if (bVertigoLeft && !bVertigoRight)
                {
                    m_blupiAction = 10;
                    m_blupiPhase = 0;
                }
                if (bVertigoRight && !bVertigoLeft)
                {
                    m_blupiAction = 10;
                    m_blupiPhase = 0;
                }
            }
            if (m_blupiFocus)
            {
                if (m_blupiAction == 8 && m_blupiPhase == 16)
                {
                    m_blupiAction = 9;
                    m_blupiPhase = 0;
                }
                if (m_blupiAction == 9 && m_blupiPhase == 3)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiActionOuf = 0;
                }
                num2 = 5;
                if (m_blupiJeep)
                {
                    num2 = 10;
                }
                if (m_blupiTank)
                {
                    num2 = 10;
                }
                if (m_blupiSkate)
                {
                    num2 = 10;
                }
                if (m_blupiAction == 10 && m_blupiPhase == num2)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                }
            }
            BlupiSearchIcon();
            if (m_blupiShield)
            {
                if (m_blupiTimeShield == 10)
                {
                    PlaySound(43, m_blupiPos);
                }
                if (m_blupiTimeShield == 0)
                {
                    m_blupiShield = false;
                    m_jauges[1].SetHide(true);
                }
                else if (m_time % 5 == 0)
                {
                    m_blupiTimeShield--;
                    m_jauges[1].SetLevel(m_blupiTimeShield);
                }
            }
            if (m_blupiPower)
            {
                if (m_blupiTimeShield == 20)
                {
                    PlaySound(45, m_blupiPos);
                }
                if (m_blupiTimeShield == 0)
                {
                    m_blupiPower = false;
                    m_jauges[1].SetHide(true);
                }
                else if (m_time % 3 == 0)
                {
                    m_blupiTimeShield--;
                    m_jauges[1].SetLevel(m_blupiTimeShield);
                }
            }
            if (m_blupiCloud)
            {
                if (m_blupiTimeShield == 25)
                {
                    PlaySound(56, m_blupiPos);
                }
                if (m_blupiTimeShield == 0)
                {
                    m_blupiCloud = false;
                    m_jauges[1].SetHide(true);
                }
                else if (m_time % 4 == 0)
                {
                    m_blupiTimeShield--;
                    m_jauges[1].SetLevel(m_blupiTimeShield);
                }
            }
            if (m_blupiHide)
            {
                if (m_blupiTimeShield == 20)
                {
                    PlaySound(63, m_blupiPos);
                }
                if (m_blupiTimeShield == 0)
                {
                    m_blupiHide = false;
                    m_jauges[1].SetHide(true);
                }
                else if (m_time % 4 == 0)
                {
                    m_blupiTimeShield--;
                    m_jauges[1].SetLevel(m_blupiTimeShield);
                }
            }
            if (m_blupiInvert)
            {
                if (m_blupiTimeShield == 0)
                {
                    m_blupiInvert = false;
                    m_jauges[1].SetHide(true);
                    celSwitch.X = m_blupiPos.X;
                    celSwitch.Y = m_blupiPos.Y + 100;
                    ObjectStart(celSwitch, 42, -60);
                    celSwitch.X = m_blupiPos.X;
                    celSwitch.Y = m_blupiPos.Y - 100;
                    ObjectStart(celSwitch, 42, 60);
                    celSwitch.X = m_blupiPos.X - 100;
                    celSwitch.Y = m_blupiPos.Y;
                    ObjectStart(celSwitch, 42, 10);
                    celSwitch.X = m_blupiPos.X + 100;
                    celSwitch.Y = m_blupiPos.Y;
                    ObjectStart(celSwitch, 42, -10);
                    PlaySound(67, end);
                }
                else if (m_time % 3 == 0)
                {
                    m_blupiTimeShield--;
                    m_jauges[1].SetLevel(m_blupiTimeShield);
                }
            }
            if (m_blupiBalloon)
            {
                if (m_blupiTimeShield == 0)
                {
                    m_blupiBalloon = false;
                    m_jauges[1].SetHide(true);
                    celSwitch.X = m_blupiPos.X - 34;
                    celSwitch.Y = m_blupiPos.Y - 34;
                    ObjectStart(celSwitch, 91, 0);
                    PlaySound(41, m_blupiPos);
                }
                else if (m_time % 2 == 0)
                {
                    m_blupiTimeShield--;
                    m_jauges[1].SetLevel(m_blupiTimeShield);
                }
            }
            if (m_blupiEcrase)
            {
                if (m_blupiTimeShield == 0)
                {
                    m_blupiEcrase = false;
                    m_blupiAir = true;
                    m_jauges[1].SetHide(true);
                    ObjectStart(m_blupiPos, 41, -60);
                    ObjectStart(m_blupiPos, 41, 60);
                    ObjectStart(m_blupiPos, 41, 10);
                    ObjectStart(m_blupiPos, 41, -10);
                    celSwitch.X = m_blupiPos.X - 34;
                    celSwitch.Y = m_blupiPos.Y - 34;
                    ObjectStart(celSwitch, 90, 0);
                    PlaySound(41, m_blupiPos);
                }
                else if (m_time % 2 == 0)
                {
                    m_blupiTimeShield--;
                    m_jauges[1].SetLevel(m_blupiTimeShield);
                }
            }
            if (m_blupiPower && Math.Abs(m_blupiPos.X - m_blupiPosMagic.X) + Math.Abs(m_blupiPos.Y - m_blupiPosMagic.Y) >= 40)
            {
                icon = MoveObjectFree();
                if (icon != -1)
                {
                    m_moveObject[icon].type = 27;
                    m_moveObject[icon].phase = 0;
                    m_moveObject[icon].posCurrent = m_blupiPos;
                    m_moveObject[icon].posStart = m_moveObject[icon].posCurrent;
                    m_moveObject[icon].posEnd = m_moveObject[icon].posCurrent;
                    m_moveObject[icon].step = 1;
                    m_moveObject[icon].time = 0;
                    MoveObjectStepIcon(icon);
                    m_blupiPosMagic = m_blupiPos;
                }
            }
            if (m_blupiShield && Math.Abs(m_blupiPos.X - m_blupiPosMagic.X) + Math.Abs(m_blupiPos.Y - m_blupiPosMagic.Y) >= 40)
            {
                icon = MoveObjectFree();
                if (icon != -1)
                {
                    m_moveObject[icon].type = 57;
                    m_moveObject[icon].phase = 0;
                    m_moveObject[icon].posCurrent = m_blupiPos;
                    m_moveObject[icon].posStart = m_moveObject[icon].posCurrent;
                    m_moveObject[icon].posEnd = m_moveObject[icon].posCurrent;
                    m_moveObject[icon].step = 1;
                    m_moveObject[icon].time = 0;
                    MoveObjectStepIcon(icon);
                    m_blupiPosMagic = m_blupiPos;
                }
            }
            if (m_blupiHide && Math.Abs(m_blupiPos.X - m_blupiPosMagic.X) + Math.Abs(m_blupiPos.Y - m_blupiPosMagic.Y) >= 10)
            {
                icon = MoveObjectFree();
                if (icon != -1)
                {
                    m_moveObject[icon].type = 58;
                    m_moveObject[icon].icon = m_blupiIcon;
                    m_moveObject[icon].channel = 2;
                    m_moveObject[icon].phase = 0;
                    m_moveObject[icon].posCurrent = m_blupiPos;
                    m_moveObject[icon].posStart = m_moveObject[icon].posCurrent;
                    m_moveObject[icon].posEnd = m_moveObject[icon].posCurrent;
                    m_moveObject[icon].step = 1;
                    m_moveObject[icon].time = 0;
                    MoveObjectStepIcon(icon);
                    m_blupiPosMagic = m_blupiPos;
                }
            }
            if (m_blupiTimeNoAsc > 0)
            {
                m_blupiTimeNoAsc--;
            }
            if (m_blupiHelico && m_blupiPos.Y > 2 && m_blupiFocus && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi)
            {
                rect = BlupiRect(end);
                rect.Top = end.Y + 4;
                rect.Bottom = end.Y + 20;
                if (DecorDetect(rect))
                {
                    ByeByeHelico();
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiHelico = false;
                    celSwitch.X = m_blupiPos.X - 34;
                    celSwitch.Y = m_blupiPos.Y - 34;
                    ObjectStart(celSwitch, 9, 0);
                    m_decorAction = 1;
                    m_decorPhase = 0;
                    StopSound(16);
                    StopSound(18);
                    StopSound(29);
                    StopSound(31);
                    PlaySound(10, m_blupiPos);
                }
            }
            if (!m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && m_blupiFocus)
            {
                if (!m_blupiNage && !m_blupiSurf && IsSurfWater(m_blupiPos))
                {
                    m_scrollAdd.X = 0;
                    m_scrollAdd.Y = 0;
                    m_blupiAir = false;
                    m_blupiNage = false;
                    m_blupiSurf = true;
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiVitesseX = 0.0;
                    m_blupiVitesseY = 0.0;
                    MoveObjectPlouf(m_blupiPos);
                    if (m_blupiTransport != -1)
                    {
                        m_blupiPos.Y -= 10;
                        m_blupiTransport = -1;
                    }
                    if (m_blupiCloud)
                    {
                        m_blupiCloud = false;
                        m_jauges[1].SetHide(true);
                    }
                }
                if (!m_blupiNage && !IsSurfWater(m_blupiPos) && IsDeepWater(m_blupiPos))
                {
                    if (!m_blupiSurf)
                    {
                        m_blupiAction = 1;
                        m_blupiPhase = 0;
                        m_blupiVitesseX = 0.0;
                        m_blupiVitesseY = 0.0;
                        MoveObjectPlouf(m_blupiPos);
                    }
                    m_blupiAir = false;
                    m_blupiSurf = false;
                    m_blupiNage = true;
                    m_blupiLevel = 100;
                    m_jauges[0].SetLevel(m_blupiLevel);
                    m_jauges[0].SetMode(2);
                    m_jauges[0].SetHide(false);
                }
                if (m_blupiNage && IsSurfWater(m_blupiPos))
                {
                    m_blupiAir = false;
                    m_blupiNage = false;
                    m_blupiSurf = true;
                    PlaySound(25, m_blupiPos);
                    m_jauges[0].SetHide(true);
                }
                tinyPoint.X = m_blupiPos.X;
                tinyPoint.Y = m_blupiPos.Y - 60;
                if ((m_blupiSurf || m_blupiNage) && (m_blupiPos.Y % 64 == 64 - BLUPISURF || m_blupiPos.Y % 64 == 32) && IsOutWater(tinyPoint) && ((uint)m_keyPress & (true ? 1u : 0u)) != 0)
                {
                    m_blupiNage = false;
                    m_blupiSurf = false;
                    m_blupiAir = true;
                    m_blupiAction = 5;
                    m_blupiPhase = 0;
                    m_blupiVitesseX = 0.0;
                    if (m_blupiPower)
                    {
                        m_blupiVitesseY = -16.0;
                    }
                    else
                    {
                        m_blupiVitesseY = -12.0;
                    }
                    MoveObjectTiplouf(m_blupiPos);
                    PlaySound(22, m_blupiPos);
                    m_jauges[0].SetHide(true);
                }
                if ((m_blupiSurf || m_blupiNage) && IsOutWater(m_blupiPos))
                {
                    if (m_blupiVitesseY < 0.0)
                    {
                        if (m_blupiTransport == -1)
                        {
                            m_blupiPos = blupiPos;
                        }
                        else
                        {
                            m_blupiTransport = -1;
                            m_blupiNage = false;
                            m_blupiSurf = false;
                            m_blupiAir = true;
                            m_blupiAction = 5;
                            m_blupiPhase = 0;
                            m_blupiPos.Y -= 10;
                            m_blupiVitesseX = 0.0;
                            m_blupiVitesseY = -10.0;
                            PlaySound(22, m_blupiPos);
                            m_jauges[0].SetHide(true);
                        }
                    }
                    else if (m_blupiVitesseY > 0.0)
                    {
                        m_blupiNage = false;
                        m_blupiSurf = false;
                        m_blupiAir = false;
                        m_blupiAction = 5;
                        m_blupiPhase = 0;
                        m_blupiPos.Y += 30;
                        m_blupiVitesseX = 0.0;
                        m_blupiVitesseY = 0.0;
                        PlaySound(22, m_blupiPos);
                        m_jauges[0].SetHide(true);
                    }
                    else
                    {
                        m_blupiNage = false;
                        m_blupiSurf = false;
                        m_blupiAir = false;
                        m_blupiAction = 1;
                        m_blupiPhase = 0;
                        m_blupiPos.Y -= 10;
                        m_blupiVitesseX = 0.0;
                        m_blupiVitesseY = 0.0;
                        PlaySound(22, m_blupiPos);
                        m_jauges[0].SetHide(true);
                    }
                }
                if ((m_blupiSurf || m_blupiNage) && m_blupiActionOuf != 44)
                {
                    m_blupiActionOuf = 44;
                    m_blupiTimeOuf = 0;
                }
            }
            if ((m_blupiHelico || m_blupiOver || m_blupiJeep || m_blupiTank || m_blupiSkate) && m_blupiFocus && (IsSurfWater(m_blupiPos) || IsDeepWater(m_blupiPos)))
            {
                ByeByeHelico();
                m_blupiAction = 1;
                m_blupiPhase = 0;
                m_blupiHelico = false;
                m_blupiOver = false;
                m_blupiJeep = false;
                m_blupiTank = false;
                m_blupiSkate = false;
                celSwitch.X = m_blupiPos.X - 34;
                celSwitch.Y = m_blupiPos.Y - 34;
                ObjectStart(celSwitch, 9, 0);
                m_decorAction = 1;
                m_decorPhase = 0;
                StopSound(16);
                StopSound(18);
                StopSound(29);
                StopSound(31);
                PlaySound(10, m_blupiPos);
            }
            if (m_blupiFocus && !m_blupiSuspend && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && m_blupiNoBarre == 0 && GetTypeBarre(m_blupiPos) == 1)
            {
                tinyPoint.X = m_blupiPos.X;
                tinyPoint.Y = (m_blupiPos.Y + 22) / 64 * 64 + BLUPISUSPEND;
                rect = BlupiRect(tinyPoint);
                if (!DecorDetect(rect, true))
                {
                    m_blupiPos = tinyPoint;
                    m_blupiSuspend = true;
                    m_blupiAir = false;
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiActionOuf = 0;
                    PlaySound(34, m_blupiPos);
                }
            }
            if (m_blupiNoBarre > 0)
            {
                m_blupiNoBarre--;
            }
            if (IsVentillo(m_blupiPos))
            {
                if (m_blupiFocus && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi)
                {
                    BlupiDead(11, 75);
                }
                celSwitch.X = m_blupiPos.X - 34;
                celSwitch.Y = m_blupiPos.Y - 34;
                ObjectStart(celSwitch, 11, 0);
                m_decorAction = 2;
                m_decorPhase = 0;
                StopSound(16);
                StopSound(18);
                StopSound(29);
                StopSound(31);
                PlaySound(10, m_blupiPos);
            }
            if (m_blupiAction != 30 && m_blupiFocus)
            {
                icon = IsWorld(m_blupiPos);
                if (icon != -1)
                {
                    StopSound(16);
                    StopSound(18);
                    StopSound(29);
                    StopSound(31);
                    PlaySound(32, m_blupiPos);
                    m_blupiAction = 30;
                    m_blupiPhase = 0;
                    m_blupiFocus = false;
                    m_blupiFront = true;
                }
            }
            int num26 = MoveObjectDetect(m_blupiPos, out bNear);
            TinyPoint tinyPoint2 = default(TinyPoint);
            if (m_blupiAction != 11 && m_blupiAction != 75 && m_blupiAction != 76 && m_blupiAction != 77 && m_blupiAction != 78 && m_blupiAction != 79 && m_blupiAction != 80 && m_blupiAction != 81)
            {
                if (IsLave(m_blupiPos) && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi)
                {
                    BlupiDead(76, -1);
                    m_blupiRestart = true;
                    m_blupiPos.Y = m_blupiPos.Y / 64 * 64 + BLUPIOFFY;
                    PlaySound(8, m_blupiPos);
                }
                if (IsPiege(m_blupiPos) && !m_blupiOver && !m_blupiJeep && !m_blupiTank && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi && m_blupiFocus)
                {
                    BlupiDead(54, -1);
                    m_blupiRestart = true;
                    m_blupiAir = true;
                    ObjectStart(m_blupiPos, 53, 0);
                    PlaySound(51, m_blupiPos);
                }
                if (IsGoutte(m_blupiPos, false) && !m_blupiOver && !m_blupiJeep && !m_blupiTank && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi && m_blupiFocus)
                {
                    BlupiDead(54, -1);
                    m_blupiRestart = true;
                    m_blupiAir = true;
                    PlaySound(51, m_blupiPos);
                }
                if (IsScie(m_blupiPos) && !m_blupiOver && !m_blupiJeep && !m_blupiTank && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi && m_blupiFocus)
                {
                    BlupiDead(77, -1);
                    m_blupiFront = true;
                    m_blupiRestart = true;
                    m_blupiAir = true;
                }
                if (ButtonPressed == Def.ButtonGlygh.PlayAction && (num26 == -1 || !bNear) && IsSwitch(m_blupiPos, ref celSwitch) && !m_blupiOver && !m_blupiBalloon && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi && m_blupiFocus)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    ActiveSwitch(m_decor[celSwitch.X, celSwitch.Y].icon == 385, celSwitch);
                    m_blupiAction = 82;
                    m_blupiPhase = 0;
                    m_blupiFocus = false;
                    m_blupiVitesseX = 0.0;
                    m_blupiVitesseY = 0.0;
                }
                if (IsBlitz(m_blupiPos, false) && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi)
                {
                    BlupiDead(11, -1);
                    m_blupiRestart = true;
                    m_blupiAir = true;
                    m_blupiPos.Y = m_blupiPos.Y / 64 * 64 + BLUPIOFFY;
                    PlaySound(8, m_blupiPos);
                }
                if (IsEcraseur(m_blupiPos) && !m_blupiEcrase && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi && m_blupiFocus)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiVitesseX = 0.0;
                    m_blupiVitesseY = 0.0;
                    m_blupiEcrase = true;
                    m_blupiBalloon = false;
                    m_blupiAir = false;
                    m_blupiHelico = false;
                    m_blupiOver = false;
                    m_blupiJeep = false;
                    m_blupiTank = false;
                    m_blupiSkate = false;
                    m_blupiNage = false;
                    m_blupiSurf = false;
                    m_blupiSuspend = false;
                    m_blupiJumpAie = false;
                    m_blupiShield = false;
                    m_blupiPower = false;
                    m_blupiCloud = false;
                    m_blupiHide = false;
                    m_blupiTimeShield = 100;
                    m_blupiPosMagic = m_blupiPos;
                    m_jauges[1].SetHide(false);
                    if (!m_blupiJeep && !m_blupiTank)
                    {
                        StopSound(16);
                        StopSound(18);
                        StopSound(29);
                        StopSound(31);
                    }
                    PlaySound(70, m_blupiPos);
                    ObjectStart(m_blupiPos, 41, -60);
                    ObjectStart(m_blupiPos, 41, 60);
                    ObjectStart(m_blupiPos, 41, 10);
                    ObjectStart(m_blupiPos, 41, -10);
                    celSwitch.X = m_blupiPos.X - 34;
                    celSwitch.Y = m_blupiPos.Y - 34;
                    ObjectStart(celSwitch, 90, 0);
                    m_decorAction = 2;
                    m_decorPhase = 0;
                }
                if (IsTeleporte(m_blupiPos) != -1 && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiAir && m_blupiFocus && m_blupiPosHelico.X == -1)
                {
                    m_blupiAction = 74;
                    m_blupiPhase = 0;
                    m_blupiVitesseX = 0.0;
                    m_blupiVitesseY = 0.0;
                    m_blupiFocus = false;
                    m_blupiPos.X = m_blupiPos.X / 64 * 64;
                    PlaySound(71, m_blupiPos);
                    celSwitch.X = m_blupiPos.X;
                    celSwitch.Y = m_blupiPos.Y - 5;
                    ObjectStart(celSwitch, 92, 0);
                }
                if (IsBridge(m_blupiPos, ref celBridge) && m_blupiFocus)
                {
                    celBridge.X *= 64;
                    celBridge.Y *= 64;
                    ObjectStart(celBridge, 52, 0);
                }
                int num = IsDoor(m_blupiPos, ref celBridge);
                if (num != -1 && (m_blupiCle & (1 << num - 334)) != 0)
                {
                    OpenDoor(celBridge);
                    m_blupiCle &= ~(1 << num - 334);
                    celSwitch.X = 520;
                    celSwitch.Y = 418;
                    tinyPoint2.X = celBridge.X * 64 - m_posDecor.X;
                    tinyPoint2.Y = celBridge.Y * 64 - m_posDecor.Y;
                    VoyageInit(celSwitch, m_pixmap.HotSpotToHud(tinyPoint2), 214 + (num - 334) * 7, 10);
                }
            }
            if (!m_blupiHelico && !m_blupiSuspend && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiSkate && !m_blupiJeep && !m_blupiTank && !m_blupiJeep && m_blupiFocus)
            {
                icon = MockeryDetect(m_blupiPos);
                if (icon != 0)
                {
                    m_blupiActionOuf = icon;
                    m_blupiTimeOuf = 0;
                }
            }
            MoveObjectFollow(m_blupiPos);
            icon = num26;
            if (icon != -1 && !bNear && m_moveObject[icon].type == 2 && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && !m_blupiShield && !m_bSuperBlupi && m_blupiFocus)
            {
                m_blupiActionOuf = 48;
                m_blupiTimeOuf = 0;
            }
            if (icon != -1 && bNear)
            {
                if (m_moveObject[icon].type == 13 && (ButtonPressed == Def.ButtonGlygh.PlayAction || IsFloatingObject(icon)) && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    m_scrollAdd.X = 0;
                    m_scrollAdd.Y = 0;
                    m_blupiAir = false;
                    m_blupiHelico = true;
                    m_blupiRealRotation = 0;
                    m_blupiVitesseX = 0.0;
                    if (m_blupiCloud || m_blupiHide)
                    {
                        m_blupiCloud = false;
                        m_blupiHide = false;
                        m_jauges[1].SetHide(true);
                    }
                }
                if (ButtonPressed == Def.ButtonGlygh.PlayAction && m_moveObject[icon].type == 46 && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    m_scrollAdd.X = 0;
                    m_scrollAdd.Y = 0;
                    m_blupiAir = false;
                    m_blupiOver = true;
                    m_blupiVitesseX = 0.0;
                    if (m_blupiCloud || m_blupiHide)
                    {
                        m_blupiCloud = false;
                        m_blupiHide = false;
                        m_jauges[1].SetHide(true);
                    }
                }
                if (ButtonPressed == Def.ButtonGlygh.PlayAction && m_moveObject[icon].type == 19 && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    m_scrollAdd.X = 0;
                    m_scrollAdd.Y = 0;
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiAir = false;
                    m_blupiJeep = true;
                    m_blupiVitesseX = 0.0;
                    if (m_blupiCloud || m_blupiHide)
                    {
                        m_blupiCloud = false;
                        m_blupiHide = false;
                        m_jauges[1].SetHide(true);
                    }
                }
                if (ButtonPressed == Def.ButtonGlygh.PlayAction && m_moveObject[icon].type == 28 && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    m_scrollAdd.X = 0;
                    m_scrollAdd.Y = 0;
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiAir = false;
                    m_blupiTank = true;
                    m_blupiVitesseX = 0.0;
                    if (m_blupiCloud || m_blupiHide)
                    {
                        m_blupiCloud = false;
                        m_blupiHide = false;
                        m_jauges[1].SetHide(true);
                    }
                }
                if (m_moveObject[icon].type == 29 && m_blupiFocus && m_blupiBullet < 10)
                {
                    ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    celSwitch.X = m_moveObject[icon].posCurrent.X - m_posDecor.X;
                    celSwitch.Y = m_moveObject[icon].posCurrent.Y - m_posDecor.Y;
                    tinyPoint2.X = 570;
                    tinyPoint2.Y = 430;
                    VoyageInit(m_pixmap.HotSpotToHud(celSwitch), tinyPoint2, 177, 10);
                    m_blupiBullet += 10;
                    if (m_blupiBullet > 10)
                    {
                        m_blupiBullet = 10;
                    }
                }
                if (ButtonPressed == Def.ButtonGlygh.PlayAction && m_moveObject[icon].type == 24 && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    m_scrollAdd.X = 0;
                    m_scrollAdd.Y = 0;
                    m_blupiAction = 42;
                    m_blupiPhase = 0;
                    m_blupiPos.Y = m_moveObject[icon].posCurrent.Y / 64 * 64 + BLUPIOFFY;
                    m_blupiFocus = false;
                    m_blupiAir = false;
                    m_blupiSkate = true;
                    m_blupiVitesseX = 0.0;
                    if (m_blupiCloud || m_blupiHide)
                    {
                        m_blupiCloud = false;
                        m_blupiHide = false;
                        m_jauges[1].SetHide(true);
                    }
                }
                if ((m_moveObject[icon].type == 3 || m_moveObject[icon].type == 16 || m_moveObject[icon].type == 96 || m_moveObject[icon].type == 97) && m_blupiBalloon && m_blupiPosHelico.X == -1)
                {
                    m_blupiBalloon = false;
                    m_blupiAir = true;
                    m_blupiTimeShield = 0;
                    m_jauges[1].SetHide(true);
                    m_decorAction = 0;
                    celSwitch.X = m_blupiPos.X - 34;
                    celSwitch.Y = m_blupiPos.Y - 34;
                    ObjectStart(celSwitch, 91, 0);
                    PlaySound(41, m_blupiPos);
                    m_blupiPos.Y += 4;
                    m_blupiVitesseY = 0.0;
                    m_blupiPosHelico = m_blupiPos;
                }
                else if ((m_moveObject[icon].type == 2 || m_moveObject[icon].type == 3 || m_moveObject[icon].type == 96 || m_moveObject[icon].type == 97 || m_moveObject[icon].type == 16 || m_moveObject[icon].type == 4 || m_moveObject[icon].type == 17 || m_moveObject[icon].type == 20) && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi && m_blupiPosHelico.X == -1)
                {
                    if (!m_blupiJeep && !m_blupiTank && !m_blupiSkate && (m_blupiFocus || m_blupiAction == 5 || m_blupiAction == 36))
                    {
                        if (m_blupiHelico || m_blupiOver || m_blupiBalloon || m_blupiEcrase)
                        {
                            m_blupiAir = true;
                        }
                        BlupiDead(11, 75);
                    }
                    if (m_moveObject[icon].type == 17 || m_moveObject[icon].type == 20)
                    {
                        celSwitch = m_moveObject[icon].posCurrent;
                        ObjectDelete(celSwitch, m_moveObject[icon].type);
                        celSwitch.X -= 34;
                        celSwitch.Y -= 34;
                        ObjectStart(celSwitch, 10, 0);
                        m_decorAction = 2;
                        m_decorPhase = 0;
                    }
                    else
                    {
                        celSwitch = m_moveObject[icon].posCurrent;
                        ObjectDelete(celSwitch, m_moveObject[icon].type);
                        celSwitch.X -= 34;
                        celSwitch.Y -= 34;
                        ObjectStart(celSwitch, 8, 0);
                        m_decorAction = 1;
                        m_decorPhase = 0;
                    }
                    if (!m_blupiJeep && !m_blupiTank)
                    {
                        StopSound(16);
                        StopSound(18);
                        StopSound(29);
                        StopSound(31);
                    }
                    PlaySound(10, m_moveObject[icon].posCurrent);
                }
                if (m_moveObject[icon].type == 44 && m_blupiFocus && !m_blupiBalloon && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi)
                {
                    ByeByeHelico();
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiVitesseX = 0.0;
                    m_blupiVitesseY = 0.0;
                    m_blupiBalloon = true;
                    m_blupiEcrase = false;
                    m_blupiAir = false;
                    m_blupiHelico = false;
                    m_blupiOver = false;
                    m_blupiJeep = false;
                    m_blupiTank = false;
                    m_blupiSkate = false;
                    m_blupiNage = false;
                    m_blupiSurf = false;
                    m_blupiSuspend = false;
                    m_blupiJumpAie = false;
                    m_blupiShield = false;
                    m_blupiPower = false;
                    m_blupiCloud = false;
                    m_blupiHide = false;
                    m_blupiTimeShield = 100;
                    m_blupiPosMagic = m_blupiPos;
                    m_jauges[1].SetHide(false);
                    if (!m_blupiJeep && !m_blupiTank)
                    {
                        StopSound(16);
                        StopSound(18);
                        StopSound(29);
                        StopSound(31);
                    }
                    PlaySound(40, m_moveObject[icon].posCurrent);
                    celSwitch.X = m_blupiPos.X - 34;
                    celSwitch.Y = m_blupiPos.Y - 34;
                    ObjectStart(celSwitch, 90, 0);
                    m_decorAction = 5;
                    m_decorPhase = 0;
                }
                if (m_moveObject[icon].type == 54 && m_moveObject[icon].step != 2 && m_moveObject[icon].step != 4 && m_blupiFocus && !m_blupiBalloon && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi)
                {
                    ByeByeHelico();
                    celSwitch.X = m_blupiPos.X;
                    celSwitch.Y = (m_blupiPos.Y + 64 - 10) / 64 * 64 + 4;
                    ObjectStart(celSwitch, 53, 0);
                    m_blupiAction = 54;
                    m_blupiPhase = 0;
                    m_blupiSuspend = false;
                    m_blupiJumpAie = false;
                    m_blupiFocus = false;
                    m_blupiRestart = true;
                    if (flag2)
                    {
                        m_blupiAir = true;
                    }
                    if (m_blupiHelico || m_blupiOver || m_blupiBalloon || m_blupiEcrase || m_blupiJeep || m_blupiTank || m_blupiSkate)
                    {
                        m_blupiHelico = false;
                        m_blupiOver = false;
                        m_blupiBalloon = false;
                        m_blupiEcrase = false;
                        m_blupiJeep = false;
                        m_blupiTank = false;
                        m_blupiSkate = false;
                        celSwitch = m_moveObject[icon].posCurrent;
                        celSwitch.X -= 34;
                        celSwitch.Y -= 34;
                        ObjectStart(celSwitch, 10, 0);
                        StopSound(16);
                        StopSound(18);
                        StopSound(29);
                        StopSound(31);
                        PlaySound(10, m_moveObject[icon].posCurrent);
                        m_decorAction = 1;
                        m_decorPhase = 0;
                    }
                    else
                    {
                        PlaySound(51, m_moveObject[icon].posCurrent);
                    }
                    m_blupiCloud = false;
                    m_blupiHide = false;
                    m_jauges[1].SetHide(true);
                }
                if (m_moveObject[icon].type == 23 && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi && m_blupiAction != 13 && m_blupiAction != 30 && m_blupiAction != 11 && m_blupiAction != 75 && m_blupiAction != 76 && m_blupiAction != 77 && m_blupiAction != 78 && m_blupiAction != 79 && m_blupiAction != 80 && m_blupiAction != 81 && m_blupiAction != 54 && m_blupiAction != 57 && m_blupiAction != 35)
                {
                    ByeByeHelico();
                    celSwitch = m_moveObject[icon].posCurrent;
                    ObjectDelete(celSwitch, m_moveObject[icon].type);
                    m_blupiAction = 54;
                    m_blupiPhase = 0;
                    m_blupiSuspend = false;
                    m_blupiJumpAie = false;
                    m_blupiFocus = false;
                    m_blupiRestart = true;
                    if (flag2)
                    {
                        m_blupiAir = true;
                    }
                    if (m_blupiHelico || m_blupiOver || m_blupiBalloon || m_blupiEcrase || m_blupiJeep || m_blupiTank || m_blupiSkate)
                    {
                        m_blupiHelico = false;
                        m_blupiOver = false;
                        m_blupiBalloon = false;
                        m_blupiEcrase = false;
                        m_blupiJeep = false;
                        m_blupiTank = false;
                        m_blupiSkate = false;
                    }
                    StartSploutchGlu(m_moveObject[icon].posCurrent);
                    m_blupiCloud = false;
                    m_blupiHide = false;
                    m_jauges[1].SetHide(true);
                }
                if (m_moveObject[icon].type == 5)
                {
                    ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    celSwitch.X = m_moveObject[icon].posCurrent.X - m_posDecor.X;
                    celSwitch.Y = m_moveObject[icon].posCurrent.Y - m_posDecor.Y;
                    TinyPoint end2 = default(TinyPoint);
                    end2.X = 430;
                    end2.Y = 430;
                    VoyageInit(m_pixmap.HotSpotToHud(celSwitch), end2, 6, 10);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, -60);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, 60);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, 10);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, -10);
                }
                if (m_moveObject[icon].type == 49 && (m_voyageIcon != 215 || m_voyageChannel != 10) && (m_blupiCle & 1) == 0)
                {
                    ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    celSwitch.X = m_moveObject[icon].posCurrent.X - m_posDecor.X;
                    celSwitch.Y = m_moveObject[icon].posCurrent.Y - m_posDecor.Y;
                    TinyPoint end3 = default(TinyPoint);
                    end3.X = 520;
                    end3.Y = 418;
                    VoyageInit(m_pixmap.HotSpotToHud(celSwitch), end3, 215, 10);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, -60);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, 60);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, 10);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, -10);
                }
                if (m_moveObject[icon].type == 50 && (m_voyageIcon != 222 || m_voyageChannel != 10) && (m_blupiCle & 2) == 0)
                {
                    ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    celSwitch.X = m_moveObject[icon].posCurrent.X - m_posDecor.X;
                    celSwitch.Y = m_moveObject[icon].posCurrent.Y - m_posDecor.Y;
                    TinyPoint end4 = default(TinyPoint);
                    end4.X = 530;
                    end4.Y = 418;
                    VoyageInit(m_pixmap.HotSpotToHud(celSwitch), end4, 222, 10);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, -60);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, 60);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, 10);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, -10);
                }
                if (m_moveObject[icon].type == 51 && (m_voyageIcon != 229 || m_voyageChannel != 10) && (m_blupiCle & 4) == 0)
                {
                    ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    celSwitch.X = m_moveObject[icon].posCurrent.X - m_posDecor.X;
                    celSwitch.Y = m_moveObject[icon].posCurrent.Y - m_posDecor.Y;
                    TinyPoint end5 = default(TinyPoint);
                    end5.X = 540;
                    end5.Y = 418;
                    VoyageInit(m_pixmap.HotSpotToHud(celSwitch), end5, 229, 10);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, -60);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, 60);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, 10);
                    ObjectStart(m_moveObject[icon].posCurrent, 39, -10);
                }
                if (m_moveObject[icon].type == 6 && m_nbVies < 10 && m_blupiFocus)
                {
                    ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    celSwitch.X = m_moveObject[icon].posCurrent.X - m_posDecor.X;
                    celSwitch.Y = m_moveObject[icon].posCurrent.Y - m_posDecor.Y;
                    VoyageInit(m_pixmap.HotSpotToHud(celSwitch), VoyageGetPosVie(m_nbVies + 1), 21, 10);
                }
                if (m_moveObject[icon].type == 25 && !m_blupiShield && !m_blupiHide && !m_blupiPower && m_blupiFocus)
                {
                    PlaySound(42, m_moveObject[icon].posCurrent);
                    m_blupiShield = true;
                    m_blupiPower = false;
                    m_blupiCloud = false;
                    m_blupiHide = false;
                    m_blupiTimeShield = 100;
                    m_blupiPosMagic = m_blupiPos;
                    m_jauges[1].SetHide(false);
                }
                if (ButtonPressed == Def.ButtonGlygh.PlayAction && m_moveObject[icon].type == 26 && !m_blupiShield && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && m_blupiFocus)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    m_sucettePos = m_moveObject[icon].posCurrent;
                    m_sucetteType = m_moveObject[icon].type;
                    ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    m_blupiAction = 49;
                    m_blupiPhase = 0;
                    m_blupiCloud = false;
                    m_blupiHide = false;
                    m_blupiFocus = false;
                    PlaySound(50, end);
                }
                if (m_moveObject[icon].type == 40 && !m_blupiHide && m_blupiFocus)
                {
                    ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    m_blupiInvert = true;
                    m_blupiTimeShield = 100;
                    m_blupiPosMagic = m_blupiPos;
                    m_jauges[1].SetHide(false);
                    PlaySound(66, end);
                    ObjectStart(m_blupiPos, 41, -60);
                    ObjectStart(m_blupiPos, 41, 60);
                    ObjectStart(m_blupiPos, 41, 10);
                    ObjectStart(m_blupiPos, 41, -10);
                }
                if (ButtonPressed == Def.ButtonGlygh.PlayAction && m_moveObject[icon].type == 30 && !m_blupiShield && !m_blupiCloud && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && m_blupiFocus)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    m_sucettePos = m_moveObject[icon].posCurrent;
                    m_sucetteType = m_moveObject[icon].type;
                    ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    m_blupiAction = 55;
                    m_blupiPhase = 0;
                    m_blupiShield = false;
                    m_blupiPower = false;
                    m_blupiJumpAie = false;
                    m_blupiFocus = false;
                    PlaySound(57, end);
                }
                if (m_moveObject[icon].type == 31 && !m_blupiShield && !m_blupiHide && !m_blupiPower && !m_blupiCloud && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && m_blupiFocus)
                {
                    m_blupiAction = 56;
                    m_blupiPhase = 0;
                    m_blupiShield = false;
                    m_blupiPower = false;
                    m_blupiJumpAie = false;
                    m_blupiFocus = false;
                    m_blupiCloud = true;
                    m_blupiTimeShield = 100;
                    PlaySound(58, end);
                    if (m_blupiHide)
                    {
                        m_blupiHide = false;
                        m_jauges[1].SetHide(true);
                    }
                }
                if (m_moveObject[icon].type >= 200 && m_moveObject[icon].type <= 203 && m_blupiFocus)
                {
                    if (m_moveObject[icon].type == 200)
                    {
                        if (m_blupiPerso < 5 && ButtonPressed == Def.ButtonGlygh.PlayAction)
                        {
                            ButtonPressed = Def.ButtonGlygh.None;
                            ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                            celSwitch.X = m_moveObject[icon].posCurrent.X - m_posDecor.X;
                            celSwitch.Y = m_moveObject[icon].posCurrent.Y - m_posDecor.Y;
                            tinyPoint2.X = 0;
                            tinyPoint2.Y = 438;
                            VoyageInit(m_pixmap.HotSpotToHud(celSwitch), tinyPoint2, 108, 4);
                        }
                    }
                    else if (!m_blupiShield && !m_blupiHide && !m_bSuperBlupi)
                    {
                        ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                        BlupiDead(11, 75);
                        celSwitch = m_moveObject[icon].posCurrent;
                        celSwitch.X -= 34;
                        celSwitch.Y -= 34;
                        ObjectStart(celSwitch, 10, 0);
                        PlaySound(10, m_moveObject[icon].posCurrent);
                        m_decorAction = 1;
                        m_decorPhase = 0;
                    }
                }
                if (m_moveObject[icon].type == 55 && m_blupiFocus && m_blupiDynamite == 0 && (m_voyageIcon != 252 || m_voyageChannel != 10) && ButtonPressed == Def.ButtonGlygh.PlayAction)
                {
                    ButtonPressed = Def.ButtonGlygh.None;
                    ObjectDelete(m_moveObject[icon].posCurrent, m_moveObject[icon].type);
                    celSwitch.X = m_moveObject[icon].posCurrent.X - m_posDecor.X;
                    celSwitch.Y = m_moveObject[icon].posCurrent.Y - m_posDecor.Y;
                    tinyPoint2.X = 505;
                    tinyPoint2.Y = 414;
                    VoyageInit(m_pixmap.HotSpotToHud(celSwitch), tinyPoint2, 252, 10);
                    m_blupiAction = 86;
                    m_blupiPhase = 0;
                    m_blupiFocus = false;
                }
                if (m_moveObject[icon].type == 12 && !m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && !m_blupiSuspend && m_blupiFocus && m_blupiAction == 2)
                {
                    end = m_moveObject[icon].posCurrent;
                    if (m_blupiDir == 1 && m_blupiPos.X > end.X)
                    {
                        end.X = m_blupiPos.X - 59;
                        PlaySound(38, end);
                        m_blupiActionOuf = 45;
                        m_blupiTimeOuf = 0;
                        m_blupiAction = 14;
                        m_blupiPhase = 0;
                    }
                    if (m_blupiDir == 2 && m_blupiPos.X < end.X)
                    {
                        end.X = m_blupiPos.X + 55;
                        PlaySound(38, end);
                        m_blupiActionOuf = 45;
                        m_blupiTimeOuf = 0;
                        m_blupiAction = 14;
                        m_blupiPhase = 0;
                    }
                    if (!TestPushCaisse(icon, end, false))
                    {
                        m_blupiPos.X = blupiPos.X;
                    }
                }
                if ((m_moveObject[icon].type == 7 || m_moveObject[icon].type == 21) && m_blupiFocus)
                {
                    if (m_goalPhase == 0)
                    {
                        if (m_nbTresor >= m_totalTresor)
                        {
                            if (m_moveObject[icon].type == 21)
                            {
                                m_bFoundCle = true;
                            }
                            ByeByeHelico();
                            StopSound(16);
                            StopSound(18);
                            StopSound(29);
                            StopSound(31);
                            PlaySound(14, m_moveObject[icon].posCurrent);
                            m_blupiAction = 13;
                            m_blupiPhase = 0;
                            m_blupiFocus = false;
                            m_blupiFront = true;
                            m_blupiPos.Y = m_moveObject[icon].posCurrent.Y;
                        }
                        else
                        {
                            PlaySound(13, m_moveObject[icon].posCurrent);
                        }
                        m_goalPhase = 50;
                    }
                    else
                    {
                        m_goalPhase--;
                    }
                }
                else
                {
                    m_goalPhase = 0;
                }
            }
            else
            {
                m_goalPhase = 0;
            }
            if (m_blupiAction == 14 && m_blupiFocus)
            {
                icon = CaisseInFront();
                if (icon != -1)
                {
                    end = m_moveObject[icon].posCurrent;
                    if (m_blupiDir == 1)
                    {
                        end.X = m_blupiPos.X - 59;
                    }
                    else
                    {
                        end.X = m_blupiPos.X + 55;
                    }
                    if (!TestPushCaisse(icon, end, false))
                    {
                        m_blupiPos.X = blupiPos.X;
                    }
                }
                else
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                }
            }
            if (m_blupiAction == 29 && m_blupiFocus)
            {
                icon = CaisseInFront();
                if (icon != -1)
                {
                    end = m_moveObject[icon].posCurrent;
                    if (m_blupiDir == 1)
                    {
                        end.X = m_blupiPos.X - 59;
                    }
                    else
                    {
                        end.X = m_blupiPos.X + 55;
                    }
                    if (!TestPushCaisse(icon, end, true))
                    {
                        m_blupiAction = 1;
                        m_blupiPhase = 0;
                    }
                }
                else
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                }
            }
            if (!m_blupiHelico && !m_blupiOver && !m_blupiBalloon && !m_blupiEcrase && !m_blupiJeep && !m_blupiTank && !m_blupiSkate && !m_blupiNage && !m_blupiSurf && m_blupiFocus)
            {
                if (m_blupiActionOuf == 44 && m_blupiAction == 1)
                {
                    if (m_blupiTimeOuf > 50)
                    {
                        m_blupiAction = m_blupiActionOuf;
                        m_blupiPhase = 0;
                        PlaySound(46, m_blupiPos);
                    }
                    m_blupiActionOuf = 0;
                }
                if (m_blupiActionOuf == 45 && m_blupiAction == 1)
                {
                    if (m_blupiTimeOuf > 50)
                    {
                        m_blupiAction = m_blupiActionOuf;
                        m_blupiPhase = 0;
                    }
                    m_blupiActionOuf = 0;
                }
                if (m_blupiAction == 45 && m_blupiPhase == 4)
                {
                    PlaySound(46, m_blupiPos);
                }
                if (m_blupiActionOuf == 65 && m_blupiAction == 1)
                {
                    if (m_blupiTimeOuf > 10 && m_blupiTimeOuf < 50)
                    {
                        m_blupiAction = m_blupiActionOuf;
                        m_blupiPhase = 0;
                    }
                    m_blupiActionOuf = 0;
                }
                if (m_blupiActionOuf == 47 && m_blupiAction == 1)
                {
                    if (m_blupiTimeOuf > 60)
                    {
                        m_blupiAction = m_blupiActionOuf;
                        m_blupiPhase = 0;
                        PlaySound(48, m_blupiPos);
                    }
                    m_blupiActionOuf = 0;
                }
                if (m_blupiActionOuf == 48 && m_blupiAction == 1)
                {
                    if (m_blupiTimeOuf < 10)
                    {
                        m_blupiAction = m_blupiActionOuf;
                        m_blupiPhase = 0;
                        PlaySound(49, m_blupiPos);
                    }
                    m_blupiActionOuf = 0;
                }
                if ((m_blupiActionOuf == 63 || m_blupiActionOuf == 64 || m_blupiActionOuf == 83) && m_blupiAction == 1)
                {
                    if (m_blupiTimeOuf < 20)
                    {
                        m_blupiAction = m_blupiActionOuf;
                        m_blupiPhase = 0;
                    }
                    m_blupiActionOuf = 0;
                }
            }
            if (m_blupiAction == 2 && m_blupiActionOuf != 63 && m_blupiActionOuf != 64 && m_blupiActionOuf != 83 && !m_blupiSurf && !m_blupiNage)
            {
                m_blupiActionOuf = 0;
            }
            if (m_blupiActionOuf != 0)
            {
                m_blupiTimeOuf++;
            }
            if (m_blupiTimeMockery > 0)
            {
                m_blupiTimeMockery--;
            }
            if (m_blupiAction == 86 && m_blupiPhase == 18)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
                m_blupiFocus = true;
            }
            if (m_blupiAction == 87 && m_blupiPhase == 26)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
                m_blupiFocus = true;
            }
            if (m_blupiPos.X - 30 > m_blupiPosHelico.X || m_blupiPos.X + 30 < m_blupiPosHelico.X || m_blupiPos.Y - 30 > m_blupiPosHelico.Y || m_blupiPos.Y + 30 < m_blupiPosHelico.Y)
            {
                m_blupiPosHelico.X = -1;
            }
            if (m_blupiTimeFire > 0)
            {
                m_blupiTimeFire--;
            }
            if (m_blupiAction == 74 && m_blupiPhase == 128)
            {
                TinyPoint newpos = default(TinyPoint);
                if (SearchTeleporte(m_blupiPos, ref newpos))
                {
                    m_blupiPos = newpos;
                    ObjectStart(m_blupiPos, 27, 20);
                    ObjectStart(m_blupiPos, 27, -20);
                }
                m_blupiFocus = true;
                m_blupiPosHelico = m_blupiPos;
            }
            if (m_blupiAction == 82 && m_blupiPhase == 10)
            {
                m_blupiAction = 1;
                m_blupiPhase = 0;
                m_blupiFocus = true;
            }
            if (ButtonPressed == Def.ButtonGlygh.PlayAction && m_blupiAction == 1)
            {
                m_blupiAction = 84;
                m_blupiPhase = 0;
                PlaySound(27, m_blupiPos);
            }
            if ((m_blupiAction == 11 && m_blupiPhase == 70) || (m_blupiAction == 75 && m_blupiPhase == 100) || (m_blupiAction == 76 && m_blupiPhase == 70) || (m_blupiAction == 77 && m_blupiPhase == 110) || (m_blupiAction == 78 && m_blupiPhase == 90) || (m_blupiAction == 79 && m_blupiPhase == 90) || (m_blupiAction == 80 && m_blupiPhase == 90) || (m_blupiAction == 81 && m_blupiPhase == 90) || (m_blupiAction == 24 && m_blupiPhase == 90) || (m_blupiAction == 54 && m_blupiPhase == 100) || (m_blupiAction == 57 && m_blupiPhase == 90))
            {
                if (m_nbVies > 0)
                {
                    m_blupiAction = 35;
                    m_blupiIcon = -1;
                    m_blupiPhase = 0;
                    if (m_blupiRestart)
                    {
                        m_blupiPos = m_blupiValidPos;
                    }
                    TinyPoint posDecor = GetPosDecor(m_blupiPos);
                    celSwitch.X = m_blupiPos.X - posDecor.X - 30;
                    celSwitch.Y = m_blupiPos.Y - posDecor.Y;
                    VoyageInit(VoyageGetPosVie(m_nbVies), m_pixmap.HotSpotToHud(celSwitch), 48, 2);
                }
                else
                {
                    m_nbVies = -1;
                    m_term = -1;
                    DoorsLost();
                }
                m_blupiFront = false;
            }
            num2 = ((m_dimDecor.Y != 0) ? 6400 : 480);
            if (m_blupiPos.Y >= num2 + 1 && m_blupiPos.Y <= num2 + 40)
            {
                PlaySound(8, m_blupiPos);
            }
            if (m_blupiPos.Y > num2 + 1000)
            {
                m_term = -1;
                DoorsLost();
            }
            if (m_blupiAction == 13 && m_blupiPhase == 40)
            {
                if (m_bPrivate)
                {
                    m_term = 1;
                }
                else if (m_mission == 1)
                {
                    m_term = 199;
                }
                else if (m_mission == 199)
                {
                    m_term = -2;
                }
                else if (m_bFoundCle)
                {
                    OpenGoldsWin();
                    m_term = 1;
                }
                else
                {
                    OpenDoorsWin();
                    m_term = m_mission / 10 * 10;
                }
            }
            if (m_blupiAction == 30 && m_blupiPhase == 30)
            {
                icon = IsWorld(m_blupiPos);
                if (icon != -1)
                {
                    if (m_mission == 1)
                    {
                        m_term = icon * 10;
                    }
                    else if (icon == 199)
                    {
                        m_term = 1;
                    }
                    else
                    {
                        m_term = m_mission / 10 * 10 + icon;
                    }
                }
            }
            if (blupiAction == 63 && m_blupiAction != 63)
            {
                StopSound(65);
            }
            if (blupiAction == 64 && m_blupiAction != 64)
            {
                StopSound(65);
            }
            if (blupiAction == 83 && m_blupiAction != 83)
            {
                StopSound(47);
            }
            if (m_blupiFocus && !m_blupiAir && (!m_blupiHelico || BlupiIsGround()) && (!m_blupiOver || BlupiIsGround()) && !m_blupiBalloon && !m_blupiEcrase && !m_blupiShield && !m_blupiHide && !bVertigoLeft && !bVertigoRight && m_blupiTransport == -1 && !IsLave(m_blupiPos) && !IsPiege(m_blupiPos) && !IsGoutte(m_blupiPos, true) && !IsScie(m_blupiPos) && !IsBridge(m_blupiPos, ref celSwitch) && IsTeleporte(m_blupiPos) == -1 && !IsBlitz(m_blupiPos, true) && !IsTemp(m_blupiPos) && !IsBalleTraj(m_blupiPos) && !IsMoveTraj(m_blupiPos))
            {
                if (m_blupiFifoNb > 0)
                {
                    m_blupiValidPos = m_blupiFifoPos[0];
                }
                BlupiAddFifo(m_blupiPos);
            }
            end.X = m_blupiPos.X + 30 + m_scrollAdd.X;
            end.Y = m_blupiPos.Y + 30 + m_scrollAdd.Y;
            int num27 = Math.Abs(m_scrollPoint.X - end.X);
            int num28 = Math.Abs(m_scrollPoint.Y - end.Y);
            num3 = SCROLL_SPEED;
            if (num27 > SCROLL_MARGX * 2)
            {
                num3 += (num27 - SCROLL_MARGX * 2) / 4;
            }
            if (num28 > SCROLL_MARGY * 2)
            {
                num3 += (num28 - SCROLL_MARGY * 2) / 4;
            }
            if (m_scrollPoint.X < end.X)
            {
                m_scrollPoint.X += num3;
                if (m_scrollPoint.X >= end.X)
                {
                    m_scrollPoint.X = end.X;
                }
            }
            if (m_scrollPoint.X > end.X)
            {
                m_scrollPoint.X -= num3;
                if (m_scrollPoint.X <= end.X)
                {
                    m_scrollPoint.X = end.X;
                }
            }
            if (m_scrollPoint.Y < end.Y)
            {
                m_scrollPoint.Y += num3;
                if (m_scrollPoint.Y >= end.Y)
                {
                    m_scrollPoint.Y = end.Y;
                }
            }
            if (m_scrollPoint.Y > end.Y)
            {
                m_scrollPoint.Y -= num3;
                if (m_scrollPoint.Y <= end.Y)
                {
                    m_scrollPoint.Y = end.Y;
                }
            }
            if (m_blupiAction != 75 && m_blupiAction != 76)
            {
                m_posDecor = GetPosDecor(m_scrollPoint);
            }
            if (m_time % 4 == 0)
            {
                PosSound(m_blupiPos);
            }
            VoyageStep();
            m_blupiLastSpeedX = m_blupiSpeedX;
            m_blupiLastSpeedY = m_blupiSpeedY;
            m_lastKeyPress = m_keyPress;
        }

        private void BlupiDead(int action1, int action2)
        {
            ByeByeHelico();
            if (action2 == -1)
            {
                m_blupiAction = action1;
            }
            else
            {
                m_blupiAction = ((m_random.Next() % 2 == 0) ? action1 : action2);
            }
            m_blupiPhase = 0;
            m_blupiFocus = false;
            m_blupiHelico = false;
            m_blupiOver = false;
            m_blupiJeep = false;
            m_blupiTank = false;
            m_blupiSkate = false;
            m_blupiNage = false;
            m_blupiSurf = false;
            m_blupiSuspend = false;
            m_blupiJumpAie = false;
            m_blupiShield = false;
            m_blupiPower = false;
            m_blupiCloud = false;
            m_blupiHide = false;
            m_blupiInvert = false;
            m_blupiBalloon = false;
            m_blupiEcrase = false;
            m_blupiRestart = false;
            m_blupiActionOuf = 0;
            m_jauges[0].SetHide(true);
            m_jauges[1].SetHide(true);
            StopSound(16);
            StopSound(18);
            StopSound(29);
            StopSound(31);
            TinyPoint pos = default(TinyPoint);
            TinyPoint pos2 = default(TinyPoint);
            if (m_blupiAction == 75)
            {
                pos.X = m_blupiPos.X - m_posDecor.X;
                pos.Y = m_blupiPos.Y - m_posDecor.Y;
                pos2.X = m_blupiPos.X - m_posDecor.X;
                pos2.Y = m_blupiPos.Y - m_posDecor.Y - 300;
                VoyageInit(m_pixmap.HotSpotToHud(pos), m_pixmap.HotSpotToHud(pos2), 230, 10);
                PlaySound(74, m_blupiPos);
            }
            if (m_blupiAction == 76)
            {
                pos.X = m_blupiPos.X - m_posDecor.X;
                pos.Y = m_blupiPos.Y - m_posDecor.Y;
                pos2.X = m_blupiPos.X - m_posDecor.X;
                pos2.Y = m_blupiPos.Y - m_posDecor.Y - 2000;
                VoyageInit(m_pixmap.HotSpotToHud(pos), m_pixmap.HotSpotToHud(pos2), 40, 10);
                PlaySound(74, m_blupiPos);
            }
            if (m_blupiAction == 77)
            {
                ObjectStart(m_blupiPos, 41, -70);
                ObjectStart(m_blupiPos, 41, 20);
                ObjectStart(m_blupiPos, 41, -20);
                PlaySound(75, m_blupiPos);
            }
        }

        private TinyPoint GetPosDecor(TinyPoint pos)
        {
            TinyPoint result = default(TinyPoint);
            if (m_dimDecor.X == 0)
            {
                result.X = 0;
            }
            else
            {
                result.X = pos.X - m_drawBounds.Width / 2;
                result.X = Math.Max(result.X, 0);
                result.X = Math.Min(result.X, 6400 - m_drawBounds.Width);
            }
            if (m_dimDecor.Y == 0)
            {
                result.Y = 0;
            }
            else
            {
                result.Y = pos.Y - m_drawBounds.Height / 2;
                result.Y = Math.Max(result.Y, 0);
                result.Y = Math.Min(result.Y, 6400 - m_drawBounds.Height);
            }
            return result;
        }

        private void BlupiAddFifo(TinyPoint pos)
        {
            if (m_blupiFifoNb < 10)
            {
                if (m_blupiFifoNb <= 0 || pos.X != m_blupiFifoPos[m_blupiFifoNb - 1].X || pos.Y != m_blupiFifoPos[m_blupiFifoNb - 1].Y)
                {
                    m_blupiFifoPos[m_blupiFifoNb] = pos;
                    m_blupiFifoNb++;
                }
            }
            else if (pos.X != m_blupiFifoPos[9].X || pos.Y != m_blupiFifoPos[9].Y)
            {
                for (int i = 0; i < 9; i++)
                {
                    m_blupiFifoPos[i] = m_blupiFifoPos[i + 1];
                }
                m_blupiFifoPos[9] = pos;
            }
        }

        private bool DecorDetect(TinyRect rect)
        {
            return DecorDetect(rect, true);
        }

        private bool DecorDetect(TinyRect rect, bool bCaisse)
        {
            m_detectIcon = -1;
            if (rect.Left < 0 || rect.Top < 0)
            {
                return true;
            }
            int num = ((m_dimDecor.X != 0) ? 6400 : 640);
            if (rect.Right > num)
            {
                return true;
            }
            if (m_blupiHelico || m_blupiOver || m_blupiBalloon || m_blupiEcrase || m_blupiNage || m_blupiSurf)
            {
                num = ((m_dimDecor.Y != 0) ? 6400 : 480);
                if (rect.Bottom > num)
                {
                    return true;
                }
            }
            int num2 = rect.Left / 16;
            int num3 = (rect.Right + 16 - 1) / 16;
            int num4 = rect.Top / 16;
            int num5 = (rect.Bottom + 16 - 1) / 16;
            TinyRect src = default(TinyRect);
            TinyRect dst;
            for (int i = num4; i <= num5; i++)
            {
                for (int j = num2; j <= num3; j++)
                {
                    int num6 = j / 4;
                    int num7 = i / 4;
                    if (num6 < 0 || num6 >= 100 || num7 < 0 || num7 >= 100)
                    {
                        continue;
                    }
                    int icon = m_decor[num6, num7].icon;
                    if (icon < 0 || icon >= MAXQUART || (m_blupiHelico && icon == 214) || (m_blupiOver && icon == 214) || (icon == 324 && m_time / 4 % 20 >= 18))
                    {
                        continue;
                    }
                    num6 = j % 4;
                    num7 = i % 4;
                    if (Tables.table_decor_quart[icon * 16 + num7 * 4 + num6] != 0)
                    {
                        src.Left = j * 16;
                        src.Right = src.Left + 16;
                        src.Top = i * 16;
                        src.Bottom = src.Top + 16;
                        if (Misc.IntersectRect(out dst, src, rect))
                        {
                            m_detectIcon = icon;
                            return true;
                        }
                    }
                }
            }
            if (!bCaisse)
            {
                return false;
            }
            for (int k = 0; k < m_nbRankCaisse; k++)
            {
                int num8 = m_rankCaisse[k];
                src.Left = m_moveObject[num8].posCurrent.X;
                src.Right = m_moveObject[num8].posCurrent.X + 64;
                src.Top = m_moveObject[num8].posCurrent.Y;
                src.Bottom = m_moveObject[num8].posCurrent.Y + 64;
                if (Misc.IntersectRect(out dst, src, rect))
                {
                    m_detectIcon = m_moveObject[num8].icon;
                    return true;
                }
            }
            return false;
        }

        private bool TestPath(TinyRect rect, TinyPoint start, ref TinyPoint end)
        {
            int num = Math.Abs(end.X - start.X);
            int num2 = Math.Abs(end.Y - start.Y);
            TinyPoint tinyPoint = start;
            TinyRect rect2 = default(TinyRect);
            if (num > num2)
            {
                if (end.X > start.X)
                {
                    for (int i = 0; i <= num; i++)
                    {
                        int num3 = i * (end.Y - start.Y) / num;
                        rect2.Left = rect.Left + i;
                        rect2.Right = rect.Right + i;
                        rect2.Top = rect.Top + num3;
                        rect2.Bottom = rect.Bottom + num3;
                        if (DecorDetect(rect2))
                        {
                            end = tinyPoint;
                            return false;
                        }
                        tinyPoint.X = start.X + i;
                        tinyPoint.Y = start.Y + num3;
                    }
                }
                if (end.X < start.X)
                {
                    for (int i = 0; i >= -num; i--)
                    {
                        int num3 = i * (start.Y - end.Y) / num;
                        rect2.Left = rect.Left + i;
                        rect2.Right = rect.Right + i;
                        rect2.Top = rect.Top + num3;
                        rect2.Bottom = rect.Bottom + num3;
                        if (DecorDetect(rect2))
                        {
                            end = tinyPoint;
                            return false;
                        }
                        tinyPoint.X = start.X + i;
                        tinyPoint.Y = start.Y + num3;
                    }
                }
            }
            else
            {
                if (end.Y > start.Y)
                {
                    for (int num3 = 0; num3 <= num2; num3++)
                    {
                        int i = num3 * (end.X - start.X) / num2;
                        rect2.Left = rect.Left + i;
                        rect2.Right = rect.Right + i;
                        rect2.Top = rect.Top + num3;
                        rect2.Bottom = rect.Bottom + num3;
                        if (DecorDetect(rect2))
                        {
                            end = tinyPoint;
                            return false;
                        }
                        tinyPoint.X = start.X + i;
                        tinyPoint.Y = start.Y + num3;
                    }
                }
                if (end.Y < start.Y)
                {
                    for (int num3 = 0; num3 >= -num2; num3--)
                    {
                        int i = num3 * (start.X - end.X) / num2;
                        rect2.Left = rect.Left + i;
                        rect2.Right = rect.Right + i;
                        rect2.Top = rect.Top + num3;
                        rect2.Bottom = rect.Bottom + num3;
                        if (DecorDetect(rect2))
                        {
                            end = tinyPoint;
                            return false;
                        }
                        tinyPoint.X = start.X + i;
                        tinyPoint.Y = start.Y + num3;
                    }
                }
            }
            return true;
        }

        private void MoveObjectPollution()
        {
            bool flag = false;
            TinyPoint blupiPos = m_blupiPos;
            TinyPoint tinyPoint = default(TinyPoint);
            tinyPoint.X = 0;
            tinyPoint.Y = 0;
            int num = 20;
            if (m_blupiAction == 3)
            {
                return;
            }
            if (m_blupiHelico)
            {
                if (m_blupiVitesseY < -5.0)
                {
                    if (m_time % 20 != 0 && m_time % 20 != 2 && m_time % 20 != 5 && m_time % 20 != 8 && m_time % 20 != 10 && m_time % 20 != 11 && m_time % 20 != 16 && m_time % 20 != 18)
                    {
                        return;
                    }
                }
                else if (m_blupiVitesseX == 0.0)
                {
                    if (m_time % 50 != 0 && m_time % 50 != 12 && m_time % 50 != 30)
                    {
                        return;
                    }
                }
                else if (m_time % 20 != 0 && m_time % 20 != 3 && m_time % 20 != 5 && m_time % 20 != 11 && m_time % 20 != 15)
                {
                    return;
                }
                tinyPoint.X = 22;
                flag = true;
            }
            if (m_blupiOver)
            {
                if (m_blupiSpeedY < 0.0 || ((uint)m_keyPress & (true ? 1u : 0u)) != 0)
                {
                    if (m_time % 20 != 0 && m_time % 20 != 2 && m_time % 20 != 5 && m_time % 20 != 8 && m_time % 20 != 11 && m_time % 20 != 13 && m_time % 20 != 14 && m_time % 20 != 18)
                    {
                        return;
                    }
                    num = 58;
                    tinyPoint.X = m_random.Next(-10, 10);
                    tinyPoint.Y = 22;
                }
                else
                {
                    if (m_time % 50 != 0 && m_time % 50 != 12 && m_time % 50 != 30)
                    {
                        return;
                    }
                    num = 20;
                    tinyPoint.X = 30;
                }
                flag = true;
            }
            if (m_blupiJeep)
            {
                if (m_blupiVitesseX == 0.0)
                {
                    if (m_blupiPhase % 50 != 0 && m_blupiPhase % 50 != 12 && m_blupiPhase % 50 != 20 && m_blupiPhase % 50 != 35)
                    {
                        return;
                    }
                }
                else if (m_blupiPhase % 20 != 0 && m_blupiPhase % 20 != 3 && m_blupiPhase % 20 != 5 && m_blupiPhase % 20 != 11 && m_blupiPhase % 20 != 15)
                {
                    return;
                }
                tinyPoint.X = 32;
                flag = true;
            }
            if (m_blupiTank)
            {
                if (m_blupiVitesseX == 0.0)
                {
                    if (m_blupiPhase % 50 != 0 && m_blupiPhase % 50 != 15 && m_blupiPhase % 50 != 28)
                    {
                        return;
                    }
                }
                else if (m_blupiPhase % 20 != 0 && m_blupiPhase % 20 != 4 && m_blupiPhase % 20 != 12)
                {
                    return;
                }
                tinyPoint.X = 35;
                flag = true;
            }
            if (!flag)
            {
                return;
            }
            if (m_blupiDir == 2)
            {
                blupiPos.X -= tinyPoint.X - 5;
                if (num < 50)
                {
                    num = -num;
                }
            }
            else
            {
                blupiPos.X += tinyPoint.X;
            }
            blupiPos.Y += tinyPoint.Y;
            ObjectStart(blupiPos, 36, num);
        }

        private void MoveObjectPlouf(TinyPoint pos)
        {
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type == 14)
                {
                    return;
                }
            }
            pos.Y -= 45;
            PlaySound(23, pos);
            ObjectStart(pos, 14, 0);
        }

        private void MoveObjectTiplouf(TinyPoint pos)
        {
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type == 35)
                {
                    return;
                }
            }
            if (m_blupiDir == 2)
            {
                pos.X += 5;
            }
            else
            {
                pos.X -= 5;
            }
            pos.Y -= 45;
            PlaySound(64, pos);
            ObjectStart(pos, 35, 0);
        }

        private void MoveObjectBlup(TinyPoint pos)
        {
            PlaySound(24, pos);
            pos.Y -= 20;
            int num = 0;
            TinyPoint tinyPoint = pos;
            while (tinyPoint.Y > 0)
            {
                int icon = m_decor[(tinyPoint.X + 16) / 64, tinyPoint.Y / 64].icon;
                if (icon != 91 && icon != 92)
                {
                    break;
                }
                num++;
                tinyPoint.Y -= 64;
            }
            num--;
            if (num > 0)
            {
                int num2 = MoveObjectFree();
                if (num2 != -1)
                {
                    m_moveObject[num2].type = 15;
                    m_moveObject[num2].phase = 0;
                    m_moveObject[num2].posCurrent.X = pos.X;
                    m_moveObject[num2].posCurrent.Y = pos.Y;
                    m_moveObject[num2].posStart = m_moveObject[num2].posCurrent;
                    m_moveObject[num2].posEnd.X = pos.X;
                    m_moveObject[num2].posEnd.Y = pos.Y - num * 64;
                    m_moveObject[num2].timeStopStart = 0;
                    m_moveObject[num2].stepAdvance = num * 10;
                    m_moveObject[num2].step = 2;
                    m_moveObject[num2].time = 0;
                    MoveObjectStepIcon(num2);
                }
            }
        }

        private int IsWorld(TinyPoint pos)
        {
            pos.X += 30;
            pos.Y += 30;
            if (pos.X < 0 || pos.X >= 6400 || pos.Y < 0 || pos.Y >= 6400)
            {
                return -1;
            }
            int icon = m_decor[pos.X / 64, pos.Y / 64].icon;
            if (icon >= 158 && icon <= 165)
            {
                return icon - 158 + 1;
            }
            if (icon >= 166 && icon <= 173)
            {
                return icon - 166 + 1;
            }
            switch (icon)
            {
                case 309:
                case 310:
                    return 9;
                case 411:
                case 412:
                case 413:
                case 414:
                case 415:
                    return icon - 411 + 10;
                default:
                    if (icon >= 416 && icon <= 420)
                    {
                        return icon - 416 + 10;
                    }
                    if (icon >= 174 && icon <= 181)
                    {
                        return icon - 174 + 1;
                    }
                    if (icon == 184)
                    {
                        return 199;
                    }
                    return -1;
            }
        }

        private void ActiveSwitch(bool bState, TinyPoint cel)
        {
            TinyPoint pos = default(TinyPoint);
            pos.X = cel.X * 64;
            pos.Y = cel.Y * 64;
            ModifDecor(pos, bState ? 384 : 385);
            PlaySound(bState ? 77 : 76, pos);
            cel.X -= 20;
            for (int i = 0; i < 41; i++)
            {
                if (cel.X >= 0 && cel.X < 100 && m_decor[cel.X, cel.Y].icon == (bState ? 379 : 378))
                {
                    pos.X = cel.X * 64;
                    pos.Y = cel.Y * 64;
                    ModifDecor(pos, bState ? 378 : 379);
                }
                cel.X++;
            }
        }

        private int GetTypeBarre(TinyPoint pos)
        {
            TinyPoint pos2 = pos;
            pos.X += 30;
            pos.Y += 22;
            if (pos.Y % 64 > 44)
            {
                return 0;
            }
            if (pos.X < 0 || pos.X >= 6400 || pos.Y < 0 || pos.Y >= 6400)
            {
                return 0;
            }
            int icon = m_decor[pos.X / 64, pos.Y / 64].icon;
            if (icon != 138 && icon != 202)
            {
                return 0;
            }
            if (pos.Y >= 6336)
            {
                return 1;
            }
            icon = m_decor[pos.X / 64, pos.Y / 64 + 1].icon;
            if (!IsPassIcon(icon))
            {
                return 2;
            }
            TinyRect rect = BlupiRect(pos2);
            rect.Top = pos2.Y + 60 - 2;
            rect.Bottom = pos2.Y + 60 - 1;
            if (DecorDetect(rect, true))
            {
                return 2;
            }
            return 1;
        }

        private bool IsLave(TinyPoint pos)
        {
            pos.X += 30;
            if (pos.X < 0 || pos.X >= 6400 || pos.Y < 0 || pos.Y >= 6400)
            {
                return false;
            }
            return m_decor[pos.X / 64, pos.Y / 64].icon == 68;
        }

        private bool IsPiege(TinyPoint pos)
        {
            pos.X += 30;
            pos.Y += 60;
            if (pos.X % 64 < 15 || pos.X % 64 > 49)
            {
                return false;
            }
            if (pos.X < 0 || pos.X >= 6400 || pos.Y < 0 || pos.Y >= 6400)
            {
                return false;
            }
            return m_decor[pos.X / 64, pos.Y / 64].icon == 373;
        }

        private bool IsGoutte(TinyPoint pos, bool bAlways)
        {
            pos.X += 30;
            if (pos.X % 64 < 15 || pos.X % 64 > 49)
            {
                return false;
            }
            if (pos.X < 0 || pos.X >= 6400 || pos.Y < 0 || pos.Y >= 6400)
            {
                return false;
            }
            int icon = m_decor[pos.X / 64, pos.Y / 64].icon;
            if (bAlways)
            {
                if (icon != 404)
                {
                    return icon == 410;
                }
                return true;
            }
            return icon == 404;
        }

        private bool IsScie(TinyPoint pos)
        {
            pos.X += 30;
            if (pos.X % 64 < 4 || pos.X % 64 > 60)
            {
                return false;
            }
            if (pos.X < 0 || pos.X >= 6400 || pos.Y < 0 || pos.Y >= 6400)
            {
                return false;
            }
            return m_decor[pos.X / 64, pos.Y / 64].icon == 378;
        }

        private bool IsSwitch(TinyPoint pos, ref TinyPoint celSwitch)
        {
            pos.X += 30;
            if (pos.X % 64 < 4 || pos.X % 64 > 60)
            {
                return false;
            }
            if (pos.X < 0 || pos.X >= 6400 || pos.Y < 0 || pos.Y >= 6400)
            {
                return false;
            }
            celSwitch.X = pos.X / 64;
            celSwitch.Y = pos.Y / 64;
            if (m_decor[pos.X / 64, pos.Y / 64].icon != 384)
            {
                return m_decor[pos.X / 64, pos.Y / 64].icon == 385;
            }
            return true;
        }

        private bool IsEcraseur(TinyPoint pos)
        {
            if (m_time / 3 % 10 > 2)
            {
                return false;
            }
            pos.X += 30;
            if (pos.X < 0 || pos.X >= 6400 || pos.Y < 0 || pos.Y >= 6400)
            {
                return false;
            }
            return m_decor[pos.X / 64, pos.Y / 64].icon == 317;
        }

        private bool IsBlitz(TinyPoint pos, bool bAlways)
        {
            pos.X += 30;
            if (pos.X < 0 || pos.X >= 6400 || pos.Y < 0 || pos.Y >= 6400)
            {
                return false;
            }
            TinyPoint tinyPoint = default(TinyPoint);
            tinyPoint.X = pos.X / 64;
            tinyPoint.Y = pos.Y / 64;
            if (m_decor[tinyPoint.X, tinyPoint.Y].icon != 305)
            {
                return false;
            }
            if (bAlways)
            {
                return true;
            }
            return BlitzActif(tinyPoint.X, tinyPoint.Y);
        }

        private bool IsRessort(TinyPoint pos)
        {
            pos.X += 30;
            pos.Y += 60;
            if (pos.X < 0 || pos.X >= 6400 || pos.Y < 0 || pos.Y >= 6400)
            {
                return false;
            }
            return m_decor[pos.X / 64, pos.Y / 64].icon == 211;
        }

        private bool IsTemp(TinyPoint pos)
        {
            pos.X += 30;
            pos.Y += 60;
            if (pos.X < 0 || pos.X >= 6400 || pos.Y < 0 || pos.Y >= 6400)
            {
                return false;
            }
            return m_decor[pos.X / 64, pos.Y / 64].icon == 324;
        }

        private bool IsBridge(TinyPoint pos, ref TinyPoint celBridge)
        {
            pos.X += 30;
            pos.Y += 60;
            if (pos.X >= 0 && pos.X < 6400 && pos.Y >= 0 && pos.Y < 6400 && m_decor[pos.X / 64, pos.Y / 64].icon == 364)
            {
                celBridge.X = pos.X / 64;
                celBridge.Y = pos.Y / 64;
                return true;
            }
            pos.Y -= 60;
            if (pos.X >= 0 && pos.X < 6400 && pos.Y >= 0 && pos.Y < 6400 && m_decor[pos.X / 64, pos.Y / 64].icon == 364)
            {
                celBridge.X = pos.X / 64;
                celBridge.Y = pos.Y / 64;
                return true;
            }
            return false;
        }

        private int IsDoor(TinyPoint pos, ref TinyPoint celPorte)
        {
            int num = ((m_blupiDir != 1) ? 60 : (-60));
            pos.X += 30;
            for (int i = 0; i < 2; i++)
            {
                if (pos.X >= 0 && pos.X < 6400 && pos.Y >= 0 && pos.Y < 6400 && m_decor[pos.X / 64, pos.Y / 64].icon >= 334 && m_decor[pos.X / 64, pos.Y / 64].icon <= 336)
                {
                    celPorte.X = pos.X / 64;
                    celPorte.Y = pos.Y / 64;
                    return m_decor[pos.X / 64, pos.Y / 64].icon;
                }
                pos.X += num;
            }
            return -1;
        }

        private int IsTeleporte(TinyPoint pos)
        {
            if (pos.X % 64 > 6)
            {
                return -1;
            }
            pos.X += 30;
            pos.Y -= 60;
            if (pos.X < 0 || pos.X >= 6400 || pos.Y < 0 || pos.Y >= 6400)
            {
                return -1;
            }
            if (m_decor[pos.X / 64, pos.Y / 64].icon >= 330 && m_decor[pos.X / 64, pos.Y / 64].icon <= 333)
            {
                return m_decor[pos.X / 64, pos.Y / 64].icon;
            }
            return -1;
        }

        private bool SearchTeleporte(TinyPoint pos, ref TinyPoint newpos)
        {
            int num = IsTeleporte(pos);
            if (num == -1)
            {
                return false;
            }
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (num == m_decor[i, j].icon)
                    {
                        newpos.X = i * 64;
                        newpos.Y = j * 64 + 60;
                        if (newpos.X < pos.X - 40 || newpos.X > pos.X + 40 || newpos.Y < pos.Y - 40 || newpos.Y > pos.Y + 40)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool IsNormalJump(TinyPoint pos)
        {
            pos.X += 32;
            pos.Y -= 32;
            if (m_blupiDir == 1)
            {
                pos.X -= 15;
            }
            else
            {
                pos.X += 15;
            }
            for (int i = 0; i < 2; i++)
            {
                int num = pos.X / 64;
                int num2 = pos.Y / 64;
                if (num2 < 0)
                {
                    return false;
                }
                int icon = m_decor[num, num2].icon;
                if (!IsPassIcon(icon))
                {
                    return false;
                }
                pos.Y -= 64;
            }
            return true;
        }

        private bool IsSurfWater(TinyPoint pos)
        {
            if (pos.Y % 64 < 64 - BLUPISURF)
            {
                return false;
            }
            int icon = m_decor[(pos.X + 30) / 64, pos.Y / 64].icon;
            int icon2 = m_decor[(pos.X + 30) / 64, (pos.Y + BLUPISURF) / 64].icon;
            if (icon != 92 && icon2 == 92)
            {
                return true;
            }
            return false;
        }

        private bool IsDeepWater(TinyPoint pos)
        {
            int num = (pos.X + 30) / 64;
            int num2 = pos.Y / 64;
            if (num < 0 || num >= 100 || num2 < 0 || num2 >= 100)
            {
                return false;
            }
            int icon = m_decor[num, num2].icon;
            if (icon != 91)
            {
                return icon == 92;
            }
            return true;
        }

        private bool IsOutWater(TinyPoint pos)
        {
            int icon = m_decor[(pos.X + 30) / 64, (pos.Y + 30) / 64].icon;
            if (icon == 91 || icon == 92)
            {
                return false;
            }
            return IsPassIcon(icon);
        }

        private bool IsPassIcon(int icon)
        {
            if (icon == 324 && m_time / 4 % 20 >= 18)
            {
                return true;
            }
            if (icon >= 0 && icon < MAXQUART)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (Tables.table_decor_quart[icon * 16 + i] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsBlocIcon(int icon)
        {
            if (icon < 0 || icon >= MAXQUART)
            {
                return false;
            }
            if (icon == 324 && m_time / 4 % 20 < 18)
            {
                return true;
            }
            for (int i = 0; i < 16; i++)
            {
                if (Tables.table_decor_quart[icon * 16 + i] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void FlushBalleTraj()
        {
            for (int i = 0; i < 1300; i++)
            {
                m_balleTraj[i] = 0;
            }
        }

        private void SetBalleTraj(TinyPoint pos)
        {
            if (pos.X >= 0 && pos.X < 100 && pos.Y >= 0 && pos.Y < 100)
            {
                int num = pos.Y * 13;
                num += pos.X / 8;
                int num2 = pos.X & 7;
                m_balleTraj[num] |= 1 << num2;
            }
        }

        private bool IsBalleTraj(TinyPoint pos)
        {
            pos.X = (pos.X + 32) / 64;
            pos.Y = (pos.Y + 32) / 64;
            if (pos.X < 0 || pos.X >= 100 || pos.Y < 0 || pos.Y >= 100)
            {
                return false;
            }
            int num = pos.Y * 13;
            num += pos.X / 8;
            int num2 = pos.X & 7;
            return (m_balleTraj[num] & (1 << num2)) != 0;
        }

        private void FlushMoveTraj()
        {
            for (int i = 0; i < 1300; i++)
            {
                m_moveTraj[i] = 0;
            }
        }

        private void SetMoveTraj(TinyPoint pos)
        {
            if (pos.X >= 0 && pos.X < 100 && pos.Y >= 0 && pos.Y < 100)
            {
                int num = pos.Y * 13;
                num += pos.X / 8;
                int num2 = pos.X & 7;
                m_moveTraj[num] |= 1 << num2;
            }
        }

        private bool IsMoveTraj(TinyPoint pos)
        {
            pos.X = (pos.X + 32) / 64;
            pos.Y = (pos.Y + 32) / 64;
            if (pos.X < 0 || pos.X >= 100 || pos.Y < 0 || pos.Y >= 100)
            {
                return false;
            }
            int num = pos.Y * 13;
            num += pos.X / 8;
            int num2 = pos.X & 7;
            return (m_moveTraj[num] & (1 << num2)) != 0;
        }

        private int SearchDistRight(TinyPoint pos, TinyPoint dir, int type)
        {
            int num = 0;
            if (type == 36 || type == 39 || type == 41 || type == 42 || type == 93)
            {
                return 500;
            }
            pos.X = (pos.X + 32) / 64;
            pos.Y = (pos.Y + 32) / 64;
            while (pos.X >= 0 && pos.X < 100 && pos.Y >= 0 && pos.Y < 100 && !IsBlocIcon(m_decor[pos.X, pos.Y].icon))
            {
                if (type == 23)
                {
                    SetBalleTraj(pos);
                }
                num += 64;
                pos.X += dir.X;
                pos.Y += dir.Y;
            }
            if ((type == 34 || type == 38) && num >= 64)
            {
                num -= 64;
            }
            if (type == 23 && num >= 10)
            {
                num -= 10;
            }
            return num;
        }

        private bool IsVentillo(TinyPoint pos)
        {
            int num = 0;
            bool flag = false;
            TinyPoint tinyPoint = default(TinyPoint);
            pos.X += 30;
            pos.Y += 30;
            if (pos.X < 0 || pos.X >= 6400 || pos.Y < 0 || pos.Y >= 6400)
            {
                return false;
            }
            int icon = m_decor[pos.X / 64, pos.Y / 64].icon;
            switch (icon)
            {
                default:
                    return false;
                case 126:
                    if (pos.X % 64 <= 16)
                    {
                        flag = true;
                    }
                    tinyPoint.X = -64;
                    tinyPoint.Y = 0;
                    num = 110;
                    break;
                case 127:
                case 128:
                case 129:
                case 130:
                case 131:
                case 132:
                case 133:
                case 134:
                case 135:
                case 136:
                case 137:
                    break;
            }
            if (icon == 129)
            {
                if (pos.X % 64 >= 48)
                {
                    flag = true;
                }
                tinyPoint.X = 64;
                tinyPoint.Y = 0;
                num = 114;
            }
            if (icon == 132)
            {
                if (pos.Y % 64 <= 32)
                {
                    flag = true;
                }
                tinyPoint.X = 0;
                tinyPoint.Y = -64;
                num = 118;
            }
            if (icon == 135)
            {
                if (pos.Y % 64 >= 48)
                {
                    flag = true;
                }
                tinyPoint.X = 0;
                tinyPoint.Y = 64;
                num = 122;
            }
            if (!flag)
            {
                return false;
            }
            ModifDecor(pos, -1);
            do
            {
                pos.X += tinyPoint.X;
                pos.Y += tinyPoint.Y;
                if (num != m_decor[pos.X / 64, pos.Y / 64].icon)
                {
                    break;
                }
                ModifDecor(pos, -1);
            }
            while (pos.X >= 0 && pos.X < 6400 && pos.Y >= 0 && pos.Y < 6400);
            return true;
        }

        private void NetStopCloud(int rank)
        {
        }

        private void StartSploutchGlu(TinyPoint pos)
        {
            TinyPoint pos2 = default(TinyPoint);
            pos2.X = pos.X;
            pos2.Y = pos.Y;
            ObjectStart(pos2, 98, 0);
            pos2.X = pos.X + 15;
            pos2.Y = pos.Y + 20;
            ObjectStart(pos2, 99, 0);
            pos2.X = pos.X - 20;
            pos2.Y = pos.Y + 18;
            ObjectStart(pos2, 99, 0);
            pos2.X = pos.X + 23;
            pos2.Y = pos.Y - 18;
            ObjectStart(pos2, 99, 0);
            pos2.X = pos.X - 15;
            pos2.Y = pos.Y - 18;
            ObjectStart(pos2, 99, 0);
            pos2.X = pos.X + 32;
            pos2.Y = pos.Y + 10;
            ObjectStart(pos2, 100, 0);
            pos2.X = pos.X - 28;
            pos2.Y = pos.Y + 15;
            ObjectStart(pos2, 100, 0);
            StopSound(16);
            StopSound(18);
            StopSound(29);
            StopSound(31);
            PlaySound(51, pos);
        }

        private int ObjectStart(TinyPoint pos, int type, int speed)
        {
            int num = MoveObjectFree();
            if (num == -1)
            {
                return -1;
            }
            m_moveObject[num].type = type;
            m_moveObject[num].phase = 0;
            m_moveObject[num].posCurrent = pos;
            m_moveObject[num].posStart = pos;
            m_moveObject[num].posEnd = pos;
            MoveObjectStepIcon(num);
            if (speed != 0)
            {
                TinyPoint tinyPoint = pos;
                int num2 = speed;
                int num3 = 0;
                TinyPoint dir = default(TinyPoint);
                if (num2 > 50)
                {
                    num2 -= 50;
                    dir.X = 0;
                    dir.Y = 1;
                    num3 = SearchDistRight(tinyPoint, dir, type);
                    tinyPoint.Y += num3;
                }
                else if (num2 < -50)
                {
                    num2 += 50;
                    dir.X = 0;
                    dir.Y = -1;
                    num3 = SearchDistRight(tinyPoint, dir, type);
                    tinyPoint.Y -= num3;
                }
                else if (num2 > 0)
                {
                    dir.X = 1;
                    dir.Y = 0;
                    num3 = SearchDistRight(tinyPoint, dir, type);
                    tinyPoint.X += num3;
                }
                else if (num2 < 0)
                {
                    dir.X = -1;
                    dir.Y = 0;
                    num3 = SearchDistRight(tinyPoint, dir, type);
                    tinyPoint.X -= num3;
                }
                if (num3 == 0)
                {
                    if (type == 23)
                    {
                        m_moveObject[num].type = 0;
                        return num;
                    }
                }
                else
                {
                    m_moveObject[num].posEnd = tinyPoint;
                    m_moveObject[num].timeStopStart = 0;
                    m_moveObject[num].stepAdvance = Math.Abs(num2 * num3 / 64);
                    m_moveObject[num].step = 2;
                    m_moveObject[num].time = 0;
                }
            }
            MoveObjectPriority(num);
            return num;
        }

        private bool ObjectDelete(TinyPoint pos, int type)
        {
            int num = MoveObjectSearch(pos, type);
            if (num == -1)
            {
                return false;
            }
            if (m_moveObject[num].type == 4 || m_moveObject[num].type == 12 || m_moveObject[num].type == 16 || m_moveObject[num].type == 17 || m_moveObject[num].type == 20 || m_moveObject[num].type == 40 || m_moveObject[num].type == 96 || m_moveObject[num].type == 97)
            {
                int num2 = 17;
                double animationSpeed = 1.0;
                if (m_moveObject[num].type == 4)
                {
                    num2 = 7;
                }
                if (m_moveObject[num].type == 17 || m_moveObject[num].type == 20)
                {
                    num2 = 33;
                }
                if (m_moveObject[num].type == 40)
                {
                    animationSpeed = 0.5;
                }
                ByeByeAdd(m_moveObject[num].channel, m_moveObject[num].icon, m_moveObject[num].posCurrent, num2, animationSpeed);
            }
            m_moveObject[num].type = 0;
            return true;
        }

        private void ModifDecor(TinyPoint pos, int icon)
        {
            int icon2 = m_decor[pos.X / 64, pos.Y / 64].icon;
            if (icon == -1 && icon2 >= 126 && icon2 <= 137)
            {
                ByeByeAdd(1, icon2, pos, 17.0, 1.0);
            }
            m_decor[pos.X / 64, pos.Y / 64].icon = icon;
        }

        private void MoveObjectStep()
        {
            m_blupiVector.X = 0;
            m_blupiVector.Y = 0;
            m_blupiTransport = -1;
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type == 0)
                {
                    continue;
                }
                MoveObjectStepLine(i);
                MoveObjectStepIcon(i);
                if (m_moveObject[i].type == 4 || m_moveObject[i].type == 33 || m_moveObject[i].type == 32)
                {
                    int num = MovePersoDetect(m_moveObject[i].posCurrent);
                    if (num != -1)
                    {
                        TinyPoint posCurrent = m_moveObject[i].posCurrent;
                        posCurrent.X -= 34;
                        posCurrent.Y -= 34;
                        ObjectStart(posCurrent, 8, 0);
                        PlaySound(10, m_moveObject[i].posCurrent);
                        m_decorAction = 1;
                        m_decorPhase = 0;
                        posCurrent = m_moveObject[i].posCurrent;
                        posCurrent.X += 2;
                        posCurrent.Y += BLUPIOFFY;
                        ObjectDelete(m_moveObject[i].posCurrent, m_moveObject[i].type);
                        ObjectStart(posCurrent, 37, 0);
                        ObjectDelete(m_moveObject[num].posCurrent, m_moveObject[num].type);
                    }
                    if (BlupiElectro(m_moveObject[i].posCurrent))
                    {
                        TinyPoint posCurrent = m_moveObject[i].posCurrent;
                        posCurrent.X += 2;
                        posCurrent.Y += BLUPIOFFY;
                        ObjectDelete(m_moveObject[i].posCurrent, m_moveObject[i].type);
                        ObjectStart(posCurrent, 38, 55);
                        PlaySound(59, posCurrent);
                    }
                }
            }
        }

        private void MoveObjectStepLine(int i)
        {
            TinyPoint tinyPoint = default(TinyPoint);
            bool flag = false;
            TinyRect tinyRect = default(TinyRect);
            if ((m_moveObject[i].type == 1 || m_moveObject[i].type == 47 || m_moveObject[i].type == 48) && !m_blupiSuspend)
            {
                TinyRect src = default(TinyRect);
                src.Left = m_blupiPos.X + 20;
                src.Right = m_blupiPos.X + 60 - 20;
                src.Top = m_blupiPos.Y + 60 - 2;
                src.Bottom = m_blupiPos.Y + 60 - 1;
                tinyRect.Left = m_moveObject[i].posCurrent.X;
                tinyRect.Right = m_moveObject[i].posCurrent.X + 64;
                tinyRect.Top = m_moveObject[i].posCurrent.Y;
                tinyRect.Bottom = m_moveObject[i].posCurrent.Y + 16;
                TinyRect dst;
                flag = Misc.IntersectRect(out dst, tinyRect, src);
                tinyPoint = m_moveObject[i].posCurrent;
            }
            TinyPoint end;
            if (m_blupiFocus && !m_blupiHide && m_moveObject[i].type == 97)
            {
                end = m_moveObject[i].posCurrent;
                if (end.X < m_blupiPos.X)
                {
                    end.X++;
                }
                if (end.X > m_blupiPos.X)
                {
                    end.X--;
                }
                if (end.Y < m_blupiPos.Y)
                {
                    end.Y++;
                }
                if (end.Y > m_blupiPos.Y)
                {
                    end.Y--;
                }
                tinyRect.Left = end.X + 10;
                tinyRect.Right = end.X + 60 - 10;
                tinyRect.Top = end.Y + 10;
                tinyRect.Bottom = end.Y + 60 - 10;
                if (TestPath(tinyRect, m_moveObject[i].posCurrent, ref end))
                {
                    m_moveObject[i].posCurrent = end;
                    m_moveObject[i].posStart = end;
                    m_moveObject[i].posEnd = end;
                }
                else
                {
                    ObjectDelete(m_moveObject[i].posCurrent, m_moveObject[i].type);
                    end.X -= 34;
                    end.Y -= 34;
                    ObjectStart(end, 9, 0);
                    PlaySound(10, end);
                    m_decorAction = 1;
                    m_decorPhase = 0;
                }
            }
            if (m_moveObject[i].posStart.X != m_moveObject[i].posEnd.X || m_moveObject[i].posStart.Y != m_moveObject[i].posEnd.Y)
            {
                if (m_moveObject[i].step == 1)
                {
                    if (m_moveObject[i].time < m_moveObject[i].timeStopStart)
                    {
                        m_moveObject[i].time++;
                    }
                    else
                    {
                        m_moveObject[i].step = 2;
                        m_moveObject[i].time = 0;
                    }
                }
                else if (m_moveObject[i].step == 2)
                {
                    if (m_moveObject[i].posCurrent.X != m_moveObject[i].posEnd.X || m_moveObject[i].posCurrent.Y != m_moveObject[i].posEnd.Y)
                    {
                        m_moveObject[i].time++;
                        if (m_moveObject[i].stepAdvance != 0)
                        {
                            m_moveObject[i].posCurrent.X = (m_moveObject[i].posEnd.X - m_moveObject[i].posStart.X) * m_moveObject[i].time / m_moveObject[i].stepAdvance + m_moveObject[i].posStart.X;
                            m_moveObject[i].posCurrent.Y = (m_moveObject[i].posEnd.Y - m_moveObject[i].posStart.Y) * m_moveObject[i].time / m_moveObject[i].stepAdvance + m_moveObject[i].posStart.Y;
                        }
                    }
                    else if (m_moveObject[i].type == 15 || m_moveObject[i].type == 23)
                    {
                        m_moveObject[i].type = 0;
                    }
                    else if (m_moveObject[i].type == 34)
                    {
                        m_moveObject[i].posStart = m_moveObject[i].posCurrent;
                        m_moveObject[i].posEnd = m_moveObject[i].posCurrent;
                        m_moveObject[i].step = 3;
                        m_moveObject[i].time = 0;
                    }
                    else
                    {
                        m_moveObject[i].step = 3;
                        m_moveObject[i].time = 0;
                    }
                }
                else if (m_moveObject[i].step == 3)
                {
                    if (m_moveObject[i].time < m_moveObject[i].timeStopEnd)
                    {
                        m_moveObject[i].time++;
                    }
                    else
                    {
                        m_moveObject[i].step = 4;
                        m_moveObject[i].time = 0;
                    }
                }
                else if (m_moveObject[i].step == 4)
                {
                    if (m_moveObject[i].posCurrent.X != m_moveObject[i].posStart.X || m_moveObject[i].posCurrent.Y != m_moveObject[i].posStart.Y)
                    {
                        m_moveObject[i].time++;
                        if (m_moveObject[i].stepRecede != 0)
                        {
                            m_moveObject[i].posCurrent.X = (m_moveObject[i].posStart.X - m_moveObject[i].posEnd.X) * m_moveObject[i].time / m_moveObject[i].stepRecede + m_moveObject[i].posEnd.X;
                            m_moveObject[i].posCurrent.Y = (m_moveObject[i].posStart.Y - m_moveObject[i].posEnd.Y) * m_moveObject[i].time / m_moveObject[i].stepRecede + m_moveObject[i].posEnd.Y;
                        }
                    }
                    else
                    {
                        m_moveObject[i].step = 1;
                        m_moveObject[i].time = 0;
                    }
                }
            }
            if (m_moveObject[i].type == 22 && m_moveObject[i].step == 3)
            {
                m_moveObject[i].type = 0;
            }
            end = m_moveObject[i].posCurrent;
            if (m_moveObject[i].type == 1 || m_moveObject[i].type == 47 || m_moveObject[i].type == 48)
            {
                end.Y -= 64;
            }
            end.X = (end.X + 32) / 64;
            end.Y = (end.Y + 32) / 64;
            SetMoveTraj(end);
            if (flag)
            {
                m_blupiVector.X = m_moveObject[i].posCurrent.X - tinyPoint.X;
                m_blupiVector.Y = m_moveObject[i].posCurrent.Y - (m_blupiPos.Y + 60 - BLUPIFLOOR);
                if (m_moveObject[i].type == 47)
                {
                    m_blupiVector.X += 2;
                }
                if (m_moveObject[i].type == 48)
                {
                    m_blupiVector.X -= 2;
                }
                if (m_blupiTimeNoAsc == 0)
                {
                    m_blupiTransport = i;
                }
            }
        }

        private void MoveObjectStepIcon(int i)
        {
            if (m_moveObject[i].type == 47)
            {
                m_moveObject[i].icon = Tables.table_chenille[m_moveObject[i].phase / 1 % 6];
            }
            if (m_moveObject[i].type == 48)
            {
                m_moveObject[i].icon = Tables.table_chenillei[m_moveObject[i].phase / 1 % 6];
            }
            if (m_moveObject[i].type == 2)
            {
                m_moveObject[i].icon = 12 + m_moveObject[i].phase / 2 % 9;
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 3)
            {
                m_moveObject[i].icon = 48 + m_moveObject[i].phase / 2 % 9;
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 16)
            {
                m_moveObject[i].icon = 69 + m_moveObject[i].phase / 1 % 9;
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 96)
            {
                m_moveObject[i].icon = Tables.table_follow1[m_moveObject[i].phase / 1 % 26];
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 97)
            {
                m_moveObject[i].icon = Tables.table_follow2[m_moveObject[i].phase / 1 % 5];
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 200)
            {
                m_moveObject[i].icon = 257 + m_moveObject[i].phase / 1 % 6;
                m_moveObject[i].channel = 2;
            }
            if (m_moveObject[i].type == 201)
            {
                m_moveObject[i].icon = 257 + m_moveObject[i].phase / 1 % 6;
                m_moveObject[i].channel = 11;
            }
            if (m_moveObject[i].type == 202)
            {
                m_moveObject[i].icon = 257 + m_moveObject[i].phase / 1 % 6;
                m_moveObject[i].channel = 12;
            }
            if (m_moveObject[i].type == 203)
            {
                m_moveObject[i].icon = 257 + m_moveObject[i].phase / 1 % 6;
                m_moveObject[i].channel = 13;
            }
            if (m_moveObject[i].type == 55)
            {
                m_moveObject[i].icon = 252;
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 56)
            {
                m_moveObject[i].icon = Tables.table_dynamitef[m_moveObject[i].phase / 1 % 100];
                m_moveObject[i].channel = 10;
                if (m_moveObject[i].phase == 50)
                {
                    DynamiteStart(i, 0, 0);
                }
                if (m_moveObject[i].phase == 53)
                {
                    DynamiteStart(i, -100, 8);
                }
                if (m_moveObject[i].phase == 55)
                {
                    DynamiteStart(i, 80, 10);
                }
                if (m_moveObject[i].phase == 56)
                {
                    DynamiteStart(i, -15, -100);
                }
                if (m_moveObject[i].phase == 59)
                {
                    DynamiteStart(i, 20, 70);
                }
                if (m_moveObject[i].phase == 62)
                {
                    DynamiteStart(i, 30, -50);
                }
                if (m_moveObject[i].phase == 64)
                {
                    DynamiteStart(i, -40, 30);
                }
                if (m_moveObject[i].phase == 67)
                {
                    DynamiteStart(i, -180, 10);
                }
                if (m_moveObject[i].phase == 69)
                {
                    DynamiteStart(i, 200, -10);
                }
                if (m_moveObject[i].phase >= 70)
                {
                    m_moveObject[i].type = 0;
                }
            }
            if (m_moveObject[i].type == 5)
            {
                if (m_moveObject[i].phase / 3 % 22 < 11)
                {
                    m_moveObject[i].icon = m_moveObject[i].phase / 3 % 11;
                }
                else
                {
                    m_moveObject[i].icon = 11 - m_moveObject[i].phase / 3 % 11;
                }
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 6)
            {
                m_moveObject[i].icon = 21 + m_moveObject[i].phase / 4 % 8;
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 7)
            {
                m_moveObject[i].icon = 29 + m_moveObject[i].phase / 3 % 8;
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 21)
            {
                m_moveObject[i].icon = Tables.table_cle[m_moveObject[i].phase / 3 % 12];
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 49)
            {
                m_moveObject[i].icon = Tables.table_cle1[m_moveObject[i].phase / 3 % 12];
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 50)
            {
                m_moveObject[i].icon = Tables.table_cle2[m_moveObject[i].phase / 3 % 12];
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 51)
            {
                m_moveObject[i].icon = Tables.table_cle3[m_moveObject[i].phase / 3 % 12];
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 24)
            {
                m_moveObject[i].icon = Tables.table_skate[m_moveObject[i].phase / 1 % 34];
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 25)
            {
                m_moveObject[i].icon = Tables.table_shield[m_moveObject[i].phase / 2 % 16];
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 26)
            {
                m_moveObject[i].icon = Tables.table_power[m_moveObject[i].phase / 2 % 8];
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 40)
            {
                m_moveObject[i].icon = Tables.table_invert[m_moveObject[i].phase / 2 % 20];
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 31)
            {
                m_moveObject[i].icon = Tables.table_charge[m_moveObject[i].phase / 2 % 6];
                m_moveObject[i].channel = 1;
            }
            if (m_moveObject[i].type == 27)
            {
                m_moveObject[i].icon = Tables.table_magictrack[m_moveObject[i].phase / 1 % 24];
                m_moveObject[i].channel = 10;
                if (m_moveObject[i].phase >= 24)
                {
                    m_moveObject[i].type = 0;
                }
            }
            if (m_moveObject[i].type == 57)
            {
                m_moveObject[i].icon = Tables.table_shieldtrack[m_moveObject[i].phase / 1 % 20];
                m_moveObject[i].channel = 10;
                if (m_moveObject[i].phase >= 20)
                {
                    m_moveObject[i].type = 0;
                }
            }
            if (m_moveObject[i].type == 39)
            {
                m_moveObject[i].icon = Tables.table_tresortrack[m_moveObject[i].phase / 1 % 11];
                m_moveObject[i].channel = 10;
                if (m_moveObject[i].phase >= 11)
                {
                    m_moveObject[i].type = 0;
                }
            }
            if (m_moveObject[i].type == 58 && m_moveObject[i].phase >= 20)
            {
                m_moveObject[i].type = 0;
            }
            if (m_moveObject[i].type == 8)
            {
                if (m_moveObject[i].phase >= Tables.table_explo1.Length)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_explo1[m_moveObject[i].phase];
                    m_moveObject[i].channel = 9;
                }
            }
            if (m_moveObject[i].type == 9)
            {
                if (m_moveObject[i].phase >= 20)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_explo2[m_moveObject[i].phase % 20];
                    m_moveObject[i].channel = 9;
                }
            }
            if (m_moveObject[i].type == 10)
            {
                if (m_moveObject[i].phase >= 20)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_explo3[m_moveObject[i].phase / 1 % 20];
                    m_moveObject[i].channel = 9;
                }
            }
            if (m_moveObject[i].type == 11)
            {
                if (m_moveObject[i].phase >= 9)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_explo4[m_moveObject[i].phase / 1 % 9];
                    m_moveObject[i].channel = 9;
                }
            }
            if (m_moveObject[i].type == 90)
            {
                if (m_moveObject[i].phase >= 12)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_explo5[m_moveObject[i].phase / 1 % 12];
                    m_moveObject[i].channel = 9;
                }
            }
            if (m_moveObject[i].type == 91)
            {
                if (m_moveObject[i].phase >= 6)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_explo6[m_moveObject[i].phase / 1 % 6];
                    m_moveObject[i].channel = 9;
                }
            }
            if (m_moveObject[i].type == 92)
            {
                if (m_moveObject[i].phase >= 128)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_explo7[m_moveObject[i].phase / 1 % 128];
                    m_moveObject[i].channel = 9;
                }
            }
            if (m_moveObject[i].type == 93)
            {
                if (m_moveObject[i].phase >= 5)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_explo8[m_moveObject[i].phase / 1 % 5];
                    m_moveObject[i].channel = 9;
                }
            }
            if (m_moveObject[i].type == 98)
            {
                if (m_moveObject[i].phase >= 10)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_sploutch1[m_moveObject[i].phase / 1 % 10];
                    m_moveObject[i].channel = 9;
                }
            }
            if (m_moveObject[i].type == 99)
            {
                if (m_moveObject[i].phase >= 13)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_sploutch2[m_moveObject[i].phase / 1 % 13];
                    m_moveObject[i].channel = 9;
                }
            }
            if (m_moveObject[i].type == 100)
            {
                if (m_moveObject[i].phase >= 18)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_sploutch3[m_moveObject[i].phase / 1 % 18];
                    m_moveObject[i].channel = 9;
                }
            }
            if (m_moveObject[i].type == 53)
            {
                if (m_moveObject[i].phase >= 90)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_tentacule[m_moveObject[i].phase / 2 % 45];
                    m_moveObject[i].channel = 9;
                }
            }
            TinyPoint pos = default(TinyPoint);
            if (m_moveObject[i].type == 52)
            {
                if (m_moveObject[i].phase == 0)
                {
                    PlaySound(72, m_moveObject[i].posStart);
                }
                if (m_moveObject[i].phase == 137)
                {
                    PlaySound(73, m_moveObject[i].posStart);
                }
                if (m_moveObject[i].phase >= 157)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_bridge[m_moveObject[i].phase / 1 % 157];
                    m_moveObject[i].channel = 1;
                    pos.X = m_moveObject[i].posStart.X / 64;
                    pos.Y = m_moveObject[i].posStart.Y / 64;
                    m_decor[pos.X, pos.Y].icon = m_moveObject[i].icon;
                }
            }
            if (m_moveObject[i].type == 36)
            {
                if (m_moveObject[i].phase >= 16)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_pollution[m_moveObject[i].phase / 2 % 8];
                    m_moveObject[i].channel = 10;
                }
            }
            if (m_moveObject[i].type == 41)
            {
                if (m_moveObject[i].phase >= 16)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_invertstart[m_moveObject[i].phase / 2 % 8];
                    m_moveObject[i].channel = 10;
                }
            }
            if (m_moveObject[i].type == 42)
            {
                if (m_moveObject[i].phase >= 16)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_invertstop[m_moveObject[i].phase / 2 % 8];
                    m_moveObject[i].channel = 10;
                }
            }
            if (m_moveObject[i].type == 14)
            {
                if (m_moveObject[i].phase >= 14)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_plouf[m_moveObject[i].phase / 2 % 7];
                    m_moveObject[i].channel = 1;
                }
            }
            if (m_moveObject[i].type == 35)
            {
                if (m_moveObject[i].phase >= 6)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_tiplouf[m_moveObject[i].phase / 2 % 7];
                    m_moveObject[i].channel = 1;
                }
            }
            if (m_moveObject[i].type == 15)
            {
                m_moveObject[i].icon = Tables.table_blup[m_moveObject[i].phase / 2 % 20];
                m_moveObject[i].channel = 1;
            }
            if (m_moveObject[i].type == 4)
            {
                if (m_moveObject[i].posStart.X > m_moveObject[i].posEnd.X)
                {
                    if (m_moveObject[i].step == 1)
                    {
                        m_moveObject[i].icon = Tables.table_bulldozer_turn2l[m_moveObject[i].time % 22];
                    }
                    if (m_moveObject[i].step == 3)
                    {
                        m_moveObject[i].icon = Tables.table_bulldozer_turn2r[m_moveObject[i].time % 22];
                    }
                    if (m_moveObject[i].step == 2)
                    {
                        m_moveObject[i].icon = Tables.table_bulldozer_left[m_moveObject[i].time % 8];
                    }
                    if (m_moveObject[i].step == 4)
                    {
                        m_moveObject[i].icon = Tables.table_bulldozer_right[m_moveObject[i].time % 8];
                    }
                }
                else
                {
                    if (m_moveObject[i].step == 1)
                    {
                        m_moveObject[i].icon = Tables.table_bulldozer_turn2r[m_moveObject[i].time % 22];
                    }
                    if (m_moveObject[i].step == 3)
                    {
                        m_moveObject[i].icon = Tables.table_bulldozer_turn2l[m_moveObject[i].time % 22];
                    }
                    if (m_moveObject[i].step == 2)
                    {
                        m_moveObject[i].icon = Tables.table_bulldozer_right[m_moveObject[i].time % 8];
                    }
                    if (m_moveObject[i].step == 4)
                    {
                        m_moveObject[i].icon = Tables.table_bulldozer_left[m_moveObject[i].time % 8];
                    }
                }
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 17)
            {
                if (m_moveObject[i].posStart.X > m_moveObject[i].posEnd.X)
                {
                    if (m_moveObject[i].step == 1)
                    {
                        m_moveObject[i].icon = Tables.table_poisson_turn2l[m_moveObject[i].time % 48];
                    }
                    if (m_moveObject[i].step == 3)
                    {
                        m_moveObject[i].icon = Tables.table_poisson_turn2r[m_moveObject[i].time % 48];
                    }
                    if (m_moveObject[i].step == 2)
                    {
                        m_moveObject[i].icon = Tables.table_poisson_left[m_moveObject[i].time % 8];
                    }
                    if (m_moveObject[i].step == 4)
                    {
                        m_moveObject[i].icon = Tables.table_poisson_right[m_moveObject[i].time % 8];
                    }
                }
                else
                {
                    if (m_moveObject[i].step == 1)
                    {
                        m_moveObject[i].icon = Tables.table_poisson_turn2r[m_moveObject[i].time % 48];
                    }
                    if (m_moveObject[i].step == 3)
                    {
                        m_moveObject[i].icon = Tables.table_poisson_turn2l[m_moveObject[i].time % 48];
                    }
                    if (m_moveObject[i].step == 2)
                    {
                        m_moveObject[i].icon = Tables.table_poisson_right[m_moveObject[i].time % 8];
                    }
                    if (m_moveObject[i].step == 4)
                    {
                        m_moveObject[i].icon = Tables.table_poisson_left[m_moveObject[i].time % 8];
                    }
                }
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 20)
            {
                if (m_moveObject[i].posStart.X > m_moveObject[i].posEnd.X)
                {
                    if (m_moveObject[i].step == 1)
                    {
                        m_moveObject[i].icon = Tables.table_oiseau_turn2l[m_moveObject[i].time % 10];
                    }
                    if (m_moveObject[i].step == 3)
                    {
                        m_moveObject[i].icon = Tables.table_oiseau_turn2r[m_moveObject[i].time % 10];
                    }
                    if (m_moveObject[i].step == 2)
                    {
                        m_moveObject[i].icon = Tables.table_oiseau_left[m_moveObject[i].time % 8];
                    }
                    if (m_moveObject[i].step == 4)
                    {
                        m_moveObject[i].icon = Tables.table_oiseau_right[m_moveObject[i].time % 8];
                    }
                }
                else
                {
                    if (m_moveObject[i].step == 1)
                    {
                        m_moveObject[i].icon = Tables.table_oiseau_turn2r[m_moveObject[i].time % 10];
                    }
                    if (m_moveObject[i].step == 3)
                    {
                        m_moveObject[i].icon = Tables.table_oiseau_turn2l[m_moveObject[i].time % 10];
                    }
                    if (m_moveObject[i].step == 2)
                    {
                        m_moveObject[i].icon = Tables.table_oiseau_right[m_moveObject[i].time % 8];
                    }
                    if (m_moveObject[i].step == 4)
                    {
                        m_moveObject[i].icon = Tables.table_oiseau_left[m_moveObject[i].time % 8];
                    }
                }
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 44)
            {
                if (m_moveObject[i].posStart.X > m_moveObject[i].posEnd.X)
                {
                    if (m_moveObject[i].step == 1)
                    {
                        m_moveObject[i].icon = Tables.table_guepe_turn2l[m_moveObject[i].time % 5];
                    }
                    if (m_moveObject[i].step == 3)
                    {
                        m_moveObject[i].icon = Tables.table_guepe_turn2r[m_moveObject[i].time % 5];
                    }
                    if (m_moveObject[i].step == 2)
                    {
                        m_moveObject[i].icon = Tables.table_guepe_left[m_moveObject[i].time % 6];
                    }
                    if (m_moveObject[i].step == 4)
                    {
                        m_moveObject[i].icon = Tables.table_guepe_right[m_moveObject[i].time % 6];
                    }
                }
                else
                {
                    if (m_moveObject[i].step == 1)
                    {
                        m_moveObject[i].icon = Tables.table_guepe_turn2r[m_moveObject[i].time % 5];
                    }
                    if (m_moveObject[i].step == 3)
                    {
                        m_moveObject[i].icon = Tables.table_guepe_turn2l[m_moveObject[i].time % 5];
                    }
                    if (m_moveObject[i].step == 2)
                    {
                        m_moveObject[i].icon = Tables.table_guepe_right[m_moveObject[i].time % 6];
                    }
                    if (m_moveObject[i].step == 4)
                    {
                        m_moveObject[i].icon = Tables.table_guepe_left[m_moveObject[i].time % 6];
                    }
                }
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 54)
            {
                if (m_moveObject[i].posStart.X > m_moveObject[i].posEnd.X)
                {
                    if (m_moveObject[i].step == 1)
                    {
                        m_moveObject[i].icon = Tables.table_creature_turn2[m_moveObject[i].time % 152];
                    }
                    if (m_moveObject[i].step == 3)
                    {
                        m_moveObject[i].icon = Tables.table_creature_turn2[m_moveObject[i].time % 152];
                    }
                    if (m_moveObject[i].step == 2)
                    {
                        m_moveObject[i].icon = Tables.table_creature_left[m_moveObject[i].time % 8];
                    }
                    if (m_moveObject[i].step == 4)
                    {
                        m_moveObject[i].icon = Tables.table_creature_right[m_moveObject[i].time % 8];
                    }
                }
                else
                {
                    if (m_moveObject[i].step == 1)
                    {
                        m_moveObject[i].icon = Tables.table_creature_turn2[m_moveObject[i].time % 152];
                    }
                    if (m_moveObject[i].step == 3)
                    {
                        m_moveObject[i].icon = Tables.table_creature_turn2[m_moveObject[i].time % 152];
                    }
                    if (m_moveObject[i].step == 2)
                    {
                        m_moveObject[i].icon = Tables.table_creature_right[m_moveObject[i].time % 8];
                    }
                    if (m_moveObject[i].step == 4)
                    {
                        m_moveObject[i].icon = Tables.table_creature_left[m_moveObject[i].time % 8];
                    }
                }
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 32)
            {
                if (m_moveObject[i].posStart.X > m_moveObject[i].posEnd.X)
                {
                    if (m_moveObject[i].step == 1)
                    {
                        m_moveObject[i].icon = Tables.table_blupih_turn2l[m_moveObject[i].time % 26];
                    }
                    if (m_moveObject[i].step == 3)
                    {
                        m_moveObject[i].icon = Tables.table_blupih_turn2r[m_moveObject[i].time % 26];
                    }
                    if (m_moveObject[i].step == 2)
                    {
                        m_moveObject[i].icon = Tables.table_blupih_left[m_moveObject[i].time % 8];
                    }
                    if (m_moveObject[i].step == 4)
                    {
                        m_moveObject[i].icon = Tables.table_blupih_right[m_moveObject[i].time % 8];
                    }
                }
                else
                {
                    if (m_moveObject[i].step == 1)
                    {
                        m_moveObject[i].icon = Tables.table_blupih_turn2r[m_moveObject[i].time % 26];
                    }
                    if (m_moveObject[i].step == 3)
                    {
                        m_moveObject[i].icon = Tables.table_blupih_turn2l[m_moveObject[i].time % 26];
                    }
                    if (m_moveObject[i].step == 2)
                    {
                        m_moveObject[i].icon = Tables.table_blupih_right[m_moveObject[i].time % 8];
                    }
                    if (m_moveObject[i].step == 4)
                    {
                        m_moveObject[i].icon = Tables.table_blupih_left[m_moveObject[i].time % 8];
                    }
                }
                if ((m_moveObject[i].step == 1 || m_moveObject[i].step == 3) && m_moveObject[i].time == 21)
                {
                    pos.X = m_moveObject[i].posCurrent.X;
                    pos.Y = m_moveObject[i].posCurrent.Y + 40;
                    if (ObjectStart(pos, 23, 55) != -1)
                    {
                        PlaySound(52, pos);
                    }
                }
            }
            if (m_moveObject[i].type == 33)
            {
                if (m_moveObject[i].posStart.X > m_moveObject[i].posEnd.X)
                {
                    if (m_moveObject[i].step == 1)
                    {
                        m_moveObject[i].icon = Tables.table_blupit_turn2l[m_moveObject[i].time % 24];
                    }
                    if (m_moveObject[i].step == 3)
                    {
                        m_moveObject[i].icon = Tables.table_blupit_turn2r[m_moveObject[i].time % 24];
                    }
                    if (m_moveObject[i].step == 2)
                    {
                        m_moveObject[i].icon = Tables.table_blupit_left[m_moveObject[i].time % 8];
                    }
                    if (m_moveObject[i].step == 4)
                    {
                        m_moveObject[i].icon = Tables.table_blupit_right[m_moveObject[i].time % 8];
                    }
                }
                else
                {
                    if (m_moveObject[i].step == 1)
                    {
                        m_moveObject[i].icon = Tables.table_blupit_turn2r[m_moveObject[i].time % 24];
                    }
                    if (m_moveObject[i].step == 3)
                    {
                        m_moveObject[i].icon = Tables.table_blupit_turn2l[m_moveObject[i].time % 24];
                    }
                    if (m_moveObject[i].step == 2)
                    {
                        m_moveObject[i].icon = Tables.table_blupit_right[m_moveObject[i].time % 8];
                    }
                    if (m_moveObject[i].step == 4)
                    {
                        m_moveObject[i].icon = Tables.table_blupit_left[m_moveObject[i].time % 8];
                    }
                }
                if ((m_moveObject[i].step == 1 || m_moveObject[i].step == 3) && m_moveObject[i].time == 3)
                {
                    int speed;
                    if ((m_moveObject[i].posStart.X < m_moveObject[i].posEnd.X && m_moveObject[i].step == 1) || (m_moveObject[i].posStart.X > m_moveObject[i].posEnd.X && m_moveObject[i].step == 3))
                    {
                        pos.X = m_moveObject[i].posCurrent.X - 30;
                        pos.Y = m_moveObject[i].posCurrent.Y + BLUPIOFFY;
                        speed = -5;
                    }
                    else
                    {
                        pos.X = m_moveObject[i].posCurrent.X + 30;
                        pos.Y = m_moveObject[i].posCurrent.Y + BLUPIOFFY;
                        speed = 5;
                    }
                    if (ObjectStart(pos, 23, speed) != -1)
                    {
                        PlaySound(52, pos);
                    }
                }
                if ((m_moveObject[i].step == 1 || m_moveObject[i].step == 3) && m_moveObject[i].time == 21)
                {
                    int speed;
                    if ((m_moveObject[i].posStart.X < m_moveObject[i].posEnd.X && m_moveObject[i].step == 1) || (m_moveObject[i].posStart.X > m_moveObject[i].posEnd.X && m_moveObject[i].step == 3))
                    {
                        pos.X = m_moveObject[i].posCurrent.X + 30;
                        pos.Y = m_moveObject[i].posCurrent.Y + BLUPIOFFY;
                        speed = 5;
                    }
                    else
                    {
                        pos.X = m_moveObject[i].posCurrent.X - 30;
                        pos.Y = m_moveObject[i].posCurrent.Y + BLUPIOFFY;
                        speed = -5;
                    }
                    if (ObjectStart(pos, 23, speed) != -1)
                    {
                        PlaySound(52, pos);
                    }
                }
            }
            if (m_moveObject[i].type == 34)
            {
                m_moveObject[i].icon = Tables.table_glu[m_moveObject[i].phase / 1 % 25];
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 37)
            {
                if (m_moveObject[i].phase >= 70)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_clear[m_moveObject[i].phase / 1 % 70];
                    m_moveObject[i].channel = 10;
                }
            }
            if (m_moveObject[i].type == 38)
            {
                if (m_moveObject[i].phase >= 90)
                {
                    m_moveObject[i].type = 0;
                }
                else
                {
                    m_moveObject[i].icon = Tables.table_electro[m_moveObject[i].phase / 1 % 90];
                    if (m_moveObject[i].phase < 30)
                    {
                        m_moveObject[i].channel = 12;
                    }
                    else
                    {
                        m_moveObject[i].channel = 10;
                    }
                }
            }
            if (m_moveObject[i].type == 13)
            {
                m_moveObject[i].icon = 68;
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 46)
            {
                m_moveObject[i].icon = 208;
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 19)
            {
                m_moveObject[i].icon = 89;
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 28)
            {
                m_moveObject[i].icon = 167;
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 23)
            {
                m_moveObject[i].icon = 176;
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 29)
            {
                m_moveObject[i].icon = 177;
                m_moveObject[i].channel = 10;
            }
            if (m_moveObject[i].type == 30)
            {
                m_moveObject[i].icon = 178;
                m_moveObject[i].channel = 10;
            }
            m_moveObject[i].phase++;
            if (m_moveObject[i].phase > 32700)
            {
                m_moveObject[i].phase = 0;
            }
        }

        private void DynamiteStart(int i, int dx, int dy)
        {
            TinyPoint posStart = m_moveObject[i].posStart;
            posStart.X -= 34;
            posStart.Y -= 34;
            posStart.X += dx;
            posStart.Y -= dy;
            ObjectStart(posStart, 8, 0);
            if (dx == 0 && dy == 0)
            {
                PlaySound(10, posStart);
                m_decorAction = 1;
                m_decorPhase = 0;
            }
            TinyRect src = default(TinyRect);
            src.Left = posStart.X;
            src.Right = posStart.X + 128;
            src.Top = posStart.Y;
            src.Bottom = posStart.Y + 128;
            TinyPoint tinyPoint = default(TinyPoint);
            tinyPoint.Y = posStart.Y / 64;
            TinyPoint pos = default(TinyPoint);
            for (int j = 0; j < 2; j++)
            {
                tinyPoint.X = posStart.X / 64;
                for (int k = 0; k < 2; k++)
                {
                    if (tinyPoint.X >= 0 && tinyPoint.X < 100 && tinyPoint.Y >= 0 && tinyPoint.Y < 100)
                    {
                        int icon = m_decor[tinyPoint.X, tinyPoint.Y].icon;
                        if (icon == 378 || icon == 379 || icon == 404 || icon == 410)
                        {
                            pos.X = tinyPoint.X * 64;
                            pos.Y = tinyPoint.Y * 64;
                            ModifDecor(pos, -1);
                        }
                    }
                    tinyPoint.X++;
                }
                tinyPoint.Y++;
            }
            TinyRect src2 = default(TinyRect);
            for (i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type == 2 || m_moveObject[i].type == 3 || m_moveObject[i].type == 96 || m_moveObject[i].type == 97 || m_moveObject[i].type == 4 || m_moveObject[i].type == 6 || m_moveObject[i].type == 12 || m_moveObject[i].type == 13 || m_moveObject[i].type == 16 || m_moveObject[i].type == 17 || m_moveObject[i].type == 18 || m_moveObject[i].type == 19 || m_moveObject[i].type == 20 || m_moveObject[i].type == 24 || m_moveObject[i].type == 25 || m_moveObject[i].type == 26 || m_moveObject[i].type == 28 || m_moveObject[i].type == 30 || m_moveObject[i].type == 32 || m_moveObject[i].type == 33 || m_moveObject[i].type == 34 || m_moveObject[i].type == 40 || m_moveObject[i].type == 44 || m_moveObject[i].type == 46 || m_moveObject[i].type == 52 || m_moveObject[i].type == 54 || m_moveObject[i].type == 200 || m_moveObject[i].type == 201 || m_moveObject[i].type == 202 || m_moveObject[i].type == 203)
                {
                    src2.Left = m_moveObject[i].posCurrent.X;
                    src2.Right = m_moveObject[i].posCurrent.X + 60;
                    src2.Top = m_moveObject[i].posCurrent.Y;
                    src2.Bottom = m_moveObject[i].posCurrent.Y + 60;
                    TinyRect dst;
                    if (Misc.IntersectRect(out dst, src2, src))
                    {
                        if (m_moveObject[i].type == 12)
                        {
                            SearchLinkCaisse(i, true);
                            for (int l = 0; l < m_nbLinkCaisse; l++)
                            {
                                int channel = m_moveObject[m_linkCaisse[l]].channel;
                                int icon2 = m_moveObject[m_linkCaisse[l]].icon;
                                TinyPoint posCurrent = m_moveObject[m_linkCaisse[l]].posCurrent;
                                double num = m_random.Next(7, 23);
                                if (m_random.Next(0, 100) % 2 == 0)
                                {
                                    num = 0.0 - num;
                                }
                                ByeByeAdd(channel, icon2, posCurrent, num, 1.0);
                                m_moveObject[m_linkCaisse[l]].type = 0;
                            }
                            ObjectDelete(m_moveObject[i].posCurrent, m_moveObject[i].type);
                            UpdateCaisse();
                        }
                        else
                        {
                            ObjectDelete(m_moveObject[i].posCurrent, m_moveObject[i].type);
                        }
                    }
                }
            }
            if (m_blupiFocus && !m_blupiShield && !m_blupiHide && !m_bSuperBlupi && m_blupiPos.X > posStart.X - 30 && m_blupiPos.X < posStart.X + 30 + 64 && m_blupiPos.Y > posStart.Y - 30 && m_blupiPos.Y < posStart.Y + 30 + 64)
            {
                BlupiDead(11, -1);
                m_blupiAir = true;
            }
        }

        private int AscenseurDetect(TinyRect rect, TinyPoint oldpos, TinyPoint newpos)
        {
            if (m_blupiTimeNoAsc != 0)
            {
                return -1;
            }
            int num = newpos.Y - oldpos.Y;
            int num2 = ((num >= 0) ? 30 : (-30));
            num = Math.Abs(num);
            TinyRect src = default(TinyRect);
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type != 1 && m_moveObject[i].type != 47 && m_moveObject[i].type != 48)
                {
                    continue;
                }
                src.Left = m_moveObject[i].posCurrent.X;
                src.Right = m_moveObject[i].posCurrent.X + 64;
                src.Top = m_moveObject[i].posCurrent.Y;
                src.Bottom = m_moveObject[i].posCurrent.Y + 16;
                TinyRect dst;
                if (num < 30)
                {
                    if (Misc.IntersectRect(out dst, src, rect))
                    {
                        return i;
                    }
                    continue;
                }
                TinyRect src2 = rect;
                src2.Top -= num / 30 * num2;
                src2.Bottom -= num / 30 * num2;
                for (int j = 0; j <= num / 30; j++)
                {
                    if (Misc.IntersectRect(out dst, src, src2))
                    {
                        return i;
                    }
                    src2.Top += num2;
                    src2.Bottom += num2;
                }
            }
            return -1;
        }

        private void AscenseurVertigo(int i, out bool bVertigoLeft, out bool bVertigoRight)
        {
            bVertigoLeft = false;
            bVertigoRight = false;
            if (m_blupiPos.X + 20 + 4 < m_moveObject[i].posCurrent.X)
            {
                bVertigoLeft = true;
            }
            if (m_blupiPos.X + 60 - 20 - 4 > m_moveObject[i].posCurrent.X + 64)
            {
                bVertigoRight = true;
            }
            if (AscenseurShift(i))
            {
                if (bVertigoLeft)
                {
                    bVertigoLeft = false;
                    bVertigoRight = true;
                    m_blupiTimeNoAsc = 10;
                }
                else if (bVertigoRight)
                {
                    bVertigoRight = false;
                    bVertigoLeft = true;
                    m_blupiTimeNoAsc = 10;
                }
            }
        }

        private bool AscenseurShift(int i)
        {
            if (i == -1)
            {
                return false;
            }
            if (m_moveObject[i].icon >= 311)
            {
                return m_moveObject[i].icon <= 316;
            }
            return false;
        }

        private void AscenseurSynchro(int i)
        {
            for (i = 0; i < MAXMOVEOBJECT; i++)
            {
                m_moveObject[i].posCurrent = m_moveObject[i].posStart;
                m_moveObject[i].step = 1;
                m_moveObject[i].time = 0;
                m_moveObject[i].phase = 0;
            }
        }

        private void UpdateCaisse()
        {
            m_nbRankCaisse = 0;
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type == 12)
                {
                    m_rankCaisse[m_nbRankCaisse++] = i;
                }
            }
        }

        private bool TestPushCaisse(int i, TinyPoint pos, bool bPop)
        {
            TinyPoint move = default(TinyPoint);
            move.X = pos.X - m_moveObject[i].posCurrent.X;
            move.Y = 0;
            SearchLinkCaisse(i, bPop);
            int y = m_moveObject[i].posCurrent.Y;
            for (int j = 0; j < m_nbLinkCaisse; j++)
            {
                i = m_linkCaisse[j];
                if (!TestPushOneCaisse(i, move, y))
                {
                    return false;
                }
            }
            for (int j = 0; j < m_nbLinkCaisse; j++)
            {
                i = m_linkCaisse[j];
                m_moveObject[i].posCurrent.X += move.X;
                m_moveObject[i].posStart.X += move.X;
                m_moveObject[i].posEnd.X += move.X;
            }
            return true;
        }

        private bool TestPushOneCaisse(int i, TinyPoint move, int b)
        {
            TinyRect rect = default(TinyRect);
            int num = (rect.Left = m_moveObject[i].posCurrent.X + move.X);
            rect.Right = num + 64;
            rect.Top = m_moveObject[i].posCurrent.Y;
            rect.Bottom = m_moveObject[i].posCurrent.Y + 64;
            if (DecorDetect(rect, false))
            {
                return false;
            }
            if (m_moveObject[i].posCurrent.Y != b)
            {
                return true;
            }
            rect.Left = num;
            rect.Right = num + 20;
            rect.Top = m_moveObject[i].posCurrent.Y + 64;
            rect.Bottom = m_moveObject[i].posCurrent.Y + 64 + 2;
            if (!DecorDetect(rect))
            {
                return false;
            }
            rect.Left = num + 64 - 20;
            rect.Right = num + 64;
            rect.Top = m_moveObject[i].posCurrent.Y + 64;
            rect.Bottom = m_moveObject[i].posCurrent.Y + 64 + 2;
            if (!DecorDetect(rect))
            {
                return false;
            }
            return true;
        }

        private void SearchLinkCaisse(int rank, bool bPop)
        {
            m_nbLinkCaisse = 0;
            AddLinkCaisse(rank);
            TinyPoint posCurrent = m_moveObject[rank].posCurrent;
            bool flag;
            TinyRect src = default(TinyRect);
            TinyRect src2 = default(TinyRect);
            do
            {
                flag = false;
                for (int i = 0; i < m_nbLinkCaisse; i++)
                {
                    int num = m_linkCaisse[i];
                    if (m_moveObject[num].posCurrent.Y > posCurrent.Y || (bPop && (m_moveObject[num].posCurrent.X < posCurrent.X - 32 || m_moveObject[num].posCurrent.X > posCurrent.X + 32)))
                    {
                        continue;
                    }
                    src.Left = m_moveObject[num].posCurrent.X - 1;
                    src.Top = m_moveObject[num].posCurrent.Y - 1;
                    src.Right = src.Left + 64 + 1;
                    src.Bottom = src.Top + 64 + 1;
                    for (int j = 0; j < m_nbRankCaisse; j++)
                    {
                        int num2 = m_rankCaisse[j];
                        if (num2 != num && m_moveObject[num2].posCurrent.Y <= posCurrent.Y && (!bPop || (m_moveObject[num2].posCurrent.X >= posCurrent.X - 32 && m_moveObject[num2].posCurrent.X <= posCurrent.X + 32)))
                        {
                            src2.Left = m_moveObject[num2].posCurrent.X - 1;
                            src2.Top = m_moveObject[num2].posCurrent.Y - 1;
                            src2.Right = src2.Left + 64 + 1;
                            src2.Bottom = src2.Top + 64 + 1;
                            TinyRect dst;
                            if (Misc.IntersectRect(out dst, src2, src) && AddLinkCaisse(num2))
                            {
                                flag = true;
                            }
                        }
                    }
                }
            }
            while (flag);
        }

        private bool AddLinkCaisse(int rank)
        {
            for (int i = 0; i < m_nbLinkCaisse; i++)
            {
                if (m_linkCaisse[i] == rank)
                {
                    return false;
                }
            }
            m_linkCaisse[m_nbLinkCaisse] = rank;
            m_nbLinkCaisse++;
            return true;
        }

        private int CaisseInFront()
        {
            TinyPoint tinyPoint = default(TinyPoint);
            if (m_blupiDir == 1)
            {
                tinyPoint.X = m_blupiPos.X + 16 - 32;
                tinyPoint.Y = m_blupiPos.Y;
            }
            else
            {
                tinyPoint.X = m_blupiPos.X + 60 - 16 + 32;
                tinyPoint.Y = m_blupiPos.Y;
            }
            for (int i = 0; i < m_nbRankCaisse; i++)
            {
                int num = m_rankCaisse[i];
                if (tinyPoint.X > m_moveObject[num].posCurrent.X && tinyPoint.X < m_moveObject[num].posCurrent.X + 64 && tinyPoint.Y > m_moveObject[num].posCurrent.Y && tinyPoint.Y < m_moveObject[num].posCurrent.Y + 64)
                {
                    return num;
                }
            }
            return -1;
        }

        private int CaisseGetMove(int max)
        {
            max -= (m_nbLinkCaisse - 1) / 2;
            if (max < 1)
            {
                max = 1;
            }
            if (m_blupiPower)
            {
                max *= 2;
            }
            if (m_blupiPhase < 20)
            {
                max = max * m_blupiPhase / 20;
                if (max == 0)
                {
                    max++;
                }
            }
            return max;
        }

        private int MockeryDetect(TinyPoint pos)
        {
            if (m_blupiTimeMockery > 0)
            {
                return 0;
            }
            if (m_blupiAir)
            {
                TinyPoint tinyPoint = default(TinyPoint);
                tinyPoint.X = pos.X + 30;
                tinyPoint.Y = pos.Y + 30 + 64;
                if (tinyPoint.X >= 0 && tinyPoint.X < 6400 && tinyPoint.Y >= 0 && tinyPoint.Y < 6400)
                {
                    int icon = m_decor[tinyPoint.X / 64, tinyPoint.Y / 64].icon;
                    if (icon == 68 || icon == 317)
                    {
                        return 64;
                    }
                }
                tinyPoint.Y += 64;
                if (tinyPoint.X >= 0 && tinyPoint.X < 6400 && tinyPoint.Y >= 0 && tinyPoint.Y < 6400)
                {
                    int icon = m_decor[tinyPoint.X / 64, tinyPoint.Y / 64].icon;
                    if (icon == 68 || icon == 317)
                    {
                        return 64;
                    }
                }
            }
            TinyRect src = default(TinyRect);
            src.Left = pos.X;
            src.Right = pos.X + 60;
            src.Top = pos.Y + 11;
            src.Bottom = pos.Y + 60;
            if (m_blupiAir)
            {
                src.Bottom += 90;
            }
            TinyRect src2 = default(TinyRect);
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type != 2 && m_moveObject[i].type != 16 && m_moveObject[i].type != 96 && m_moveObject[i].type != 97 && m_moveObject[i].type != 4 && m_moveObject[i].type != 20 && m_moveObject[i].type != 44 && m_moveObject[i].type != 54 && m_moveObject[i].type != 23 && m_moveObject[i].type != 32 && m_moveObject[i].type != 33)
                {
                    continue;
                }
                src2.Left = m_moveObject[i].posCurrent.X;
                src2.Right = m_moveObject[i].posCurrent.X + 60;
                src2.Top = m_moveObject[i].posCurrent.Y + 36;
                src2.Bottom = m_moveObject[i].posCurrent.Y + 60;
                TinyRect dst;
                if (!Misc.IntersectRect(out dst, src2, src))
                {
                    continue;
                }
                if (m_moveObject[i].type == 54)
                {
                    return 83;
                }
                if (m_blupiDir == 2)
                {
                    if (pos.X < src2.Left)
                    {
                        if (m_moveObject[i].type == 2)
                        {
                            return 0;
                        }
                        return 63;
                    }
                    return 64;
                }
                if (pos.X < src2.Left)
                {
                    return 64;
                }
                if (m_moveObject[i].type == 2)
                {
                    return 0;
                }
                return 63;
            }
            return 0;
        }

        private bool BlupiElectro(TinyPoint pos)
        {
            if (!m_blupiCloud)
            {
                return false;
            }
            TinyRect src = default(TinyRect);
            src.Left = pos.X + 16;
            src.Right = pos.X + 60 - 16;
            src.Top = pos.Y + 11;
            src.Bottom = pos.Y + 60 - 2;
            TinyRect src2 = default(TinyRect);
            src2.Left = m_blupiPos.X - 16 - 40;
            src2.Right = m_blupiPos.X + 60 + 16 + 40;
            src2.Top = m_blupiPos.Y + 11 - 40;
            src2.Bottom = m_blupiPos.Y + 60 - 2 + 40;
            TinyRect dst;
            if (Misc.IntersectRect(out dst, src, src2))
            {
                return true;
            }
            return false;
        }

        private void MoveObjectFollow(TinyPoint pos)
        {
            if (m_blupiHide)
            {
                return;
            }
            TinyRect src = BlupiRect(pos);
            src.Left = pos.X + 16;
            src.Right = pos.X + 60 - 16;
            TinyRect src2 = default(TinyRect);
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type == 96)
                {
                    src2.Left = m_moveObject[i].posCurrent.X - 100;
                    src2.Right = m_moveObject[i].posCurrent.X + 60 + 100;
                    src2.Top = m_moveObject[i].posCurrent.Y - 100;
                    src2.Bottom = m_moveObject[i].posCurrent.Y + 60 + 100;
                    TinyRect dst;
                    if (Misc.IntersectRect(out dst, src2, src))
                    {
                        m_moveObject[i].type = 97;
                        PlaySound(92, m_moveObject[i].posCurrent);
                    }
                }
            }
        }

        private int MoveObjectDetect(TinyPoint pos, out bool bNear)
        {
            TinyRect src = BlupiRect(pos);
            src.Left = pos.X + 16;
            src.Right = pos.X + 60 - 16;
            TinyRect src2 = default(TinyRect);
            src2.Left = src.Left - 20;
            src2.Right = src.Right + 20;
            src2.Top = src.Top - 40;
            src2.Bottom = src.Bottom + 30;
            TinyRect src3 = default(TinyRect);
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type == 0 || m_moveObject[i].type == 27 || m_moveObject[i].type == 57 || m_moveObject[i].type == 39 || m_moveObject[i].type == 58 || m_moveObject[i].type == 34 || m_moveObject[i].type == 37 || m_moveObject[i].type == 38 || ((m_blupiAction == 14 || m_blupiAction == 29) && m_moveObject[i].type == 12))
                {
                    continue;
                }
                src3.Left = m_moveObject[i].posCurrent.X + 16;
                src3.Right = m_moveObject[i].posCurrent.X + 60 - 16;
                src3.Top = m_moveObject[i].posCurrent.Y + 36;
                src3.Bottom = m_moveObject[i].posCurrent.Y + 60;
                if (m_moveObject[i].type == 3)
                {
                    if (m_blupiAction == 6)
                    {
                        continue;
                    }
                    src3.Top = m_moveObject[i].posCurrent.Y;
                    src3.Bottom = m_moveObject[i].posCurrent.Y + 60 - 36;
                }
                if (m_moveObject[i].type == 12)
                {
                    src3.Left = m_moveObject[i].posCurrent.X - 16;
                    src3.Right = m_moveObject[i].posCurrent.X + 64 + 16;
                    src3.Top = m_moveObject[i].posCurrent.Y;
                    src3.Bottom = m_moveObject[i].posCurrent.Y + 64;
                    if (m_blupiDir == 1)
                    {
                        src3.Left += 20;
                    }
                    else
                    {
                        src3.Right -= 20;
                    }
                }
                if (m_moveObject[i].type == 17 || m_moveObject[i].type == 20 || m_moveObject[i].type == 44 || m_moveObject[i].type == 54)
                {
                    src3.Top = m_moveObject[i].posCurrent.Y + 16;
                    src3.Bottom = m_moveObject[i].posCurrent.Y + 60 - 16;
                }
                if (m_moveObject[i].type == 23)
                {
                    src3.Left = m_moveObject[i].posCurrent.X + 24;
                    src3.Right = m_moveObject[i].posCurrent.X + 64 - 24;
                    src3.Top = m_moveObject[i].posCurrent.Y + 10;
                    src3.Bottom = m_moveObject[i].posCurrent.Y + 60 - 32;
                }
                TinyRect dst;
                if (Misc.IntersectRect(out dst, src3, src))
                {
                    bNear = true;
                    return i;
                }
                if (m_moveObject[i].type == 2 && Misc.IntersectRect(out dst, src3, src2))
                {
                    bNear = false;
                    return i;
                }
            }
            bNear = false;
            return -1;
        }

        private int MoveAscenseurDetect(TinyPoint pos, int height)
        {
            if (m_blupiTimeNoAsc != 0)
            {
                return -1;
            }
            TinyRect src = default(TinyRect);
            src.Left = pos.X + 12;
            src.Right = pos.X + 60 - 12;
            src.Top = pos.Y + 60 - 2;
            src.Bottom = pos.Y + 60 + height - 1;
            TinyRect src2 = default(TinyRect);
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type == 1 || m_moveObject[i].type == 47 || m_moveObject[i].type == 48)
                {
                    src2.Left = m_moveObject[i].posCurrent.X;
                    src2.Right = m_moveObject[i].posCurrent.X + 64;
                    src2.Top = m_moveObject[i].posCurrent.Y;
                    src2.Bottom = m_moveObject[i].posCurrent.Y + 16;
                    TinyRect dst;
                    if (Misc.IntersectRect(out dst, src2, src))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private int MoveChargeDetect(TinyPoint pos)
        {
            TinyRect src = default(TinyRect);
            src.Left = pos.X + 16;
            src.Right = pos.X + 60 - 16;
            src.Top = pos.Y + 11;
            src.Bottom = pos.Y + 60 - 2;
            TinyRect src2 = default(TinyRect);
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type == 31)
                {
                    src2.Left = m_moveObject[i].posCurrent.X - 10;
                    src2.Right = m_moveObject[i].posCurrent.X + 60 + 10;
                    src2.Top = m_moveObject[i].posCurrent.Y + 36;
                    src2.Bottom = m_moveObject[i].posCurrent.Y + 60;
                    TinyRect dst;
                    if (Misc.IntersectRect(out dst, src2, src))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private int MovePersoDetect(TinyPoint pos)
        {
            TinyRect src = default(TinyRect);
            src.Left = pos.X + 16;
            src.Right = pos.X + 60 - 16;
            src.Top = pos.Y + 11;
            src.Bottom = pos.Y + 60 - 2;
            TinyRect src2 = default(TinyRect);
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type >= 200 && m_moveObject[i].type <= 203)
                {
                    src2.Left = m_moveObject[i].posCurrent.X + 16;
                    src2.Right = m_moveObject[i].posCurrent.X + 60 - 16;
                    src2.Top = m_moveObject[i].posCurrent.Y + 36;
                    src2.Bottom = m_moveObject[i].posCurrent.Y + 60;
                    TinyRect dst;
                    if (Misc.IntersectRect(out dst, src2, src))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private int MoveObjectDelete(TinyPoint cel)
        {
            int result = -1;
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type != 0)
                {
                    if (cel.X == m_moveObject[i].posStart.X / 64 && cel.Y == m_moveObject[i].posStart.Y / 64)
                    {
                        result = m_moveObject[i].type;
                        m_moveObject[i].type = 0;
                    }
                    else if (cel.X == m_moveObject[i].posEnd.X / 64 && cel.Y == m_moveObject[i].posEnd.Y / 64)
                    {
                        result = m_moveObject[i].type;
                        m_moveObject[i].type = 0;
                    }
                }
            }
            return result;
        }

        private int MoveObjectFree()
        {
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type == 0)
                {
                    m_moveObject[i].type = 0;
                    return i;
                }
            }
            return -1;
        }

        private int SortGetType(int type)
        {
            switch (type)
            {
                case 2:
                case 3:
                case 96:
                case 97:
                    return 1;
                case 12:
                    return 2;
                default:
                    return 3;
            }
        }

        private void MoveObjectSort()
        {
            MoveObject dst = default(MoveObject);
            int num = 0;
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type != 0)
                {
                    MoveObjectCopy(ref m_moveObject[num++], m_moveObject[i]);
                }
            }
            for (int i = num; i < MAXMOVEOBJECT; i++)
            {
                m_moveObject[i].type = 0;
            }
            if (num <= 1)
            {
                return;
            }
            bool flag;
            do
            {
                flag = false;
                for (int i = 0; i < num - 1; i++)
                {
                    if (SortGetType(m_moveObject[i].type) > SortGetType(m_moveObject[i + 1].type))
                    {
                        MoveObjectCopy(ref dst, m_moveObject[i]);
                        MoveObjectCopy(ref m_moveObject[i], m_moveObject[i + 1]);
                        MoveObjectCopy(ref m_moveObject[i + 1], dst);
                        flag = true;
                    }
                }
            }
            while (flag);
            UpdateCaisse();
            m_nbLinkCaisse = 0;
        }

        private void MoveObjectPriority(int i)
        {
            MoveObject dst = default(MoveObject);
            if (i == 0 || m_moveObject[i].type != 23)
            {
                return;
            }
            for (int j = 0; j < MAXMOVEOBJECT; j++)
            {
                if (m_moveObject[j].type == 23)
                {
                    continue;
                }
                if (j <= i)
                {
                    MoveObjectCopy(ref dst, m_moveObject[i]);
                    MoveObjectCopy(ref m_moveObject[i], m_moveObject[j]);
                    MoveObjectCopy(ref m_moveObject[j], dst);
                    if (m_moveObject[i].type == 12 || m_moveObject[j].type == 12)
                    {
                        UpdateCaisse();
                    }
                }
                break;
            }
        }

        private int MoveObjectSearch(TinyPoint pos)
        {
            return MoveObjectSearch(pos, -1);
        }

        private int MoveObjectSearch(TinyPoint pos, int type)
        {
            for (int i = 0; i < MAXMOVEOBJECT; i++)
            {
                if (m_moveObject[i].type == 0 || (type != -1 && m_moveObject[i].type != type))
                {
                    continue;
                }
                if (m_moveObject[i].type == 23 && m_moveObject[i].posStart.X != m_moveObject[i].posEnd.X)
                {
                    if (m_moveObject[i].posCurrent.X >= pos.X - 100 && m_moveObject[i].posCurrent.X <= pos.X + 100 && m_moveObject[i].posCurrent.Y == pos.Y)
                    {
                        return i;
                    }
                }
                else if (m_moveObject[i].type == 23 && m_moveObject[i].posStart.Y != m_moveObject[i].posEnd.Y)
                {
                    if (m_moveObject[i].posCurrent.Y >= pos.Y - 100 && m_moveObject[i].posCurrent.Y <= pos.Y + 100 && m_moveObject[i].posCurrent.X == pos.X)
                    {
                        return i;
                    }
                }
                else if (m_moveObject[i].posCurrent.X == pos.X && m_moveObject[i].posCurrent.Y == pos.Y)
                {
                    return i;
                }
            }
            return -1;
        }

        private void ByeByeHelico()
        {
            if (m_blupiHelico)
            {
                ByeByeAdd(10, 68, m_blupiPos, 7.0, 0.5);
            }
        }

        private void ByeByeAdd(int channel, int icon, TinyPoint pos, double rotationSpeed, double animationSpeed)
        {
            ByeByeObject byeByeObject = new ByeByeObject();
            byeByeObject.channel = channel;
            byeByeObject.icon = icon;
            byeByeObject.posX = pos.X;
            byeByeObject.posY = pos.Y;
            byeByeObject.rotation = 0.0;
            byeByeObject.phase = 0.0;
            byeByeObject.rotationSpeed = rotationSpeed;
            byeByeObject.animationSpeed = animationSpeed;
            ByeByeObject byeByeObject2 = byeByeObject;
            int num = m_random.Next(0, 10);
            if (m_random.Next(0, 1000) % 2 == 0)
            {
                byeByeObject2.speedX = num + 10;
            }
            else
            {
                byeByeObject2.speedX = -(num + 10);
            }
            byeByeObjects.Add(byeByeObject2);
        }

        private void ByeByeStep()
        {
            int num = 0;
            while (num < byeByeObjects.Count)
            {
                ByeByeObject byeByeObject = byeByeObjects[num];
                double num2 = 10.0 - byeByeObject.phase;
                if (num2 > 0.0)
                {
                    byeByeObject.posY -= Math.Pow(num2, 1.5) * byeByeObject.animationSpeed;
                }
                if (num2 < 0.0)
                {
                    byeByeObject.posY += Math.Pow(0.0 - num2, 1.5) * byeByeObject.animationSpeed;
                }
                byeByeObject.posX += byeByeObject.speedX * byeByeObject.animationSpeed;
                if (byeByeObject.speedX > 0.0)
                {
                    byeByeObject.speedX -= byeByeObject.animationSpeed;
                }
                if (byeByeObject.speedX < 0.0)
                {
                    byeByeObject.speedX += byeByeObject.animationSpeed;
                }
                byeByeObject.rotation += byeByeObject.rotationSpeed;
                byeByeObject.phase += byeByeObject.animationSpeed;
                if (byeByeObject.channel == 10 && byeByeObject.icon >= 187 && byeByeObject.icon <= 194)
                {
                    byeByeObject.icon = Tables.table_invert[(int)byeByeObject.phase / 2 % 20];
                }
                if (byeByeObject.phase > 30.0)
                {
                    byeByeObjects.RemoveAt(num);
                }
                else
                {
                    num++;
                }
            }
        }

        private void ByeByeDraw(TinyPoint posDecor)
        {
            foreach (ByeByeObject byeByeObject in byeByeObjects)
            {
                TinyPoint tinyPoint = default(TinyPoint);
                tinyPoint.X = m_drawBounds.Left + (int)byeByeObject.posX - posDecor.X;
                tinyPoint.Y = m_drawBounds.Top + (int)byeByeObject.posY - posDecor.Y;
                TinyPoint pos = tinyPoint;
                m_pixmap.QuickIcon(byeByeObject.channel, byeByeObject.icon, pos, 1.0, byeByeObject.rotation);
            }
        }

        private TinyPoint VoyageGetPosVie(int nbVies)
        {
            TinyPoint result = default(TinyPoint);
            result.X = 210 + 16 * nbVies;
            result.Y = 417;
            return result;
        }

        private void VoyageInit(TinyPoint start, TinyPoint end, int icon, int channel)
        {
            if (m_voyageIcon != -1)
            {
                m_voyagePhase = m_voyageTotal;
                VoyageStep();
            }
            m_voyageStart = start;
            m_voyageEnd = end;
            m_voyageIcon = icon;
            m_voyageChannel = channel;
            int num = Math.Abs(end.X - start.X);
            int num2 = Math.Abs(end.Y - start.Y);
            m_voyagePhase = 0;
            m_voyageTotal = (num + num2) / 10;
            if (m_voyageIcon == 48 && m_voyageChannel == 2)
            {
                m_voyageTotal = 40;
                m_nbVies--;
                m_sound.PlayImage(9, end, -1, false);
            }
            if (m_voyageIcon == 21 && m_voyageChannel == 10)
            {
                m_sound.PlayImage(12, start, -1, false);
            }
            if (m_voyageIcon == 6 && m_voyageChannel == 10)
            {
                if (m_nbTresor == m_totalTresor - 1)
                {
                    m_sound.PlayImage(19, start, -1, false);
                }
                else
                {
                    m_sound.PlayImage(11, start, -1, false);
                }
            }
            if (m_voyageIcon == 215 && m_voyageChannel == 10)
            {
                m_sound.PlayImage(11, start, -1, false);
            }
            if (m_voyageIcon == 222 && m_voyageChannel == 10)
            {
                m_sound.PlayImage(11, start, -1, false);
            }
            if (m_voyageIcon == 229 && m_voyageChannel == 10)
            {
                m_sound.PlayImage(11, start, -1, false);
            }
            if (m_voyageIcon == 108 && m_voyageChannel == 4)
            {
                m_sound.PlayImage(60, start, -1, false);
            }
            if (m_voyageIcon == 252 && m_voyageChannel == 10)
            {
                m_sound.PlayImage(60, start, -1, false);
            }
            if (m_voyageIcon == 177 && m_voyageChannel == 10)
            {
                m_sound.PlayImage(54, start, -1, false);
            }
            if (m_voyageIcon == 230 && m_voyageChannel == 10)
            {
                m_voyageTotal = 100;
            }
            if (m_voyageIcon == 40 && m_voyageChannel == 10)
            {
                m_voyageTotal = 50;
            }
        }

        private void VoyageStep()
        {
            if (m_voyageIcon == -1)
            {
                return;
            }
            if (m_voyagePhase < m_voyageTotal)
            {
                if (m_time % 2 == 0 && m_voyageIcon >= 230 && m_voyageIcon <= 241 && m_voyageChannel == 10)
                {
                    m_voyageIcon++;
                    if (m_voyageIcon > 241)
                    {
                        m_voyageIcon = 230;
                    }
                }
            }
            else
            {
                if (m_voyageIcon == 48 && m_voyageChannel == 2)
                {
                    m_blupiAction = 1;
                    m_blupiPhase = 0;
                    m_blupiFocus = true;
                }
                if (m_voyageIcon == 21 && m_voyageChannel == 10)
                {
                    if (m_nbVies < 10)
                    {
                        m_nbVies++;
                    }
                    m_sound.PlayImage(3, m_voyageEnd, -1, false);
                }
                if (m_voyageIcon == 6 && m_voyageChannel == 10)
                {
                    m_nbTresor++;
                    OpenDoorsTresor();
                    m_sound.PlayImage(3, m_voyageEnd, -1, false);
                }
                if (m_voyageIcon == 215 && m_voyageChannel == 10)
                {
                    m_blupiCle |= 1;
                    m_sound.PlayImage(3, m_voyageEnd, -1, false);
                }
                if (m_voyageIcon == 222 && m_voyageChannel == 10)
                {
                    m_blupiCle |= 2;
                    m_sound.PlayImage(3, m_voyageEnd, -1, false);
                }
                if (m_voyageIcon == 229 && m_voyageChannel == 10)
                {
                    m_blupiCle |= 4;
                    m_sound.PlayImage(3, m_voyageEnd, -1, false);
                }
                if (m_voyageIcon == 108 && m_voyageChannel == 4)
                {
                    m_blupiPerso++;
                    m_sound.PlayImage(3, m_voyageEnd, -1, false);
                }
                if (m_voyageIcon == 252 && m_voyageChannel == 10)
                {
                    m_blupiDynamite++;
                    m_sound.PlayImage(3, m_voyageEnd, -1, false);
                }
                if (m_voyageIcon == 177 && m_voyageChannel == 10)
                {
                    m_sound.PlayImage(3, m_voyageEnd, -1, false);
                }
                m_voyageIcon = -1;
            }
            m_voyagePhase++;
        }

        private void VoyageDraw()
        {
            if (m_voyageIcon == -1 || m_voyageTotal == 0)
            {
                return;
            }
            int num = m_voyagePhase;
            if (m_voyageIcon == 40 && m_voyageChannel == 10)
            {
                num -= 30;
                if (num < 0)
                {
                    num = 0;
                }
            }
            TinyPoint pos = default(TinyPoint);
            pos.X = m_voyageStart.X + (m_voyageEnd.X - m_voyageStart.X) * num / m_voyageTotal;
            pos.Y = m_voyageStart.Y + (m_voyageEnd.Y - m_voyageStart.Y) * num / m_voyageTotal;
            if (m_voyageIcon != 40 || m_voyageChannel != 10 || num != 0)
            {
                m_pixmap.HudIcon(m_voyageChannel, m_voyageIcon, pos);
            }
            if (m_voyageIcon == 40 && m_voyageChannel == 10)
            {
                int[] array = new int[7] { -8, -6, -4, 0, 4, 6, 8 };
                pos.X -= 34;
                pos.X += m_posDecor.X;
                pos.Y += m_posDecor.Y;
                int num2 = array[m_random.Next(0, 6)];
                int num3 = m_random.Next(-10, 10);
                if (num == 0)
                {
                    num2 /= 2;
                    num3 *= 4;
                }
                pos.Y += num3;
                ObjectStart(pos, 93, num2);
            }
        }

        private bool IsFloatingObject(int i)
        {
            TinyPoint posCurrent = m_moveObject[i].posCurrent;
            int num = (posCurrent.X + 32) / 64;
            int num2 = posCurrent.Y / 64 + 1;
            int icon = m_decor[num, num2].icon;
            return IsPassIcon(icon);
        }

        private bool IsRightBorder(int x, int y, int dx, int dy)
        {
            int num = ((m_dimDecor.X != 0) ? 100 : 10);
            int num2 = ((m_dimDecor.Y != 0) ? 100 : 8);
            if (x < 0 || x >= num || y < 0 || y >= num2)
            {
                return true;
            }
            int icon = m_decor[x + dx, y + dy].icon;
            if (icon < 386 || icon > 397)
            {
                switch (icon)
                {
                    case 245:
                    case 400:
                        break;
                    case 250:
                    case 251:
                    case 252:
                    case 253:
                    case 254:
                    case 255:
                    case 256:
                    case 257:
                    case 258:
                    case 259:
                    case 260:
                        icon = m_decor[x, y].icon;
                        if (icon >= 250)
                        {
                            return icon <= 260;
                        }
                        return false;
                    default:
                        icon = m_decor[x, y].icon;
                        switch (icon)
                        {
                            case -1:
                                return false;
                            case 32:
                            case 33:
                            case 34:
                                return false;
                            case 68:
                            case 92:
                                if (dy == -1)
                                {
                                    return false;
                                }
                                return true;
                            case 317:
                                if (dy == 1)
                                {
                                    return false;
                                }
                                return true;
                            case 19:
                            case 21:
                            case 25:
                            case 26:
                            case 28:
                                if (dy == 1)
                                {
                                    return false;
                                }
                                return true;
                            case 27:
                                if (dx != 0)
                                {
                                    return false;
                                }
                                return true;
                            case 45:
                            case 46:
                            case 47:
                                if (dy == 1)
                                {
                                    return false;
                                }
                                return true;
                            default:
                                switch (icon)
                                {
                                    case 15:
                                    case 16:
                                    case 75:
                                    case 89:
                                    case 90:
                                    case 155:
                                        if (dx == -1 || dy == 1)
                                        {
                                            return false;
                                        }
                                        return true;
                                    case 17:
                                    case 18:
                                    case 74:
                                    case 87:
                                    case 88:
                                    case 154:
                                        if (dx == 1 || dy == 1)
                                        {
                                            return false;
                                        }
                                        return true;
                                    case 76:
                                    case 77:
                                    case 199:
                                    case 200:
                                        if (dx != 0)
                                        {
                                            return false;
                                        }
                                        return true;
                                    case 110:
                                    case 111:
                                    case 112:
                                    case 113:
                                    case 114:
                                    case 115:
                                    case 116:
                                    case 117:
                                    case 118:
                                    case 119:
                                    case 120:
                                    case 121:
                                    case 122:
                                    case 123:
                                    case 124:
                                    case 125:
                                        return false;
                                    default:
                                        switch (icon)
                                        {
                                            case 126:
                                                if (dx == 1)
                                                {
                                                    return true;
                                                }
                                                return false;
                                            case 129:
                                                if (dx == -1)
                                                {
                                                    return true;
                                                }
                                                return false;
                                            case 132:
                                                if (dy == 1)
                                                {
                                                    return true;
                                                }
                                                return false;
                                            case 135:
                                                if (dy == -1)
                                                {
                                                    return true;
                                                }
                                                return false;
                                            case 139:
                                            case 140:
                                            case 141:
                                            case 142:
                                            case 143:
                                                return false;
                                            default:
                                                switch (icon)
                                                {
                                                    case 138:
                                                        if (dy == -1)
                                                        {
                                                            return true;
                                                        }
                                                        return false;
                                                    case 202:
                                                        return false;
                                                    case 107:
                                                    case 108:
                                                    case 109:
                                                    case 157:
                                                        if (dx != 0)
                                                        {
                                                            return true;
                                                        }
                                                        return false;
                                                    default:
                                                        switch (icon)
                                                        {
                                                            case 309:
                                                            case 310:
                                                            case 410:
                                                            case 411:
                                                            case 412:
                                                            case 413:
                                                            case 414:
                                                            case 415:
                                                            case 416:
                                                            case 417:
                                                            case 418:
                                                            case 419:
                                                            case 420:
                                                                break;
                                                            default:
                                                                switch (icon)
                                                                {
                                                                    case 182:
                                                                    case 183:
                                                                        if (dy != 0)
                                                                        {
                                                                            return true;
                                                                        }
                                                                        return false;
                                                                    case 334:
                                                                    case 335:
                                                                    case 336:
                                                                        if (dy != 0)
                                                                        {
                                                                            return true;
                                                                        }
                                                                        return false;
                                                                    default:
                                                                        if (icon >= 250 && icon <= 260)
                                                                        {
                                                                            return false;
                                                                        }
                                                                        if (icon >= 264 && icon <= 282)
                                                                        {
                                                                            return false;
                                                                        }
                                                                        switch (icon)
                                                                        {
                                                                            case 378:
                                                                                return false;
                                                                            case 404:
                                                                            case 410:
                                                                                return false;
                                                                            case 421:
                                                                            case 422:
                                                                            case 423:
                                                                            case 424:
                                                                            case 425:
                                                                            case 426:
                                                                            case 427:
                                                                            case 428:
                                                                            case 429:
                                                                            case 430:
                                                                            case 431:
                                                                            case 432:
                                                                            case 433:
                                                                            case 434:
                                                                            case 435:
                                                                            case 436:
                                                                            case 437:
                                                                            case 438:
                                                                            case 439:
                                                                            case 440:
                                                                                if (dy != 0)
                                                                                {
                                                                                    return true;
                                                                                }
                                                                                return false;
                                                                            default:
                                                                                return true;
                                                                        }
                                                                }
                                                        }
                                                        break;
                                                    case 158:
                                                    case 159:
                                                    case 160:
                                                    case 161:
                                                    case 162:
                                                    case 163:
                                                    case 164:
                                                    case 165:
                                                    case 166:
                                                    case 167:
                                                    case 168:
                                                    case 169:
                                                    case 170:
                                                    case 171:
                                                    case 172:
                                                    case 173:
                                                    case 174:
                                                    case 175:
                                                    case 176:
                                                    case 177:
                                                    case 178:
                                                    case 179:
                                                    case 180:
                                                    case 181:
                                                        break;
                                                }
                                                if (dy == 1)
                                                {
                                                    return true;
                                                }
                                                return false;
                                        }
                                }
                        }
                }
            }
            icon = m_decor[x, y].icon;
            if ((icon < 386 || icon > 397) && icon != 400)
            {
                return icon == 245;
            }
            return true;
        }

        private bool IsFromage(int x, int y)
        {
            if (x < 0 || x >= 100 || y < 0 || y >= 100)
            {
                return false;
            }
            int icon = m_decor[x, y].icon;
            if (icon >= 246 && icon <= 249)
            {
                return true;
            }
            if (icon == 339)
            {
                return true;
            }
            return false;
        }

        private bool IsGrotte(int x, int y)
        {
            if (x < 0 || x >= 100 || y < 0 || y >= 100)
            {
                return false;
            }
            switch (m_decor[x, y].icon)
            {
                case 284:
                case 301:
                    return true;
                case 337:
                    return true;
                default:
                    return false;
            }
        }

        private void AdaptMidBorder(int x, int y)
        {
            if (x < 0 || x >= 100 || y < 0 || y >= 100)
            {
                return;
            }
            int num = 15;
            if (!IsRightBorder(x, y + 1, 0, -1))
            {
                num &= -2;
            }
            if (!IsRightBorder(x, y - 1, 0, 1))
            {
                num &= -3;
            }
            if (!IsRightBorder(x + 1, y, -1, 0))
            {
                num &= -5;
            }
            if (!IsRightBorder(x - 1, y, 1, 0))
            {
                num &= -9;
            }
            int num2 = m_decor[x, y].icon;
            if (num2 == 156)
            {
                num2 = 35;
            }
            if (num2 == 252 || num2 == 253)
            {
                num2 = 251;
            }
            if (num2 == 255)
            {
                num2 = 254;
            }
            if (num2 == 362)
            {
                num2 = 347;
            }
            if (num2 == 363)
            {
                num2 = 348;
            }
            if (num2 >= 341 && num2 <= 346)
            {
                num2 = 341;
            }
            for (int i = 0; i < 144; i++)
            {
                if (num2 == Tables.table_adapt_decor[i])
                {
                    num2 = Tables.table_adapt_decor[i / 16 * 16 + num];
                    if (num2 == 35 && m_random.Next() % 2 == 0)
                    {
                        num2 = 156;
                    }
                    if (num2 == 251)
                    {
                        num2 = m_random.Next(251, 253);
                    }
                    if (num2 == 254 && m_random.Next() % 2 == 0)
                    {
                        num2 = 255;
                    }
                    if (num2 == 347 && m_random.Next() % 2 == 0)
                    {
                        num2 = 362;
                    }
                    if (num2 == 348 && m_random.Next() % 2 == 0)
                    {
                        num2 = 363;
                    }
                    if (num2 == 341)
                    {
                        num2 = m_random.Next(341, 346);
                    }
                    m_decor[x, y].icon = num2;
                    return;
                }
            }
            switch (m_decor[x, y].icon)
            {
                case -1:
                case 264:
                case 265:
                case 266:
                case 267:
                case 268:
                case 269:
                case 270:
                case 271:
                case 272:
                case 273:
                case 274:
                case 275:
                case 276:
                case 277:
                case 278:
                case 279:
                case 280:
                case 281:
                case 282:
                    num = 15;
                    if (!IsFromage(x, y + 1))
                    {
                        num &= -2;
                    }
                    if (!IsFromage(x, y - 1))
                    {
                        num &= -3;
                    }
                    if (!IsFromage(x + 1, y))
                    {
                        num &= -5;
                    }
                    if (!IsFromage(x - 1, y))
                    {
                        num &= -9;
                    }
                    num2 = Tables.table_adapt_fromage[num];
                    if (num2 == 268 && m_random.Next() % 2 == 0)
                    {
                        num2 = 279;
                    }
                    if (num2 == 269 && m_random.Next() % 2 == 0)
                    {
                        num2 = 280;
                    }
                    if (num2 == 264 && m_random.Next() % 2 == 0)
                    {
                        num2 = 281;
                    }
                    if (num2 == 265 && m_random.Next() % 2 == 0)
                    {
                        num2 = 282;
                    }
                    m_decor[x, y].icon = num2;
                    break;
            }
            switch (m_decor[x, y].icon)
            {
                case -1:
                case 285:
                case 286:
                case 287:
                case 288:
                case 289:
                case 290:
                case 291:
                case 292:
                case 293:
                case 294:
                case 295:
                case 296:
                case 297:
                case 298:
                case 299:
                case 300:
                case 302:
                case 303:
                    num = 15;
                    if (!IsGrotte(x, y + 1))
                    {
                        num &= -2;
                    }
                    if (!IsGrotte(x, y - 1))
                    {
                        num &= -3;
                    }
                    if (!IsGrotte(x + 1, y))
                    {
                        num &= -5;
                    }
                    if (!IsGrotte(x - 1, y))
                    {
                        num &= -9;
                    }
                    num2 = Tables.table_adapt_fromage[num + 16];
                    if (num2 == 289 && m_random.Next() % 2 == 0)
                    {
                        num2 = 300;
                    }
                    if (num2 == 285 && m_random.Next() % 2 == 0)
                    {
                        num2 = 302;
                    }
                    if (num2 == 286 && m_random.Next() % 2 == 0)
                    {
                        num2 = 303;
                    }
                    m_decor[x, y].icon = num2;
                    break;
            }
        }

        private void AdaptBorder(TinyPoint cel)
        {
            AdaptMidBorder(cel.X, cel.Y);
            AdaptMidBorder(cel.X + 1, cel.Y);
            AdaptMidBorder(cel.X - 1, cel.Y);
            AdaptMidBorder(cel.X, cel.Y + 1);
            AdaptMidBorder(cel.X, cel.Y - 1);
            int icon = m_decor[cel.X, cel.Y].icon;
            if (icon != -1 && !IsPassIcon(icon))
            {
                MoveObjectDelete(cel);
            }
            icon = m_decor[cel.X, cel.Y].icon;
            if (icon == 304)
            {
                for (int i = 0; i < 4; i++)
                {
                    cel.Y++;
                    if (cel.Y >= 100)
                    {
                        break;
                    }
                    icon = m_decor[cel.X, cel.Y].icon;
                    if (icon != -1)
                    {
                        break;
                    }
                    m_decor[cel.X, cel.Y].icon = 305;
                }
            }
            if (icon != -1)
            {
                return;
            }
            for (int i = 0; i < 4; i++)
            {
                cel.Y++;
                if (cel.Y >= 100)
                {
                    break;
                }
                icon = m_decor[cel.X, cel.Y].icon;
                if (icon != 305)
                {
                    break;
                }
                m_decor[cel.X, cel.Y].icon = -1;
            }
        }

        public void CurrentDelete()
        {
            Worlds.DeleteCurrentGame();
        }

        public bool CurrentWrite()
        {
            Worlds.WriteClear();
            Worlds.WriteSection("DescFile");
            Worlds.WriteIntField("_version_", 1);
            Worlds.WritePointField("_posDecor_", m_posDecor);
            Worlds.WritePointField("_dimDecor_", m_dimDecor);
            Worlds.WriteIntField("_term_", m_term);
            Worlds.WriteIntField("_music_", m_music);
            Worlds.WriteIntField("_region_", m_region);
            Worlds.WriteIntField("_time_", m_time);
            Worlds.WritePointField("_blupiPos_", m_blupiPos);
            Worlds.WritePointField("_blupiValidPos_", m_blupiValidPos);
            Worlds.WriteIntField("_blupiAction_", m_blupiAction);
            Worlds.WriteIntField("_blupiDir_", m_blupiDir);
            Worlds.WriteIntField("_blupiPhase_", m_blupiPhase);
            Worlds.WriteDoubleField("_blupiVitesseX_", m_blupiVitesseX);
            Worlds.WriteDoubleField("_blupiVitesseY_", m_blupiVitesseY);
            Worlds.WriteIntField("_blupiIcon_", m_blupiIcon);
            Worlds.WriteIntField("_blupiSec_", m_blupiSec);
            Worlds.WriteIntField("_blupiChannel_", m_blupiChannel);
            Worlds.WritePointField("_blupiVector_", m_blupiVector);
            Worlds.WriteIntField("_blupiTransport_", m_blupiTransport);
            Worlds.WriteBoolField("_blupiFocus_", m_blupiFocus);
            Worlds.WriteBoolField("_blupiAir_", m_blupiAir);
            Worlds.WriteBoolField("_blupiHelico_", m_blupiHelico);
            Worlds.WriteBoolField("_blupiOver_", m_blupiOver);
            Worlds.WriteBoolField("_blupiJeep_", m_blupiJeep);
            Worlds.WriteBoolField("_blupiTank_", m_blupiTank);
            Worlds.WriteBoolField("_blupiSkate_", m_blupiSkate);
            Worlds.WriteBoolField("_blupiNage_", m_blupiNage);
            Worlds.WriteBoolField("_blupiSurf_", m_blupiSurf);
            Worlds.WriteBoolField("_blupiVent_", m_blupiVent);
            Worlds.WriteBoolField("_blupiSuspend_", m_blupiSuspend);
            Worlds.WriteBoolField("_blupiJumpAie_", m_blupiJumpAie);
            Worlds.WriteBoolField("_blupiShield_", m_blupiShield);
            Worlds.WriteBoolField("_blupiPower_", m_blupiPower);
            Worlds.WriteBoolField("_blupiCloud_", m_blupiCloud);
            Worlds.WriteBoolField("_blupiHide_", m_blupiHide);
            Worlds.WriteBoolField("_blupiInvert_", m_blupiInvert);
            Worlds.WriteBoolField("_blupiBalloon_", m_blupiBalloon);
            Worlds.WriteBoolField("_blupiEcrase_", m_blupiEcrase);
            Worlds.WriteBoolField("_blupiMotorHigh_", m_blupiMotorHigh);
            Worlds.WritePointField("_blupiPosHelico_", m_blupiPosHelico);
            Worlds.WritePointField("_blupiPosMagic_", m_blupiPosMagic);
            Worlds.WriteBoolField("_blupiRestart_", m_blupiRestart);
            Worlds.WriteBoolField("_blupiFront_", m_blupiFront);
            Worlds.WriteIntField("_blupiBullet_", m_blupiBullet);
            Worlds.WriteIntField("_blupiCle_", m_blupiCle);
            Worlds.WriteIntField("_blupiPerso_", m_blupiPerso);
            Worlds.WriteIntField("_blupiDynamite_", m_blupiDynamite);
            Worlds.WriteIntField("_blupiNoBarre_", m_blupiNoBarre);
            Worlds.WriteIntField("_blupiTimeShield_", m_blupiTimeShield);
            Worlds.WriteIntField("_blupiTimeFire_", m_blupiTimeFire);
            Worlds.WriteIntField("_blupiTimeNoAsc_", m_blupiTimeNoAsc);
            Worlds.WriteIntField("_blupiTimeOuf_", m_blupiTimeOuf);
            Worlds.WriteIntField("_blupiActionOuf_", m_blupiActionOuf);
            Worlds.WriteIntField("_blupiFifoNb_", m_blupiFifoNb);
            Worlds.WritePointField("_blupiStartPos_", m_blupiStartPos);
            Worlds.WriteIntField("_blupiStartDir_", m_blupiStartDir);
            Worlds.WriteIntField("_blupiLevel_", m_blupiLevel);
            Worlds.WriteBoolField("_bFoundCle_", m_bFoundCle);
            Worlds.WriteBoolField("_bPrivate_", m_bPrivate);
            Worlds.WriteBoolField("_bCheatDoors_", m_bCheatDoors);
            Worlds.WriteBoolField("_bSuperBlupi_", m_bSuperBlupi);
            Worlds.WriteBoolField("_bDrawSecret_", m_bDrawSecret);
            Worlds.WriteIntField("_mission_", m_mission);
            Worlds.WriteIntField("_nbVies_", m_nbVies);
            Worlds.WriteIntField("_nbTresor_", m_nbTresor);
            Worlds.WriteIntField("_totalTresor_", m_totalTresor);
            Worlds.WriteIntField("_goalPhase_", m_goalPhase);
            Worlds.WritePointField("_scrollPoint_", m_scrollPoint);
            Worlds.WritePointField("_scrollAdd_", m_scrollAdd);
            Worlds.WriteIntField("_voyageIcon_", m_voyageIcon);
            Worlds.WriteIntField("_voyageChannel_", m_voyageChannel);
            Worlds.WriteIntField("_voyagePhase_", m_voyagePhase);
            Worlds.WriteIntField("_voyageTotal_", m_voyageTotal);
            Worlds.WritePointField("_voyageStart_", m_voyageStart);
            Worlds.WritePointField("_voyageEnd_", m_voyageEnd);
            Worlds.WriteIntField("_decorAction_", m_decorAction);
            Worlds.WriteIntField("_decorPhase_", m_decorPhase);
            Worlds.WriteIntField("_nbRankCaisse_", m_nbRankCaisse);
            Worlds.WriteIntField("_nbLinkCaisse_", m_nbLinkCaisse);
            Worlds.WritePointField("_sucettePos_", m_sucettePos);
            Worlds.WriteIntField("_sucetteType_", m_sucetteType);
            Worlds.WriteIntArrayField("_RankCaisse_", m_rankCaisse);
            Worlds.WriteIntArrayField("_LinkCaisse_", m_linkCaisse);
            Worlds.WriteIntArrayField("_BalleTraj_", m_balleTraj);
            Worlds.WriteIntArrayField("_MoveTraj_", m_moveTraj);
            Worlds.WriteIntArrayField("_Doors_", m_doors);
            Worlds.WriteEndSection();
            Worlds.WriteSection("Decor");
            Worlds.WriteEndSection();
            for (int i = 0; i < 100; i++)
            {
                int[] array = new int[100];
                for (int j = 0; j < 100; j++)
                {
                    array[j] = m_decor[i, j].icon;
                }
                Worlds.WriteDecorField(array);
            }
            Worlds.WriteSection("BigDecor");
            Worlds.WriteEndSection();
            for (int k = 0; k < 100; k++)
            {
                int[] array2 = new int[100];
                for (int l = 0; l < 100; l++)
                {
                    array2[l] = m_bigDecor[k, l].icon;
                }
                Worlds.WriteDecorField(array2);
            }
            for (int m = 0; m < MAXMOVEOBJECT; m++)
            {
                if (m_moveObject[m].type != 0)
                {
                    Worlds.WriteSection("MoveObject");
                    Worlds.WriteIntField("index", m);
                    Worlds.WriteIntField("type", m_moveObject[m].type);
                    Worlds.WriteIntField("stepAdvance", m_moveObject[m].stepAdvance);
                    Worlds.WriteIntField("stepRecede", m_moveObject[m].stepRecede);
                    Worlds.WriteIntField("timeStopStart", m_moveObject[m].timeStopStart);
                    Worlds.WriteIntField("timeStopEnd", m_moveObject[m].timeStopEnd);
                    Worlds.WritePointField("posStart", m_moveObject[m].posStart);
                    Worlds.WritePointField("posEnd", m_moveObject[m].posEnd);
                    Worlds.WritePointField("posCurrent", m_moveObject[m].posCurrent);
                    Worlds.WriteIntField("step", m_moveObject[m].step);
                    Worlds.WriteIntField("time", m_moveObject[m].time);
                    Worlds.WriteIntField("phase", m_moveObject[m].phase);
                    Worlds.WriteIntField("channel", m_moveObject[m].channel);
                    Worlds.WriteIntField("icon", m_moveObject[m].icon);
                    Worlds.WriteEndSection();
                }
            }
            for (int n = 0; n < 2; n++)
            {
                Worlds.WriteSection("Jauge");
                Worlds.WriteBoolField("hide", m_jauges[n].GetHide());
                Worlds.WriteIntField("mode", m_jauges[n].GetMode());
                Worlds.WriteIntField("level", m_jauges[n].GetLevel());
                Worlds.WriteEndSection();
            }
            Worlds.WriteCurrentGame(Worlds.GetWriteString());
            return true;
        }

        public bool CurrentRead()
        {
            string text = Worlds.ReadCurrentGame();
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            InitDecor();
            string[] lines = text.Split('\n');
            Worlds.GetIntField(lines, "DescFile", 0, "_version_");
            m_posDecor = Worlds.GetPointField(lines, "DescFile", 0, "_posDecor_");
            m_dimDecor = Worlds.GetPointField(lines, "DescFile", 0, "_dimDecor_");
            m_term = Worlds.GetIntField(lines, "DescFile", 0, "_term_");
            m_music = Worlds.GetIntField(lines, "DescFile", 0, "_music_");
            m_region = Worlds.GetIntField(lines, "DescFile", 0, "_region_");
            m_time = Worlds.GetIntField(lines, "DescFile", 0, "_time_");
            m_blupiPos = Worlds.GetPointField(lines, "DescFile", 0, "_blupiPos_");
            m_blupiValidPos = Worlds.GetPointField(lines, "DescFile", 0, "_blupiValidPos_");
            m_blupiAction = Worlds.GetIntField(lines, "DescFile", 0, "_blupiAction_");
            m_blupiDir = Worlds.GetIntField(lines, "DescFile", 0, "_blupiDir_");
            m_blupiPhase = Worlds.GetIntField(lines, "DescFile", 0, "_blupiPhase_");
            m_blupiVitesseX = Worlds.GetDoubleField(lines, "DescFile", 0, "_blupiVitesseX_");
            m_blupiVitesseY = Worlds.GetDoubleField(lines, "DescFile", 0, "_blupiVitesseY_");
            m_blupiIcon = Worlds.GetIntField(lines, "DescFile", 0, "_blupiIcon_");
            m_blupiSec = Worlds.GetIntField(lines, "DescFile", 0, "_blupiSec_");
            m_blupiChannel = Worlds.GetIntField(lines, "DescFile", 0, "_blupiChannel_");
            m_blupiVector = Worlds.GetPointField(lines, "DescFile", 0, "_blupiVector_");
            m_blupiTransport = Worlds.GetIntField(lines, "DescFile", 0, "_blupiTransport_");
            m_blupiFocus = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiFocus_");
            m_blupiAir = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiAir_");
            m_blupiHelico = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiHelico_");
            m_blupiOver = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiOver_");
            m_blupiJeep = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiJeep_");
            m_blupiTank = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiTank_");
            m_blupiSkate = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiSkate_");
            m_blupiNage = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiNage_");
            m_blupiSurf = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiSurf_");
            m_blupiVent = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiVent_");
            m_blupiSuspend = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiSuspend_");
            m_blupiJumpAie = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiJumpAie_");
            m_blupiShield = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiShield_");
            m_blupiPower = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiPower_");
            m_blupiCloud = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiCloud_");
            m_blupiHide = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiHide_");
            m_blupiInvert = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiInvert_");
            m_blupiBalloon = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiBalloon_");
            m_blupiEcrase = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiEcrase_");
            m_blupiMotorHigh = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiMotorHigh_");
            m_blupiPosHelico = Worlds.GetPointField(lines, "DescFile", 0, "_blupiPosHelico_");
            m_blupiPosMagic = Worlds.GetPointField(lines, "DescFile", 0, "_blupiPosMagic_");
            m_blupiRestart = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiRestart_");
            m_blupiFront = Worlds.GetBoolField(lines, "DescFile", 0, "_blupiFront_");
            m_blupiBullet = Worlds.GetIntField(lines, "DescFile", 0, "_blupiBullet_");
            m_blupiCle = Worlds.GetIntField(lines, "DescFile", 0, "_blupiCle_");
            m_blupiPerso = Worlds.GetIntField(lines, "DescFile", 0, "_blupiPerso_");
            m_blupiDynamite = Worlds.GetIntField(lines, "DescFile", 0, "_blupiDynamite_");
            m_blupiNoBarre = Worlds.GetIntField(lines, "DescFile", 0, "_blupiNoBarre_");
            m_blupiTimeShield = Worlds.GetIntField(lines, "DescFile", 0, "_blupiTimeShield_");
            m_blupiTimeFire = Worlds.GetIntField(lines, "DescFile", 0, "_blupiTimeFire_");
            m_blupiTimeNoAsc = Worlds.GetIntField(lines, "DescFile", 0, "_blupiTimeNoAsc_");
            m_blupiTimeOuf = Worlds.GetIntField(lines, "DescFile", 0, "_blupiTimeOuf_");
            m_blupiActionOuf = Worlds.GetIntField(lines, "DescFile", 0, "_blupiActionOuf_");
            m_blupiFifoNb = Worlds.GetIntField(lines, "DescFile", 0, "_blupiFifoNb_");
            m_blupiStartPos = Worlds.GetPointField(lines, "DescFile", 0, "_blupiStartPos_");
            m_blupiStartDir = Worlds.GetIntField(lines, "DescFile", 0, "_blupiStartDir_");
            m_blupiLevel = Worlds.GetIntField(lines, "DescFile", 0, "_blupiLevel_");
            m_bFoundCle = Worlds.GetBoolField(lines, "DescFile", 0, "_bFoundCle_");
            m_bPrivate = Worlds.GetBoolField(lines, "DescFile", 0, "_bPrivate_");
            m_bCheatDoors = Worlds.GetBoolField(lines, "DescFile", 0, "_bCheatDoors_");
            m_bSuperBlupi = Worlds.GetBoolField(lines, "DescFile", 0, "_bSuperBlupi_");
            m_bDrawSecret = Worlds.GetBoolField(lines, "DescFile", 0, "_bDrawSecret_");
            m_mission = Worlds.GetIntField(lines, "DescFile", 0, "_mission_");
            m_nbVies = Worlds.GetIntField(lines, "DescFile", 0, "_nbVies_");
            m_nbTresor = Worlds.GetIntField(lines, "DescFile", 0, "_nbTresor_");
            m_totalTresor = Worlds.GetIntField(lines, "DescFile", 0, "_totalTresor_");
            m_goalPhase = Worlds.GetIntField(lines, "DescFile", 0, "_goalPhase_");
            m_scrollPoint = Worlds.GetPointField(lines, "DescFile", 0, "_scrollPoint_");
            m_scrollAdd = Worlds.GetPointField(lines, "DescFile", 0, "_scrollAdd_");
            m_voyageIcon = Worlds.GetIntField(lines, "DescFile", 0, "_voyageIcon_");
            m_voyageChannel = Worlds.GetIntField(lines, "DescFile", 0, "_voyageChannel_");
            m_voyagePhase = Worlds.GetIntField(lines, "DescFile", 0, "_voyagePhase_");
            m_voyageTotal = Worlds.GetIntField(lines, "DescFile", 0, "_voyageTotal_");
            m_voyageStart = Worlds.GetPointField(lines, "DescFile", 0, "_voyageStart_");
            m_voyageEnd = Worlds.GetPointField(lines, "DescFile", 0, "_voyageEnd_");
            m_decorAction = Worlds.GetIntField(lines, "DescFile", 0, "_decorAction_");
            m_decorPhase = Worlds.GetIntField(lines, "DescFile", 0, "_decorPhase_");
            m_nbRankCaisse = Worlds.GetIntField(lines, "DescFile", 0, "_nbRankCaisse_");
            m_nbLinkCaisse = Worlds.GetIntField(lines, "DescFile", 0, "_nbLinkCaisse_");
            m_sucettePos = Worlds.GetPointField(lines, "DescFile", 0, "_sucettePos_");
            m_sucetteType = Worlds.GetIntField(lines, "DescFile", 0, "_sucetteType_");
            Worlds.GetIntArrayField(lines, "DescFile", 0, "_RankCaisse_", m_rankCaisse);
            Worlds.GetIntArrayField(lines, "DescFile", 0, "_LinkCaisse_", m_linkCaisse);
            Worlds.GetIntArrayField(lines, "DescFile", 0, "_BalleTraj_", m_balleTraj);
            Worlds.GetIntArrayField(lines, "DescFile", 0, "_MoveTraj_", m_moveTraj);
            Worlds.GetIntArrayField(lines, "DescFile", 0, "_Doors_", m_doors);
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    m_decor[j, i].icon = Worlds.GetDecorField(lines, "Decor", j, i) ?? (-1);
                }
            }
            for (int k = 0; k < 100; k++)
            {
                for (int l = 0; l < 100; l++)
                {
                    m_bigDecor[l, k].icon = Worlds.GetDecorField(lines, "BigDecor", l, k) ?? (-1);
                }
            }
            for (int m = 0; m < MAXMOVEOBJECT; m++)
            {
                m_moveObject[m].type = 0;
            }
            for (int n = 0; n < MAXMOVEOBJECT; n++)
            {
                int intField = Worlds.GetIntField(lines, "MoveObject", n, "type");
                if (intField == 0)
                {
                    break;
                }
                int intField2 = Worlds.GetIntField(lines, "MoveObject", n, "index");
                m_moveObject[intField2].type = intField;
                m_moveObject[intField2].stepAdvance = Worlds.GetIntField(lines, "MoveObject", n, "stepAdvance");
                m_moveObject[intField2].stepRecede = Worlds.GetIntField(lines, "MoveObject", n, "stepRecede");
                m_moveObject[intField2].timeStopStart = Worlds.GetIntField(lines, "MoveObject", n, "timeStopStart");
                m_moveObject[intField2].timeStopEnd = Worlds.GetIntField(lines, "MoveObject", n, "timeStopEnd");
                m_moveObject[intField2].posStart = Worlds.GetPointField(lines, "MoveObject", n, "posStart");
                m_moveObject[intField2].posEnd = Worlds.GetPointField(lines, "MoveObject", n, "posEnd");
                m_moveObject[intField2].posCurrent = Worlds.GetPointField(lines, "MoveObject", n, "posCurrent");
                m_moveObject[intField2].step = Worlds.GetIntField(lines, "MoveObject", n, "step");
                m_moveObject[intField2].time = Worlds.GetIntField(lines, "MoveObject", n, "time");
                m_moveObject[intField2].phase = Worlds.GetIntField(lines, "MoveObject", n, "phase");
                m_moveObject[intField2].channel = Worlds.GetIntField(lines, "MoveObject", n, "channel");
                m_moveObject[intField2].icon = Worlds.GetIntField(lines, "MoveObject", n, "icon");
            }
            for (int num = 0; num < 2; num++)
            {
                m_jauges[num].SetHide(Worlds.GetBoolField(lines, "Jauge", num, "hide"));
                m_jauges[num].SetMode(Worlds.GetIntField(lines, "Jauge", num, "mode"));
                m_jauges[num].SetLevel(Worlds.GetIntField(lines, "Jauge", num, "level"));
            }
            return true;
        }

        public bool Read(int gamer, int rank, bool bUser)
        {
            InitDecor();
            string[] array = Worlds.ReadWorld(gamer, rank);
            if (array == null)
            {
                return false;
            }
            m_posDecor = Worlds.GetPointField(array, "DescFile", 0, "posDecor");
            m_dimDecor = Worlds.GetPointField(array, "DescFile", 0, "dimDecor");
            m_music = Worlds.GetIntField(array, "DescFile", 0, "music");
            m_region = Worlds.GetIntField(array, "DescFile", 0, "region");
            m_blupiStartPos = Worlds.GetPointField(array, "DescFile", 0, "blupiPos");
            m_blupiStartDir = Worlds.GetIntField(array, "DescFile", 0, "blupiDir");
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    m_decor[j, i].icon = Worlds.GetDecorField(array, "Decor", j, i) ?? (-1);
                }
            }
            for (int k = 0; k < 100; k++)
            {
                for (int l = 0; l < 100; l++)
                {
                    m_bigDecor[l, k].icon = Worlds.GetDecorField(array, "BigDecor", l, k) ?? (-1);
                }
            }
            for (int m = 0; m < MAXMOVEOBJECT; m++)
            {
                m_moveObject[m].type = 0;
            }
            for (int n = 0; n < MAXMOVEOBJECT; n++)
            {
                int intField = Worlds.GetIntField(array, "MoveObject", n, "type");
                if (intField == 0)
                {
                    break;
                }
                m_moveObject[n].type = intField;
                m_moveObject[n].stepAdvance = Worlds.GetIntField(array, "MoveObject", n, "stepAdvance");
                m_moveObject[n].stepRecede = Worlds.GetIntField(array, "MoveObject", n, "stepRecede");
                m_moveObject[n].timeStopStart = Worlds.GetIntField(array, "MoveObject", n, "timeStopStart");
                m_moveObject[n].timeStopEnd = Worlds.GetIntField(array, "MoveObject", n, "timeStopEnd");
                m_moveObject[n].posStart = Worlds.GetPointField(array, "MoveObject", n, "posStart");
                m_moveObject[n].posEnd = Worlds.GetPointField(array, "MoveObject", n, "posEnd");
                m_moveObject[n].posCurrent = Worlds.GetPointField(array, "MoveObject", n, "posCurrent");
                m_moveObject[n].step = Worlds.GetIntField(array, "MoveObject", n, "step");
                m_moveObject[n].time = Worlds.GetIntField(array, "MoveObject", n, "time");
                m_moveObject[n].phase = Worlds.GetIntField(array, "MoveObject", n, "phase");
                m_moveObject[n].channel = Worlds.GetIntField(array, "MoveObject", n, "channel");
                m_moveObject[n].icon = Worlds.GetIntField(array, "MoveObject", n, "icon");
                if (m_moveObject[n].type == 54)
                {
                    m_moveObject[n].timeStopStart = 152;
                    m_moveObject[n].timeStopEnd = 152;
                }
            }
            return true;
        }

        private bool Delete(int gamer, int rank, bool bUser)
        {
            return true;
        }

        private bool FileExist(int gamer, int rank, bool bUser)
        {
            return false;
        }

        private bool SearchWorld(int world, ref TinyPoint blupi, ref int dir)
        {
            if (world < 0 || world > 12)
            {
                return false;
            }
            int num = Tables.world_terminal[world * 2];
            int num2 = Tables.world_terminal[world * 2 + 1];
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    int icon = m_decor[i, j].icon;
                    if (icon == num || icon == num2)
                    {
                        if (IsPassIcon(m_decor[i - 1, j].icon))
                        {
                            blupi.X = (i - 1) * 64 + 2;
                            blupi.Y = j * 64 + BLUPIOFFY;
                            dir = 2;
                            return true;
                        }
                        if (IsPassIcon(m_decor[i + 1, j].icon))
                        {
                            blupi.X = (i + 1) * 64 + 2;
                            blupi.Y = j * 64 + BLUPIOFFY;
                            dir = 1;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool SearchDoor(int n, ref TinyPoint cel, ref TinyPoint blupi)
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    int icon = m_decor[i, j].icon;
                    if (icon >= 174 && icon <= 181 && icon - 174 + 1 == n)
                    {
                        if (i > 0 && m_decor[i - 1, j].icon == 182)
                        {
                            cel.X = i - 1;
                            cel.Y = j;
                            blupi.X = (i - 2) * 64 + 2;
                            blupi.Y = j * 64 + BLUPIOFFY;
                            return true;
                        }
                        if (i > 1 && m_decor[i - 2, j].icon == 182)
                        {
                            cel.X = i - 2;
                            cel.Y = j;
                            blupi.X = (i - 3) * 64 + 2;
                            blupi.Y = j * 64 + BLUPIOFFY;
                            return true;
                        }
                        if (i < 99 && m_decor[i + 1, j].icon == 182)
                        {
                            cel.X = i + 1;
                            cel.Y = j;
                            blupi.X = (i + 2) * 64 + 2;
                            blupi.Y = j * 64 + BLUPIOFFY;
                            return true;
                        }
                        if (i < 98 && m_decor[i + 2, j].icon == 182)
                        {
                            cel.X = i + 2;
                            cel.Y = j;
                            blupi.X = (i + 3) * 64 + 2;
                            blupi.Y = j * 64 + BLUPIOFFY;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool SearchGold(int n, ref TinyPoint cel)
        {
            for (int num = 99; num >= 0; num--)
            {
                for (int num2 = 99; num2 >= 0; num2--)
                {
                    if (m_decor[num2, num].icon == 183)
                    {
                        cel.X = num2;
                        cel.Y = num;
                        return true;
                    }
                }
            }
            return false;
        }

        public void MainSwitchInitialize(int lastWorld)
        {
            if (m_mission == 1)
            {
                TinyPoint blupi = default(TinyPoint);
                int dir = 0;
                if (SearchWorld(lastWorld, ref blupi, ref dir))
                {
                    m_blupiStartPos = blupi;
                    m_blupiStartDir = dir;
                }
            }
        }

        public void AdaptDoors(bool bPrivate)
        {
            TinyPoint cel = default(TinyPoint);
            TinyPoint blupi = default(TinyPoint);
            m_bPrivate = bPrivate;
            if (m_bPrivate)
            {
                return;
            }
            if (m_mission == 1)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (SearchGold(i, ref cel) && (m_doors[180 + i] == 1 || m_bCheatDoors))
                    {
                        m_decor[cel.X, cel.Y].icon = -1;
                        int num = MoveObjectFree();
                        m_moveObject[num].type = 22;
                        m_moveObject[num].stepAdvance = 50;
                        m_moveObject[num].stepRecede = 1;
                        m_moveObject[num].timeStopStart = 0;
                        m_moveObject[num].timeStopEnd = 0;
                        m_moveObject[num].posStart.X = 64 * cel.X;
                        m_moveObject[num].posStart.Y = 64 * cel.Y;
                        m_moveObject[num].posEnd.X = 64 * cel.X;
                        m_moveObject[num].posEnd.Y = 64 * (cel.Y - 1);
                        m_moveObject[num].posCurrent = m_moveObject[num].posStart;
                        m_moveObject[num].step = 1;
                        m_moveObject[num].time = 0;
                        m_moveObject[num].phase = 0;
                        m_moveObject[num].channel = 1;
                        m_moveObject[num].icon = 183;
                        PlaySound(33, m_moveObject[num].posStart);
                    }
                }
                for (int j = 0; j < 100; j++)
                {
                    for (int k = 0; k < 100; k++)
                    {
                        int icon = m_decor[j, k].icon;
                        if (icon >= 158 && icon <= 165 && (m_doors[180 + icon - 158 + 1] == 1 || m_bCheatDoors))
                        {
                            m_decor[j, k].icon += 8;
                        }
                        if (icon == 309 && (m_doors[189] == 1 || m_bCheatDoors))
                        {
                            m_decor[j, k].icon = 310;
                        }
                        if (icon >= 410 && icon <= 415 && (m_doors[180 + icon - 410 + 9] == 1 || m_bCheatDoors))
                        {
                            m_decor[j, k].icon += 5;
                        }
                    }
                }
            }
            else
            {
                if (m_mission % 10 != 0)
                {
                    return;
                }
                for (int i = 0; i < 10; i++)
                {
                    if (SearchDoor(i, ref cel, ref blupi) && (m_doors[m_mission + i] == 1 || m_bCheatDoors))
                    {
                        OpenDoor(cel);
                        m_blupiStartPos = blupi;
                        if (blupi.X < cel.X * 64)
                        {
                            m_blupiStartDir = 2;
                        }
                        else
                        {
                            m_blupiStartDir = 1;
                        }
                    }
                }
            }
        }

        private void OpenDoorsTresor()
        {
            TinyPoint cel = default(TinyPoint);
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    int icon = m_decor[i, j].icon;
                    if (icon >= 421 && icon <= 421 + m_nbTresor - 1)
                    {
                        cel.X = i;
                        cel.Y = j;
                        OpenDoor(cel);
                    }
                }
            }
        }

        private void OpenDoor(TinyPoint cel)
        {
            int icon = m_decor[cel.X, cel.Y].icon;
            m_decor[cel.X, cel.Y].icon = -1;
            int num = MoveObjectFree();
            m_moveObject[num].type = 22;
            m_moveObject[num].stepAdvance = 50;
            m_moveObject[num].stepRecede = 1;
            m_moveObject[num].timeStopStart = 0;
            m_moveObject[num].timeStopEnd = 0;
            m_moveObject[num].posStart.X = 64 * cel.X;
            m_moveObject[num].posStart.Y = 64 * cel.Y;
            m_moveObject[num].posEnd.X = 64 * cel.X;
            m_moveObject[num].posEnd.Y = 64 * (cel.Y - 1);
            m_moveObject[num].posCurrent = m_moveObject[num].posStart;
            m_moveObject[num].step = 1;
            m_moveObject[num].time = 0;
            m_moveObject[num].phase = 0;
            m_moveObject[num].channel = 1;
            m_moveObject[num].icon = icon;
            PlaySound(33, m_moveObject[num].posStart);
        }

        private void OpenDoorsWin()
        {
            m_doors[m_mission + 1] = 1;
        }

        private void OpenGoldsWin()
        {
            m_doors[180 + m_mission / 10] = 1;
        }

        private void DoorsLost()
        {
            m_nbVies = 3;
        }
    }

}