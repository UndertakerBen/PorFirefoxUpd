using System.IO;
using System.Windows.Forms;

namespace Firefox_ESR_x64_Launcher
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (radioButton1.Checked)
            {
                File.WriteAllText(@"Firefox ESR x64\updates\Profile.txt", "-allow-downgrade -no-remote -profile \"profile\"");
                this.Close();
            }
            if (radioButton2.Checked)
            {
                File.WriteAllText(@"Firefox ESR x64\updates\Profile.txt", "-no-remote -profile \"Firefox ESR x64\\profile\"");
                this.Close();
            }
            if (radioButton3.Checked)
            {
                File.WriteAllText(@"Firefox ESR x64\updates\Profile.txt", "");
                this.Close();
            }
        }
        private void RadioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Warnung\n\nDiese Option ist nicht Empfohlen\n\nDie Commandline Option \"-allow-downgrade\" wird angefügt\n\nDer Herabstufungsschutz von Firefox 67 verhindert das versehentliche Starten von Firefox in einem Profil, in dem eine spätere Version von Firefox läuft. Je nach den Änderungen zwischen den beiden Versionen sind einige Dateien in einem Profil möglicherweise nicht abwärtskompatibel. Durch das Hinzufügen dieser Option wird der Herabstufungsschutz umgangen.", "Firefox Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
