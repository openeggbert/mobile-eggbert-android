// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.InputPad
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using WindowsPhoneSpeedyBlupi;
using static WindowsPhoneSpeedyBlupi.Def;

namespace WindowsPhoneSpeedyBlupi
{
    public class InputPad
    {
        private static readonly int padSize = 140;

        private readonly Game1 game1;

        private readonly Decor decor;

        private readonly Pixmap pixmap;

        private readonly Sound sound;

        private readonly GameData gameData;

        private readonly List<Def.ButtonGlygh> pressedGlyphs;

        private readonly Accelerometer accelSensor;

        private readonly Slider accelSlider;

        private bool padPressed;

        private bool showCheatMenu;

        private TinyPoint padTouchPos;

        private Def.ButtonGlygh lastButtonDown;

        private Def.ButtonGlygh buttonPressed;

        private int touchCount;

        private bool accelStarted;

        private bool accelActive;

        private double accelSpeedX;

        private bool accelLastState;

        private bool accelWaitZero;

        private int mission;

        public Def.Phase Phase { get; set; }

        public int SelectedGamer { get; set; }

        public TinyPoint PixmapOrigin { get; set; }

        public int TotalTouch
        {
            get
            {
                return touchCount;
            }
        }

        public Def.ButtonGlygh ButtonPressed
        {
            get
            {
                Def.ButtonGlygh result = buttonPressed;
                buttonPressed = Def.ButtonGlygh.None;
                return result;
            }
        }

        public bool ShowCheatMenu
        {
            get
            {
                return showCheatMenu;
            }
            set
            {
                showCheatMenu = value;
            }
        }

        private IEnumerable<Def.ButtonGlygh> ButtonGlyphs
        {
            get
            {
                switch (Phase)
                {
                    case Def.Phase.Init:
                        yield return Def.ButtonGlygh.InitGamerA;
                        yield return Def.ButtonGlygh.InitGamerB;
                        yield return Def.ButtonGlygh.InitGamerC;
                        yield return Def.ButtonGlygh.InitSetup;
                        yield return Def.ButtonGlygh.InitPlay;
                        if (game1.IsTrialMode)
                        {
                            yield return Def.ButtonGlygh.InitBuy;
                        }
                        if (game1.IsRankingMode)
                        {
                            yield return Def.ButtonGlygh.InitRanking;
                        }
                        break;
                    case Def.Phase.Play:
                        yield return Def.ButtonGlygh.PlayPause;
                        yield return Def.ButtonGlygh.PlayAction;
                        yield return Def.ButtonGlygh.PlayJump;
                        if (accelStarted)
                        {
                            yield return Def.ButtonGlygh.PlayDown;
                        }
                        yield return Def.ButtonGlygh.Cheat11;
                        yield return Def.ButtonGlygh.Cheat12;
                        yield return Def.ButtonGlygh.Cheat21;
                        yield return Def.ButtonGlygh.Cheat22;
                        yield return Def.ButtonGlygh.Cheat31;
                        yield return Def.ButtonGlygh.Cheat32;
                        break;
                    case Def.Phase.Pause:
                        yield return Def.ButtonGlygh.PauseMenu;
                        if (mission != 1)
                        {
                            yield return Def.ButtonGlygh.PauseBack;
                        }
                        yield return Def.ButtonGlygh.PauseSetup;
                        if (mission != 1 && mission % 10 != 0)
                        {
                            yield return Def.ButtonGlygh.PauseRestart;
                        }
                        yield return Def.ButtonGlygh.PauseContinue;
                        break;
                    case Def.Phase.Resume:
                        yield return Def.ButtonGlygh.ResumeMenu;
                        yield return Def.ButtonGlygh.ResumeContinue;
                        break;
                    case Def.Phase.Lost:
                    case Def.Phase.Win:
                        yield return Def.ButtonGlygh.WinLostReturn;
                        break;
                    case Def.Phase.Trial:
                        yield return Def.ButtonGlygh.TrialBuy;
                        yield return Def.ButtonGlygh.TrialCancel;
                        break;
                    case Def.Phase.MainSetup:
                        yield return Def.ButtonGlygh.SetupSounds;
                        yield return Def.ButtonGlygh.SetupJump;
                        yield return Def.ButtonGlygh.SetupZoom;
                        yield return Def.ButtonGlygh.SetupAccel;
                        yield return Def.ButtonGlygh.SetupReset;
                        yield return Def.ButtonGlygh.SetupReturn;
                        break;
                    case Def.Phase.PlaySetup:
                        yield return Def.ButtonGlygh.SetupSounds;
                        yield return Def.ButtonGlygh.SetupJump;
                        yield return Def.ButtonGlygh.SetupZoom;
                        yield return Def.ButtonGlygh.SetupAccel;
                        yield return Def.ButtonGlygh.SetupReturn;
                        break;
                    case Def.Phase.Ranking:
                        yield return Def.ButtonGlygh.RankingContinue;
                        break;
                }
                if (showCheatMenu)
                {
                    yield return Def.ButtonGlygh.Cheat1;
                    yield return Def.ButtonGlygh.Cheat2;
                    yield return Def.ButtonGlygh.Cheat3;
                    yield return Def.ButtonGlygh.Cheat4;
                    yield return Def.ButtonGlygh.Cheat5;
                    yield return Def.ButtonGlygh.Cheat6;
                    yield return Def.ButtonGlygh.Cheat7;
                    yield return Def.ButtonGlygh.Cheat8;
                    yield return Def.ButtonGlygh.Cheat9;
                }
            }
        }

