using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firefox_Updater
{
    public partial class Regfile
    {
        public static void RegCreate(string applicationPath, string instDir)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\FirefoxHTML.PORTABLE");
            key.SetValue(default, "Firefox Document");
            key.SetValue("FriendlyTypeName", "Firefox Document");
			key.SetValue("EditFlags", 2, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\FirefoxHTML.PORTABLE\\Application");
            key.SetValue("AppUserModelId", "Firefox.PORTABLE");
            key.SetValue("ApplicationIcon", applicationPath + @"\" + instDir + @"\firefox.exe,1");
            key.SetValue("ApplicationName", "Mozilla " + instDir + @" Portable");
            key.SetValue("ApplicationDescription", "Im Web surfen");
            key.SetValue("ApplicationCompany", "Mozilla Corporation");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\FirefoxHTML.PORTABLE\\DefaultIcon");
            key.SetValue(default, applicationPath + @"\" + instDir + @"\firefox.exe,1");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\FirefoxHTML.PORTABLE\\shell\\open\\command");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe"" -url ""%1""");
            key.Close();
			key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\FirefoxURL.PORTABLE");
            key.SetValue(default, "Firefox URL");
            key.SetValue("FriendlyTypeName", "Firefox URL");
			key.SetValue("URL Protocol", "");
			key.SetValue("EditFlags", 2, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\FirefoxURL.PORTABLE\\Application");
            key.SetValue("AppUserModelId", "Firefox.PORTABLE");
            key.SetValue("ApplicationIcon", applicationPath + @"\" + instDir + @"\firefox.exe,1");
            key.SetValue("ApplicationName", "Mozilla " + instDir + @" Portable");
            key.SetValue("ApplicationDescription", "Im Web surfen");
            key.SetValue("ApplicationCompany", "Mozilla Corporation");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\FirefoxURL.PORTABLE\\DefaultIcon");
            key.SetValue(default, applicationPath + @"\" + instDir + @"\firefox.exe,1");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\FirefoxURL.PORTABLE\\shell\\open\\command");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe"" -url ""%1""");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\RegisteredApplications");
            key.SetValue("Mozilla Firefox.PORTABLE", @"Software\Clients\StartMenuInternet\Mozilla Firefox.PORTABLE\Capabilities");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE");
            key.SetValue(default, "Mozilla " + instDir + @" Portable");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\Capabilities");
            key.SetValue("ApplicationDescription", "Firefox ermöglicht sicheres und einfaches Surfen. Mit einer gewohnten Oberfläche, verbesserten Sicherheitsfunktionen, inklusive Schutz vor Identitätsdiebstahl und integrierter Suche holen Sie mehr aus dem Web.");
            key.SetValue("ApplicationIcon", applicationPath + @"\" + instDir + @"\firefox.exe,0");
            key.SetValue("ApplicationName", "Mozilla " + instDir + @" Portable");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\Capabilities\\FileAssociations");
            key.SetValue(".htm", "FirefoxHTML.PORTABLE");
            key.SetValue(".html", "FirefoxHTML.PORTABLE");
            key.SetValue(".shtml", "FirefoxHTML.PORTABLE");
            key.SetValue(".svg", "FirefoxHTML.PORTABLE");
            key.SetValue(".xht", "FirefoxHTML.PORTABLE");
            key.SetValue(".xhtml", "FirefoxHTML.PORTABLE");
            key.SetValue(".webp", "FirefoxHTML.PORTABLE");
            key.SetValue(".pdf", "FirefoxHTML.PORTABLE");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\Capabilities\\Startmenu");
            key.SetValue("StartMenuInternet", "Mozilla Firefox.PORTABLE");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\Capabilities\\URLAssociations");
            key.SetValue("ftp", "FirefoxURL.PORTABLE");
            key.SetValue("http", "FirefoxURL.PORTABLE");
            key.SetValue("https", "FirefoxURL.PORTABLE");
            key.SetValue("mailto", "FirefoxURL.PORTABLE");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\DefaultIcon");
            key.SetValue("ApplicationIcon", applicationPath + @"\" + instDir + @"\firefox.exe,0");
            key.Close();
            //key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\InstallInfo");
            //key.SetValue("ReinstallCommand", "\"" + applicationPath + @"\\" + instDir + @" Launcher.exe"" --make-default-browser");
            //key.SetValue("HideIconsCommand", "\"" + applicationPath + @"\\" + instDir + @" Launcher.exe"" --hide-icons");
            //key.SetValue("ShowIconsCommand", "\"" + applicationPath + @"\\" + instDir + @" Launcher.exe"" --show-icons");
            //key.SetValue("IconsVisible", 1, Microsoft.Win32.RegistryValueKind.DWord);
            //key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\shell\\open\\command");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe"" \""%1\""");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.xhtml\\OpenWithProgids");
            key.SetValue("FirefoxHTML.PORTABLE", "");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.xht\\OpenWithProgids");
            key.SetValue("FirefoxHTML.PORTABLE", "");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.webp\\OpenWithProgids");
            key.SetValue("FirefoxHTML.PORTABLE", "");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.svg\\OpenWithProgids");
            key.SetValue("FirefoxHTML.PORTABLE", "");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.shtml\\OpenWithProgids");
            key.SetValue("FirefoxHTML.PORTABLE", "");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.pdf\\OpenWithProgids");
            key.SetValue("FirefoxHTML.PORTABLE", "");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.html\\OpenWithProgids");
            key.SetValue("FirefoxHTML.PORTABLE", "");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.htm\\OpenWithProgids");
            key.SetValue("FirefoxHTML.PORTABLE", "");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\firefox.exe");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe"" ""%1""");
            key.SetValue("Path", applicationPath);
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ApplicationAssociationToasts");
            key.SetValue("FirefoxHTML.PORTABLE_microsoft-edge", 0, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\Shell\\Associations\\UrlAssociations\\https\\UserChoice");
            key.SetValue("ProgId", "FirefoxHTML.PORTABLE");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\Shell\\Associations\\UrlAssociations\\http\\UserChoice");
            key.SetValue("ProgId", "FirefoxHTML.PORTABLE");
            key.Close();
			key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ftp");
            key.SetValue("URL Protocol", "");
			key.SetValue("EditFlags", 2, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();
			key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ftp\\DefaultIcon");
            key.SetValue(default, applicationPath + @"\" + instDir + @"\firefox.exe,1");
            key.Close();
			key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ftp\\shell\\open\\command");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe"" -url ""%1""");
            key.Close();
			key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\http");
            key.SetValue("URL Protocol", "");
			key.SetValue("EditFlags", 2, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();
			key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\http\\DefaultIcon");
            key.SetValue(default, applicationPath + @"\" + instDir + @"\firefox.exe,1");
            key.Close();
			key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\http\\shell\\open\\command");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe"" -url ""%1""");
            key.Close();
			key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\https");
            key.SetValue("URL Protocol", "");
			key.SetValue("EditFlags", 2, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();
			key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\https\\DefaultIcon");
            key.SetValue(default, applicationPath + @"\" + instDir + @"\firefox.exe,1");
            key.Close();
			key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\https\\shell\\open\\command");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe"" -url ""%1""");
            key.Close();
            try
            {
                key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", false);
                if (key.GetValue("ProductName").ToString().Contains("Windows 10"))
                {
                    key.Close();
                    Process process = new Process();
                    process.StartInfo.FileName = "ms-settings:defaultapps";
                    process.Start();
                }
                else
                {
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void RegDel()
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.pdf\\UserChoice", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\Capabilities\\FileAssociations", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\shell\\open\\command", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\shell\\open", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\shell", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\DefaultIcon", false);
                //Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\InstallInfo", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\Capabilities\\Startmenu", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE\\Capabilities\\URLAssociations", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\FirefoxHTML.Portable\\shell\\open\\command", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\FirefoxHTML.Portable\\shell\\open", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\FirefoxHTML.Portable\\shell", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\FirefoxHTML.Portable\\DefaultIcon", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\FirefoxHTML.Portable\\Application", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\FirefoxHTML.Portable", false);
				Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\FirefoxURL.Portable\\shell\\open\\command", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\FirefoxURL.Portable\\shell\\open", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\FirefoxURL.Portable\\shell", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\FirefoxURL.Portable\\DefaultIcon", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\FirefoxURL.Portable\\Application", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\FirefoxURL.Portable", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\msedge.exe", false);
				Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ftp\\shell\\open\\command", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ftp\\shell\\open", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ftp\\shell", false);
				Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ftp\\DefaultIcon", false);
				Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\http\\shell\\open\\command", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\http\\shell\\open", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\http\\shell", false);
				Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\http\\DefaultIcon", false);
				Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\https\\shell\\open\\command", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\https\\shell\\open", false);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\https\\shell", false);
				Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\https\\DefaultIcon", false);
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\RegisteredApplications", true);
                key.DeleteValue("Mozilla Firefox.PORTABLE", false);
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\.xhtml\\OpenWithProgids", true);
                key.DeleteValue("FirefoxHTML.PORTABLE", false);
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\.xht\\OpenWithProgids", true);
                key.DeleteValue("FirefoxHTML.PORTABLE", false);
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\.webp\\OpenWithProgids", true);
                key.DeleteValue("FirefoxHTML.PORTABLE", false);
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\.svg\\OpenWithProgids", true);
                key.DeleteValue("FirefoxHTML.PORTABLE", false);
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\.shtml\\OpenWithProgids", true);
                key.DeleteValue("FirefoxHTML.PORTABLE", false);
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\.pdf\\OpenWithProgids", true);
                key.DeleteValue("FirefoxHTML.PORTABLE", false);
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\.html\\OpenWithProgids", true);
                key.DeleteValue("FirefoxHTML.PORTABLE", false);
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\.htm\\OpenWithProgids", true);
                key.DeleteValue("FirefoxHTML.PORTABLE", false);
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ApplicationAssociationToasts", true);
                key.DeleteValue("FirefoxHTML.PORTABLE_microsoft-edge", false);
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\Shell\\Associations\\UrlAssociations\\https\\UserChoice", true);
                key.DeleteValue("Hash", false);
                key.DeleteValue("ProgId", false);
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\Shell\\Associations\\UrlAssociations\\http\\UserChoice", true);                
                key.DeleteValue("Hash", false);
                key.DeleteValue("ProgId", false);
                key.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
