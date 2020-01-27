using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.IO;

namespace Firefox_Launcher
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
            if (File.Exists(@"Firefox\Firefox.exe"))
            {
                if (!File.Exists(@"Firefox\updates\Profile.txt"))
                {
                    if (culture1.Name == "de-DE")
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form1());
                        String Arguments = File.ReadAllText(@"Firefox\updates\Profile.txt");
                        _ = Process.Start(@"Firefox\Firefox.exe", Arguments);
                    }
                    else
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form2());
                        String Arguments = File.ReadAllText(@"Firefox\updates\Profile.txt");
                        _ = Process.Start(@"Firefox\Firefox.exe", Arguments);
                    }
                    }
                else
                {
                    String Arguments = File.ReadAllText(@"Firefox\updates\Profile.txt");
                    if (File.Exists(@"Firefox\profile\extensions.json"))
                    {
                        File.Delete(@"Firefox\profile\extensions.json");
                        Process.Start(@"Firefox\Firefox.exe", Arguments);
                    }
                    else if (File.Exists(@"profile\extensions.json"))
                        {
                        File.Delete(@"profile\extensions.json");
                        Process.Start(@"Firefox\Firefox.exe", Arguments);
                    }
                    else
                    {
                        Process.Start(@"Firefox\Firefox.exe", Arguments);
                    }

                }
            }
            else if (culture1.Name == "de-DE")
            {
                string message = "Firefox ist nicht installiert";
                _ = MessageBox.Show(message, "Firefox Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string message = "Firefox is not installed";
                _ = MessageBox.Show(message, "Firefox Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
