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
using Firefox_Updater.Properties;

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
        readonly WebClient myWebClient = new WebClient();
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
            }
            CheckUpdate();
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
            Form progessForm = new Form
            {
                AutoSize = true,
                Size = new Size(365, 125),
                Icon = Resources.Firefox_Updater_32,
                Text = "Firefox download",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label title = new Label
            {
                AutoSize = false,
                Location = new Point(0, 5),
                Size = new Size(340, 25),
                Text = "Firefox_" + ring2[c] + "_" + buildversion[c] + "_" + architektur[a] + "_" + lang[comboIndex] + ".exe",
                TextAlign = ContentAlignment.BottomCenter
            };
            title.Font = new Font(title.Font.Name, 10F, FontStyle.Bold);
            progessForm.Controls.Add(title);
            Label downloadLabel = new Label
            {
                AutoSize = false,
                Location = new Point(15, 35),
                Size = new Size(200, 25),
                TextAlign = ContentAlignment.BottomLeft
            };
            progessForm.Controls.Add(downloadLabel);
            Label percLabel = new Label
            {
                AutoSize = false,
                Location = new Point(235, 35),
                Size = new Size(100, 25),
                TextAlign = ContentAlignment.BottomRight
            };
            progessForm.Controls.Add(percLabel);
            ProgressBar progressBarneu = new ProgressBar
            {
                Location = new Point(15, 65),
                Size = new Size(320, 7)
            };
            progessForm.Controls.Add(progressBarneu);
            List<Task> list = new List<Task>();
            WebRequest myWebRequest = WebRequest.Create("https://download.mozilla.org/?" + ring[c] + lang[comboIndex]);
            WebResponse myWebResponse = myWebRequest.GetResponse();
            Uri uri = new Uri(myWebResponse.ResponseUri.ToString());
            ServicePoint sp = ServicePointManager.FindServicePoint(uri);
            sp.ConnectionLimit = 10;
            myWebResponse.Close();
            using (WebClient myWebClient = new WebClient())
            {
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
                    if (args.Cancelled == true)
                    {
                        MessageBox.Show("Download has been canceled.");
                    }
                    else
                    {
                            downloadLabel.Text = culture1.Name != "de-DE" ? "Unpacking" : "Entpacken";
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
                    downloadLabel.Text = culture1.Name != "de-DE" ? "Unpacked" : "Entpackt";
                };
                try
                {
                    progessForm.Show();
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
            progessForm.Close();
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
        private void CheckUpdate()
        {
            Form updateForm = new Form
            {
                Size = new Size(300, 150),
                ShowIcon = true,
                Icon = Resources.Firefox_Updater_32,
                Text = "New Versioninfo",
                TopMost = true,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label versionLabel = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.BottomCenter,
                Dock = DockStyle.None,
                Location = new Point(0, 35),
                Size = new Size(280, 25),
            };
            versionLabel.Font = new Font(versionLabel.Font.Name, 10F, FontStyle.Bold);
            updateForm.Controls.Add(versionLabel);
            Label infoLabel = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.BottomCenter,
                Dock = DockStyle.None,
                Location = new Point(0, 10),
                Size = new Size(284, 25),
                Text = "Eine neue Version ist verfügbar"
            };
            infoLabel.Font = new Font(infoLabel.Font.Name, 8.75F);
            updateForm.Controls.Add(infoLabel);
            Label downLabel = new Label
            {
                Location = new Point(25, 71),
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize = false,
                Size = new Size(100, 23),
                Text = "Jetzt Updaten"
            };
            updateForm.Controls.Add(downLabel);
           
            Button laterButton = new Button
            {
                Location = new Point(135, 71),
                Text = "Nein",
                Size = new Size(40, 23)
            };
            laterButton.Click += new EventHandler(LaterButton_Click);
            updateForm.Controls.Add(laterButton);
            Button updateButton = new Button
            {
                Location = new Point(180, 71),
                Text = "Ja",
                Size = new Size(40, 23)
            };
            updateForm.Controls.Add(updateButton);
            updateButton.Click += new EventHandler(UpdateButton_Click);
            if (culture1.Name != "de-DE")
            {
                infoLabel.Text = "A new version is available";
                laterButton.Text = "No";
                updateButton.Text = "Yes";
                downLabel.Text = "Update now";
            }
            void LaterButton_Click(object sender, EventArgs e)
            {
                updateForm.Close();
            }
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var request = (WebRequest)HttpWebRequest.Create("https://github.com/UndertakerBen/PorFirefoxUpd/raw/master/Version.txt");
            var response = request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                var version = reader.ReadToEnd();
                versionLabel.Text = version;
                FileVersionInfo testm = FileVersionInfo.GetVersionInfo(applicationPath + "\\Portable Firefox Updater.exe");
                if (Convert.ToDecimal(version) > Convert.ToDecimal(testm.FileVersion))
                {
                    updateForm.Show();
                }
                reader.Close();
            }
            void UpdateButton_Click(object sender, EventArgs e)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var request2 = (WebRequest)HttpWebRequest.Create("https://github.com/UndertakerBen/PorFirefoxUpd/raw/master/Version.txt");
                var response2 = request2.GetResponse();
                using (StreamReader reader = new StreamReader(response2.GetResponseStream()))
                {
                    var version = reader.ReadToEnd();
                    reader.Close();
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    using (WebClient myWebClient2 = new WebClient())
                    {
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
        }
    }
}
