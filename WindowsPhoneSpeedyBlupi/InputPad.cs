// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.InputPad
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
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

        private readonly List<ButtonGlyph> pressedGlyphs;

        private readonly Accelerometer accelSensor;

        private readonly Slider accelSlider;

        private bool padPressed;

        private bool showCheatMenu;

        private TinyPoint padTouchPos;

        private ButtonGlyph lastButtonDown;

        private ButtonGlyph buttonPressed;

        private int touchCount;

        private bool accelStarted;

        private bool accelActive;

        private double accelSpeedX;

        private bool accelLastState;

        private bool accelWaitZero;

        private int mission;

        public Phase Phase { get; set; }

        public int SelectedGamer { get; set; }

        public TinyPoint PixmapOrigin { get; set; }

        public int TotalTouch
        {
            get
            {
                return touchCount;
            }
        }

        public ButtonGlyph ButtonPressed
        {
            get
            {
                ButtonGlyph result = buttonPressed;
                buttonPressed = ButtonGlyph.None;
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

        private IEnumerable<ButtonGlyph> ButtonGlyphs
        {
            get
            {
                switch (Phase)
                {
                    case Phase.Init:
                        yield return ButtonGlyph.InitGamerA;
                        yield return ButtonGlyph.InitGamerB;
                        yield return ButtonGlyph.InitGamerC;
                        yield return ButtonGlyph.InitSetup;
                        yield return ButtonGlyph.InitPlay;
                        if (game1.IsTrialMode)
                        {
                            yield return ButtonGlyph.InitBuy;
                        }
                        if (game1.IsRankingMode)
                        {
                            yield return ButtonGlyph.InitRanking;
                        }
                        break;
                    case Phase.Play:
                        yield return ButtonGlyph.PlayPause;
                        yield return ButtonGlyph.PlayAction;
                        yield return ButtonGlyph.PlayJump;
                        if (accelStarted)
                        {
                            yield return ButtonGlyph.PlayDown;
                        }
                        yield return ButtonGlyph.Cheat11;
                        yield return ButtonGlyph.Cheat12;
                        yield return ButtonGlyph.Cheat21;
                        yield return ButtonGlyph.Cheat22;
                        yield return ButtonGlyph.Cheat31;
                        yield return ButtonGlyph.Cheat32;
                        break;
                    case Phase.Pause:
                        yield return ButtonGlyph.PauseMenu;
                        if (mission != 1)
                        {
                            yield return ButtonGlyph.PauseBack;
                        }
                        yield return ButtonGlyph.PauseSetup;
                        if (mission != 1 && mission % 10 != 0)
                        {
                            yield return ButtonGlyph.PauseRestart;
                        }
                        yield return ButtonGlyph.PauseContinue;
                        break;
                    case Phase.Resume:
                        yield return ButtonGlyph.ResumeMenu;
                        yield return ButtonGlyph.ResumeContinue;
                        break;
                    case Phase.Lost:
                    case Phase.Win:
                        yield return ButtonGlyph.WinLostReturn;
                        break;
                    case Phase.Trial:
                        yield return ButtonGlyph.TrialBuy;
                        yield return ButtonGlyph.TrialCancel;
                        break;
                    case Phase.MainSetup:
                        yield return ButtonGlyph.SetupSounds;
                        yield return ButtonGlyph.SetupJump;
                        yield return ButtonGlyph.SetupZoom;
                        yield return ButtonGlyph.SetupAccel;
                        yield return ButtonGlyph.SetupReset;
                        yield return ButtonGlyph.SetupReturn;
                        break;
                    case Phase.PlaySetup:
                        yield return ButtonGlyph.SetupSounds;
                        yield return ButtonGlyph.SetupJump;
                        yield return ButtonGlyph.SetupZoom;
                        yield return ButtonGlyph.SetupAccel;
                        yield return ButtonGlyph.SetupReturn;
                        break;
                    case Phase.Ranking:
                        yield return ButtonGlyph.RankingContinue;
                        break;
                }
                if (showCheatMenu)
                {
                    yield return ButtonGlyph.Cheat1;
                    yield return ButtonGlyph.Cheat2;
                    yield return ButtonGlyph.Cheat3;
                    yield return ButtonGlyph.Cheat4;
                    yield return ButtonGlyph.Cheat5;
                    yield return ButtonGlyph.Cheat6;
                    yield return ButtonGlyph.Cheat7;
                    yield return ButtonGlyph.Cheat8;
                    yield return ButtonGlyph.Cheat9;
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
                    TinyPoint result = default;
                    result.X = 100;
                    result.Y = drawBounds.Height - 100;
                    return result;
                }
                TinyPoint result2 = default;
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
            pressedGlyphs = new List<ButtonGlyph>();
            accelSensor = new Accelerometer();
            ((SensorBase<AccelerometerReading>)(object)accelSensor).CurrentValueChanged += HandleAccelSensorCurrentValueChanged;
            accelSlider = new Slider
            {
                TopLeftCorner = new TinyPoint
                {
                    X = 320,
                    Y = 400
                },
                Value = this.gameData.AccelSensitivity
            };
            lastButtonDown = ButtonGlyph.None;
            buttonPressed = ButtonGlyph.None;
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
            ButtonGlyph buttonGlyph = ButtonGlyph.None;
            TouchCollection touches = TouchPanel.GetState();
            touchCount = touches.Count;
            List<TinyPoint> touchesOrClicks = new List<TinyPoint>();
            foreach (TouchLocation item in touches)
            {
                if (item.State == TouchLocationState.Pressed || item.State == TouchLocationState.Moved)
                {
                    TinyPoint tinyPoint = default;
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

            if (PLATFORM == Platform.Android && screenRatio > 1.3333333333333333)
            {
                for (int i = 0; i < touchesOrClicks.Count; i++)
                {

                    var touchOrClick = touchesOrClicks[i];
                    if (touchOrClick.X == -1) continue;

                    float originalX = touchOrClick.X;
                    float originalY = touchOrClick.Y;

                    float widthHeightRatio = screenWidth / screenHeight;
                    float heightRatio = 480 / screenHeight;
                    float widthRatio = 640 / screenWidth;
                    if (DETAILED_DEBUGGING)
                    {
                        Debug.WriteLine("-----");
                        Debug.WriteLine("originalX=" + originalX);
                        Debug.WriteLine("originalY=" + originalY);
                        Debug.WriteLine("heightRatio=" + heightRatio);
                        Debug.WriteLine("widthRatio=" + widthRatio);
                        Debug.WriteLine("widthHeightRatio=" + widthHeightRatio);
                    }
                    if (screenHeight > 480)
                    {
                        touchOrClick.X = (int)(originalX * heightRatio);
                        touchOrClick.Y = (int)(originalY * heightRatio);
                        touchesOrClicks[i] = touchOrClick;
                    }

                    if (DETAILED_DEBUGGING) Debug.WriteLine("new X" + touchOrClick.X);
                    if (DETAILED_DEBUGGING) Debug.WriteLine("new Y" + touchOrClick.Y);
                }
            }

            KeyboardState newState = Keyboard.GetState();
            {
                if (newState.IsKeyDown(Keys.LeftControl)) touchesOrClicks.Add(createTinyPoint(-1, (int)KeyboardPress.LeftControl));
                if (newState.IsKeyDown(Keys.Up)) touchesOrClicks.Add(createTinyPoint(-1, (int)KeyboardPress.Up));
                if (newState.IsKeyDown(Keys.Right)) touchesOrClicks.Add(createTinyPoint(-1, (int)KeyboardPress.Right));
                if (newState.IsKeyDown(Keys.Down)) touchesOrClicks.Add(createTinyPoint(-1, (int)KeyboardPress.Down));
                if (newState.IsKeyDown(Keys.Left)) touchesOrClicks.Add(createTinyPoint(-1, (int)KeyboardPress.Left));
                if (newState.IsKeyDown(Keys.Space)) touchesOrClicks.Add(createTinyPoint(-1, (int)KeyboardPress.Space));
            }
            if (newState.IsKeyDown(Keys.F11))
            {
                game1.ToggleFullScreen();
                Debug.WriteLine("F11 was pressed.");
            }

            bool keyPressedUp = false;
            bool keyPressedDown = false;
            bool keyPressedLeft = false;
            bool keyPressedRight = false;
            foreach (TinyPoint touchOrClick in touchesOrClicks)
            {
                bool keyboardPressed = false;
                if (touchOrClick.X == -1)
                {
                    keyboardPressed = true;
                }
                KeyboardPress keyboardPress = keyboardPressed ? (KeyboardPress)touchOrClick.Y : KeyboardPress.None;
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
                    ButtonGlyph buttonGlyph2 = ButtonDetect(tinyPoint2);
                    Debug.WriteLine("buttonGlyph2 =" + buttonGlyph2);
                    if (buttonGlyph2 != 0)
                    {
                        pressedGlyphs.Add(buttonGlyph2);
                    }
                    if (keyboardPressed)
                    {
                        switch (keyboardPress)
                        {
                            case KeyboardPress.LeftControl: buttonGlyph2 = ButtonGlyph.PlayJump; pressedGlyphs.Add(buttonGlyph2); break;
                            case KeyboardPress.Space: buttonGlyph2 = ButtonGlyph.PlayAction; pressedGlyphs.Add(buttonGlyph2); break;
                        }
                    }

                    if ((Phase == Phase.MainSetup || Phase == Phase.PlaySetup) && accelSlider.Move(tinyPoint2))
                    {
                        gameData.AccelSensitivity = accelSlider.Value;
                    }
                    switch (buttonGlyph2)
                    {
                        case ButtonGlyph.PlayJump:
                            Debug.WriteLine("Jumping detected");
                            accelWaitZero = false;
                            num3 |= 1;
                            break;
                        case ButtonGlyph.PlayDown:
                            accelWaitZero = false;
                            num3 |= 4;
                            break;
                        case ButtonGlyph.InitGamerA:
                        case ButtonGlyph.InitGamerB:
                        case ButtonGlyph.InitGamerC:
                        case ButtonGlyph.InitSetup:
                        case ButtonGlyph.InitPlay:
                        case ButtonGlyph.InitBuy:
                        case ButtonGlyph.InitRanking:
                        case ButtonGlyph.WinLostReturn:
                        case ButtonGlyph.TrialBuy:
                        case ButtonGlyph.TrialCancel:
                        case ButtonGlyph.SetupSounds:
                        case ButtonGlyph.SetupJump:
                        case ButtonGlyph.SetupZoom:
                        case ButtonGlyph.SetupAccel:
                        case ButtonGlyph.SetupReset:
                        case ButtonGlyph.SetupReturn:
                        case ButtonGlyph.PauseMenu:
                        case ButtonGlyph.PauseBack:
                        case ButtonGlyph.PauseSetup:
                        case ButtonGlyph.PauseRestart:
                        case ButtonGlyph.PauseContinue:
                        case ButtonGlyph.PlayPause:
                        case ButtonGlyph.PlayAction:
                        case ButtonGlyph.ResumeMenu:
                        case ButtonGlyph.ResumeContinue:
                        case ButtonGlyph.RankingContinue:
                        case ButtonGlyph.Cheat11:
                        case ButtonGlyph.Cheat12:
                        case ButtonGlyph.Cheat21:
                        case ButtonGlyph.Cheat22:
                        case ButtonGlyph.Cheat31:
                        case ButtonGlyph.Cheat32:
                        case ButtonGlyph.Cheat1:
                        case ButtonGlyph.Cheat2:
                        case ButtonGlyph.Cheat3:
                        case ButtonGlyph.Cheat4:
                        case ButtonGlyph.Cheat5:
                        case ButtonGlyph.Cheat6:
                        case ButtonGlyph.Cheat7:
                        case ButtonGlyph.Cheat8:
                        case ButtonGlyph.Cheat9:
                            accelWaitZero = false;
                            buttonGlyph = buttonGlyph2;
                            showCheatMenu = false;
                            break;
                    }
                }
            }
            if (buttonGlyph != 0 && buttonGlyph != ButtonGlyph.PlayAction && buttonGlyph != ButtonGlyph.Cheat11 && buttonGlyph != ButtonGlyph.Cheat12 && buttonGlyph != ButtonGlyph.Cheat21 && buttonGlyph != ButtonGlyph.Cheat22 && buttonGlyph != ButtonGlyph.Cheat31 && buttonGlyph != ButtonGlyph.Cheat32 && lastButtonDown == ButtonGlyph.None)
            {
                TinyPoint tinyPoint3 = default;
                tinyPoint3.X = 320;
                tinyPoint3.Y = 240;
                TinyPoint pos = tinyPoint3;
                sound.PlayImage(0, pos);
            }
            if (buttonGlyph == ButtonGlyph.None && lastButtonDown != 0)
            {
                buttonPressed = lastButtonDown;
            }
            lastButtonDown = buttonGlyph;
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
                    if (keyPressedDown)
                    {
                        padTouchPos.Y = PadCenter.Y + 30;
                        padTouchPos.X = PadCenter.X;
                        if (keyPressedLeft) padTouchPos.X = PadCenter.X - 30;
                        if (keyPressedRight) padTouchPos.X = PadCenter.X + 30;
                    }
                    if (keyPressedLeft)
                    {
                        padTouchPos.X = PadCenter.X - 30;
                        padTouchPos.Y = PadCenter.Y;
                        if (keyPressedUp) padTouchPos.Y = PadCenter.Y - 30;
                        if (keyPressedDown) padTouchPos.Y = PadCenter.Y + 30;
                    }
                    if (keyPressedRight)
                    {
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

        private ButtonGlyph ButtonDetect(TinyPoint pos)
        {
            foreach (ButtonGlyph item in ButtonGlyphs.Reverse())
            {
                int value = 0;
                if (item == ButtonGlyph.PlayJump || item == ButtonGlyph.PlayAction || item == ButtonGlyph.PlayDown || item == ButtonGlyph.PlayPause)
                {
                    value = 20;
                }
                TinyRect rect = Misc.Inflate(GetButtonRect(item), value);
                if (Misc.IsInside(rect, pos))
                {
                    return item;
                }
            }
            return ButtonGlyph.None;
        }

        public void Draw()
        {
            if (!accelStarted && Phase == Phase.Play)
            {
                pixmap.DrawIcon(14, 0, GetPadBounds(PadCenter, padSize / 2), 1.0, false);
                TinyPoint center = padPressed ? padTouchPos : PadCenter;
                pixmap.DrawIcon(14, 1, GetPadBounds(center, padSize / 2), 1.0, false);
            }
            foreach (ButtonGlyph buttonGlyph in ButtonGlyphs)
            {
                bool pressed = pressedGlyphs.Contains(buttonGlyph);
                bool selected = false;
                if (buttonGlyph >= ButtonGlyph.InitGamerA && buttonGlyph <= ButtonGlyph.InitGamerC)
                {
                    int num = (int)(buttonGlyph - 1);
                    selected = num == gameData.SelectedGamer;
                }
                if (buttonGlyph == ButtonGlyph.SetupSounds)
                {
                    selected = gameData.Sounds;
                }
                if (buttonGlyph == ButtonGlyph.SetupJump)
                {
                    selected = gameData.JumpRight;
                }
                if (buttonGlyph == ButtonGlyph.SetupZoom)
                {
                    selected = gameData.AutoZoom;
                }
                if (buttonGlyph == ButtonGlyph.SetupAccel)
                {
                    selected = gameData.AccelActive;
                }
                pixmap.DrawInputButton(GetButtonRect(buttonGlyph), buttonGlyph, pressed, selected);
            }
            if ((Phase == Phase.MainSetup || Phase == Phase.PlaySetup) && gameData.AccelActive)
            {
                accelSlider.Draw(pixmap);
            }
        }

        private TinyRect GetPadBounds(TinyPoint center, int radius)
        {
            TinyRect result = default;
            result.Left = center.X - radius;
            result.Right = center.X + radius;
            result.Top = center.Y - radius;
            result.Bottom = center.Y + radius;
            return result;
        }

        public TinyRect GetButtonRect(ButtonGlyph glyph)
        {
            TinyRect drawBounds = pixmap.DrawBounds;
            double num = drawBounds.Width;
            double num2 = drawBounds.Height;
            double num3 = num2 / 5.0;
            double num4 = num2 * 140.0 / 480.0;
            double num5 = num2 / 3.5;
            if (glyph >= ButtonGlyph.Cheat1 && glyph <= ButtonGlyph.Cheat9)
            {
                int num6 = (int)(glyph - 35);
                TinyRect result = default;
                result.Left = 80 * num6;
                result.Right = 80 * (num6 + 1);
                result.Top = 0;
                result.Bottom = 80;
                return result;
            }
            switch (glyph)
            {
                case ButtonGlyph.InitGamerA:
                    {
                        TinyRect result19 = default;
                        result19.Left = (int)(20.0 + num4 * 0.0);
                        result19.Right = (int)(20.0 + num4 * 0.5);
                        result19.Top = (int)(num2 - 20.0 - num4 * 2.1);
                        result19.Bottom = (int)(num2 - 20.0 - num4 * 1.6);
                        return result19;
                    }
                case ButtonGlyph.InitGamerB:
                    {
                        TinyRect result18 = default;
                        result18.Left = (int)(20.0 + num4 * 0.0);
                        result18.Right = (int)(20.0 + num4 * 0.5);
                        result18.Top = (int)(num2 - 20.0 - num4 * 1.6);
                        result18.Bottom = (int)(num2 - 20.0 - num4 * 1.1);
                        return result18;
                    }
                case ButtonGlyph.InitGamerC:
                    {
                        TinyRect result15 = default;
                        result15.Left = (int)(20.0 + num4 * 0.0);
                        result15.Right = (int)(20.0 + num4 * 0.5);
                        result15.Top = (int)(num2 - 20.0 - num4 * 1.1);
                        result15.Bottom = (int)(num2 - 20.0 - num4 * 0.6);
                        return result15;
                    }
                case ButtonGlyph.InitSetup:
                    {
                        TinyRect result14 = default;
                        result14.Left = (int)(20.0 + num4 * 0.0);
                        result14.Right = (int)(20.0 + num4 * 0.5);
                        result14.Top = (int)(num2 - 20.0 - num4 * 0.5);
                        result14.Bottom = (int)(num2 - 20.0 - num4 * 0.0);
                        return result14;
                    }
                case ButtonGlyph.InitPlay:
                    {
                        TinyRect result11 = default;
                        result11.Left = (int)(num - 20.0 - num4 * 1.0);
                        result11.Right = (int)(num - 20.0 - num4 * 0.0);
                        result11.Top = (int)(num2 - 40.0 - num4 * 1.0);
                        result11.Bottom = (int)(num2 - 40.0 - num4 * 0.0);
                        return result11;
                    }
                case ButtonGlyph.InitBuy:
                case ButtonGlyph.InitRanking:
                    {
                        TinyRect result10 = default;
                        result10.Left = (int)(num - 20.0 - num4 * 0.75);
                        result10.Right = (int)(num - 20.0 - num4 * 0.25);
                        result10.Top = (int)(num2 - 20.0 - num4 * 2.1);
                        result10.Bottom = (int)(num2 - 20.0 - num4 * 1.6);
                        return result10;
                    }
                case ButtonGlyph.PauseMenu:
                    {
                        TinyRect result37 = default;
                        result37.Left = (int)(PixmapOrigin.X + num4 * -0.21);
                        result37.Right = (int)(PixmapOrigin.X + num4 * 0.79);
                        result37.Top = (int)(PixmapOrigin.Y + num4 * 2.2);
                        result37.Bottom = (int)(PixmapOrigin.Y + num4 * 3.2);
                        return result37;
                    }
                case ButtonGlyph.PauseBack:
                    {
                        TinyRect result36 = default;
                        result36.Left = (int)(PixmapOrigin.X + num4 * 0.79);
                        result36.Right = (int)(PixmapOrigin.X + num4 * 1.79);
                        result36.Top = (int)(PixmapOrigin.Y + num4 * 2.2);
                        result36.Bottom = (int)(PixmapOrigin.Y + num4 * 3.2);
                        return result36;
                    }
                case ButtonGlyph.PauseSetup:
                    {
                        TinyRect result35 = default;
                        result35.Left = (int)(PixmapOrigin.X + num4 * 1.79);
                        result35.Right = (int)(PixmapOrigin.X + num4 * 2.79);
                        result35.Top = (int)(PixmapOrigin.Y + num4 * 2.2);
                        result35.Bottom = (int)(PixmapOrigin.Y + num4 * 3.2);
                        return result35;
                    }
                case ButtonGlyph.PauseRestart:
                    {
                        TinyRect result34 = default;
                        result34.Left = (int)(PixmapOrigin.X + num4 * 2.79);
                        result34.Right = (int)(PixmapOrigin.X + num4 * 3.79);
                        result34.Top = (int)(PixmapOrigin.Y + num4 * 2.2);
                        result34.Bottom = (int)(PixmapOrigin.Y + num4 * 3.2);
                        return result34;
                    }
                case ButtonGlyph.PauseContinue:
                    {
                        TinyRect result33 = default;
                        result33.Left = (int)(PixmapOrigin.X + num4 * 3.79);
                        result33.Right = (int)(PixmapOrigin.X + num4 * 4.79);
                        result33.Top = (int)(PixmapOrigin.Y + num4 * 2.2);
                        result33.Bottom = (int)(PixmapOrigin.Y + num4 * 3.2);
                        return result33;
                    }
                case ButtonGlyph.ResumeMenu:
                    {
                        TinyRect result32 = default;
                        result32.Left = (int)(PixmapOrigin.X + num4 * 1.29);
                        result32.Right = (int)(PixmapOrigin.X + num4 * 2.29);
                        result32.Top = (int)(PixmapOrigin.Y + num4 * 2.2);
                        result32.Bottom = (int)(PixmapOrigin.Y + num4 * 3.2);
                        return result32;
                    }
                case ButtonGlyph.ResumeContinue:
                    {
                        TinyRect result31 = default;
                        result31.Left = (int)(PixmapOrigin.X + num4 * 2.29);
                        result31.Right = (int)(PixmapOrigin.X + num4 * 3.29);
                        result31.Top = (int)(PixmapOrigin.Y + num4 * 2.2);
                        result31.Bottom = (int)(PixmapOrigin.Y + num4 * 3.2);
                        return result31;
                    }
                case ButtonGlyph.WinLostReturn:
                    {
                        TinyRect result30 = default;
                        result30.Left = (int)(PixmapOrigin.X + num - num3 * 2.2);
                        result30.Right = (int)(PixmapOrigin.X + num - num3 * 1.2);
                        result30.Top = (int)(PixmapOrigin.Y + num3 * 0.2);
                        result30.Bottom = (int)(PixmapOrigin.Y + num3 * 1.2);
                        return result30;
                    }
                case ButtonGlyph.TrialBuy:
                    {
                        TinyRect result29 = default;
                        result29.Left = (int)(PixmapOrigin.X + num4 * 2.5);
                        result29.Right = (int)(PixmapOrigin.X + num4 * 3.5);
                        result29.Top = (int)(PixmapOrigin.Y + num4 * 2.1);
                        result29.Bottom = (int)(PixmapOrigin.Y + num4 * 3.1);
                        return result29;
                    }
                case ButtonGlyph.TrialCancel:
                    {
                        TinyRect result28 = default;
                        result28.Left = (int)(PixmapOrigin.X + num4 * 3.5);
                        result28.Right = (int)(PixmapOrigin.X + num4 * 4.5);
                        result28.Top = (int)(PixmapOrigin.Y + num4 * 2.1);
                        result28.Bottom = (int)(PixmapOrigin.Y + num4 * 3.1);
                        return result28;
                    }
                case ButtonGlyph.RankingContinue:
                    {
                        TinyRect result27 = default;
                        result27.Left = (int)(PixmapOrigin.X + num4 * 3.5);
                        result27.Right = (int)(PixmapOrigin.X + num4 * 4.5);
                        result27.Top = (int)(PixmapOrigin.Y + num4 * 2.1);
                        result27.Bottom = (int)(PixmapOrigin.Y + num4 * 3.1);
                        return result27;
                    }
                case ButtonGlyph.SetupSounds:
                    {
                        TinyRect result26 = default;
                        result26.Left = (int)(20.0 + num4 * 0.0);
                        result26.Right = (int)(20.0 + num4 * 0.5);
                        result26.Top = (int)(num2 - 20.0 - num4 * 2.0);
                        result26.Bottom = (int)(num2 - 20.0 - num4 * 1.5);
                        return result26;
                    }
                case ButtonGlyph.SetupJump:
                    {
                        TinyRect result25 = default;
                        result25.Left = (int)(20.0 + num4 * 0.0);
                        result25.Right = (int)(20.0 + num4 * 0.5);
                        result25.Top = (int)(num2 - 20.0 - num4 * 1.5);
                        result25.Bottom = (int)(num2 - 20.0 - num4 * 1.0);
                        return result25;
                    }
                case ButtonGlyph.SetupZoom:
                    {
                        TinyRect result24 = default;
                        result24.Left = (int)(20.0 + num4 * 0.0);
                        result24.Right = (int)(20.0 + num4 * 0.5);
                        result24.Top = (int)(num2 - 20.0 - num4 * 1.0);
                        result24.Bottom = (int)(num2 - 20.0 - num4 * 0.5);
                        return result24;
                    }
                case ButtonGlyph.SetupAccel:
                    {
                        TinyRect result23 = default;
                        result23.Left = (int)(20.0 + num4 * 0.0);
                        result23.Right = (int)(20.0 + num4 * 0.5);
                        result23.Top = (int)(num2 - 20.0 - num4 * 0.5);
                        result23.Bottom = (int)(num2 - 20.0 - num4 * 0.0);
                        return result23;
                    }
                case ButtonGlyph.SetupReset:
                    {
                        TinyRect result22 = default;
                        result22.Left = (int)(450.0 + num4 * 0.0);
                        result22.Right = (int)(450.0 + num4 * 0.5);
                        result22.Top = (int)(num2 - 20.0 - num4 * 2.0);
                        result22.Bottom = (int)(num2 - 20.0 - num4 * 1.5);
                        return result22;
                    }
                case ButtonGlyph.SetupReturn:
                    {
                        TinyRect result21 = default;
                        result21.Left = (int)(num - 20.0 - num4 * 0.8);
                        result21.Right = (int)(num - 20.0 - num4 * 0.0);
                        result21.Top = (int)(num2 - 20.0 - num4 * 0.8);
                        result21.Bottom = (int)(num2 - 20.0 - num4 * 0.0);
                        return result21;
                    }
                case ButtonGlyph.PlayPause:
                    {
                        TinyRect result20 = default;
                        result20.Left = (int)(num - num3 * 0.7);
                        result20.Right = (int)(num - num3 * 0.2);
                        result20.Top = (int)(num3 * 0.2);
                        result20.Bottom = (int)(num3 * 0.7);
                        return result20;
                    }
                case ButtonGlyph.PlayAction:
                    {
                        if (gameData.JumpRight)
                        {
                            TinyRect result16 = default;
                            result16.Left = (int)(drawBounds.Width - num3 * 1.2);
                            result16.Right = (int)(drawBounds.Width - num3 * 0.2);
                            result16.Top = (int)(num2 - num3 * 2.6);
                            result16.Bottom = (int)(num2 - num3 * 1.6);
                            return result16;
                        }
                        TinyRect result17 = default;
                        result17.Left = (int)(num3 * 0.2);
                        result17.Right = (int)(num3 * 1.2);
                        result17.Top = (int)(num2 - num3 * 2.6);
                        result17.Bottom = (int)(num2 - num3 * 1.6);
                        return result17;
                    }
                case ButtonGlyph.PlayJump:
                    {
                        if (gameData.JumpRight)
                        {
                            TinyRect result12 = default;
                            result12.Left = (int)(drawBounds.Width - num3 * 1.2);
                            result12.Right = (int)(drawBounds.Width - num3 * 0.2);
                            result12.Top = (int)(num2 - num3 * 1.2);
                            result12.Bottom = (int)(num2 - num3 * 0.2);
                            return result12;
                        }
                        TinyRect result13 = default;
                        result13.Left = (int)(num3 * 0.2);
                        result13.Right = (int)(num3 * 1.2);
                        result13.Top = (int)(num2 - num3 * 1.2);
                        result13.Bottom = (int)(num2 - num3 * 0.2);
                        return result13;
                    }
                case ButtonGlyph.PlayDown:
                    {
                        if (gameData.JumpRight)
                        {
                            TinyRect result8 = default;
                            result8.Left = (int)(num3 * 0.2);
                            result8.Right = (int)(num3 * 1.2);
                            result8.Top = (int)(num2 - num3 * 1.2);
                            result8.Bottom = (int)(num2 - num3 * 0.2);
                            return result8;
                        }
                        TinyRect result9 = default;
                        result9.Left = (int)(drawBounds.Width - num3 * 1.2);
                        result9.Right = (int)(drawBounds.Width - num3 * 0.2);
                        result9.Top = (int)(num2 - num3 * 1.2);
                        result9.Bottom = (int)(num2 - num3 * 0.2);
                        return result9;
                    }
                case ButtonGlyph.Cheat11:
                    {
                        TinyRect result7 = default;
                        result7.Left = (int)(num5 * 0.0);
                        result7.Right = (int)(num5 * 1.0);
                        result7.Top = (int)(num5 * 0.0);
                        result7.Bottom = (int)(num5 * 1.0);
                        return result7;
                    }
                case ButtonGlyph.Cheat12:
                    {
                        TinyRect result6 = default;
                        result6.Left = (int)(num5 * 0.0);
                        result6.Right = (int)(num5 * 1.0);
                        result6.Top = (int)(num5 * 1.0);
                        result6.Bottom = (int)(num5 * 2.0);
                        return result6;
                    }
                case ButtonGlyph.Cheat21:
                    {
                        TinyRect result5 = default;
                        result5.Left = (int)(num5 * 1.0);
                        result5.Right = (int)(num5 * 2.0);
                        result5.Top = (int)(num5 * 0.0);
                        result5.Bottom = (int)(num5 * 1.0);
                        return result5;
                    }
                case ButtonGlyph.Cheat22:
                    {
                        TinyRect result4 = default;
                        result4.Left = (int)(num5 * 1.0);
                        result4.Right = (int)(num5 * 2.0);
                        result4.Top = (int)(num5 * 1.0);
                        result4.Bottom = (int)(num5 * 2.0);
                        return result4;
                    }
                case ButtonGlyph.Cheat31:
                    {
                        TinyRect result3 = default;
                        result3.Left = (int)(num5 * 2.0);
                        result3.Right = (int)(num5 * 3.0);
                        result3.Top = (int)(num5 * 0.0);
                        result3.Bottom = (int)(num5 * 1.0);
                        return result3;
                    }
                case ButtonGlyph.Cheat32:
                    {
                        TinyRect result2 = default;
                        result2.Left = (int)(num5 * 2.0);
                        result2.Right = (int)(num5 * 3.0);
                        result2.Top = (int)(num5 * 1.0);
                        result2.Bottom = (int)(num5 * 2.0);
                        return result2;
                    }
                default:
                    return default;
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
            float y = sensorReading.Acceleration.Y;
            float num = (1f - (float)gameData.AccelSensitivity) * 0.06f + 0.04f;
            float num2 = accelLastState ? num * 0.6f : num;
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