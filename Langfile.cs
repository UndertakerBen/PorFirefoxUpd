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
					switch (langText)
					{
						case "Button12":
							return "Выход";
						case "Button11":
							return "Установить все";
						case "Button11UAll":
							return "Обновить все";
						case "Label11":
							return "Установить все версии x86 и/или x64";
						case "checkBox4":
							return "Игнорировать проверку версии";
						case "checkBox3":
							return "Разные версии в отдельных папках";
						case "checkBox5":
							return "Создать ярлык на рабочем столе";
						case "GBox3":
							return "Выберите желаемый язык";
						case "downUnpstart":
							return "Распаковка";
						case "downUnpfine":
							return "Распакованный";
						case "infoLabel":
							return "Доступна новая версия";
						case "laterButton":
							return "нет";
						case "updateButton":
							return "Да";
						case "downLabel":
							return "ОБНОВИТЬ";
						case "MeassageVersion":
							return "Данная версия уже установлена";
						case "MeassageRunning":
							return "Необходимо закрыть Mozilla Firefox перед обновлением.";
						case "Register":
							return "регистр";
						case "Remove":
							return "Удалить";
						case "Browser":
							return " как браузер по умолчанию";
						case "Extra":
							return "отде́льно";
						case "VInfo":
							return "О версиях";
						case "AppDescriptFull":
							return "Firefox обеспечивает вам легкую и безопасную работу с веб-сайтами.Знакомый интерфейс пользователя, улучшенная система безопасности, в том числе защита от кражи личной информации, и интегрированная система поиска позволяют вам добиться максимальной отдачи от Интернета.";
					}
					break;
                case "de":
					switch (langText)
					{
						case "Button12":
							return "Beenden";
						case "Button11":
							return "Alle Installieren";
						case "Button11UAll":
							return "Alle Updaten";
						case "Label11":
							return "Alle x86 und oder x64 installieren";
						case "checkBox4":
							return "Versionkontrolle ignorieren";
						case "checkBox3":
							return "Für jede Version einen eigenen Ordner";
						case "checkBox5":
							return "Eine Verknüpfung auf dem Desktop erstellen";
						case "GBox3":
							return "Wählen Sie die gewünschte Sprache";
						case "downUnpstart":
							return "Entpacken";
						case "downUnpfine":
							return "Entpackt";
						case "infoLabel":
							return "Eine neue Version ist verfügbar";
						case "laterButton":
							return "Nein";
						case "updateButton":
							return "Ja";
						case "downLabel":
							return "Jetzt Updaten";
						case "MeassageVersion":
							return "Die selbe Version ist bereits installiert";
						case "MeassageRunning":
							return "Bitte schließen Sie den laufenden Mozilla Firefox-Browser, bevor Sie den Browser aktualisieren.";
						case "Register":
							return "Registrieren";
						case "Remove":
							return "Entfernen";
						case "Browser":
							return " als Standardbrowser";
						case "Extra":
							return "Extras";
						case "VInfo":
							return "Versions Info";
						case "AppDescriptFull":
							return "Firefox ermöglicht sicheres und einfaches Surfen. Mit einer gewohnten Oberfläche, verbesserten Sicherheitsfunktionen, inklusive Schutz vor Identitätsdiebstahl und integrierter Suche holen Sie mehr aus dem Web.";
					}
                    break;
                default:
					switch (langText)
					{
						case "Button12":
							return "Quit";
						case "Button11":
							return "Install all";
						case "Button11UAll":
							return "Update all";
						case "Label11":
							return "Install all x86 and or x64";
						case "checkBox4":
							return "Ignore version check";
						case "checkBox3":
							return "Create a Folder for each version";
						case "checkBox5":
							return "Create a shortcut on the desktop";
						case "GBox3":
							return "Select your desired language";
						case "downUnpstart":
							return "Unpacking";
						case "downUnpfine":
							return "Unpacked";
						case "infoLabel":
							return "A new version is available";
						case "laterButton":
							return "No";
						case "updateButton":
							return "Yes";
						case "downLabel":
							return "Update now";
						case "MeassageVersion":
							return "The same version is already installed";
						case "MeassageRunning":
							return "Please close the running Mozilla Firefox browser before updating the browser.";
						case "Register":
							return "Register";
						case "Remove":
							return "Remove";
						case "Browser":
							return " as default browser";
						case "Extra":
							return "Extras";
						case "VInfo":
							return "Version Info";
						case "AppDescriptFull":
							return "Firefox delivers safe, easy web browsing. A familiar user interface, enhanced security features including protection from online identity theft, and integrated search let you get the most out of the web.";
					}
					break;
            }
            return "";
        }
    }
}
