// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.Worlds
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using Microsoft.Xna.Framework;
using WindowsPhoneSpeedyBlupi;

namespace WindowsPhoneSpeedyBlupi
{
    public static class Worlds
    {
        private static StringBuilder output = new StringBuilder();

        private static string GameDataFilename
        {
            get
            {
                return "SpeedyBlupi";
            }
        }

        private static string CurrentGameFilename
        {
            get
            {
                return "CurrentGame";
            }
        }

        public static string[] ReadWorld(int gamer, int rank)
        {
            string worldFilename = GetWorldFilename(gamer, rank);
            string text = null;
            try
            {
                Stream stream = TitleContainer.OpenStream(worldFilename);
                StreamReader streamReader = new StreamReader(stream);
                text = streamReader.ReadToEnd();
                stream.Close();
            }
            catch
            {
                Debug.Write("Fatal error. Loading world failed: " + worldFilename + "\n");
                //Environment.Exit(1);
            }
            if (text == null)
            {
                return null;
            }
            return text.Split('\n');
        }

        private static string GetWorldFilename(int gamer, int rank)
        {
            return string.Format("worlds/world{0}.txt", rank.ToString("d3"));
        }

        public static bool ReadGameData(byte[] data)
        {
            IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication();
            if (userStoreForApplication.FileExists(GameDataFilename))
            {
                IsolatedStorageFileStream isolatedStorageFileStream = null;
                try
                {
                    isolatedStorageFileStream = userStoreForApplication.OpenFile(GameDataFilename, FileMode.Open);
                }
                catch (IsolatedStorageException)
                {
                    return false;
                }
                if (isolatedStorageFileStream != null)
                {
                    int count = Math.Min(data.Length, (int)isolatedStorageFileStream.Length);
                    isolatedStorageFileStream.Read(data, 0, count);
                    isolatedStorageFileStream.Close();
                    return true;
                }
            }
            return false;
        }

        public static void WriteGameData(byte[] data)
        {
            IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream isolatedStorageFileStream = userStoreForApplication.OpenFile(GameDataFilename, FileMode.Create);
            if (isolatedStorageFileStream != null)
            {
                isolatedStorageFileStream.Write(data, 0, data.Length);
                isolatedStorageFileStream.Close();
            }
        }

        public static void DeleteCurrentGame()
        {
            IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication();
            try
            {
                userStoreForApplication.DeleteFile(CurrentGameFilename);
            }
            catch
            {
            }
        }

        public static string ReadCurrentGame()
        {
            IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication();
            if (userStoreForApplication.FileExists(CurrentGameFilename))
            {
                IsolatedStorageFileStream isolatedStorageFileStream = null;
                try
                {
                    isolatedStorageFileStream = userStoreForApplication.OpenFile(CurrentGameFilename, FileMode.Open);
                }
                catch (IsolatedStorageException)
                {
                    return null;
                }
                if (isolatedStorageFileStream != null)
                {
                    byte[] array = new byte[isolatedStorageFileStream.Length];
                    isolatedStorageFileStream.Read(array, 0, array.Length);
                    isolatedStorageFileStream.Close();
                    return Encoding.UTF8.GetString(array, 0, array.Length);
                }
            }
            return null;
        }

        public static void WriteCurrentGame(string data)
        {
            IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream isolatedStorageFileStream = userStoreForApplication.OpenFile(CurrentGameFilename, FileMode.Create);
            if (isolatedStorageFileStream != null)
            {
                isolatedStorageFileStream.Write(Encoding.UTF8.GetBytes(data), 0, data.Length);
                isolatedStorageFileStream.Close();
            }
        }

        public static void GetIntArrayField(string[] lines, string section, int rank, string name, int[] array)
        {
            foreach (string text in lines)
            {
                if (!text.StartsWith(section + ":") || rank-- != 0)
                {
                    continue;
                }
                int num = text.IndexOf(name + "=");
                if (num == -1)
                {
                    break;
                }
                num += name.Length + 1;
                int num2 = text.IndexOf(" ", num);
                if (num2 == -1)
                {
                    break;
                }
                string[] array2 = text.Substring(num, num2 - num).Split(',');
                for (int j = 0; j < array2.Length; j++)
                {
                    int result;
                    if (int.TryParse(array2[j], out result))
                    {
                        array[j] = result;
                    }
                    else
                    {
                        array[j] = 0;
                    }
                }
            }
        }

        public static bool GetBoolField(string[] lines, string section, int rank, string name)
        {
            foreach (string text in lines)
            {
                if (text.StartsWith(section + ":") && rank-- == 0)
                {
                    int num = text.IndexOf(name + "=");
                    if (num == -1)
                    {
                        return false;
                    }
                    num += name.Length + 1;
                    int num2 = text.IndexOf(" ", num);
                    if (num2 == -1)
                    {
                        return false;
                    }
                    string value = text.Substring(num, num2 - num);
                    bool result;
                    if (bool.TryParse(value, out result))
                    {
                        return result;
                    }
                    return false;
                }
            }
            return false;
        }