        private TinyPoint PadCenter
        {
            get
            {
                TinyRect drawBounds = pixmap.DrawBounds;
                if (gameData.JumpRight)
                {
                    TinyPoint result = default(TinyPoint);
                    result.X = 100;
                    result.Y = drawBounds.Height - 100;
                    return result;
                }
                TinyPoint result2 = default(TinyPoint);
                result2.X = drawBounds.Width - 100;
                result2.Y = drawBounds.Height - 100;
                return result2;
            }
        }

        public InputPad(Game1 game1, Decor decor, Pixmap pixmap, Sound sound, GameData gameData)
        {
            //IL_0037: Unknown result type (might be due to invalid IL or missing references)
            //IL_0041: Expected O, but got Unknown
            this.game1 = game1;
            this.decor = decor;
            this.pixmap = pixmap;
            this.sound = sound;
            this.gameData = gameData;
            pressedGlyphs = new List<Def.ButtonGlygh>();
            accelSensor = new Accelerometer();
            accelSensor.CurrentValueChanged += HandleAccelSensorCurrentValueChanged;
            accelSlider = new Slider
            {
                TopLeftCorner = new TinyPoint
                {
                    X = 320,
                    Y = 400
                },
                Value = this.gameData.AccelSensitivity
            };
            lastButtonDown = Def.ButtonGlygh.None;
            buttonPressed = Def.ButtonGlygh.None;
        }

        public void StartMission(int mission)
        {
            this.mission = mission;
            accelWaitZero = true;
        }

        private TinyPoint createTinyPoint(int x, int y)
        {
            TinyPoint tinyPoint = new TinyPoint();
            tinyPoint.X = x;
            tinyPoint.Y = y;
            return tinyPoint;
        }
        public void Update()
        {
            pressedGlyphs.Clear();
            if (accelActive != gameData.AccelActive)
            {
                accelActive = gameData.AccelActive;
                if (accelActive)
                {
                    StartAccel();
                }
                else
                {
                    StopAccel();
                }
            }
            double horizontalChange = 0.0;
            double verticalChange = 0.0;
            int num3 = 0;
            padPressed = false;
            Def.ButtonGlygh buttonGlygh = Def.ButtonGlygh.None;
            TouchCollection touches = TouchPanel.GetState();
            touchCount = touches.Count;
            List<TinyPoint> touchesOrClicks = new List<TinyPoint>();
            foreach (TouchLocation item in touches)
            {
                if (item.State == TouchLocationState.Pressed || item.State == TouchLocationState.Moved)
                {
                    TinyPoint tinyPoint = default(TinyPoint);
                    tinyPoint.X = (int)item.Position.X;
                    tinyPoint.Y = (int)item.Position.Y;
                    touchesOrClicks.Add(tinyPoint);
                }
            }

            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                touchCount++;
                TinyPoint click = new TinyPoint();
                click.X = mouseState.X;
                click.Y = mouseState.Y;
                touchesOrClicks.Add(click);
            }


            float screenWidth = game1.getGraphics().GraphicsDevice.Viewport.Width;
            float screenHeight = game1.getGraphics().GraphicsDevice.Viewport.Height;
            float screenRatio = screenWidth / screenHeight;


            //if (screenRatio < 1.3333333333333333 && false)
            {
                for (int i = 0; i < touchesOrClicks.Count; i++)
                {

                    //if (touchOrClick.X == -1) continue;
                    var touchOrClick = touchesOrClicks[i];

                    float originalX = touchOrClick.X;
                    float originalY = touchOrClick.Y;


                    float widthHeightRatio = screenWidth / screenHeight;
                    float heightRatio = 480 / screenHeight;
                    float widthRatio = 640 / screenWidth;
                    Debug.WriteLine("-----");
                    Debug.WriteLine("originalX=" + originalX);
                    Debug.WriteLine("originalY=" + originalY);
                    Debug.WriteLine("heightRatio=" + heightRatio);
                    Debug.WriteLine("widthRatio=" + widthRatio);
                    Debug.WriteLine("widthHeightRatio=" + widthHeightRatio);
                    if (screenHeight> 480) {
                    touchOrClick.X = (int)(originalX * heightRatio);
                    touchOrClick.Y = (int)(originalY * heightRatio);
                    touchesOrClicks[i] = touchOrClick;
                    }

                    Debug.WriteLine("new X" + touchOrClick.X);
                    Debug.WriteLine("new Y" + touchOrClick.Y);
                    

                }
            }

