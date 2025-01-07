// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.Game1
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsPhoneSpeedyBlupi
{
    public class Game1 : Game
    {
        private static readonly double[] waitTable = new double[24]
        {
        0.1, 7.0, 0.2, 20.0, 0.25, 22.0, 0.45, 50.0, 0.6, 53.0,
        0.65, 58.0, 0.68, 60.0, 0.8, 70.0, 0.84, 75.0, 0.9, 84.0,
        0.94, 91.0, 1.0, 100.0
        };

        private static readonly Def.ButtonGlyph[] cheatGeste = new Def.ButtonGlyph[10]
        {
        Def.ButtonGlyph.Cheat12,
        Def.ButtonGlyph.Cheat22,
        Def.ButtonGlyph.Cheat32,
        Def.ButtonGlyph.Cheat12,
        Def.ButtonGlyph.Cheat11,
        Def.ButtonGlyph.Cheat21,
        Def.ButtonGlyph.Cheat22,
        Def.ButtonGlyph.Cheat21,
        Def.ButtonGlyph.Cheat31,
        Def.ButtonGlyph.Cheat32
        };

        private readonly GraphicsDeviceManager graphics;

        private readonly Pixmap pixmap;

        private readonly Sound sound;

        private readonly Decor decor;

        private readonly InputPad inputPad;

        private readonly GameData gameData;

        private Def.Phase phase;

        private TimeSpan startTime;

        private int missionToStart1;

        private int missionToStart2;

        private int mission;

        private int cheatGesteIndex;

        private int continueMission;

        private Jauge waitJauge;

        private double waitProgress;

        private bool isTrialMode;

        private bool simulateTrialMode;

        private bool playSetup;

        private int phaseTime;

        private Def.Phase fadeOutPhase;

        private int fadeOutMission;

        public bool IsRankingMode
        {
            get
            {
                return false;
            }
        }

        public bool IsTrialMode
        {
            get
            {
                if (!simulateTrialMode)
                {
                    return isTrialMode;
                }
                return true;
            }
        }

        public Game1()
        {
            Exiting += OnExiting;
            if (!TouchPanel.GetCapabilities().IsConnected)
            {
                IsMouseVisible = true;
                Mouse.SetCursor(MouseCursor.Arrow);
            }
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            TargetElapsedTime = TimeSpan.FromTicks(500000L);
            InactiveSleepTime = TimeSpan.FromSeconds(1.0);
            missionToStart1 = -1;
            missionToStart2 = -1;
            gameData = new GameData();
            pixmap = new Pixmap(this, graphics);
            sound = new Sound(this, gameData);
            decor = new Decor();
            decor.Create(sound, pixmap, gameData);
            TinyPoint pos = new TinyPoint
            {
                X = 196,
                Y = 426
            };
            waitJauge = new Jauge();
            waitJauge.Create(pixmap, sound, pos, 3, false);
            waitJauge.SetHide(false);
            waitJauge.Zoom = 2.0;
            phase = Def.Phase.None;
            fadeOutPhase = Def.Phase.None;
            inputPad = new InputPad(this, decor, pixmap, sound, gameData);
            SetPhase(Def.Phase.First);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            pixmap.BackgroundCache("wait");
        }

        protected override void UnloadContent()
        {
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            if (phase == Def.Phase.Play)
            {
                decor.CurrentWrite();
            }
            else
            {
                decor.CurrentDelete();
            }
            base.OnDeactivated(sender, args);
        }

        protected override void OnActivated(object sender, EventArgs args)
        {
            continueMission = 1;
            base.OnActivated(sender, args);
        }

        protected void OnExiting(object sender, EventArgs args)
        {
            decor.CurrentDelete();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                if (phase == Def.Phase.Play)
                {
                    SetPhase(Def.Phase.Pause);
                }
                else if (phase == Def.Phase.PlaySetup)
                {
                    SetPhase(Def.Phase.Play, -1);
                }
                else if (phase != Def.Phase.Init)
                {
                    SetPhase(Def.Phase.Init);
                }
                else
                {
                    Exit();
                }
                return;
            }
            phaseTime++;
            if (fadeOutPhase != 0)
            {
                if (phaseTime >= 20)
                {
                    SetPhase(fadeOutPhase);
                }
                return;
            }
            if (missionToStart2 != -1)
            {
                SetPhase(Def.Phase.Play, missionToStart2);
                return;
            }
            if (phase == Def.Phase.First)
            {
                startTime = gameTime.TotalGameTime;
                pixmap.LoadContent();
                sound.LoadContent();
                gameData.Read();
                inputPad.PixmapOrigin = pixmap.Origin;
                SetPhase(Def.Phase.Wait);
                return;
            }
            if (phase == Def.Phase.Wait)
            {
                if (continueMission == 2)
                {
                    continueMission = 0;
                    if (decor.CurrentRead())
                    {
                        SetPhase(Def.Phase.Resume);
                        return;
                    }
                }
                long num = gameTime.TotalGameTime.Ticks - startTime.Ticks;
                waitProgress = num / 50000000.0;
                if (waitProgress > 1.0)
                {
                    SetPhase(Def.Phase.Init);
                }
                return;
            }
            inputPad.Update();
            Def.ButtonGlyph buttonPressed = inputPad.ButtonPressed;
            if (buttonPressed >= Def.ButtonGlyph.InitGamerA && buttonPressed <= Def.ButtonGlyph.InitGamerC)
            {
                SetGamer((int)(buttonPressed - 1));
                return;
            }
            switch (buttonPressed)
            {
                case Def.ButtonGlyph.InitSetup:
                    SetPhase(Def.Phase.MainSetup);
                    return;
                case Def.ButtonGlyph.PauseSetup:
                    SetPhase(Def.Phase.PlaySetup);
                    return;
                case Def.ButtonGlyph.SetupSounds:
                    gameData.Sounds = !gameData.Sounds;
                    gameData.Write();
                    return;
                case Def.ButtonGlyph.SetupJump:
                    gameData.JumpRight = !gameData.JumpRight;
                    gameData.Write();
                    return;
                case Def.ButtonGlyph.SetupZoom:
                    gameData.AutoZoom = !gameData.AutoZoom;
                    gameData.Write();
                    return;
                case Def.ButtonGlyph.SetupAccel:
                    gameData.AccelActive = !gameData.AccelActive;
                    gameData.Write();
                    return;
                case Def.ButtonGlyph.SetupReset:
                    gameData.Reset();
                    gameData.Write();
                    return;
                case Def.ButtonGlyph.SetupReturn:
                    if (playSetup)
                    {
                        SetPhase(Def.Phase.Play, -1);
                    }
                    else
                    {
                        SetPhase(Def.Phase.Init);
                    }
                    return;
                case Def.ButtonGlyph.InitPlay:
                    SetPhase(Def.Phase.Play, 1);
                    return;
                case Def.ButtonGlyph.PlayPause:
                    SetPhase(Def.Phase.Pause);
                    return;
                case Def.ButtonGlyph.WinLostReturn:
                case Def.ButtonGlyph.PauseMenu:
                case Def.ButtonGlyph.ResumeMenu:
                    SetPhase(Def.Phase.Init);
                    break;
            }
            switch (buttonPressed)
            {
                case Def.ButtonGlyph.ResumeContinue:
                    ContinueMission();
                    return;
                case Def.ButtonGlyph.InitBuy:
                case Def.ButtonGlyph.TrialBuy:
                    Guide.Show(PlayerIndex.One);
                    SetPhase(Def.Phase.Init);
                    return;
                case Def.ButtonGlyph.InitRanking:
                    SetPhase(Def.Phase.Ranking);
                    return;
                case Def.ButtonGlyph.TrialCancel:
                case Def.ButtonGlyph.RankingContinue:
                    SetPhase(Def.Phase.Init);
                    return;
                case Def.ButtonGlyph.PauseBack:
                    MissionBack();
                    return;
                case Def.ButtonGlyph.PauseRestart:
                    SetPhase(Def.Phase.Play, mission);
                    return;
                case Def.ButtonGlyph.PauseContinue:
                    SetPhase(Def.Phase.Play, -1);
                    return;
                case Def.ButtonGlyph.Cheat11:
                case Def.ButtonGlyph.Cheat12:
                case Def.ButtonGlyph.Cheat21:
                case Def.ButtonGlyph.Cheat22:
                case Def.ButtonGlyph.Cheat31:
                case Def.ButtonGlyph.Cheat32:
                    if (buttonPressed == cheatGeste[cheatGesteIndex])
                    {
                        cheatGesteIndex++;
                        if (cheatGesteIndex == cheatGeste.Length)
                        {
                            cheatGesteIndex = 0;
                            inputPad.ShowCheatMenu = true;
                        }
                    }
                    else
                    {
                        cheatGesteIndex = 0;
                    }
                    break;
                default:
                    if (buttonPressed != 0)
                    {
                        cheatGesteIndex = 0;
                    }
                    break;
            }
            if (buttonPressed >= Def.ButtonGlyph.Cheat1 && buttonPressed <= Def.ButtonGlyph.Cheat9)
            {
                CheatAction(buttonPressed);
            }
            if (phase == Def.Phase.Play)
            {
                decor.ButtonPressed = buttonPressed;
                decor.MoveStep();
                int num2 = decor.IsTerminated();
                if (num2 == -1)
                {
                    MemorizeGamerProgress();
                    SetPhase(Def.Phase.Lost);
                }
                else if (num2 == -2)
                {
                    MemorizeGamerProgress();
                    SetPhase(Def.Phase.Win);
                }
                else if (num2 >= 1)
                {
                    MemorizeGamerProgress();
                    StartMission(num2);
                }
            }
            base.Update(gameTime);
        }

        private void MissionBack()
        {
            int num = mission;
            if (num == 1)
            {
                SetPhase(Def.Phase.Init);
                return;
            }
            num = num % 10 == 0 ? 1 : num / 10 * 10;
            SetPhase(Def.Phase.Play, num);
        }

        private void StartMission(int mission)
        {
            if (mission > 20 && mission % 10 > 1 && IsTrialMode)
            {
                SetPhase(Def.Phase.Trial);
                return;
            }
            this.mission = mission;
            if (this.mission != 1)
            {
                gameData.LastWorld = this.mission / 10;
            }
            decor.Read(0, this.mission, false);
            decor.LoadImages();
            decor.SetMission(this.mission);
            decor.SetNbVies(gameData.NbVies);
            decor.InitializeDoors(gameData);
            decor.AdaptDoors(false);
            decor.MainSwitchInitialize(gameData.LastWorld);
            decor.PlayPrepare(false);
            decor.StartSound();
            inputPad.StartMission(this.mission);
        }

        private void ContinueMission()
        {
            SetPhase(Def.Phase.Play, -2);
            mission = decor.GetMission();
            if (mission != 1)
            {
                gameData.LastWorld = mission / 10;
            }
            decor.LoadImages();
            decor.StartSound();
            inputPad.StartMission(mission);
        }

        private void CheatAction(Def.ButtonGlyph glyph)
        {
            switch (glyph)
            {
                case Def.ButtonGlyph.Cheat1:
                    decor.CheatAction(Tables.CheatCodes.OpenDoors);
                    break;
                case Def.ButtonGlyph.Cheat2:
                    decor.CheatAction(Tables.CheatCodes.SuperBlupi);
                    break;
                case Def.ButtonGlyph.Cheat3:
                    decor.CheatAction(Tables.CheatCodes.ShowSecret);
                    break;
                case Def.ButtonGlyph.Cheat4:
                    decor.CheatAction(Tables.CheatCodes.LayEgg);
                    break;
                case Def.ButtonGlyph.Cheat5:
                    gameData.Reset();
                    break;
                case Def.ButtonGlyph.Cheat6:
                    simulateTrialMode = !simulateTrialMode;
                    break;
                case Def.ButtonGlyph.Cheat7:
                    decor.CheatAction(Tables.CheatCodes.CleanAll);
                    break;
                case Def.ButtonGlyph.Cheat8:
                    decor.CheatAction(Tables.CheatCodes.AllTreasure);
                    break;
                case Def.ButtonGlyph.Cheat9:
                    decor.CheatAction(Tables.CheatCodes.EndGoal);
                    break;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            if (continueMission == 1)
            {
                continueMission = 2;
            }
            if (phase == Def.Phase.Wait || phase == Def.Phase.Init || phase == Def.Phase.Pause || phase == Def.Phase.Resume || phase == Def.Phase.Lost || phase == Def.Phase.Win || phase == Def.Phase.MainSetup || phase == Def.Phase.PlaySetup || phase == Def.Phase.Trial || phase == Def.Phase.Ranking)
            {
                pixmap.DrawBackground();
                if (fadeOutPhase == Def.Phase.None && missionToStart1 != -1)
                {
                    missionToStart2 = missionToStart1;
                    missionToStart1 = -1;
                }
                else
                {
                    DrawBackgroundFade();
                    if (fadeOutPhase == Def.Phase.None)
                    {
                        DrawButtonsBackground();
                        inputPad.Draw();
                        DrawButtonsText();
                    }
                }
            }
            else if (phase == Def.Phase.Play)
            {
                decor.Build();
                inputPad.Draw();
            }
            if (phase == Def.Phase.Wait)
            {
                DrawWaitProgress();
            }
            base.Draw(gameTime);
        }

        private void DrawBackgroundFade()
        {
            if (phase == Def.Phase.Init)
            {
                double num = Math.Min(phaseTime / 20.0, 1.0);
                TinyRect rect;
                double opacity;
                if (fadeOutPhase == Def.Phase.MainSetup)
                {
                    num = (1.0 - num) * (1.0 - num);
                    TinyRect tinyRect = default;
                    tinyRect.Left = (int)(720.0 - 640.0 * num);
                    tinyRect.Right = (int)(1360.0 - 640.0 * num);
                    tinyRect.Top = 0;
                    tinyRect.Bottom = 160;
                    rect = tinyRect;
                    opacity = num * num;
                }
                else
                {
                    num = fadeOutPhase != 0 ? 1.0 - num * 2.0 : 1.0 - (1.0 - num) * (1.0 - num);
                    TinyRect tinyRect2 = default;
                    tinyRect2.Left = 80;
                    tinyRect2.Right = 720;
                    tinyRect2.Top = (int)(-160.0 + num * 160.0);
                    tinyRect2.Bottom = (int)(0.0 + num * 160.0);
                    rect = tinyRect2;
                    opacity = 1.0;
                }
                pixmap.DrawIcon(15, 0, rect, opacity, false);
            }
            if (phase == Def.Phase.Init)
            {
                double num = Math.Min(phaseTime / 20.0, 1.0);
                double opacity;
                if (fadeOutPhase == Def.Phase.MainSetup)
                {
                    opacity = (1.0 - num) * (1.0 - num);
                    num = 1.0;
                }
                else if (fadeOutPhase == Def.Phase.None)
                {
                    num = 0.5 + num / 2.0;
                    opacity = Math.Min(num * num, 1.0);
                }
                else
                {
                    opacity = 1.0 - num;
                    num = 1.0 + num * 10.0;
                }
                TinyRect tinyRect3 = default;
                tinyRect3.Left = (int)(468.0 - 205.0 * num);
                tinyRect3.Right = (int)(468.0 + 205.0 * num);
                tinyRect3.Top = (int)(280.0 - 190.0 * num);
                tinyRect3.Bottom = (int)(280.0 + 190.0 * num);
                TinyRect rect = tinyRect3;
                pixmap.DrawIcon(16, 0, rect, opacity, 0.0, false);
            }
            if (phase == Def.Phase.Pause || phase == Def.Phase.Resume)
            {
                if (fadeOutPhase == Def.Phase.Play)
                {
                    double num = Math.Min(phaseTime / 20.0, 1.0);
                    double opacity = 1.0 - num;
                    num = 1.0 + num * 10.0;
                    TinyRect tinyRect4 = default;
                    tinyRect4.Left = (int)(418.0 - 205.0 * num);
                    tinyRect4.Right = (int)(418.0 + 205.0 * num);
                    tinyRect4.Top = (int)(190.0 - 190.0 * num);
                    tinyRect4.Bottom = (int)(190.0 + 190.0 * num);
                    TinyRect rect = tinyRect4;
                    pixmap.DrawIcon(16, 0, rect, opacity, 0.0, false);
                }
                else if (fadeOutPhase == Def.Phase.PlaySetup)
                {
                    double num = Math.Min(phaseTime / 20.0, 1.0);
                    num *= num;
                    TinyRect tinyRect5 = default;
                    tinyRect5.Left = (int)(213.0 + 800.0 * num);
                    tinyRect5.Right = (int)(623.0 + 800.0 * num);
                    tinyRect5.Top = 0;
                    tinyRect5.Bottom = 0;
                    TinyRect rect = tinyRect5;
                    pixmap.DrawIcon(16, 0, rect, 1.0, 0.0, false);
                }
                else
                {
                    double num;
                    if (fadeOutPhase == Def.Phase.None)
                    {
                        num = Math.Min(phaseTime / 15.0, 1.0);
                    }
                    else
                    {
                        num = Math.Min(phaseTime / 15.0, 1.0);
                        num = 1.0 - num;
                    }
                    TinyRect tinyRect6 = default;
                    tinyRect6.Left = (int)(418.0 - 205.0 * num);
                    tinyRect6.Right = (int)(418.0 + 205.0 * num);
                    tinyRect6.Top = (int)(190.0 - 190.0 * num);
                    tinyRect6.Bottom = (int)(190.0 + 190.0 * num);
                    TinyRect rect = tinyRect6;
                    double rotation = 0.0;
                    if (num < 1.0)
                    {
                        rotation = (1.0 - num) * (1.0 - num) * 360.0 * 1.0;
                    }
                    if (rect.Width > 0 && rect.Height > 0)
                    {
                        pixmap.DrawIcon(16, 0, rect, 1.0, rotation, false);
                    }
                }
            }
            if (phase == Def.Phase.MainSetup || phase == Def.Phase.PlaySetup)
            {
                double num = Math.Min(phaseTime / 20.0, 1.0);
                num = 1.0 - (1.0 - num) * (1.0 - num);
                double num2;
                if (phaseTime < 20)
                {
                    num2 = phaseTime / 20.0;
                    num2 = 1.0 - (1.0 - num2) * (1.0 - num2);
                }
                else
                {
                    num2 = 1.0 + (phaseTime - 20.0) / 400.0;
                }
                if (fadeOutPhase != 0)
                {
                    num = 1.0 - num;
                    num2 = 1.0 - num2;
                }
                TinyRect tinyRect7 = default;
                tinyRect7.Left = (int)(720.0 - 640.0 * num);
                tinyRect7.Right = (int)(1360.0 - 640.0 * num);
                tinyRect7.Top = 0;
                tinyRect7.Bottom = 160;
                TinyRect rect = tinyRect7;
                pixmap.DrawIcon(15, 0, rect, num * num, false);
                TinyRect tinyRect8 = default;
                tinyRect8.Left = 487;
                tinyRect8.Right = 713;
                tinyRect8.Top = 148;
                tinyRect8.Bottom = 374;
                TinyRect rect2 = tinyRect8;
                TinyRect tinyRect9 = default;
                tinyRect9.Left = 118;
                tinyRect9.Right = 570;
                tinyRect9.Top = 268;
                tinyRect9.Bottom = 720;
                TinyRect rect3 = tinyRect9;
                double opacity = 0.5 - num * 0.4;
                double rotation = (0.0 - num2) * 100.0 * 2.5;
                pixmap.DrawIcon(17, 0, rect2, opacity, rotation, false);
                pixmap.DrawIcon(17, 0, rect3, opacity, (0.0 - rotation) * 0.5, false);
            }
            if (phase == Def.Phase.Lost)
            {
                double num = Math.Min(phaseTime / 100.0, 1.0);
                TinyRect tinyRect10 = default;
                tinyRect10.Left = (int)(418.0 - 205.0 * num);
                tinyRect10.Right = (int)(418.0 + 205.0 * num);
                tinyRect10.Top = (int)(238.0 - 190.0 * num);
                tinyRect10.Bottom = (int)(238.0 + 190.0 * num);
                TinyRect rect = tinyRect10;
                double rotation = 0.0;
                if (num < 1.0)
                {
                    rotation = (1.0 - num) * (1.0 - num) * 360.0 * 6.0;
                }
                if (rect.Width > 0 && rect.Height > 0)
                {
                    pixmap.DrawIcon(16, 0, rect, 1.0, rotation, false);
                }
            }
            if (phase == Def.Phase.Win)
            {
                double num = Math.Sin(phaseTime / 3.0) / 2.0 + 1.0;
                TinyRect tinyRect11 = default;
                tinyRect11.Left = (int)(418.0 - 205.0 * num);
                tinyRect11.Right = (int)(418.0 + 205.0 * num);
                tinyRect11.Top = (int)(238.0 - 190.0 * num);
                tinyRect11.Bottom = (int)(238.0 + 190.0 * num);
                TinyRect rect = tinyRect11;
                pixmap.DrawIcon(16, 0, rect, 1.0, 0.0, false);
            }
        }

        private void DrawButtonsBackground()
        {
            if (phase == Def.Phase.Init)
            {
                TinyRect drawBounds = pixmap.DrawBounds;
                int width = drawBounds.Width;
                int height = drawBounds.Height;
                TinyRect tinyRect = default;
                tinyRect.Left = 10;
                tinyRect.Right = 260;
                tinyRect.Top = height - 325;
                tinyRect.Bottom = height - 10;
                TinyRect rect = tinyRect;
                pixmap.DrawIcon(14, 15, rect, 0.3, false);
                TinyRect tinyRect2 = default;
                tinyRect2.Left = width - 170;
                tinyRect2.Right = width - 10;
                tinyRect2.Top = height - (IsTrialMode || IsRankingMode ? 325 : 195);
                tinyRect2.Bottom = height - 10;
                rect = tinyRect2;
                pixmap.DrawIcon(14, 15, rect, 0.3, false);
            }
        }

        private void DrawButtonsText()
        {
            if (phase == Def.Phase.Init)
            {
                DrawButtonGamerText(Def.ButtonGlyph.InitGamerA, 0);
                DrawButtonGamerText(Def.ButtonGlyph.InitGamerB, 1);
                DrawButtonGamerText(Def.ButtonGlyph.InitGamerC, 2);
                DrawTextUnderButton(Def.ButtonGlyph.InitPlay, MyResource.TX_BUTTON_PLAY);
                DrawTextRightButton(Def.ButtonGlyph.InitSetup, MyResource.TX_BUTTON_SETUP);
                if (IsTrialMode)
                {
                    DrawTextUnderButton(Def.ButtonGlyph.InitBuy, MyResource.TX_BUTTON_BUY);
                }
                if (IsRankingMode)
                {
                    DrawTextUnderButton(Def.ButtonGlyph.InitRanking, MyResource.TX_BUTTON_RANKING);
                }
            }
            if (phase == Def.Phase.Pause)
            {
                DrawTextUnderButton(Def.ButtonGlyph.PauseMenu, MyResource.TX_BUTTON_MENU);
                if (mission != 1)
                {
                    DrawTextUnderButton(Def.ButtonGlyph.PauseBack, MyResource.TX_BUTTON_BACK);
                }
                DrawTextUnderButton(Def.ButtonGlyph.PauseSetup, MyResource.TX_BUTTON_SETUP);
                if (mission != 1 && mission % 10 != 0)
                {
                    DrawTextUnderButton(Def.ButtonGlyph.PauseRestart, MyResource.TX_BUTTON_RESTART);
                }
                DrawTextUnderButton(Def.ButtonGlyph.PauseContinue, MyResource.TX_BUTTON_CONTINUE);
            }
            if (phase == Def.Phase.Resume)
            {
                DrawTextUnderButton(Def.ButtonGlyph.ResumeMenu, MyResource.TX_BUTTON_MENU);
                DrawTextUnderButton(Def.ButtonGlyph.ResumeContinue, MyResource.TX_BUTTON_CONTINUE);
            }
            if (phase == Def.Phase.MainSetup || phase == Def.Phase.PlaySetup)
            {
                DrawTextRightButton(Def.ButtonGlyph.SetupSounds, MyResource.TX_BUTTON_SETUP_SOUNDS);
                DrawTextRightButton(Def.ButtonGlyph.SetupJump, MyResource.TX_BUTTON_SETUP_JUMP);
                DrawTextRightButton(Def.ButtonGlyph.SetupZoom, MyResource.TX_BUTTON_SETUP_ZOOM);
                DrawTextRightButton(Def.ButtonGlyph.SetupAccel, MyResource.TX_BUTTON_SETUP_ACCEL);
                if (phase == Def.Phase.MainSetup)
                {
                    string text = string.Format(MyResource.LoadString(MyResource.TX_BUTTON_SETUP_RESET), new string((char)(65 + gameData.SelectedGamer), 1));
                    DrawTextRightButton(Def.ButtonGlyph.SetupReset, text);
                }
            }
            if (phase == Def.Phase.Trial)
            {
                TinyPoint tinyPoint = default;
                tinyPoint.X = 360;
                tinyPoint.Y = 50;
                TinyPoint pos = tinyPoint;
                Text.DrawText(pixmap, pos, MyResource.LoadString(MyResource.TX_TRIAL1), 0.9);
                pos.Y += 40;
                Text.DrawText(pixmap, pos, MyResource.LoadString(MyResource.TX_TRIAL2), 0.7);
                pos.Y += 25;
                Text.DrawText(pixmap, pos, MyResource.LoadString(MyResource.TX_TRIAL3), 0.7);
                pos.Y += 25;
                Text.DrawText(pixmap, pos, MyResource.LoadString(MyResource.TX_TRIAL4), 0.7);
                pos.Y += 25;
                Text.DrawText(pixmap, pos, MyResource.LoadString(MyResource.TX_TRIAL5), 0.7);
                pos.Y += 25;
                Text.DrawText(pixmap, pos, MyResource.LoadString(MyResource.TX_TRIAL6), 0.7);
                DrawTextUnderButton(Def.ButtonGlyph.TrialBuy, MyResource.TX_BUTTON_BUY);
                DrawTextUnderButton(Def.ButtonGlyph.TrialCancel, MyResource.TX_BUTTON_BACK);
            }
            if (phase == Def.Phase.Ranking)
            {
                DrawTextUnderButton(Def.ButtonGlyph.RankingContinue, MyResource.TX_BUTTON_BACK);
            }
        }

        private void DrawButtonGamerText(Def.ButtonGlyph glyph, int gamer)
        {
            TinyRect buttonRect = inputPad.GetButtonRect(glyph);
            int nbVies;
            int mainDoors;
            int secondaryDoors;
            gameData.GetGamerInfo(gamer, out nbVies, out mainDoors, out secondaryDoors);
            TinyPoint tinyPoint = default;
            tinyPoint.X = buttonRect.Right + 5 - pixmap.Origin.X;
            tinyPoint.Y = buttonRect.Top + 3 - pixmap.Origin.Y;
            TinyPoint pos = tinyPoint;
            string text = string.Format(MyResource.LoadString(MyResource.TX_GAMER_TITLE), new string((char)(65 + gamer), 1));
            Text.DrawText(pixmap, pos, text, 0.7);
            TinyPoint tinyPoint2 = default;
            tinyPoint2.X = buttonRect.Right + 5 - pixmap.Origin.X;
            tinyPoint2.Y = buttonRect.Top + 25 - pixmap.Origin.Y;
            pos = tinyPoint2;
            text = string.Format(MyResource.LoadString(MyResource.TX_GAMER_MDOORS), mainDoors);
            Text.DrawText(pixmap, pos, text, 0.45);
            TinyPoint tinyPoint3 = default;
            tinyPoint3.X = buttonRect.Right + 5 - pixmap.Origin.X;
            tinyPoint3.Y = buttonRect.Top + 39 - pixmap.Origin.Y;
            pos = tinyPoint3;
            text = string.Format(MyResource.LoadString(MyResource.TX_GAMER_SDOORS), secondaryDoors);
            Text.DrawText(pixmap, pos, text, 0.45);
            TinyPoint tinyPoint4 = default;
            tinyPoint4.X = buttonRect.Right + 5 - pixmap.Origin.X;
            tinyPoint4.Y = buttonRect.Top + 53 - pixmap.Origin.Y;
            pos = tinyPoint4;
            text = string.Format(MyResource.LoadString(MyResource.TX_GAMER_LIFES), nbVies);
            Text.DrawText(pixmap, pos, text, 0.45);
        }

        private void DrawTextRightButton(Def.ButtonGlyph glyph, int res)
        {
            DrawTextRightButton(glyph, MyResource.LoadString(res));
        }

        private void DrawTextRightButton(Def.ButtonGlyph glyph, string text)
        {
            TinyRect buttonRect = inputPad.GetButtonRect(glyph);
            string[] array = text.Split('\n');
            if (array.Length == 2)
            {
                TinyPoint tinyPoint = default;
                tinyPoint.X = buttonRect.Right + 10 - pixmap.Origin.X;
                tinyPoint.Y = (buttonRect.Top + buttonRect.Bottom) / 2 - 20 - pixmap.Origin.Y;
                TinyPoint pos = tinyPoint;
                Text.DrawText(pixmap, pos, array[0], 0.7);
                pos.Y += 24;
                Text.DrawText(pixmap, pos, array[1], 0.7);
            }
            else
            {
                TinyPoint tinyPoint2 = default;
                tinyPoint2.X = buttonRect.Right + 10 - pixmap.Origin.X;
                tinyPoint2.Y = (buttonRect.Top + buttonRect.Bottom) / 2 - 8 - pixmap.Origin.Y;
                TinyPoint pos2 = tinyPoint2;
                Text.DrawText(pixmap, pos2, text, 0.7);
            }
        }

        private void DrawTextUnderButton(Def.ButtonGlyph glyph, int res)
        {
            TinyRect buttonRect = inputPad.GetButtonRect(glyph);
            TinyPoint tinyPoint = default;
            tinyPoint.X = (buttonRect.Left + buttonRect.Right) / 2 - pixmap.Origin.X;
            tinyPoint.Y = buttonRect.Bottom + 2 - pixmap.Origin.Y;
            TinyPoint pos = tinyPoint;
            string text = MyResource.LoadString(res);
            Text.DrawTextCenter(pixmap, pos, text, 0.7);
        }

        private void DrawWaitProgress()
        {
            if (continueMission != 0)
            {
                return;
            }
            for (int i = 0; i < waitTable.Length; i++)
            {
                if (waitProgress <= waitTable[i * 2])
                {
                    waitJauge.SetLevel((int)waitTable[i * 2 + 1]);
                    break;
                }
            }
            waitJauge.Draw();
        }

        private void DrawDebug()
        {
            TinyPoint tinyPoint = default;
            tinyPoint.X = 10;
            tinyPoint.Y = 20;
            TinyPoint pos = tinyPoint;
            Text.DrawText(pixmap, pos, inputPad.TotalTouch.ToString(), 1.0);
        }

        private void SetGamer(int gamer)
        {
            gameData.SelectedGamer = gamer;
            gameData.Write();
        }

        private void SetPhase(Def.Phase phase)
        {
            SetPhase(phase, 0);
        }

        private void SetPhase(Def.Phase phase, int mission)
        {
            if (mission != -2)
            {
                if (missionToStart2 == -1)
                {
                    if ((this.phase == Def.Phase.Init || this.phase == Def.Phase.MainSetup || this.phase == Def.Phase.PlaySetup || this.phase == Def.Phase.Pause || this.phase == Def.Phase.Resume) && fadeOutPhase == Def.Phase.None)
                    {
                        fadeOutPhase = phase;
                        fadeOutMission = mission;
                        phaseTime = 0;
                        return;
                    }
                    if (phase == Def.Phase.Play)
                    {
                        fadeOutPhase = Def.Phase.None;
                        if (fadeOutMission != -1)
                        {
                            missionToStart1 = fadeOutMission;
                            return;
                        }
                        mission = fadeOutMission;
                        decor.LoadImages();
                    }
                }
                else
                {
                    mission = missionToStart2;
                }
            }
            this.phase = phase;
            fadeOutPhase = Def.Phase.None;
            inputPad.Phase = this.phase;
            playSetup = this.phase == Def.Phase.PlaySetup;
            isTrialMode = Guide.IsTrialMode;
            phaseTime = 0;
            missionToStart2 = -1;
            decor.StopSound();
            switch (this.phase)
            {
                case Def.Phase.Init:
                    pixmap.BackgroundCache("init");
                    break;
                case Def.Phase.Pause:
                case Def.Phase.Resume:
                    pixmap.BackgroundCache("pause");
                    break;
                case Def.Phase.Lost:
                    pixmap.BackgroundCache("lost");
                    break;
                case Def.Phase.Win:
                    pixmap.BackgroundCache("win");
                    break;
                case Def.Phase.MainSetup:
                case Def.Phase.PlaySetup:
                    pixmap.BackgroundCache("setup");
                    break;
                case Def.Phase.Trial:
                    pixmap.BackgroundCache("trial");
                    break;
                case Def.Phase.Ranking:
                    pixmap.BackgroundCache("pause");
                    break;
                case Def.Phase.Play:
                    decor.DrawBounds = pixmap.DrawBounds;
                    break;
            }
            if (this.phase == Def.Phase.Play && mission > 0)
            {
                StartMission(mission);
            }
        }

        private void MemorizeGamerProgress()
        {
            gameData.NbVies = decor.GetNbVies();
            decor.MemorizeDoors(gameData);
            gameData.Write();
        }

        public void ToggleFullScreen()
        {
            graphics.ToggleFullScreen();
        }
        public bool IsFullScreen() { return graphics.IsFullScreen; }

        public GraphicsDeviceManager getGraphics()
        {
            return graphics;
        }
    }
}