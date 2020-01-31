using System.IO;
using System.Windows.Forms;

namespace Firefox_Dev_x64_Launcher
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (radioButton1.Checked)
            {
                File.WriteAllText(@"Firefox Dev x64\updates\Profile.txt", "-allow-downgrade -no-remote -profile \"profile\"");
                this.Close();
            }
            if (radioButton2.Checked)
            {
                System.IO.File.WriteAllText(@"Firefox Dev x64\updates\Profile.txt", "-no-remote -profile \"Firefox Dev x64\\profile\"");
                this.Close();
            }
            if (radioButton3.Checked)
            {
                System.IO.File.WriteAllText(@"Firefox Dev x64\updates\Profile.txt", "");
                this.Close();
            }
        }
        private void RadioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Warning\n\nThis option is not recommended\n\nThe commandline option \"-allow-downgrade\" will be added.\n\nFirefox 67's downgrade protection prevents accidentally starting Firefox in a profile running a later version of Firefox. Depending on changes between the two versions, some files in a profile may not be downwards compatible. Adding this option bypasses downgrade protection.", "Firefox Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
