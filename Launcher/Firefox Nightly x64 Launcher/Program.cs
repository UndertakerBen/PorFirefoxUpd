﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.IO;

namespace Firefox_Nightly_x64_Launcher
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
            if (File.Exists(@"Firefox Nightly x64\Firefox.exe"))
            {
                if (!File.Exists(@"Firefox Nightly x64\updates\Profile.txt"))
                {
                    if (culture1.Name == "de-DE")
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form1());
                        String Arguments = File.ReadAllText(@"Firefox Nightly x64\updates\Profile.txt");
                        Process.Start(@"Firefox Nightly x64\Firefox.exe", Arguments);
                    }
                    else
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form2());
                        String Arguments = File.ReadAllText(@"Firefox Nightly x64\updates\Profile.txt");
                        Process.Start(@"Firefox Nightly x64\Firefox.exe", Arguments);
                    }
                }
                else
                {
                    String Arguments = File.ReadAllText(@"Firefox Nightly x64\updates\Profile.txt");
                    if (File.Exists(@"Firefox Nightly x64\profile\extensions.json"))
                    {
                        File.Delete(@"Firefox Nightly x64\profile\extensions.json");
                        Process.Start(@"Firefox Nightly x64\Firefox.exe", Arguments);
                    }
                    else if (File.Exists(@"profile\extensions.json"))
                    {
                        File.Delete(@"profile\extensions.json");
                        Process.Start(@"Firefox Nightly x64\Firefox.exe", Arguments);
                    }
                    else
                    {
                        Process.Start(@"Firefox Nightly x64\Firefox.exe", Arguments);
                    }
                }
            }
            else if (culture1.Name == "de-DE")
            {
                string message = "Firefox Nightly x64 ist nicht installiert";
                MessageBox.Show(message, "Firefox Nightly x64 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string message = "Firefox Nightly x64 is not installed";
                MessageBox.Show(message, "Firefox Nightly x64 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}