        public static int GetIntField(string[] lines, string section, int rank, string name)
        {
            foreach (string text in lines)
            {
                if (text.StartsWith(section + ":") && rank-- == 0)
                {
                    int num = text.IndexOf(name + "=");
                    if (num == -1)
                    {
                        return 0;
                    }
                    num += name.Length + 1;
                    int num2 = text.IndexOf(" ", num);
                    if (num2 == -1)
                    {
                        return 0;
                    }
                    string s = text.Substring(num, num2 - num);
                    int result;
                    if (int.TryParse(s, out result))
                    {
                        return result;
                    }
                    return 0;
                }
            }
            return 0;
        }

        public static double GetDoubleField(string[] lines, string section, int rank, string name)
        {
            foreach (string text in lines)
            {
                if (text.StartsWith(section + ":") && rank-- == 0)
                {
                    int num = text.IndexOf(name + "=");
                    if (num == -1)
                    {
                        return 0.0;
                    }
                    num += name.Length + 1;
                    int num2 = text.IndexOf(" ", num);
                    if (num2 == -1)
                    {
                        return 0.0;
                    }
                    string s = text.Substring(num, num2 - num);
                    double result;
                    if (double.TryParse(s, out result))
                    {
                        return result;
                    }
                    return 0.0;
                }
            }
            return 0.0;
        }

        public static TinyPoint GetPointField(string[] lines, string section, int rank, string name)
        {
            foreach (string text in lines)
            {
                if (text.StartsWith(section + ":") && rank-- == 0)
                {
                    int num = text.IndexOf(name + "=");
                    if (num == -1)
                    {
                        return default(TinyPoint);
                    }
                    num += name.Length + 1;
                    int num2 = text.IndexOf(";", num);
                    if (num2 == -1)
                    {
                        return default(TinyPoint);
                    }
                    int num3 = text.IndexOf(" ", num);
                    if (num3 == -1)
                    {
                        return default(TinyPoint);
                    }
                    string s = text.Substring(num, num2 - num);
                    string s2 = text.Substring(num2 + 1, num3 - num2 - 1);
                    int result;
                    if (!int.TryParse(s, out result))
                    {
                        return default(TinyPoint);
                    }
                    int result2;
                    if (!int.TryParse(s2, out result2))
                    {
                        return default(TinyPoint);
                    }
                    TinyPoint result3 = default(TinyPoint);
                    result3.X = result;
                    result3.Y = result2;
                    return result3;
                }
            }
            return default(TinyPoint);
        }

        public static int? GetDecorField(string[] lines, string section, int x, int y)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string text = lines[i];
                if (text.StartsWith(section + ":"))
                {
                    text = lines[i + 1 + x];
                    string[] array = text.Split(',');
                    if (string.IsNullOrEmpty(array[y]))
                    {
                        return -1;
                    }
                    int result;
                    if (int.TryParse(array[y], out result))
                    {
                        return result;
                    }
                    return null;
                }
            }
            return null;
        }

        public static void GetDoorsField(string[] lines, string section, int[] doors)
        {
            foreach (string text in lines)
            {
                if (!text.StartsWith(section + ":"))
                {
                    continue;
                }
                string[] array = text.Substring(section.Length + 2).Split(',');
                for (int j = 0; j < array.Length; j++)
                {
                    int result;
                    if (string.IsNullOrEmpty(array[j]))
                    {
                        doors[j] = 1;
                    }
                    else if (int.TryParse(array[j], out result))
                    {
                        doors[j] = result;
                    }
                }
            }
        }

        public static void WriteClear()
        {
            output.Clear();
        }

        public static void WriteSection(string section)
        {
            output.Append(section);
            output.Append(": ");
        }

        public static void WriteIntArrayField(string name, int[] array)
        {
            output.Append(name);
            output.Append("=");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                {
                    output.Append(array[i].ToString(CultureInfo.InvariantCulture));
                }
                if (i < array.Length - 1)
                {
                    output.Append(",");
                }
            }
            output.Append(" ");
        }

        public static void WriteBoolField(string name, bool n)
        {
            output.Append(name);
            output.Append("=");
            output.Append(n.ToString(CultureInfo.InvariantCulture));
            output.Append(" ");
        }

        public static void WriteIntField(string name, int n)
        {
            output.Append(name);
            output.Append("=");
            output.Append(n.ToString(CultureInfo.InvariantCulture));
            output.Append(" ");
        }

        public static void WriteDoubleField(string name, double n)
        {
            output.Append(name);
            output.Append("=");
            output.Append(n.ToString(CultureInfo.InvariantCulture));
            output.Append(" ");
        }

        public static void WritePointField(string name, TinyPoint p)
        {
            output.Append(name);
            output.Append("=");
            output.Append(p.X.ToString(CultureInfo.InvariantCulture));
            output.Append(";");
            output.Append(p.Y.ToString(CultureInfo.InvariantCulture));
            output.Append(" ");
        }

        public static void WriteDecorField(int[] line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != -1)
                {
                    output.Append(line[i].ToString(CultureInfo.InvariantCulture));
                }
                if (i < line.Length - 1)
                {
                    output.Append(",");
                }
            }
            output.Append("\n");
        }

        public static void WriteDoorsField(int[] doors)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i] != 1)
                {
                    output.Append(doors[i].ToString(CultureInfo.InvariantCulture));
                }
                if (i < doors.Length - 1)
                {
                    output.Append(",");
                }
            }
            output.Append("\n");
        }

        public static void WriteEndSection()
        {
            output.Append("\n");
        }

        public static string GetWriteString()
        {
            return output.ToString();
        }
    }
}