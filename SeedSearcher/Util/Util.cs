using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace SeedSearcherGui
{
    public static class Util
    {
        static internal DialogResult Prompt(MessageBoxButtons btn, params string[] lines)
        {
            System.Media.SystemSounds.Question.Play();
            string msg = string.Join(Environment.NewLine + Environment.NewLine, lines);
            return MessageBox.Show(msg, "Prompt", btn, MessageBoxIcon.Asterisk);
        }

        public static string CalculateChecksum(string dataToCalculate)
        {
            byte[] byteToCalculate = System.Text.Encoding.ASCII.GetBytes(dataToCalculate);
            uint checksum = 0;
            foreach (byte chData in byteToCalculate)
            {
                checksum += chData;
            }
            return checksum.ToString("X8");
        }

        public static string GetUrlString(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    while (sw.ElapsedMilliseconds < 1000)
                    {
                        if (sw.ElapsedMilliseconds > 1000) return null;
                        return client.DownloadString(url);
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
