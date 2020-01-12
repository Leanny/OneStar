using System;
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
    }
}