            KeyboardState newState = Keyboard.GetState();
            {
                if (newState.IsKeyDown(Keys.LeftControl)) touchesOrClicks.Add(createTinyPoint(-1, Misc.keyboardPressToInt(KeyboardPress.LeftControl)));
                if (newState.IsKeyDown(Keys.Up)) touchesOrClicks.Add(createTinyPoint(-1, Misc.keyboardPressToInt(KeyboardPress.Up)));
                if (newState.IsKeyDown(Keys.Right)) touchesOrClicks.Add(createTinyPoint(-1, Misc.keyboardPressToInt(KeyboardPress.Right)));
                if (newState.IsKeyDown(Keys.Down)) touchesOrClicks.Add(createTinyPoint(-1, Misc.keyboardPressToInt(KeyboardPress.Down)));
                if (newState.IsKeyDown(Keys.Left)) touchesOrClicks.Add(createTinyPoint(-1, Misc.keyboardPressToInt(KeyboardPress.Left)));
                if (newState.IsKeyDown(Keys.Space)) touchesOrClicks.Add(createTinyPoint(-1, Misc.keyboardPressToInt(KeyboardPress.Space)));
            }
            if (newState.IsKeyDown(Keys.F11))
            {
                game1.ToggleFullScreen ();
                Debug.WriteLine("F11 was pressed.");
            }

