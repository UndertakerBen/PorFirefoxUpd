using System.Globalization;
using System.Windows.Forms;

namespace Firefox_Updater
{
    public partial class Langfile
    {
        public static string Texts(string langText)
        {
            CultureInfo culture1 = CultureInfo.CurrentUICulture;
            switch (culture1.TwoLetterISOLanguageName)
            {
                case "ru":
                    if (langText == "Button12")
                    {
                        return "Выход";
                    }
                    else if (langText == "Button11")
                    {
                        return "Установить все";
                    }
                    else if (langText == "Button11UAll")
                    {
                        return "Обновить все";
                    }
                    else if (langText == "Label11")
                    {
                        return "Установить все версии x86 и/или x64";
                    }
                    else if (langText == "checkBox4")
                    {
                        return "Игнорировать проверку версии";
                    }
                    else if (langText == "checkBox3")
                    {
                        return "Разные версии в отдельных папках";
                    }
                    else if (langText == "checkBox5")
                    {
                        return "Создать ярлык на рабочем столе";
                    }
                    else if (langText == "GBox3")
                    {
                        return "Выберите желаемый язык";
                    }
                    else if (langText == "downUnpstart")
                    {
                        return "Распаковка";
                    }
                    else if (langText == "downUnpfine")
                    {
                        return "Распакованный";
                    }
                    else if (langText == "infoLabel")
                    {
                        return "Доступна новая версия";
                    }
                    else if (langText == "laterButton")
                    {
                        return "нет";
                    }
                    else if (langText == "updateButton")
                    {
                        return "Да";
                    }
                    else if (langText == "downLabel")
                    {
                        return "ОБНОВИТЬ";
                    }
                    else if (langText == "MeassageVersion")
                    {
                        return "Данная версия уже установлена";
                    }
                    else if (langText == "MeassageRunning")
                    {
                        return "Необходимо закрыть Mozilla Firefox перед обновлением.";
                    }
                    else if (langText == "Register")
                    {
                        return "регистр";
                    }
                    else if (langText == "Remove")
                    {
                        return "Удалить";
                    }
                    else if (langText == "Browser")
                    {
                        return " как браузер по умолчанию";
                    }
                    else if (langText == "Extra")
                    {
                        return "отде́льно";
                    }
                    else if (langText == "VInfo")
                    {
                        return "О версиях";
                    }
                    break;
                case "de":
                    if (langText == "Button12")
                    {
                        return "Beenden";
                    }
                    else if (langText == "Button11")
                    {
                        return "Alle Installieren";
                    }
                    else if (langText == "Button11UAll")
                    {
                        return "Alle Updaten";
                    }
                    else if (langText == "Label11")
                    {
                        return "Alle x86 und oder x64 installieren";
                    }
                    else if (langText == "checkBox4")
                    {
                        return "Versionkontrolle ignorieren";
                    }
                    else if (langText == "checkBox3")
                    {
                        return "Für jede Version einen eigenen Ordner";
                    }
                    else if (langText == "checkBox5")
                    {
                        return "Eine Verknüpfung auf dem Desktop erstellen";
                    }
                    else if (langText == "GBox3")
                    {
                        return "Wählen Sie die gewünschte Sprache";
                    }
                    else if (langText == "downUnpstart")
                    {
                        return "Entpacken";
                    }
                    else if (langText == "downUnpfine")
                    {
                        return "Entpackt";
                    }
                    else if (langText == "infoLabel")
                    {
                        return "Eine neue Version ist verfügbar";
                    }
                    else if (langText == "laterButton")
                    {
                        return "Nein";
                    }
                    else if (langText == "updateButton")
                    {
                        return "Ja";
                    }
                    else if (langText == "downLabel")
                    {
                        return "Update now";
                    }
                    else if (langText == "MeassageVersion")
                    {
                        return "Die selbe Version ist bereits installiert";
                    }
                    else if (langText == "MeassageRunning")
                    {
                        return "Bitte schließen Sie den laufenden Mozilla Firefox-Browser, bevor Sie den Browser aktualisieren.";
                    }
                    else if (langText == "Register")
                    {
                        return "Registrieren";
                    }
                    else if (langText == "Remove")
                    {
                        return "Entfernen";
                    }
                    else if (langText == "Browser")
                    {
                        return " als Standardbrowser";
                    }
                    else if (langText == "Extra")
                    {
                        return "Extras";
                    }
                    else if (langText == "VInfo")
                    {
                        return "Versions Info";
                    }
                    break;
                default:
                    if (langText == "Button12")
                    {
                        return "Quit";
                    }
                    else if (langText == "Button11")
                    {
                        return "Install all";
                    }
                    else if (langText == "Button11UAll")
                    {
                        return "Update all";
                    }
                    else if (langText == "Label11")
                    {
                        return "Install all x86 and or x64";
                    }
                    else if (langText == "checkBox4")
                    {
                        return "Ignore version check";
                    }
                    else if (langText == "checkBox3")
                    {
                        return "Create a Folder for each version";
                    }
                    else if (langText == "checkBox5")
                    {
                        return "Create a shortcut on the desktop";
                    }
                    else if (langText == "GBox3")
                    {
                        return "Select your desired language";
                    }
                    else if (langText == "downUnpstart")
                    {
                        return "Unpacking";
                    }
                    else if (langText == "downUnpfine")
                    {
                        return "Unpacked";
                    }
                    else if (langText == "infoLabel")
                    {
                        return "A new version is available";
                    }
                    else if (langText == "laterButton")
                    {
                        return "No";
                    }
                    else if (langText == "updateButton")
                    {
                        return "Yes";
                    }
                    else if (langText == "downLabel")
                    {
                        return "Update now";
                    }
                    else if (langText == "MeassageVersion")
                    {
                        return "The same version is already installed";
                    }
                    else if (langText == "MeassageRunning")
                    {
                        return "Please close the running Mozilla Firefox browser before updating the browser.";
                    }
                    else if (langText == "Register")
                    {
                        return "Register";
                    }
                    else if (langText == "Remove")
                    {
                        return "Remove";
                    }
                    else if (langText == "Edge")
                    {
                        return " as default browser";
                    }
                    else if (langText == "Extra")
                    {
                        return "Extras";
                    }
                    else if (langText == "VInfo")
                    {
                        return "Version Info";
                    }
                    break;
            }
            return "";
        }
    }
}
