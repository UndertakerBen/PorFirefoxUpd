﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.IO;

namespace Firefox_Beta_x86_Launcher
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
            string applicationPath = Application.StartupPath;
            if (File.Exists(applicationPath + "\\Firefox Beta x86\\Firefox.exe"))
            {
                var sb = new System.Text.StringBuilder();
                string[] CommandLineArgs = Environment.GetCommandLineArgs();
                for (int i = 1; i < CommandLineArgs.Length; i++)
                {
                    if (CommandLineArgs[i].Contains("="))
                    {
                        if (CommandLineArgs[i].Contains("LinkID"))
                        {
                            sb.Append(" " + CommandLineArgs[i]);
                        }
                        else if (CommandLineArgs[i].Contains("http"))
                        {
                            sb.Append(" \"" + CommandLineArgs[i] + "\"");
                        }
                        else
                        {
                            string[] test = CommandLineArgs[i].Split(new char[] { '=' }, 2);
                            sb.Append(" " + test[0] + "=\"" + test[1] + "\"");
                        }
                    }
                    else if (CommandLineArgs[i].Contains(".pdf"))
                    {
                        sb.Append(" \"" + CommandLineArgs[i] + "\"");
                    }
                    else
                    {
                        sb.Append(" " + CommandLineArgs[i]);
                    }
                }
                if (!File.Exists(applicationPath + "\\Firefox Beta x86\\updates\\Profile.txt"))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    String Arguments = File.ReadAllText(applicationPath + "\\Firefox Beta x86\\updates\\Profile.txt") + sb.ToString();
                    Process.Start(applicationPath + "\\Firefox Beta x86\\Firefox.exe", Arguments);
                }
                else
                {
                    String Arguments = File.ReadAllText(applicationPath + "\\Firefox Beta x86\\updates\\Profile.txt") + sb.ToString();
                    if (File.Exists(applicationPath + "\\Firefox Beta x86\\profile\\extensions.json"))
                    {
                        File.Delete(applicationPath + "\\Firefox Beta x86\\profile\\extensions.json");
                        Process.Start(applicationPath + "\\Firefox Beta x86\\Firefox.exe", Arguments);
                    }
                    else if (File.Exists(applicationPath + "\\profile\\extensions.json"))
                    {
                        File.Delete(applicationPath + "\\profile\\extensions.json");
                        Process.Start(applicationPath + "\\Firefox Beta x86\\Firefox.exe", Arguments);
                    }
                    else
                    {
                        Process.Start(applicationPath + "\\Firefox Beta x86\\Firefox.exe", Arguments);
                    }
                }
            }
            else if (culture1.TwoLetterISOLanguageName == "de")
            {
                _ = MessageBox.Show("Firefox Beta x86 ist nicht installiert", "Firefox Beta x86 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (culture1.TwoLetterISOLanguageName == "ru")
            {
                _ = MessageBox.Show("Mozilla Firefox не найден", "Firefox Beta x86 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                _ = MessageBox.Show("Firefox Beta x86 is not installed", "Firefox Beta x86 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