            Boolean keyPressedUp = false;
            Boolean keyPressedDown = false;
            Boolean keyPressedLeft = false;
            Boolean keyPressedRight = false;
            foreach (TinyPoint touchOrClick in touchesOrClicks)
            {
                Boolean keyboardPressed = false;
                if (touchOrClick.X == -1)
                {
                    keyboardPressed = true;
                }
                KeyboardPress keyboardPress = keyboardPressed ? Misc.intToKeyboardPress(touchOrClick.Y) : KeyboardPress.None;
                keyPressedUp = keyboardPress == KeyboardPress.Up ? true : keyPressedUp;
                keyPressedDown = keyboardPress == KeyboardPress.Down ? true : keyPressedDown;
                keyPressedLeft = keyboardPress == KeyboardPress.Left ? true : keyPressedLeft;
                keyPressedRight = keyboardPress == KeyboardPress.Right ? true : keyPressedRight;

                {
                    TinyPoint tinyPoint2 = keyboardPressed ? createTinyPoint(1, 1) : touchOrClick;
                    if (!accelStarted && Misc.IsInside(GetPadBounds(PadCenter, padSize), tinyPoint2))
                    {
                        padPressed = true;
                        padTouchPos = tinyPoint2;
                    }
                    if (keyboardPress == KeyboardPress.Up || keyboardPress == KeyboardPress.Right || keyboardPress == KeyboardPress.Down || keyboardPress == KeyboardPress.Left)
                    {
                        padPressed = true;
                    }
                    Debug.WriteLine("padPressed=" + padPressed);
                    Def.ButtonGlygh buttonGlygh2 = ButtonDetect(tinyPoint2);
                    Debug.WriteLine("buttonGlyph2 =" + buttonGlygh2);
                    if (buttonGlygh2 != 0)
                    {
                        pressedGlyphs.Add(buttonGlygh2);
                    }
                    if (keyboardPressed)
                    {
                        switch (keyboardPress)
                        {
                            case KeyboardPress.LeftControl: buttonGlygh2 = Def.ButtonGlygh.PlayJump; pressedGlyphs.Add(buttonGlygh2); break;
                            case KeyboardPress.Space: buttonGlygh2 = Def.ButtonGlygh.PlayAction; pressedGlyphs.Add(buttonGlygh2); break;
                        }
                    }

                    if ((Phase == Def.Phase.MainSetup || Phase == Def.Phase.PlaySetup) && accelSlider.Move(tinyPoint2))
                    {
                        gameData.AccelSensitivity = accelSlider.Value;
                    }
                    switch (buttonGlygh2)
                    {
                        case Def.ButtonGlygh.PlayJump:
                            Debug.WriteLine("Jumping detected");
                            accelWaitZero = false;
                            num3 |= 1;
                            break;
                        case Def.ButtonGlygh.PlayDown:
                            accelWaitZero = false;
                            num3 |= 4;
                            break;
                        case Def.ButtonGlygh.InitGamerA:
                        case Def.ButtonGlygh.InitGamerB:
                        case Def.ButtonGlygh.InitGamerC:
                        case Def.ButtonGlygh.InitSetup:
                        case Def.ButtonGlygh.InitPlay:
                        case Def.ButtonGlygh.InitBuy:
                        case Def.ButtonGlygh.InitRanking:
                        case Def.ButtonGlygh.WinLostReturn:
                        case Def.ButtonGlygh.TrialBuy:
                        case Def.ButtonGlygh.TrialCancel:
                        case Def.ButtonGlygh.SetupSounds:
                        case Def.ButtonGlygh.SetupJump:
                        case Def.ButtonGlygh.SetupZoom:
                        case Def.ButtonGlygh.SetupAccel:
                        case Def.ButtonGlygh.SetupReset:
                        case Def.ButtonGlygh.SetupReturn:
                        case Def.ButtonGlygh.PauseMenu:
                        case Def.ButtonGlygh.PauseBack:
                        case Def.ButtonGlygh.PauseSetup:
                        case Def.ButtonGlygh.PauseRestart:
                        case Def.ButtonGlygh.PauseContinue:
                        case Def.ButtonGlygh.PlayPause:
                        case Def.ButtonGlygh.PlayAction:
                        case Def.ButtonGlygh.ResumeMenu:
                        case Def.ButtonGlygh.ResumeContinue:
                        case Def.ButtonGlygh.RankingContinue:
                        case Def.ButtonGlygh.Cheat11:
                        case Def.ButtonGlygh.Cheat12:
                        case Def.ButtonGlygh.Cheat21:
                        case Def.ButtonGlygh.Cheat22:
                        case Def.ButtonGlygh.Cheat31:
                        case Def.ButtonGlygh.Cheat32:
                        case Def.ButtonGlygh.Cheat1:
                        case Def.ButtonGlygh.Cheat2:
                        case Def.ButtonGlygh.Cheat3:
                        case Def.ButtonGlygh.Cheat4:
                        case Def.ButtonGlygh.Cheat5:
                        case Def.ButtonGlygh.Cheat6:
                        case Def.ButtonGlygh.Cheat7:
                        case Def.ButtonGlygh.Cheat8:
                        case Def.ButtonGlygh.Cheat9:
                            accelWaitZero = false;
                            buttonGlygh = buttonGlygh2;
                            showCheatMenu = false;
                            break;
                    }
                }
            }
            if (buttonGlygh != 0 && buttonGlygh != Def.ButtonGlygh.PlayAction && buttonGlygh != Def.ButtonGlygh.Cheat11 && buttonGlygh != Def.ButtonGlygh.Cheat12 && buttonGlygh != Def.ButtonGlygh.Cheat21 && buttonGlygh != Def.ButtonGlygh.Cheat22 && buttonGlygh != Def.ButtonGlygh.Cheat31 && buttonGlygh != Def.ButtonGlygh.Cheat32 && lastButtonDown == Def.ButtonGlygh.None)
            {
                TinyPoint tinyPoint3 = default(TinyPoint);
                tinyPoint3.X = 320;
                tinyPoint3.Y = 240;
                TinyPoint pos = tinyPoint3;
                sound.PlayImage(0, pos);
            }
            if (buttonGlygh == Def.ButtonGlygh.None && lastButtonDown != 0)
            {
                buttonPressed = lastButtonDown;
            }
            lastButtonDown = buttonGlygh;
            if (padPressed)
            {
                Debug.WriteLine("PadCenter.X=" + PadCenter.X);
                Debug.WriteLine("PadCenter.Y=" + PadCenter.Y);
                Debug.WriteLine("padTouchPos.X=" + padTouchPos.X);
                Debug.WriteLine("padTouchPos.Y=" + padTouchPos.Y);
                Debug.WriteLine("keyPressedUp=" + keyPressedUp);
                Debug.WriteLine("keyPressedDown=" + keyPressedDown);
                Debug.WriteLine("keyPressedLeft=" + keyPressedLeft);
                Debug.WriteLine(" keyPressedRight=" + keyPressedRight);
                {
                    if (keyPressedUp)
                    {
                        padTouchPos.Y = PadCenter.Y - 30;
                        padTouchPos.X = PadCenter.X;
                        if (keyPressedLeft) padTouchPos.X = PadCenter.X - 30;
                        if (keyPressedRight) padTouchPos.X = PadCenter.X + 30;
                    }
                    if (keyPressedDown) { 
                        padTouchPos.Y = PadCenter.Y + 30;
                        padTouchPos.X = PadCenter.X;
                        if (keyPressedLeft) padTouchPos.X = PadCenter.X - 30;
                        if (keyPressedRight) padTouchPos.X = PadCenter.X + 30;
                    }
                    if (keyPressedLeft) { 
                        padTouchPos.X = PadCenter.X - 30;
                        padTouchPos.Y = PadCenter.Y;
                        if (keyPressedUp) padTouchPos.Y = PadCenter.Y - 30;
                        if (keyPressedDown) padTouchPos.Y = PadCenter.Y + 30;
                    }
                    if (keyPressedRight) { 
                        padTouchPos.X = PadCenter.X + 30;
                        padTouchPos.Y = PadCenter.Y;
                        if (keyPressedUp) padTouchPos.Y = PadCenter.Y - 30;
                        if (keyPressedDown) padTouchPos.Y = PadCenter.Y + 30;
                    }
                }
                double horizontalPosition = padTouchPos.X - PadCenter.X;
                double verticalPosition = padTouchPos.Y - PadCenter.Y;

                if (horizontalPosition > 20.0)
                {
                    horizontalChange += 1.0;
                    Debug.WriteLine(" horizontalChange += 1.0;");
                }
                if (horizontalPosition < -20.0)
                {
                    horizontalChange -= 1.0;
                    Debug.WriteLine(" horizontalChange -= 1.0;");

                }
                if (verticalPosition > 20.0)
                {
                    verticalChange += 1.0;
                    Debug.WriteLine(" verticalPosition += 1.0;");

                }
                if (verticalPosition < -20.0)
                {
                    verticalChange -= 1.0;
                    Debug.WriteLine(" verticalPosition -= 1.0;");
                }

            }
            if (accelStarted)
            {
                horizontalChange = accelSpeedX;
                verticalChange = 0.0;
                if (((uint)num3 & 4u) != 0)
                {
                    verticalChange = 1.0;
                }
            }
            decor.SetSpeedX(horizontalChange);
            decor.SetSpeedY(verticalChange);
            decor.KeyChange(num3);
        }

