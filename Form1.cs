using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections.Generic;

namespace Firefox_Updater
{
    public partial class Form1 : Form
    {
        readonly string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        readonly string applicationPath = Application.StartupPath;
        public static string[] ring = new string[10] { "product=firefox-esr-latest-ssl&os=win&lang=", "product=firefox-nightly-latest&os=win&lang=", "product=firefox-devedition-latest&os=win&lang=", "product=firefox-beta-latest&os=win&lang=", "product=firefox-latest&os=win&lang=", "product=firefox-esr-latest-ssl&os=win64&lang=", "product=firefox-nightly-latest&os=win64&lang=", "product=firefox-devedition-latest&os=win64&lang=", "product=firefox-beta-latest&os=win64&lang=", "product=firefox-latest&os=win64&lang=" };
        public static string[] lang = new string[94] { "ach", "af", "sq", "ar", "an", "hy-AM", "ast", "az", "eu", "be", "bn", "bs", "br", "bg", "my", "ca", "zh-CN", "zh-TW", "hr", "cs", "da", "nl", "en-GB", "en-CA", "en-US", "eo", "et", "fi", "fr", "fy-NL", "ff", "gd", "gl", "ka", "de", "el", "gn", "gu-IN", "he", "hi-IN", "hu", "is", "id", "ia", "ga-IE", "it", "ja", "kab", "kn", "cak", "kk", "km", "ko", "lv", "lij", "lt", "dsb", "mk", "ms", "mr", "ne-NP", "nb-NO", "nn-NO", "oc", "fa", "pl", "pt-BR", "pt-PT", "pa-IN", "ro", "rm", "ru", "sr", "si", "sk", "sl", "son", "es-AR", "es-CL", "es-MX", "es-ES", "sv-SE", "tl", "ta", "te", "th", "tr", "uk", "hsb", "ur", "uz", "vi", "cy", "xh" };
        public static string[] instDir = new string[11] { "Firefox ESR x86", "Firefox Nightly x86", "Firefox Dev x86", "Firefox Beta x86", "Firefox Stable x86", "Firefox ESR x64", "Firefox Nightly x64", "Firefox Dev x64", "Firefox Beta x64", "Firefox Stable x64", "Firefox" };
        public static string[] entpDir = new string[11] { "ESR86", "Nightly86", "Dev86", "Beta86", "Stable86", "ESR64", "Nightly64", "Dev64", "Beta64", "Stable64", "Single" };
        public static string[] ring2 = new string[10] { "ESR", "Nightly", "Developer", "Beta", "Stable", "ESR", "Nightly", "Developer", "Beta", "Stable" };
        public static string[] architektur = new string[2] { "x86", "x64" };
        public static string[] buildversion = new string[10];
        public static string[] tooltipps = new string[10];
        readonly ToolTip toolTip = new ToolTip();
        readonly WebClient myWebClient = new WebClient();
        readonly CultureInfo culture1 = CultureInfo.CurrentUICulture;
        public int comboIndex;
		public static class ProxyClass
        {
            public static WebProxy ProxyServer = null;
        }
        public Form1()
        {
            InitializeComponent();
            if (File.Exists(applicationPath + "\\Proxy.ini"))
            {
                string proxyurl = File.ReadAllText(applicationPath + "\\Proxy.ini");
                NewMethod10(proxyurl);
            }
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                if (arg.StartsWith("--proxy="))
                {
                    string proxyurl = arg.Substring(8);
                    NewMethod10(proxyurl);
                }
            }
            //try
            //{
                //WebRequest myWebRequestTest = WebRequest.Create("https://download.mozilla.org/?");
                //myWebRequestTest.Timeout = 2000;
                //myWebRequestTest.Proxy = ProxyClass.ProxyServer;
                //WebResponse myWebResponseTest = myWebRequestTest.GetResponse();
                //if (((HttpWebResponse)myWebResponseTest).StatusCode == HttpStatusCode.OK)
                //{
                    //myWebResponseTest.Close();
                //}
                //else
                //{
                    //myWebResponseTest.Close();
                    //Environment.Exit(253);
                //}
            //}
            //catch (Exception ex)
            //{
                //MessageBox.Show("Error: \n\r" + ex.Message);
                //Environment.Exit(254);
            //}
            try
            {
                for (int i = 0; i <= 4; i++)
                {
                    WebRequest myWebRequest = WebRequest.Create("https://download.mozilla.org/?" + ring[i] + "de");
                    myWebRequest.Proxy = ProxyClass.ProxyServer;
                    WebResponse myWebResponse = myWebRequest.GetResponse();
                    myWebResponse.Close();
                    if (i == 1)
                    {
                        string version = myWebResponse.ResponseUri.ToString();
                        string[] istVersion = version.Substring(version.IndexOf("firefox-")).Split(new char[] { '-', '.' });
                        buildversion[i] = istVersion[1] + "." + istVersion[2];
                        buildversion[i + 5] = istVersion[1] + "." + istVersion[2];
                    }
                    else
                    {
                        string version = myWebResponse.ResponseUri.ToString();
                        string[] istVersion = version.Substring(version.IndexOf("releases")).Split(new char[] { '/' });
                        buildversion[i] = istVersion[1];
                        buildversion[i + 5] = istVersion[1];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n\r" + ex.Message);
                Environment.Exit(255);
            }

            label6.Text = buildversion[0];
            label7.Text = buildversion[1];
            label8.Text = buildversion[2];
            label9.Text = buildversion[3];
            label10.Text = buildversion[4];
            button11.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            switch (culture1.TwoLetterISOLanguageName)
            {
                case "ru":
                    comboBox1.SelectedIndex = Array.IndexOf(lang, "ru");
                    break;
                case "de":
                    comboBox1.SelectedIndex = Array.IndexOf(lang, "de");
                    break;
                default:
                    comboBox1.SelectedIndex = Array.IndexOf(lang, "en-US");
                    break;
            }
            comboIndex = comboBox1.SelectedIndex;
            if (IntPtr.Size != 8)
            {
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                checkBox2.Visible = false;
            }
            if (IntPtr.Size == 8)
            {
                if (File.Exists(@"Firefox ESR x64\Firefox.exe") || File.Exists(@"Firefox Nightly x64\Firefox.exe") || File.Exists(@"Firefox Dev x64\Firefox.exe") || File.Exists(@"Firefox Beta x64\Firefox.exe") || File.Exists(@"Firefox Stable x64\Firefox.exe"))
                {
                    checkBox2.Enabled = false;
                }
                if (File.Exists(@"Firefox ESR x86\Firefox.exe") || File.Exists(@"Firefox Nightly x86\Firefox.exe") || File.Exists(@"Firefox Dev x86\Firefox.exe") || File.Exists(@"Firefox Beta x86\Firefox.exe") || File.Exists(@"Firefox Stable x86\Firefox.exe"))
                {
                    checkBox1.Enabled = false;
                }
                if (File.Exists(@"Firefox ESR x86\Firefox.exe") || File.Exists(@"Firefox Nightly x86\Firefox.exe") || File.Exists(@"Firefox Dev x86\Firefox.exe") || File.Exists(@"Firefox Beta x86\Firefox.exe") || File.Exists(@"Firefox Stable x86\Firefox.exe") || File.Exists(@"Firefox ESR x64") || File.Exists(@"Firefox Nightly x64\Firefox.exe") || File.Exists(@"Firefox Dev x64\Firefox.exe") || File.Exists(@"Firefox Beta x64\Firefox.exe") || File.Exists(@"Firefox Stable x64\Firefox.exe"))
                {
                    checkBox3.Checked = true;
                    CheckButton();
                }
                else if (!checkBox3.Checked)
                {
                    checkBox1.Enabled = false;
                    checkBox2.Enabled = false;
                    button11.Enabled = false;
                    button11.BackColor = Color.FromArgb(244, 244, 244);

                    if (File.Exists(@"Firefox\Firefox.exe"))
                    {
                        CheckButton2();
                    }
                }
            }
            else if (IntPtr.Size != 8)
            {
                if (File.Exists(@"Firefox ESR x86") || File.Exists(@"Firefox Nightly x86\Firefox.exe") || File.Exists(@"Firefox Dev x86\Firefox.exe") || File.Exists(@"Firefox Beta x86\Firefox.exe") || File.Exists(@"Firefox Stable x86\Firefox.exe"))
                {
                    checkBox3.Checked = true;
                    checkBox1.Enabled = false;
                    CheckButton();
                }
                else if (!checkBox3.Checked)
                {
                    checkBox1.Enabled = false;
                    button11.Enabled = false;
                    button11.BackColor = Color.FromArgb(244, 244, 244);

                    if (File.Exists(@"Firefox\Firefox.exe"))
                    {
                        CheckButton2();
                    }
                }
            }
            //}
            CheckUpdate();
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName.Equals("firefox"))
                {
                    MessageBox.Show(Langfile.Texts("MeassageRunning"), "Portable Firefox Updater", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboIndex = comboBox1.SelectedIndex;
        }
        private async void Button1_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                await NewMethod(0, 0, 0, 1);
            }
            else if (!checkBox3.Checked)
            {
                await NewMethod1(0, 10, 0, 1);
            }
        }
        private async void Button2_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                await NewMethod(0, 1, 1, 2);
            }
            else if (!checkBox3.Checked)
            {
                await NewMethod1(0, 10, 1, 2);
            }
        }
        private async void Button3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                await NewMethod(0, 2, 2, 3);
            }
            else if (!checkBox3.Checked)
            {
                await NewMethod1(0, 10, 2, 3);
            }
        }
        private async void Button4_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                await NewMethod(0, 3, 3, 4);
            }
            else if (!checkBox3.Checked)
            {
                await NewMethod1(0, 10, 3, 4);
            }
        }
        private async void Button5_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                await NewMethod(0, 4, 4, 5);
            }
            else if (!checkBox3.Checked)
            {
                await NewMethod1(0, 10, 4, 5);
            }
        }
        private async void Button6_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                await NewMethod(1, 5, 5,6);
            }
            else if (!checkBox3.Checked)
            {
                await NewMethod1(1, 10, 5, 6);
            }
        }
        private async void Button7_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                await NewMethod(1, 6, 6, 7);
            }
            else if (!checkBox3.Checked)
            {
                await NewMethod1(1, 10, 6, 7);
            }
        }
        private async void Button8_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                await NewMethod(1, 7, 7, 8);
            }
            else if (!checkBox3.Checked)
            {
                await NewMethod1(1, 10, 7, 8);
            }
        }
        private async void Button9_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                await NewMethod(1, 8, 8,9);
            }
            else if (!checkBox3.Checked)
            {
                await NewMethod1(1, 10, 8, 9);
            }
        }
        private async void Button10_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                await NewMethod(1, 9, 9, 10);
            }
            else if (!checkBox3.Checked)
            {
                await NewMethod1(1, 10, 9, 10);
            }
        }
        private async void Button11_Click(object sender, EventArgs e)
        {
            await Testing();
        }
        private async Task Testing()
        {
            if ((!Directory.Exists(@"Firefox ESR x86")) && (!Directory.Exists(@"Firefox Nightly x86")) && (!Directory.Exists(@"Firefox Dev x86")) && (!Directory.Exists(@"Firefox Beta x86")) && (!Directory.Exists(@"Firefox Stable x86")))
            {
                if (checkBox1.Checked)
                {
                    await DownloadFile(0, 0, 0,1);
                    await DownloadFile(0, 1, 1,2);
                    await DownloadFile(0, 2, 2,3);
                    await DownloadFile(0, 3, 3, 4);
                    await DownloadFile(0, 4, 4, 5);
					checkBox1.Checked = false;
                    checkBox1.Enabled = false;
                }
            }

            await NewMethod2(0, 0, 0, 1);
            await NewMethod2(0, 1, 1, 2);
            await NewMethod2(0, 2, 2, 3);
            await NewMethod2(0, 3, 3, 4);
            await NewMethod2(0, 4, 4, 5);
            if (IntPtr.Size == 8)
            {
                if ((!Directory.Exists(@"Firefox ESR x64")) && (!Directory.Exists(@"Firefox Nightly x64")) && (!Directory.Exists(@"Firefox Dev x64")) && (!Directory.Exists(@"Firefox Beta x64")) && (!Directory.Exists(@"Firefox Stable x64")))
                {
                    if (checkBox2.Checked)
                    {
                        await DownloadFile(1, 5, 5, 6);
                        await DownloadFile(1, 6, 6, 7);
                        await DownloadFile(1, 7, 7, 8);
                        await DownloadFile(1, 8, 8, 9);
                        await DownloadFile(1, 9, 9, 10);
						checkBox2.Checked = false;
						checkBox2.Enabled = false;
                    }
                }
                await NewMethod2(1, 5, 5, 6);
                await NewMethod2(1, 6, 6, 7);
                await NewMethod2(1, 7, 7, 8);
                await NewMethod2(1, 8, 8,9);
                await NewMethod2(1, 9, 9, 10);
            }
        }
        public async Task DownloadFile(int a, int b, int c, int g)
        {
            GroupBox progressBox = new GroupBox
            {
                Location = new Point(groupBox3.Location.X, button12.Location.Y + button12.Size.Height + 5),
                Size = new Size(groupBox3.Width, 90),
                BackColor = Color.Lavender,
            };
            Label title = new Label
            {
                AutoSize = false,
                Location = new Point(5, 10),
                Size = new Size(progressBox.Size.Width - 10, 25),
                Text = "Firefox " + ring2[c] + " " + buildversion[c] + " " + architektur[a] + " " + lang[comboIndex],
                TextAlign = ContentAlignment.BottomCenter
            };
            title.Font = new Font(title.Font.Name, 9.25F, FontStyle.Bold);
            Label downloadLabel = new Label
            {
                AutoSize = false,
                Location = new Point(8, 35),
                Size = new Size(200, 25),
                TextAlign = ContentAlignment.BottomLeft
            };
            Label percLabel = new Label
            {
                AutoSize = false,
                Location = new Point(progressBox.Size.Width - 108, 35),
                Size = new Size(100, 25),
                TextAlign = ContentAlignment.BottomRight
            };
            ProgressBar progressBarneu = new ProgressBar
            {
                Location = new Point(8, 65),
                Size = new Size(progressBox.Size.Width - 18, 7)
            };
            progressBox.Controls.Add(title);
            progressBox.Controls.Add(downloadLabel);
            progressBox.Controls.Add(percLabel);
            progressBox.Controls.Add(progressBarneu);
            Controls.Add(progressBox);
            try
            {
                List<Task> list = new List<Task>();
                WebRequest myWebRequest = WebRequest.Create("https://download.mozilla.org/?" + ring[c] + lang[comboIndex]);
                myWebRequest.Proxy = ProxyClass.ProxyServer;
                WebResponse myWebResponse = myWebRequest.GetResponse();
                Uri uri = new Uri(myWebResponse.ResponseUri.ToString());
                ServicePoint sp = ServicePointManager.FindServicePoint(uri);
                sp.ConnectionLimit = 10;
                myWebResponse.Close();
                using (WebClient myWebClient = new WebClient())
                {
                    myWebClient.Proxy = ProxyClass.ProxyServer;
                    myWebClient.DownloadProgressChanged += (o, args) =>
                    {
                        Control[] buttons = Controls.Find("button" + g, true);
                        if (buttons.Length > 0)
                        {
                            Button button = (Button)buttons[0];
                            button.BackColor = Color.Orange;
                        }
                        progressBarneu.Value = args.ProgressPercentage;
                        downloadLabel.Text = string.Format("{0} MB's / {1} MB's",
                            (args.BytesReceived / 1024d / 1024d).ToString("0.00"),
                            (args.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
                        percLabel.Text = args.ProgressPercentage.ToString() + "%";
                    };
                    myWebClient.DownloadFileCompleted += (o, args) =>
                    {
                        if (args.Error != null)
                        {
                            MessageBox.Show("Download has been canceled.\n\r" + args.Error.Message);
                        }
                        else
                        {
                            downloadLabel.Text = Langfile.Texts("downUnpstart");
                            string arguments = " x " + "Firefox_" + ring2[c] + "_" + buildversion[c] + "_" + architektur[a] + "_" + lang[comboIndex] + ".exe" + " -o" + @"Update\" + entpDir[b] + " -y";
                            Process process = new Process();
                            process.StartInfo.FileName = @"Bin\7zr.exe";
                            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                            process.StartInfo.Arguments = arguments;
                            process.Start();
                            process.WaitForExit();
                            if (File.Exists(instDir[b] + "\\updates\\Version.log"))
                            {
                                if (checkBox3.Checked)
                                {
                                    string[] instVersion = File.ReadAllText(instDir[b] + "\\updates\\Version.log").Split(new char[] { '|' });
                                    if (buildversion[c] != instVersion[0])
                                    {
                                        NewMethod4(b, c, a);
                                    }
                                    else if ((buildversion[c] == instVersion[0]) && (checkBox4.Checked))
                                    {
                                        NewMethod4(b, c, a);
                                    }
                                }
                                else if (!checkBox3.Checked)
                                {
                                    NewMethod4(b, c, a);
                                }
                            }
                            else
                            {
                                NewMethod9(b, c, a);
                            }
                        }
                        if (checkBox5.Checked)
                        {
                            if (!File.Exists(deskDir + "\\" + instDir[b] + ".lnk"))
                            {
                                NewMethod5(b);
                            }
                        }
                        if (!File.Exists(@instDir[b] + " Launcher.exe"))
                        {
                            File.Copy(@"Bin\Launcher\" + instDir[b] + " Launcher.exe", @instDir[b] + " Launcher.exe");
                        }
                        File.Delete("Firefox_" + ring2[c] + "_" + buildversion[c] + "_" + architektur[a] + "_" + lang[comboIndex] + ".exe");
                        downloadLabel.Text = Langfile.Texts("downUnpfine");
                    };
                    try
                    {
                        var task = myWebClient.DownloadFileTaskAsync(uri, "Firefox_" + ring2[c] + "_" + buildversion[c] + "_" + architektur[a] + "_" + lang[comboIndex] + ".exe");
                        list.Add(task);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                await Task.WhenAll(list);
                await Task.Delay(2000);
                Controls.Remove(progressBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n\r" + ex.Message);
                Controls.Remove(progressBox);

            }
        }
        public void Message1()
        {
            MessageBox.Show(Langfile.Texts("MeassageVersion"), "Portabel Firefox Updater", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void CheckButton()
        {
            NewMethod3();
            for (int i = 0; i <= 9; i++)
            {
                if (File.Exists(@instDir[i] + "\\updates\\Version.log"))
                {
                    Control[] buttons = Controls.Find("button" + (i + 1), true);
                    string[] instVersion = File.ReadAllText(@instDir[i] + "\\updates\\Version.log").Split(new char[] { '|' });
                    if (buildversion[i] == instVersion[0])
                    {
                        if (buttons.Length > 0)
                        {
                            Button button = (Button)buttons[0];
                            button.BackColor = Color.Green;
                        }
                    }
                    else if (buildversion[i] != instVersion[0])
                    {
                        button11.Text = Langfile.Texts("Button11UAll");
                        button11.Enabled = true;
                        button11.BackColor = Color.FromArgb(224, 224, 224);
                        if (buttons.Length > 0)
                        {
                            Button button = (Button)buttons[0];
                            button.BackColor = Color.Red;
                        }
                    }
                }
            }
        }
        public void CheckButton2()
        {
            NewMethod3();
            if (File.Exists(@"Firefox\updates\Version.log"))
            {
                string[] instVersion = File.ReadAllText(@"Firefox\updates\Version.log").Split(new char[] { '|' });
                switch (instVersion[1])
                {
                    case "ESR":
                        NewMethod6(instVersion, 1, 6 , 0);
                        break;
                    case "Nightly":
                        NewMethod6(instVersion, 2, 7, 1);
                        break;
                    case "Developer":
                        NewMethod6(instVersion, 3, 8, 2);
                        break;
                    case "Beta":
                        NewMethod6(instVersion, 4, 9, 3);
                        break;
                    case "Stable":
                        NewMethod6(instVersion, 5, 10, 4);
                        break;
                }
            }
        }
        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox2.Enabled = !File.Exists(@"Firefox ESR x64\Firefox.exe") && !File.Exists(@"Firefox Nightly x64\Firefox.exe") && !File.Exists(@"Firefox Dev x64\Firefox.exe") && !File.Exists(@"Firefox Beta x64\Firefox.exe") && !File.Exists(@"Firefox Stable x64\Firefox.exe");
                checkBox1.Enabled = !File.Exists(@"Firefox ESR x86\Firefox.exe") && !File.Exists(@"Firefox Nightly x86\Firefox.exe") && !File.Exists(@"Firefox Dev x86\Firefox.exe") && !File.Exists(@"Firefox Beta x86\Firefox.exe") && !File.Exists(@"Firefox Stable x86\Firefox.exe");
                if (button11.Enabled)
                {
                    button11.BackColor = Color.FromArgb(224, 224, 224);
                }
                CheckButton();
            }
            if (!checkBox3.Checked)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                button11.Enabled = false;
                button11.BackColor = Color.FromArgb(244, 244, 244);
                CheckButton2();
            }
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button11.Enabled = true;
                button11.BackColor = Color.FromArgb(224, 224, 224);
            }
            else if ((!checkBox1.Checked) && (!checkBox2.Checked))
            {
                button11.Enabled = false;
                button11.BackColor = Color.FromArgb(244, 244, 244);
            }
        }
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                button11.Enabled = true;
                button11.BackColor = Color.FromArgb(224, 224, 224);
            }
            else if ((!checkBox1.Checked) && (!checkBox2.Checked))
            {
                button11.Enabled = false;
                button11.BackColor = Color.FromArgb(244, 244, 244);
            }
        }
        private void Button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Directory.Exists(@"Update"))
            {
                Directory.Delete(@"Update", true);
            }
        }
        private void Button1_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(0, "x86", 1);
        }
        private void Button2_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(1, "x86", 2);
        }
        private void Button3_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(2, "x86", 3);
        }
        private void Button4_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(3, "x86", 4);
        }
        private void Button5_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(4, "x86", 5);
        }
        private void Button6_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(5, "x64", 6);
        }
        private void Button7_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(6, "x64", 7);
        }
        private void Button8_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(7, "x64", 8);
        }
        private void Button9_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(8, "x64", 9);
        }
        private void Button10_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(9, "x64", 10);
        }
        private void Button11_EnabledChanged(object sender, EventArgs e)
        {
            if (!button11.Enabled)
            {
                button11.BackColor = Color.FromArgb(244, 244, 244);
            }
        }
        private async Task NewMethod(int a, int b, int c, int g)
        {
            if (File.Exists(@instDir[b] + "\\updates\\Version.log"))
            {
                string[] instVersion = File.ReadAllText(@instDir[b] + "\\updates\\Version.log").Split(new char[] { '|' });
                if (instVersion[0] == buildversion[c])
                {
                    if (checkBox4.Checked)
                    {
                        await DownloadFile(a, b, c,g);
                    }
                    else
                    {
                        Message1();
                    }
                }
                else
                {
                    await DownloadFile(a, b, c, g);
                }
            }
            else
            {
                await DownloadFile(a, b, c, g);
            }
        }
        private async Task NewMethod1(int a, int b, int c, int g)
        {
            if (File.Exists(@"Firefox\updates\Version.log"))
            {
                string[] instVersion = File.ReadAllText(@"Firefox\updates\Version.log").Split(new char[] { '|' });
                if ((instVersion[0] == buildversion[c]) && (instVersion[1] == ring2[c]) && (instVersion[2] == architektur[a]))
                {
                    if (checkBox4.Checked)
                    {
                        await DownloadFile(a, b, c, g);
                    }
                    else
                    {
                        Message1();
                    }
                }
                else
                {
                    await DownloadFile(a, b, c, g);
                }
            }
            else
            {
                await DownloadFile(a, b, c, g);
            }
        }
        private async Task NewMethod2(int a, int b, int c, int g)
        {
            if (Directory.Exists(instDir[b]))
            {
                if (File.Exists(@instDir[b] + "\\updates\\Version.log"))
                {
                    string[] instVersion = File.ReadAllText(@instDir[b] + "\\updates\\Version.log").Split(new char[] { '|' });
                    if (instVersion[0] != buildversion[c])
                    {
                        await DownloadFile(a, b, c, g);
                    }
                }
            }
        }
        private void NewMethod3()
        {
            for (int i = 1; i <= 10; i++)
            {
                Control[] buttons = Controls.Find("button" + i, true);
                if (buttons.Length > 0)
                {
                    Button button = (Button)buttons[0];
                    button.BackColor = Color.FromArgb(224, 224, 224);
                }
            }
        }
        private void NewMethod4(int d, int c, int a)
        {
            if (Directory.Exists(instDir[d] + "\\updates"))
            {
                Directory.Move(instDir[d] + "\\Updates", @"Update\" + entpDir[d] + "\\core\\updates");
            }
            if (Directory.Exists(instDir[d] + "\\profile"))
            {
                Directory.Move(instDir[d] + "\\profile", @"Update\" + entpDir[d] + "\\core\\profile");
            }
            Thread.Sleep(2000);
            if (Directory.Exists(instDir[d]))
            {
                Directory.Delete(instDir[d], true);
            }
            Thread.Sleep(2000);
            NewMethod9(d, c, a);
        }
        private void NewMethod5(int d)
        {
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut link = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(deskDir + "\\" + instDir[d] + ".lnk");
            link.IconLocation = applicationPath + "\\" + instDir[d] + "\\Firefox.exe,0";
            link.WorkingDirectory = applicationPath;
            link.TargetPath = applicationPath + "\\" + instDir[d] + " Launcher.exe";
            link.Save();
        }
        private void NewMethod6(string[] instVersion, int a, int b, int c)
        {
            Control[] buttons = Controls.Find("button" + a, true);
            Control[] buttons2 = Controls.Find("button" + b, true);
            if (instVersion[0] == buildversion[c])
            {
                if (instVersion[2] == "x86")
                {
                    if (buttons.Length > 0)
                    {
                        Button button = (Button)buttons[0];
                        button.BackColor = Color.Green;
                    }
                }
                else if (instVersion[2] == "x64")
                {
                    if (buttons2.Length > 0)
                    {
                        Button button = (Button)buttons2[0];
                        button.BackColor = Color.Green;
                    }
                }
            }
            else if (instVersion[0] != buildversion[c])
            {
                if (instVersion[2] == "x86")
                {
                    if (buttons.Length > 0)
                    {
                        Button button = (Button)buttons[0];
                        button.BackColor = Color.Red;
                    }
                }
                else if (instVersion[2] == "x64")
                {
                    if (buttons2.Length > 0)
                    {
                        Button button = (Button)buttons2[0];
                        button.BackColor = Color.Red;
                    }
                }
            }
        }
        private void NewMethod7(int a, string arch, int b)
        {
            Control[] buttons = Controls.Find("button" + (b), true);
            Button button = (Button)buttons[0];
            if (!checkBox3.Checked)
            {
                if (File.Exists(@"Firefox\updates\Version.log"))
                {
                    NewMethod8(a, arch, button, File.ReadAllText(@"Firefox\updates\Version.log").Split(new char[] { '|' }));
                }
            }
            if (checkBox3.Checked)
            {
                if (File.Exists(instDir[a] + "\\updates\\Version.log"))
                {
                    NewMethod8(a, arch, button, File.ReadAllText(instDir[a] + "\\updates\\Version.log").Split(new char[] { '|' }));
                }
            }
        }
        private void NewMethod8(int a, string arch, Button button, string[] instVersion)
        {
            if ((instVersion[1] == ring2[a]) && (instVersion[2] == arch))
            {
                toolTip.SetToolTip(button, instVersion[0]);
            }
            else
            {
                toolTip.SetToolTip(button, String.Empty);
            }
        }
        private void NewMethod9(int d, int c, int a)
        {
            Directory.Move(@"Update\" + entpDir[d] + "\\core", instDir[d]);
            if (!Directory.Exists(instDir[d] + "\\updates"))
            {
                Directory.CreateDirectory(instDir[d] + "\\updates");
            }
            File.WriteAllText(instDir[d] + "\\updates\\Version.log", buildversion[c] + "|" + ring2[c] + "|" + architektur[a]);
            Directory.Delete(@"Update\" + entpDir[d], true);
            if (checkBox3.Checked)
            {
                CheckButton();
            }
            else if (!checkBox3.Checked)
            {
                CheckButton2();
            }
        }
        private void NewMethod10(string proxyurl)
        {
            Text = Text + " - Proxy: " + proxyurl;
            ProxyClass.ProxyServer = new WebProxy(proxyurl)
            {
                UseDefaultCredentials = true,
                Credentials = CredentialCache.DefaultNetworkCredentials
            };
        }
        private void CheckUpdate()
        {
            GroupBox groupBoxupdate = new GroupBox
            {
                Location = new Point(groupBox3.Location.X, button12.Location.Y + button12.Size.Height + 5),
                Size = new Size(groupBox3.Width, 90),
                BackColor = Color.Aqua
            };
            Label versionLabel = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.BottomCenter,
                Dock = DockStyle.None,
                Location = new Point(2, 30),
                Size = new Size(groupBoxupdate.Width - 4, 25),
            };
            versionLabel.Font = new Font(versionLabel.Font.Name, 10F, FontStyle.Bold);
            Label infoLabel = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.BottomCenter,
                Dock = DockStyle.None,
                Location = new Point(2, 10),
                Size = new Size(groupBoxupdate.Width - 4, 20),
            };
            infoLabel.Font = new Font(infoLabel.Font.Name, 8.75F);
            Label downLabel = new Label
            {
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize = false,
                Size = new Size(100, 23),
            };
            Button laterButton = new Button
            {
                Size = new Size(50, 23),
                BackColor = Color.FromArgb(224, 224, 224)
            };
            Button updateButton = new Button
            {
                Location = new Point(groupBoxupdate.Width - Width - 10, 60),
                Size = new Size(50, 23),
                BackColor = Color.FromArgb(224, 224, 224)
            };
            updateButton.Location = new Point(groupBoxupdate.Width - updateButton.Width - 10, 60);
            laterButton.Location = new Point(updateButton.Location.X - laterButton.Width - 5, 60);
            downLabel.Location = new Point(laterButton.Location.X - downLabel.Width - 20, 60);
            groupBoxupdate.Controls.Add(updateButton);
            groupBoxupdate.Controls.Add(laterButton);
            groupBoxupdate.Controls.Add(downLabel);
            groupBoxupdate.Controls.Add(infoLabel);
            groupBoxupdate.Controls.Add(versionLabel);
            updateButton.Click += new EventHandler(UpdateButton_Click);
            laterButton.Click += new EventHandler(LaterButton_Click);
            infoLabel.Text = Langfile.Texts("infoLabel");
            laterButton.Text = Langfile.Texts("laterButton"); ;
            updateButton.Text = Langfile.Texts("updateButton"); ;
            downLabel.Text = Langfile.Texts("downLabel"); ;
            void LaterButton_Click(object sender, EventArgs e)
            {
                groupBoxupdate.Dispose();
                Controls.Remove(groupBoxupdate);
                groupBox3.Enabled = true;
            }
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var request = WebRequest.Create("https://github.com/UndertakerBen/PorFirefoxUpd/raw/master/Version.txt");
				request.Proxy = ProxyClass.ProxyServer;															 
                var response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var version = reader.ReadToEnd();
                    FileVersionInfo testm = FileVersionInfo.GetVersionInfo(applicationPath + "\\Portable Firefox Updater.exe");
                    versionLabel.Text = testm.FileVersion + "  >>> " + version;
                    if (Convert.ToInt32(version.Replace(".", "")) > Convert.ToInt32(testm.FileVersion.Replace(".", "")))
                    {
                        Controls.Add(groupBoxupdate);
                        groupBox3.Enabled = false;
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {

            }
            void UpdateButton_Click(object sender, EventArgs e)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var request2 = WebRequest.Create("https://github.com/UndertakerBen/PorFirefoxUpd/raw/master/Version.txt");
				request2.Proxy = ProxyClass.ProxyServer;															  
                var response2 = request2.GetResponse();
                using (StreamReader reader = new StreamReader(response2.GetResponseStream()))
                {
                    var version = reader.ReadToEnd();
                    reader.Close();
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    using (WebClient myWebClient2 = new WebClient())
                    {
						myWebClient2.Proxy = ProxyClass.ProxyServer;																  
                        myWebClient2.DownloadFile($"https://github.com/UndertakerBen/PorFirefoxUpd/releases/download/v{version}/Portable.Firefox.Updater.v{version}.7z", @"Portable.Firefox.Updater.v" + version + ".7z");
                    }
                    File.AppendAllText(@"Update.cmd", "@echo off" + "\n" +
                        "timeout /t 1 /nobreak" + "\n" +
                        "\"" + applicationPath + "\\Bin\\7zr.exe\" e \"" + applicationPath + "\\Portable.Firefox.Updater.v" + version + ".7z\" -o\"" + applicationPath + "\" \"Portable Firefox Updater.exe\"" + " -y\n" +
                        "call cmd /c Start /b \"\" " + "\"" + applicationPath + "\\Portable Firefox Updater.exe\"\n" +
                        "del /f /q \"" + applicationPath + "\\Portable.Firefox.Updater.v" + version + ".7z\"\n" +
                        "del /f /q \"" + applicationPath + "\\Update.cmd\" && exit\n" +
                        "exit\n");

                    string arguments = " /c call Update.cmd";
                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = arguments;
                    process.Start();
                    Close();
                }
            }
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var request = WebRequest.Create("https://github.com/UndertakerBen/PorFirefoxUpd/raw/master/Launcher/Version.txt");
				request.Proxy = ProxyClass.ProxyServer;															 
                var response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var version = reader.ReadToEnd();
                    FileVersionInfo testm = FileVersionInfo.GetVersionInfo(applicationPath + "\\Bin\\Launcher\\Firefox Launcher.exe");
                    if (Convert.ToInt32(version.Replace(".", "")) > Convert.ToInt32(testm.FileVersion.Replace(".", "")))
                    {
                        reader.Close();
                        try
                        {
                            using (WebClient myWebClient2 = new WebClient())
                            {
								myWebClient2.Proxy = ProxyClass.ProxyServer;																  
                                myWebClient2.DownloadFile("https://github.com/UndertakerBen/PorFirefoxUpd/raw/master/Launcher/Launcher.7z", @"Launcher.7z");
                            }
                            string arguments = " x " + @"Launcher.7z" + " -o" + @"Bin\\Launcher" + " -y";
                            Process process = new Process();
                            process.StartInfo.FileName = @"Bin\7zr.exe";
                            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                            process.StartInfo.Arguments = arguments;
                            process.Start();
                            process.WaitForExit();
                            File.Delete(@"Launcher.7z");
                            foreach (string launcher in instDir)
                            {
                                if (File.Exists(launcher + " Launcher.exe"))
                                {
                                    FileVersionInfo binLauncher = FileVersionInfo.GetVersionInfo(applicationPath + "\\Bin\\Launcher\\" + launcher + " Launcher.exe");
                                    FileVersionInfo istLauncher = FileVersionInfo.GetVersionInfo(applicationPath + "\\" + launcher + " Launcher.exe");
                                    if (Convert.ToDecimal(binLauncher.FileVersion) > Convert.ToDecimal(istLauncher.FileVersion))
                                    {
                                        File.Copy(@"bin\\Launcher\\" + launcher + " Launcher.exe", launcher + " Launcher.exe", true);
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void VersionInfo_Click(object sender, EventArgs e)
        {
            FileVersionInfo updVersion = FileVersionInfo.GetVersionInfo(applicationPath + "\\Portable Firefox Updater.exe");
            FileVersionInfo launcherVersion = FileVersionInfo.GetVersionInfo(applicationPath + "\\Bin\\Launcher\\Firefox Launcher.exe");
            MessageBox.Show("Updater Version - " + updVersion.FileVersion + "\nLauncher Version - " + launcherVersion.FileVersion, "Version Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void RegistrierenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Regfile.RegCreate(applicationPath, instDir[10]);
        }
        private void RegistrierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Regfile.RegCreate(applicationPath, instDir[9]);
        }

        private void RegistrierenToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Regfile.RegCreate(applicationPath, instDir[4]);
        }
        private void RegistrierenToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Regfile.RegCreate(applicationPath, instDir[3]);
        }
        private void RegistrierenToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Regfile.RegCreate(applicationPath, instDir[8]);
        }
        private void RegistrierenToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Regfile.RegCreate(applicationPath, instDir[2]);
        }
        private void RegistrierenToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Regfile.RegCreate(applicationPath, instDir[7]);
        }
        private void RegistrierenToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Regfile.RegCreate(applicationPath, instDir[1]);
        }
        private void RegistrierenToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Regfile.RegCreate(applicationPath, instDir[6]);
        }
        private void RegistrierenToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Regfile.RegCreate(applicationPath, instDir[0]);
        }
        private void RegistrierenToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Regfile.RegCreate(applicationPath, instDir[5]);
        }
        private void EntfernenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registrierenToolStripMenuItem1.Enabled = true;
            Regfile.RegDel();
        }
        private void EntfernenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            registrierenToolStripMenuItem.Enabled = true;
            Regfile.RegDel();
        }
        private void EntfernenToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            registrierenToolStripMenuItem2.Enabled = true;
            Regfile.RegDel();
        }
        private void EntfernenToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            registrierenToolStripMenuItem3.Enabled = true;
            Regfile.RegDel();
        }
        private void EntfernenToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            registrierenToolStripMenuItem4.Enabled = true;
            Regfile.RegDel();
        }
        private void EntfernenToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            registrierenToolStripMenuItem5.Enabled = true;
            Regfile.RegDel();
        }
        private void EntfernenToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            registrierenToolStripMenuItem6.Enabled = true;
            Regfile.RegDel();
        }
        private void EntfernenToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            registrierenToolStripMenuItem7.Enabled = true;
            Regfile.RegDel();
        }
        private void EntfernenToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            registrierenToolStripMenuItem8.Enabled = true;
            Regfile.RegDel();
        }
        private void EntfernenToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            registrierenToolStripMenuItem9.Enabled = true;
            Regfile.RegDel();
        }

        private void EntfernenToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            registrierenToolStripMenuItem10.Enabled = true;
            Regfile.RegDel();
        }
        private void ExtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                if (Microsoft.Win32.Registry.GetValue("HKEY_Current_User\\Software\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE", default, null) != null)
                {
                    key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Clients\\StartMenuInternet\\Mozilla Firefox.PORTABLE", false);
                    switch (key.GetValue(default).ToString())
                    {
                        case "Mozilla Firefox Portable":
                            key.Close();
                            registrierenToolStripMenuItem1.Enabled = false;
                            firefoxAlsStandardbrowserToolStripMenuItem.Enabled = true;
                            firefoxStableX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            break;
                        case "Mozilla Firefox Stable x86 Portable":
                            key.Close();
                            registrierenToolStripMenuItem2.Enabled = false;
                            firefoxAlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX86AlsStandardbrowserToolStripMenuItem.Enabled = true;
                            firefoxStableX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            break;
                        case "Mozilla Firefox Stable x64 Portable":
                            key.Close();
                            registrierenToolStripMenuItem.Enabled = false;
                            firefoxAlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX64AlsStandardbrowserToolStripMenuItem.Enabled = true;
                            firefoxBetaX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            break;
                        case "Mozilla Firefox Beta x86 Portable":
                            key.Close();
                            registrierenToolStripMenuItem3.Enabled = false;
                            firefoxAlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX86AlsStandardbrowserToolStripMenuItem.Enabled = true;
                            firefoxBetaX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            break;
                        case "Mozilla Firefox Beta x64 Portable":
                            key.Close();
                            registrierenToolStripMenuItem4.Enabled = false;
                            firefoxAlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX64AlsStandardbrowserToolStripMenuItem.Enabled = true;
                            firefoxDeveloperX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            break;
                        case "Mozilla Firefox Dev x86 Portable":
                            key.Close();
                            registrierenToolStripMenuItem5.Enabled = false;
                            firefoxAlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX86AlsStandardbrowserToolStripMenuItem.Enabled = true;
                            firefoxDeveloperX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            break;
                        case "Mozilla Firefox Dev x64 Portable":
                            key.Close();
                            registrierenToolStripMenuItem6.Enabled = false;
                            firefoxAlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX64AlsStandardbrowserToolStripMenuItem.Enabled = true;
                            firefoxNightlyX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            break;
                        case "Mozilla Firefox Nightly x86 Portable":
                            key.Close();
                            registrierenToolStripMenuItem7.Enabled = false;
                            firefoxAlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX86AlsStandardbrowserToolStripMenuItem.Enabled = true;
                            firefoxNightlyX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            break;
                        case "Mozilla Firefox Nightly x64 Portable":
                            key.Close();
                            registrierenToolStripMenuItem8.Enabled = false;
                            firefoxAlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX64AlsStandardbrowserToolStripMenuItem.Enabled = true;
                            firefoxESRX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            break;
                        case "Mozilla Firefox ESR x86 Portable":
                            key.Close();
                            registrierenToolStripMenuItem7.Enabled = false;
                            firefoxAlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX86AlsStandardbrowserToolStripMenuItem.Enabled = true;
                            firefoxESRX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            break;
                        case "Mozilla Firefox ESR x64 Portable":
                            key.Close();
                            registrierenToolStripMenuItem8.Enabled = false;
                            firefoxAlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxStableX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxBetaX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxDeveloperX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxNightlyX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                            firefoxESRX64AlsStandardbrowserToolStripMenuItem.Enabled = true;
                            break;
                    }
                }
                else
                {
                    if (Directory.Exists(@"Firefox"))
                    {
                        firefoxAlsStandardbrowserToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        firefoxAlsStandardbrowserToolStripMenuItem.Enabled = false;
                    }
                    if (Directory.Exists(@"Firefox Stable x86"))
                    {
                        firefoxStableX86AlsStandardbrowserToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        firefoxStableX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                    }
                    if (Directory.Exists(@"Firefox Stable x64"))
                    {
                        firefoxStableX64AlsStandardbrowserToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        firefoxStableX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                    }
                    if (Directory.Exists(@"Firefox Beta x86"))
                    {
                        firefoxBetaX86AlsStandardbrowserToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        firefoxBetaX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                    }
                    if (Directory.Exists(@"Firefox Beta x64"))
                    {
                        firefoxBetaX64AlsStandardbrowserToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        firefoxBetaX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                    }
                    if (Directory.Exists(@"Firefox Dev x86"))
                    {
                        firefoxDeveloperX86AlsStandardbrowserToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        firefoxDeveloperX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                    }
                    if (Directory.Exists(@"Firefox Dev x64"))
                    {
                        firefoxDeveloperX64AlsStandardbrowserToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        firefoxDeveloperX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                    }
                    if (Directory.Exists(@"Firefox Nightly x86"))
                    {
                        firefoxNightlyX86AlsStandardbrowserToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        firefoxNightlyX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                    }
                    if (Directory.Exists(@"Firefox Nightly x64"))
                    {
                        firefoxNightlyX64AlsStandardbrowserToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        firefoxNightlyX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                    }
                    if (Directory.Exists(@"Firefox ESR x86"))
                    {
                        firefoxESRX86AlsStandardbrowserToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        firefoxESRX86AlsStandardbrowserToolStripMenuItem.Enabled = false;
                    }
                    if (Directory.Exists(@"Firefox ESR x64"))
                    {
                        firefoxESRX64AlsStandardbrowserToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        firefoxESRX64AlsStandardbrowserToolStripMenuItem.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
