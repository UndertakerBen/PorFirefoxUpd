﻿using System.IO;
using System.Windows.Forms;

namespace Firefox_ESR_x86_Launcher
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
                File.WriteAllText(@"Firefox ESR x86\updates\Profile.txt", "-allow-downgrade -no-remote -profile \"profile\"");
                this.Close();
            }
            if (radioButton2.Checked)
            {
                File.WriteAllText(@"Firefox ESR x86\updates\Profile.txt", "-no-remote -profile \"Firefox ESR x86\\profile\"");
                this.Close();
            }
            if (radioButton3.Checked)
            {
                File.WriteAllText(@"Firefox ESR x86\updates\Profile.txt", "");
                this.Close();
            }
        }
        private void RadioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            MessageBox.Show("Warning\n\nThis option is not recommended\n\nThe commandline option \"-allow-downgrade\" will be added.\n\nFirefox 67's downgrade protection prevents accidentally starting Firefox in a profile running a later version of Firefox. Depending on changes between the two versions, some files in a profile may not be downwards compatible. Adding this option bypasses downgrade protection.", "Firefox Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}