        private Def.ButtonGlygh ButtonDetect(TinyPoint pos)
        {
            foreach (Def.ButtonGlygh item in ButtonGlyphs.Reverse())
            {
                int value = 0;
                if (item == Def.ButtonGlygh.PlayJump || item == Def.ButtonGlygh.PlayAction || item == Def.ButtonGlygh.PlayDown || item == Def.ButtonGlygh.PlayPause)
                {
                    value = 20;
                }
                TinyRect rect = Misc.Inflate(GetButtonRect(item), value);
                if (Misc.IsInside(rect, pos))
                {
                    return item;
                }
            }
            return Def.ButtonGlygh.None;
        }

        public void Draw()
        {
            if (!accelStarted && Phase == Def.Phase.Play)
            {
                pixmap.DrawIcon(14, 0, GetPadBounds(PadCenter, padSize / 2), 1.0, false);
                TinyPoint center = (padPressed ? padTouchPos : PadCenter);
                pixmap.DrawIcon(14, 1, GetPadBounds(center, padSize / 2), 1.0, false);
            }
            foreach (Def.ButtonGlygh buttonGlyph in ButtonGlyphs)
            {
                bool pressed = pressedGlyphs.Contains(buttonGlyph);
                bool selected = false;
                if (buttonGlyph >= Def.ButtonGlygh.InitGamerA && buttonGlyph <= Def.ButtonGlygh.InitGamerC)
                {
                    int num = (int)(buttonGlyph - 1);
                    selected = num == gameData.SelectedGamer;
                }
                if (buttonGlyph == Def.ButtonGlygh.SetupSounds)
                {
                    selected = gameData.Sounds;
                }
                if (buttonGlyph == Def.ButtonGlygh.SetupJump)
                {
                    selected = gameData.JumpRight;
                }
                if (buttonGlyph == Def.ButtonGlygh.SetupZoom)
                {
                    selected = gameData.AutoZoom;
                }
                if (buttonGlyph == Def.ButtonGlygh.SetupAccel)
                {
                    selected = gameData.AccelActive;
                }
                pixmap.DrawInputButton(GetButtonRect(buttonGlyph), buttonGlyph, pressed, selected);
            }
            if ((Phase == Def.Phase.MainSetup || Phase == Def.Phase.PlaySetup) && gameData.AccelActive)
            {
                accelSlider.Draw(pixmap);
            }
        }

        private TinyRect GetPadBounds(TinyPoint center, int radius)
        {
            TinyRect result = default(TinyRect);
            result.Left = center.X - radius;
            result.Right = center.X + radius;
            result.Top = center.Y - radius;
            result.Bottom = center.Y + radius;
            return result;
        }

