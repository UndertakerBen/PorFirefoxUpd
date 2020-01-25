using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace Firefox_2_test
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
        WebClient myWebClient = new WebClient();
        readonly CultureInfo culture1 = CultureInfo.CurrentUICulture;
        public int comboIndex;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i <= 4; i++)
            {
                WebRequest myWebRequest = WebRequest.Create("https://download.mozilla.org/?" + ring[i] + "de");
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
                label6.Text = buildversion[0];
                label7.Text = buildversion[1];
                label8.Text = buildversion[2];
                label9.Text = buildversion[3];
                label10.Text = buildversion[4];
                comboBox1.SelectedIndex = 34;
                comboIndex = comboBox1.SelectedIndex;
                button11.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                if (culture1.Name != "de-DE")
                {
                    button12.Text = "Quit";
                    button11.Text = "Install all";
                    label11.Text = "Install all x86 and or x64";
                    checkBox4.Text = "Ignore version check";
                    checkBox3.Text = "Create a Folder for each version";
                    groupBox3.Text = "Select your desired language";
                    checkBox5.Text = "Create a shortcut on the desktop";
                    comboBox1.SelectedIndex = 24;
                }
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
                    if (File.Exists(@"Firefox ESR x64") || File.Exists(@"Firefox Nightly x64\Firefox.exe") || File.Exists(@"Firefox Dev x64\Firefox.exe") || File.Exists(@"Firefox Beta x64\Firefox.exe") || File.Exists(@"Firefox Stable x64\Firefox.exe"))
                    {
                        checkBox2.Enabled = false;
                    }
                    if (File.Exists(@"Firefox ESR x86") || File.Exists(@"Firefox Nightly x86\Firefox.exe") || File.Exists(@"Firefox Dev x86\Firefox.exe") || File.Exists(@"Firefox Beta x86\Firefox.exe") || File.Exists(@"Firefox Stable x86\Firefox.exe"))
                    {
                        checkBox1.Enabled = false;
                    }
                    if (File.Exists(@"Firefox ESR x86") || File.Exists(@"Firefox Nightly x86\Firefox.exe") || File.Exists(@"Firefox Dev x86\Firefox.exe") || File.Exists(@"Firefox Beta x86\Firefox.exe") || File.Exists(@"Firefox Stable x86\Firefox.exe") || File.Exists(@"Firefox ESR x64") || File.Exists(@"Firefox Nightly x64\Firefox.exe") || File.Exists(@"Firefox Dev x64\Firefox.exe") || File.Exists(@"Firefox Beta x64\Firefox.exe") || File.Exists(@"Firefox Stable x64\Firefox.exe"))
                    {
                        checkBox3.Checked = true;
                        CheckButton();
                    }
                    else if (File.Exists(@"Firefox\Firefox.exe"))
                    {
                        CheckButton2();
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
                    else if (File.Exists(@"Firefox\Firefox.exe"))
                    {
                        CheckButton2();
                    }
                }
            }
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboIndex = comboBox1.SelectedIndex;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                NewMethod(0, 0, 0, 1, 12, 13 ,1);
            }
            else if (!checkBox3.Checked)
            {
                NewMethod(0, 10, 0, 1, 12, 13, 1);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                NewMethod(0, 1, 1, 2, 14, 15, 2);
            }
            else if (!checkBox3.Checked)
            {
                NewMethod(0, 10, 1, 1, 12, 13, 2);
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                NewMethod(0, 2, 2, 3, 17, 16, 3);
            }
            else if (!checkBox3.Checked)
            {
                NewMethod(0, 10, 2, 1, 12, 13, 3);
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                NewMethod(0, 3, 3, 4, 19, 18, 4);
            }
            else if (!checkBox3.Checked)
            {
                NewMethod(0, 10, 3, 1, 12, 13, 4);
            }
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                NewMethod(0, 4, 4, 5, 21, 20, 5);
            }
            else if (!checkBox3.Checked)
            {
                NewMethod(0, 10, 4, 1, 12, 13, 5);
            }
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                NewMethod(1, 5, 5, 6, 23, 22, 6);
            }
            else if (!checkBox3.Checked)
            {
                NewMethod(1, 10, 5, 1, 12, 13, 6);
            }
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                NewMethod(1, 6, 6, 7, 25, 24, 7);
            }
            else if (!checkBox3.Checked)
            {
                NewMethod(1, 10, 6, 1, 12, 13, 7);
            }
        }
        private void Button8_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                NewMethod(1, 7, 7, 8, 27, 26, 8);
            }
            else if (!checkBox3.Checked)
            {
                NewMethod(1, 10, 7, 1, 12, 13, 8);
            }
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                NewMethod(1, 8, 8, 9, 29, 28, 9);
            }
            else if (!checkBox3.Checked)
            {
                NewMethod(1, 10, 8, 1, 12, 13, 9);
            }
        }
        private void Button10_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                NewMethod(1, 9, 9, 10, 31, 30, 10);
            }
            else if (!checkBox3.Checked)
            {
                NewMethod(1, 10, 9, 1, 12, 13, 10);
            }
        }
        private void Button11_Click(object sender, EventArgs e)
        {
            if ((!Directory.Exists(@"Firefox ESR x86")) && (!Directory.Exists(@"Firefox Nightly x86")) && (!Directory.Exists(@"Firefox Dev x86")) && (!Directory.Exists(@"Firefox Beta x86")) && (!Directory.Exists(@"Firefox Stable x86")))
            {
                if (checkBox1.Checked)
                {
                    DownloadFile(0, 0, 0, 1, 12, 13, 1);
                    DownloadFile(0, 1, 1, 2, 14, 15, 2);
                    DownloadFile(0, 2, 2, 3, 17, 16, 3);
                    DownloadFile(0, 3, 3, 4, 19, 18, 4);
                    DownloadFile(0, 4, 4, 5, 21, 20, 5);
                }
            }

            NewMethod2(0, 0, 0, 1, 12, 13, 1);
            NewMethod2(0, 1, 1, 2, 14, 15, 2);
            NewMethod2(0, 2, 2, 3, 17, 16, 3);
            NewMethod2(0, 3, 3, 4, 19, 18, 4);
            NewMethod2(0, 4, 4, 5, 21, 20, 5);
            if (IntPtr.Size == 8)
            {
                if ((!Directory.Exists(@"Firefox ESR x64")) && (!Directory.Exists(@"Firefox Nightly x64")) && (!Directory.Exists(@"Firefox Dev x64")) && (!Directory.Exists(@"Firefox Beta x64")) && (!Directory.Exists(@"Firefox Stable x64")))
                {
                    if (checkBox2.Checked)
                    {
                        DownloadFile(1, 5, 5, 6, 23, 22, 6);
                        DownloadFile(1, 6, 6, 7, 25, 24, 7);
                        DownloadFile(1, 7, 7, 8, 27, 26, 8);
                        DownloadFile(1, 8, 8, 9, 29, 28, 9);
                        DownloadFile(1, 9, 9, 10, 31, 30, 10);
                    }
                }
                NewMethod2(1, 5, 5, 6, 23, 22, 6);
                NewMethod2(1, 6, 6, 7, 25, 24, 7);
                NewMethod2(1, 7, 7, 8, 27, 26, 8);
                NewMethod2(1, 8, 8, 9, 29, 28, 9);
                NewMethod2(1, 9, 9, 10, 31, 30, 10);
            }
        }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            string[] i = e.UserState.ToString().Split(new char[] { '|' });
            Control[] progressBars = Controls.Find("progressBar" + i[3], true);
            Control[] buttons = Controls.Find("button" + i[6], true);
            Control[] label1 = Controls.Find("label" + i[4], true);
            Control[] label2 = Controls.Find("label" + i[5], true);
            if (buttons.Length > 0)
            {
                Button button = (Button)buttons[0];
                button.BackColor = Color.Orange;
            }
            if (progressBars.Length > 0)
            {
                ProgressBar progressBar = (ProgressBar)progressBars[0];
                progressBar.Visible = true;
                progressBar.Value = e.ProgressPercentage;
            }
            if (label1.Length > 0)
            {
                Label label = (Label)label1[0];
                label.Visible = true;
                label.Text = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
            }
            if (label2.Length > 0)
            {
                Label label3 = (Label)label2[0];
                label3.Visible = true;
                label3.Text = e.ProgressPercentage.ToString() + "%";
            }
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            string[] i = e.UserState.ToString().Split(new char[] { '|' });
            int b = int.Parse(i[4]);
            var d = int.Parse(i[1]);
            int c = int.Parse(i[2]);
            int a = int.Parse(i[0]);
            Control[] labels = Controls.Find("label" + b, true);
            Label label = (Label)labels[0];
            if (e.Cancelled == true)
            {
                MessageBox.Show("Download has been canceled.");
            }
            else
            {
                if (labels.Length > 0)
                {
                    label.Text = culture1.Name != "de-DE" ? "Unpacking" : "Entpacken";
                    string arguments = " x " + i[7] + " -o" + @"Update\" + entpDir[d] + " -y";
                    Process process = new Process();
                    process.StartInfo.FileName = @"Bin\7zr.exe";
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    process.StartInfo.Arguments = arguments;
                    process.Start();
                    process.WaitForExit();
                    if (File.Exists(instDir[d] + "\\updates\\Version.log"))
                    {
                        if (checkBox3.Checked)
                        {
                            string[] instVersion = File.ReadAllText(instDir[d] + "\\updates\\Version.log").Split(new char[] { '|' });
                            if (buildversion[c] != instVersion[0])
                            {
                                NewMethod4(d, c, a);
                            }
                            else if ((buildversion[c] == instVersion[0]) && (checkBox4.Checked))
                            {
                                NewMethod4(d, c, a);
                            }
                        }
                        else if (!checkBox3.Checked)
                        {
                            NewMethod4(d, c, a);
                        }
                    }
                    else
                    {
                        NewMethod9(d, c, a);
                    }
                }
            }
            if (checkBox5.Checked)
            {
                if (!File.Exists(deskDir + "\\" + instDir[d] + ".lnk"))
                {
                    NewMethod5(d);
                }
            }
            if (!File.Exists(@instDir[d] + " Launcher.exe"))
            {
                File.Copy(@"Bin\Launcher\" + instDir[d] + " Launcher.exe", @instDir[d] + " Launcher.exe");
            }
            File.Delete(i[7]);
            label.Text = culture1.Name != "de-DE" ? "Unpacked" : "Entpackt";
        }
        public void DownloadFile(int a, int b, int c, int d, int e, int f, int g)
        {
            WebRequest myWebRequest = WebRequest.Create("https://download.mozilla.org/?" + ring[c] + lang[comboIndex]);
            WebResponse myWebResponse = myWebRequest.GetResponse();
            Uri uri = new Uri(myWebResponse.ResponseUri.ToString());
            ServicePoint sp = ServicePointManager.FindServicePoint(uri);
            sp.ConnectionLimit = 10;
            myWebResponse.Close();
            using (myWebClient = new WebClient())
            {
                myWebClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                myWebClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                try
                {
                    myWebClient.DownloadFileAsync(uri, "Firefox_" + ring2[c] + "_" + buildversion[c] + "_" + architektur[a] + "_" + lang[comboIndex] + ".exe", a + "|" + b + "|" + c + "|" + d + "|" + e + "|" + f + "|" + g + "|" + "Firefox_" + ring2[c] + "_" + buildversion[c] + "_" + architektur[a] + "_" + lang[comboIndex] + ".exe");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void Message1()
        {
            if (culture1.Name != "de-DE")
            {
                MessageBox.Show("The same version is already installed", "Portabel Firefox Updater", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                MessageBox.Show("Die selbe Version ist bereits installiert", "Portabel Firefox Updater", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
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
                        if (culture1.Name != "de-DE")
                        {
                            button11.Text = "Update all";
                        }
                        else
                        {
                            button11.Text = "Alle Updaten";
                        }
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
            NewMethod7(0, "x64", 6);
        }
        private void Button7_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(1, "x64", 7);
        }
        private void Button8_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(2, "x64", 8);
        }
        private void Button9_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(3, "x64", 9);
        }
        private void Button10_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(4, "x64", 10);
        }
        private void Button11_EnabledChanged(object sender, EventArgs e)
        {
            if (!button11.Enabled)
            {
                button11.BackColor = Color.FromArgb(244, 244, 244);
            }
        }
        private void NewMethod(int a, int b, int c, int d, int e, int f, int g)
        {
            if (File.Exists(@instDir[b] + "\\updates\\Version.log"))
            {
                string[] instVersion = File.ReadAllText(@instDir[b] + "\\updates\\Version.log").Split(new char[] { '|' });
                if (instVersion[0] == buildversion[c])
                {
                    if (checkBox4.Checked)
                    {
                        DownloadFile(a, b, c, d, e, f, g);
                    }
                    else
                    {
                        Message1();
                    }
                }
                else
                {
                    DownloadFile(a, b, c, d, e, f, g);
                }
            }
            else
            {
                DownloadFile(a, b, c, d, e, f, g);
            }
        }
        private void NewMethod1(int a, int b, int c, int d, int e, int f, int g)
        {
            if (File.Exists(@"Firefox\updates\Version.log"))
            {
                string[] instVersion = File.ReadAllText(@"Firefox\updates\Version.log").Split(new char[] { '|' });
                if ((instVersion[0] == buildversion[c]) && (instVersion[1] == ring[c]) && (instVersion[2] == architektur[a]))
                {
                    if (checkBox4.Checked)
                    {
                        DownloadFile(a, b, c, d, e, f, g);
                    }
                    else
                    {
                        Message1();
                    }
                }
                else
                {
                    DownloadFile(a, b, c, d, e, f, g);
                }
            }
            else
            {
                DownloadFile(a, b, c, d, e, f, g);
            }
        }
        private void NewMethod2(int a, int b, int c, int d, int e, int f, int g)
        {
            if (Directory.Exists(instDir[b]))
            {
                if (File.Exists(@instDir[b] + "\\updates\\Version.log"))
                {
                    string[] instVersion = File.ReadAllText(@instDir[b] + "\\updates\\Version.log").Split(new char[] { '|' });
                    if (instVersion[0] != buildversion[c])
                    {
                        DownloadFile(a, b, c, d, e, f, g);
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
    }
}
