// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.Jauge
using Microsoft.Xna.Framework.Media;
using WindowsPhoneSpeedyBlupi;

namespace WindowsPhoneSpeedyBlupi
{
    public class Jauge
    {
        private Pixmap m_pixmap;

        private Sound m_sound;

        private bool m_bHide;

        private TinyPoint m_pos;

        private TinyPoint m_dim;

        private int m_mode;

        private int m_level;

        private bool m_bMinimizeRedraw;

        private bool m_bRedraw;

        private double m_zoom;

        public double Zoom
        {
            get
            {
                return m_zoom;
            }
            set
            {
                m_zoom = value;
            }
        }

        public Jauge()
        {
            m_mode = 0;
            m_bHide = true;
            m_bMinimizeRedraw = false;
            m_bRedraw = false;
            m_zoom = 1.0;
        }

        public bool Create(Pixmap pixmap, Sound sound, TinyPoint pos, int mode, bool bMinimizeRedraw)
        {
            m_pixmap = pixmap;
            m_sound = sound;
            m_mode = mode;
            m_bMinimizeRedraw = bMinimizeRedraw;
            m_bHide = true;
            m_pos = pos;
            m_dim.X = 124;
            m_dim.Y = 22;
            m_level = 0;
            m_bRedraw = true;
            return true;
        }

        public void Draw()
        {
            TinyRect rect = default(TinyRect);
            if (m_bMinimizeRedraw && !m_bRedraw)
            {
                return;
            }
            m_bRedraw = false;
            if (!m_bHide)
            {
                int num = m_level * 114 / 100;
                rect.Left = 0;
                rect.Right = 124;
                rect.Top = 0;
                rect.Bottom = 22;
                m_pixmap.DrawPart(5, m_pos, rect, m_zoom);
                if (num > 0)
                {
                    rect.Left = 0;
                    rect.Right = 6 + num;
                    rect.Top = 22 * m_mode;
                    rect.Bottom = 22 * (m_mode + 1);
                    m_pixmap.DrawPart(5, m_pos, rect, m_zoom);
                }
            }
        }

        public void Redraw()
        {
            m_bRedraw = true;
        }

        public int GetLevel()
        {
            return m_level;
        }

        public void SetLevel(int level)
        {
            if (level < 0)
            {
                level = 0;
            }
            if (level > 100)
            {
                level = 100;
            }
            if (m_level != level)
            {
                m_bRedraw = true;
            }
            m_level = level;
        }

        public int GetMode()
        {
            return m_mode;
        }

        public void SetMode(int mode)
        {
            if (m_mode != mode)
            {
                m_bRedraw = true;
            }
            m_mode = mode;
        }

        public bool GetHide()
        {
            return m_bHide;
        }

        public void SetHide(bool bHide)
        {
            if (m_bHide != bHide)
            {
                m_bRedraw = true;
            }
            m_bHide = bHide;
        }

        public TinyPoint GetPos()
        {
            return m_pos;
        }

        public void SetRedraw()
        {
            m_bRedraw = true;
        }
    }

}