        public TinyRect GetButtonRect(Def.ButtonGlygh glyph)
        {
            TinyRect drawBounds = pixmap.DrawBounds;
            double num = drawBounds.Width;
            double num2 = drawBounds.Height;
            double num3 = num2 / 5.0;
            double num4 = num2 * 140.0 / 480.0;
            double num5 = num2 / 3.5;
            if (glyph >= Def.ButtonGlygh.Cheat1 && glyph <= Def.ButtonGlygh.Cheat9)
            {
                int num6 = (int)(glyph - 35);
                TinyRect result = default(TinyRect);
                result.Left = 80 * num6;
                result.Right = 80 * (num6 + 1);
                result.Top = 0;
                result.Bottom = 80;
                return result;
            }
            switch (glyph)
            {
                case Def.ButtonGlygh.InitGamerA:
                    {
                        TinyRect result19 = default(TinyRect);
                        result19.Left = (int)(20.0 + num4 * 0.0);
                        result19.Right = (int)(20.0 + num4 * 0.5);
                        result19.Top = (int)(num2 - 20.0 - num4 * 2.1);
                        result19.Bottom = (int)(num2 - 20.0 - num4 * 1.6);
                        return result19;
                    }
                case Def.ButtonGlygh.InitGamerB:
                    {
                        TinyRect result18 = default(TinyRect);
                        result18.Left = (int)(20.0 + num4 * 0.0);
                        result18.Right = (int)(20.0 + num4 * 0.5);
                        result18.Top = (int)(num2 - 20.0 - num4 * 1.6);
                        result18.Bottom = (int)(num2 - 20.0 - num4 * 1.1);
                        return result18;
                    }
                case Def.ButtonGlygh.InitGamerC:
                    {
                        TinyRect result15 = default(TinyRect);
                        result15.Left = (int)(20.0 + num4 * 0.0);
                        result15.Right = (int)(20.0 + num4 * 0.5);
                        result15.Top = (int)(num2 - 20.0 - num4 * 1.1);
                        result15.Bottom = (int)(num2 - 20.0 - num4 * 0.6);
                        return result15;
                    }
                case Def.ButtonGlygh.InitSetup:
                    {
                        TinyRect result14 = default(TinyRect);
                        result14.Left = (int)(20.0 + num4 * 0.0);
                        result14.Right = (int)(20.0 + num4 * 0.5);
                        result14.Top = (int)(num2 - 20.0 - num4 * 0.5);
                        result14.Bottom = (int)(num2 - 20.0 - num4 * 0.0);
                        return result14;
                    }
                case Def.ButtonGlygh.InitPlay:
                    {
                        TinyRect result11 = default(TinyRect);
                        result11.Left = (int)(num - 20.0 - num4 * 1.0);
                        result11.Right = (int)(num - 20.0 - num4 * 0.0);
                        result11.Top = (int)(num2 - 40.0 - num4 * 1.0);
                        result11.Bottom = (int)(num2 - 40.0 - num4 * 0.0);
                        return result11;
                    }
                case Def.ButtonGlygh.InitBuy:
                case Def.ButtonGlygh.InitRanking:
                    {
                        TinyRect result10 = default(TinyRect);
                        result10.Left = (int)(num - 20.0 - num4 * 0.75);
                        result10.Right = (int)(num - 20.0 - num4 * 0.25);
                        result10.Top = (int)(num2 - 20.0 - num4 * 2.1);
                        result10.Bottom = (int)(num2 - 20.0 - num4 * 1.6);
                        return result10;
                    }
                case Def.ButtonGlygh.PauseMenu:
                    {
                        TinyRect result37 = default(TinyRect);
                        result37.Left = (int)((double)PixmapOrigin.X + num4 * -0.21);
                        result37.Right = (int)((double)PixmapOrigin.X + num4 * 0.79);
                        result37.Top = (int)((double)PixmapOrigin.Y + num4 * 2.2);
                        result37.Bottom = (int)((double)PixmapOrigin.Y + num4 * 3.2);
                        return result37;
                    }
                case Def.ButtonGlygh.PauseBack:
                    {
                        TinyRect result36 = default(TinyRect);
                        result36.Left = (int)((double)PixmapOrigin.X + num4 * 0.79);
                        result36.Right = (int)((double)PixmapOrigin.X + num4 * 1.79);
                        result36.Top = (int)((double)PixmapOrigin.Y + num4 * 2.2);
                        result36.Bottom = (int)((double)PixmapOrigin.Y + num4 * 3.2);
                        return result36;
                    }
                case Def.ButtonGlygh.PauseSetup:
                    {
                        TinyRect result35 = default(TinyRect);
                        result35.Left = (int)((double)PixmapOrigin.X + num4 * 1.79);
                        result35.Right = (int)((double)PixmapOrigin.X + num4 * 2.79);
                        result35.Top = (int)((double)PixmapOrigin.Y + num4 * 2.2);
                        result35.Bottom = (int)((double)PixmapOrigin.Y + num4 * 3.2);
                        return result35;
                    }
                case Def.ButtonGlygh.PauseRestart:
                    {
                        TinyRect result34 = default(TinyRect);
                        result34.Left = (int)((double)PixmapOrigin.X + num4 * 2.79);
                        result34.Right = (int)((double)PixmapOrigin.X + num4 * 3.79);
                        result34.Top = (int)((double)PixmapOrigin.Y + num4 * 2.2);
                        result34.Bottom = (int)((double)PixmapOrigin.Y + num4 * 3.2);
                        return result34;
                    }
                case Def.ButtonGlygh.PauseContinue:
                    {
                        TinyRect result33 = default(TinyRect);
                        result33.Left = (int)((double)PixmapOrigin.X + num4 * 3.79);
                        result33.Right = (int)((double)PixmapOrigin.X + num4 * 4.79);
                        result33.Top = (int)((double)PixmapOrigin.Y + num4 * 2.2);
                        result33.Bottom = (int)((double)PixmapOrigin.Y + num4 * 3.2);
                        return result33;
                    }
                case Def.ButtonGlygh.ResumeMenu:
                    {
                        TinyRect result32 = default(TinyRect);
                        result32.Left = (int)((double)PixmapOrigin.X + num4 * 1.29);
                        result32.Right = (int)((double)PixmapOrigin.X + num4 * 2.29);
                        result32.Top = (int)((double)PixmapOrigin.Y + num4 * 2.2);
                        result32.Bottom = (int)((double)PixmapOrigin.Y + num4 * 3.2);
                        return result32;
                    }
                case Def.ButtonGlygh.ResumeContinue:
                    {
                        TinyRect result31 = default(TinyRect);
                        result31.Left = (int)((double)PixmapOrigin.X + num4 * 2.29);
                        result31.Right = (int)((double)PixmapOrigin.X + num4 * 3.29);
                        result31.Top = (int)((double)PixmapOrigin.Y + num4 * 2.2);
                        result31.Bottom = (int)((double)PixmapOrigin.Y + num4 * 3.2);
                        return result31;
                    }
                case Def.ButtonGlygh.WinLostReturn:
                    {
                        TinyRect result30 = default(TinyRect);
                        result30.Left = (int)((double)PixmapOrigin.X + num - num3 * 2.2);
                        result30.Right = (int)((double)PixmapOrigin.X + num - num3 * 1.2);
                        result30.Top = (int)((double)PixmapOrigin.Y + num3 * 0.2);
                        result30.Bottom = (int)((double)PixmapOrigin.Y + num3 * 1.2);
                        return result30;
                    }
                case Def.ButtonGlygh.TrialBuy:
                    {
                        TinyRect result29 = default(TinyRect);
                        result29.Left = (int)((double)PixmapOrigin.X + num4 * 2.5);
                        result29.Right = (int)((double)PixmapOrigin.X + num4 * 3.5);
                        result29.Top = (int)((double)PixmapOrigin.Y + num4 * 2.1);
                        result29.Bottom = (int)((double)PixmapOrigin.Y + num4 * 3.1);
                        return result29;
                    }
                case Def.ButtonGlygh.TrialCancel:
                    {
                        TinyRect result28 = default(TinyRect);
                        result28.Left = (int)((double)PixmapOrigin.X + num4 * 3.5);
                        result28.Right = (int)((double)PixmapOrigin.X + num4 * 4.5);
                        result28.Top = (int)((double)PixmapOrigin.Y + num4 * 2.1);
                        result28.Bottom = (int)((double)PixmapOrigin.Y + num4 * 3.1);
                        return result28;
                    }
                case Def.ButtonGlygh.RankingContinue:
                    {
                        TinyRect result27 = default(TinyRect);
                        result27.Left = (int)((double)PixmapOrigin.X + num4 * 3.5);
                        result27.Right = (int)((double)PixmapOrigin.X + num4 * 4.5);
                        result27.Top = (int)((double)PixmapOrigin.Y + num4 * 2.1);
                        result27.Bottom = (int)((double)PixmapOrigin.Y + num4 * 3.1);
                        return result27;
                    }
                case Def.ButtonGlygh.SetupSounds:
                    {
                        TinyRect result26 = default(TinyRect);
                        result26.Left = (int)(20.0 + num4 * 0.0);
                        result26.Right = (int)(20.0 + num4 * 0.5);
                        result26.Top = (int)(num2 - 20.0 - num4 * 2.0);
                        result26.Bottom = (int)(num2 - 20.0 - num4 * 1.5);
                        return result26;
                    }
                case Def.ButtonGlygh.SetupJump:
                    {
                        TinyRect result25 = default(TinyRect);
                        result25.Left = (int)(20.0 + num4 * 0.0);
                        result25.Right = (int)(20.0 + num4 * 0.5);
                        result25.Top = (int)(num2 - 20.0 - num4 * 1.5);
                        result25.Bottom = (int)(num2 - 20.0 - num4 * 1.0);
                        return result25;
                    }
                case Def.ButtonGlygh.SetupZoom:
                    {
                        TinyRect result24 = default(TinyRect);
                        result24.Left = (int)(20.0 + num4 * 0.0);
                        result24.Right = (int)(20.0 + num4 * 0.5);
                        result24.Top = (int)(num2 - 20.0 - num4 * 1.0);
                        result24.Bottom = (int)(num2 - 20.0 - num4 * 0.5);
                        return result24;
                    }
                case Def.ButtonGlygh.SetupAccel:
                    {
                        TinyRect result23 = default(TinyRect);
                        result23.Left = (int)(20.0 + num4 * 0.0);
                        result23.Right = (int)(20.0 + num4 * 0.5);
                        result23.Top = (int)(num2 - 20.0 - num4 * 0.5);
                        result23.Bottom = (int)(num2 - 20.0 - num4 * 0.0);
                        return result23;
                    }
                case Def.ButtonGlygh.SetupReset:
                    {
                        TinyRect result22 = default(TinyRect);
                        result22.Left = (int)(450.0 + num4 * 0.0);
                        result22.Right = (int)(450.0 + num4 * 0.5);
                        result22.Top = (int)(num2 - 20.0 - num4 * 2.0);
                        result22.Bottom = (int)(num2 - 20.0 - num4 * 1.5);
                        return result22;
                    }
                case Def.ButtonGlygh.SetupReturn:
                    {
                        TinyRect result21 = default(TinyRect);
                        result21.Left = (int)(num - 20.0 - num4 * 0.8);
                        result21.Right = (int)(num - 20.0 - num4 * 0.0);
                        result21.Top = (int)(num2 - 20.0 - num4 * 0.8);
                        result21.Bottom = (int)(num2 - 20.0 - num4 * 0.0);
                        return result21;
                    }
                case Def.ButtonGlygh.PlayPause:
                    {
                        TinyRect result20 = default(TinyRect);
                        result20.Left = (int)(num - num3 * 0.7);
                        result20.Right = (int)(num - num3 * 0.2);
                        result20.Top = (int)(num3 * 0.2);
                        result20.Bottom = (int)(num3 * 0.7);
                        return result20;
                    }
                case Def.ButtonGlygh.PlayAction:
                    {
                        if (gameData.JumpRight)
                        {
                            TinyRect result16 = default(TinyRect);
                            result16.Left = (int)((double)drawBounds.Width - num3 * 1.2);
                            result16.Right = (int)((double)drawBounds.Width - num3 * 0.2);
                            result16.Top = (int)(num2 - num3 * 2.6);
                            result16.Bottom = (int)(num2 - num3 * 1.6);
                            return result16;
                        }
                        TinyRect result17 = default(TinyRect);
                        result17.Left = (int)(num3 * 0.2);
                        result17.Right = (int)(num3 * 1.2);
                        result17.Top = (int)(num2 - num3 * 2.6);
                        result17.Bottom = (int)(num2 - num3 * 1.6);
                        return result17;
                    }
                case Def.ButtonGlygh.PlayJump:
                    {
                        if (gameData.JumpRight)
                        {
                            TinyRect result12 = default(TinyRect);
                            result12.Left = (int)((double)drawBounds.Width - num3 * 1.2);
                            result12.Right = (int)((double)drawBounds.Width - num3 * 0.2);
                            result12.Top = (int)(num2 - num3 * 1.2);
                            result12.Bottom = (int)(num2 - num3 * 0.2);
                            return result12;
                        }
                        TinyRect result13 = default(TinyRect);
                        result13.Left = (int)(num3 * 0.2);
                        result13.Right = (int)(num3 * 1.2);
                        result13.Top = (int)(num2 - num3 * 1.2);
                        result13.Bottom = (int)(num2 - num3 * 0.2);
                        return result13;
                    }
                case Def.ButtonGlygh.PlayDown:
                    {
                        if (gameData.JumpRight)
                        {
                            TinyRect result8 = default(TinyRect);
                            result8.Left = (int)(num3 * 0.2);
                            result8.Right = (int)(num3 * 1.2);
                            result8.Top = (int)(num2 - num3 * 1.2);
                            result8.Bottom = (int)(num2 - num3 * 0.2);
                            return result8;
                        }
                        TinyRect result9 = default(TinyRect);
                        result9.Left = (int)((double)drawBounds.Width - num3 * 1.2);
                        result9.Right = (int)((double)drawBounds.Width - num3 * 0.2);
                        result9.Top = (int)(num2 - num3 * 1.2);
                        result9.Bottom = (int)(num2 - num3 * 0.2);
                        return result9;
                    }
                case Def.ButtonGlygh.Cheat11:
                    {
                        TinyRect result7 = default(TinyRect);
                        result7.Left = (int)(num5 * 0.0);
                        result7.Right = (int)(num5 * 1.0);
                        result7.Top = (int)(num5 * 0.0);
                        result7.Bottom = (int)(num5 * 1.0);
                        return result7;
                    }
                case Def.ButtonGlygh.Cheat12:
                    {
                        TinyRect result6 = default(TinyRect);
                        result6.Left = (int)(num5 * 0.0);
                        result6.Right = (int)(num5 * 1.0);
                        result6.Top = (int)(num5 * 1.0);
                        result6.Bottom = (int)(num5 * 2.0);
                        return result6;
                    }
                case Def.ButtonGlygh.Cheat21:
                    {
                        TinyRect result5 = default(TinyRect);
                        result5.Left = (int)(num5 * 1.0);
                        result5.Right = (int)(num5 * 2.0);
                        result5.Top = (int)(num5 * 0.0);
                        result5.Bottom = (int)(num5 * 1.0);
                        return result5;
                    }
                case Def.ButtonGlygh.Cheat22:
                    {
                        TinyRect result4 = default(TinyRect);
                        result4.Left = (int)(num5 * 1.0);
                        result4.Right = (int)(num5 * 2.0);
                        result4.Top = (int)(num5 * 1.0);
                        result4.Bottom = (int)(num5 * 2.0);
                        return result4;
                    }
                case Def.ButtonGlygh.Cheat31:
                    {
                        TinyRect result3 = default(TinyRect);
                        result3.Left = (int)(num5 * 2.0);
                        result3.Right = (int)(num5 * 3.0);
                        result3.Top = (int)(num5 * 0.0);
                        result3.Bottom = (int)(num5 * 1.0);
                        return result3;
                    }
                case Def.ButtonGlygh.Cheat32:
                    {
                        TinyRect result2 = default(TinyRect);
                        result2.Left = (int)(num5 * 2.0);
                        result2.Right = (int)(num5 * 3.0);
                        result2.Top = (int)(num5 * 1.0);
                        result2.Bottom = (int)(num5 * 2.0);
                        return result2;
                    }
                default:
                    return default(TinyRect);
            }
        }

