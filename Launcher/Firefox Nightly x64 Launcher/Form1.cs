using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Firefox_Nightly_x64_Launcher
{
    public partial class Form1 : Form 
    {
        private readonly string applicationPath = Application.StartupPath;
        private readonly CultureInfo culture = CultureInfo.CurrentUICulture;
        public Form1()
        {

            InitializeComponent();
            switch (culture.TwoLetterISOLanguageName)
            {
                case "de":
                    radioButton3.Text = "Das Standard Profil von Firefox verwenden";
                    radioButton2.Text = "Für jede Version ein eigenes Profil verwenden";
                    radioButton1.Text = "Ein Profil für alle Versionen verwenden";
                    break;
                case "ru":
                    radioButton3.Text = "Использовать стандартное месторасположение профиля (readme)";
                    radioButton2.Text = "Использовать разные папки для профилей разных версий";
                    radioButton1.Text = "Использовать один профиль для всех версий";
                    break;
                default:
                    radioButton3.Text = "Use the standard profile of Firefox";
                    radioButton2.Text = "Use a separate profile for each version";
                    radioButton1.Text = "Use one profile for all versions";
                    break;
            }
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (radioButton1.Checked)
            {
                File.WriteAllText(applicationPath + "\\Firefox Nightly x64\\updates\\Profile.txt", "-allow-downgrade -profile \"profile\"");
                this.Close();
            }
            if (radioButton2.Checked)
            {
                System.IO.File.WriteAllText(applicationPath + "\\Firefox Nightly x64\\updates\\Profile.txt", "-profile \"Firefox Nightly x64\\profile\"");
                this.Close();
            }
            if (radioButton3.Checked)
            {
                System.IO.File.WriteAllText(applicationPath + "\\Firefox Nightly x64\\updates\\Profile.txt", "");
                this.Close();
            }
        }
        private void RadioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (culture.TwoLetterISOLanguageName)
            {
                case "de":
                    MessageBox.Show("Warnung\n\nDiese Option ist nicht Empfohlen\n\nDie Commandline Option \"-allow-downgrade\" wird angefügt\n\nDer Herabstufungsschutz von Firefox 67 verhindert das versehentliche Starten von Firefox in einem Profil, in dem eine spätere Version von Firefox läuft. Je nach den Änderungen zwischen den beiden Versionen sind einige Dateien in einem Profil möglicherweise nicht abwärtskompatibel. Durch das Hinzufügen dieser Option wird der Herabstufungsschutz umgangen.", "Firefox Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "ru":
                    MessageBox.Show("Предупреждение\n\nЭтот параметр не рекомендуется\n\nПараметр командной строки \"-allow-downgrade\" будет добавлен.\n\n Защита от понижения Firefox 67 предотвращает случайный запуск Firefox в профиле, в котором запущена более поздняя версия Firefox. В зависимости от изменений между двумя версиями некоторые файлы в профиле могут быть несовместимы. Добавление этой опции обходит защиту от понижения.", "Firefox Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                default:
                    MessageBox.Show("Warning\n\nThis option is not recommended\n\nThe commandline option \"-allow-downgrade\" will be added.\n\nFirefox 67's downgrade protection prevents accidentally starting Firefox in a profile running a later version of Firefox. Depending on changes between the two versions, some files in a profile may not be downwards compatible. Adding this option bypasses downgrade protection.", "Firefox Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
    }
}
