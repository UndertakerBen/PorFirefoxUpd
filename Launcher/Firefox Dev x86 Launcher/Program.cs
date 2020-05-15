using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.IO;

namespace Firefox_Dev_x86_Launcher
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo culture1 = CultureInfo.CurrentUICulture;
            if (File.Exists(@"Firefox Dev x86\Firefox.exe"))
            {
                var sb = new System.Text.StringBuilder();
                string[] CommandLineArgs = Environment.GetCommandLineArgs();
                for (int i = 1; i < CommandLineArgs.Length; i++)
                {
                    if (CommandLineArgs[i].Contains("="))
                    {
                        string[] test = CommandLineArgs[i].Split(new char[] { '=' }, 2);
                        sb.Append(" " + test[0] + "=\"" + test[1] + "\"");
                    }
                    else
                    {
                        sb.Append(" " + CommandLineArgs[i]);
                    }
                }
                if (!File.Exists(@"Firefox Dev x86\updates\Profile.txt"))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    String Arguments = File.ReadAllText(@"Firefox Dev x86\updates\Profile.txt") + sb.ToString();
                    Process.Start(@"Firefox Dev x86\Firefox.exe", Arguments);
                }
                else
                {
                    String Arguments = File.ReadAllText(@"Firefox Dev x86\updates\Profile.txt") + sb.ToString();
                    if (File.Exists(@"Firefox Dev x86\profile\extensions.json"))
                    {
                        File.Delete(@"Firefox Dev x86\profile\extensions.json");
                        Process.Start(@"Firefox Dev x86\Firefox.exe", Arguments);
                    }
                    else if (File.Exists(@"profile\extensions.json"))
                    {
                        File.Delete(@"profile\extensions.json");
                        Process.Start(@"Firefox Dev x86\Firefox.exe", Arguments);
                    }
                    else
                    {
                        Process.Start(@"Firefox\Firefox.exe", Arguments);
                    }
                }
            }
            else if (culture1.TwoLetterISOLanguageName == "de")
            {
                _ = MessageBox.Show("Firefox Dev x86 ist nicht installiert", "Firefox Dev x86 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (culture1.TwoLetterISOLanguageName == "ru")
            {
                _ = MessageBox.Show("Mozilla Firefox не найден", "Firefox Dev x86 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                _ = MessageBox.Show("Firefox Dev x86 is not installed", "Firefox Dev x86 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