        private void StartAccel()
        {
            try
            {
                accelSensor.Start();
                accelStarted = true;
            }
            catch (AccelerometerFailedException)
            {
                accelStarted = false;
            }
            catch (UnauthorizedAccessException)
            {
                accelStarted = false;
            }
        }

        private void StopAccel()
        {
            if (accelStarted)
            {
                try
                {
                    accelSensor.Stop();
                }
                catch (AccelerometerFailedException)
                {
                }
                accelStarted = false;
            }
        }


        private void HandleAccelSensorCurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            //IL_0001: Unknown result type (might be due to invalid IL or missing references)
            //IL_0006: Unknown result type (might be due to invalid IL or missing references)

            AccelerometerReading sensorReading = e.SensorReading;
            float y = ((AccelerometerReading)(sensorReading)).Acceleration.Y;
            float num = (1f - (float)gameData.AccelSensitivity) * 0.06f + 0.04f;
            float num2 = (accelLastState ? (num * 0.6f) : num);
            if (y > num2)
            {
                accelSpeedX = 0.0 - Math.Min((double)y * 0.25 / (double)num + 0.25, 1.0);
            }
            else if (y < 0f - num2)
            {
                accelSpeedX = Math.Min((double)(0f - y) * 0.25 / (double)num + 0.25, 1.0);
            }
            else
            {
                accelSpeedX = 0.0;
            }
            accelLastState = accelSpeedX != 0.0;
            if (accelWaitZero)
            {
                if (accelSpeedX == 0.0)
                {
                    accelWaitZero = false;
                }
                else
                {
                    accelSpeedX = 0.0;
                }
            }
        }
    }

}