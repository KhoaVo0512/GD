using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Management;
using System.IO;

namespace GD.Web
{
    public class FunctionHelper
    {
        public static string[] nameFolder = new string[] { "Library", "Lesson", "Templates" };

        public static string SerialUSB = "1405281524350436335923";

        public static string folderSave = ConfigurationSettings.AppSettings.Get("FolderSave").ToString();

        public static void TelegramSendMessage(string text)
        {
            string apiToken = "925698046:AAH23AxY5Qp6PWliyvd-b6Kd1tcdBQ3VE-0";
            string idChat = "-553199708";
            string urlString = $"https://api.telegram.org/bot{apiToken}/sendMessage?chat_id={idChat}&parse_mode=HTML&text={text}";

            WebClient webclient = new WebClient();

            webclient.DownloadString(urlString);
        }

        public static string TextSendTelegram(string projectName, string type, string nameOject, string time, string by)
        {
            string text = "";

            text = text + "- <b>Dự án:</b> " + projectName + "\n";

            text = text + "- <b>Thời gian:</b> " + time + "\n";

            text = text + "- <b>Đối tượng thao tác:</b> " + nameOject + "\n";

            text = text + "- <b>Loại:</b> " + type + "." + "\n";

            text = text + "- <b>Bởi:</b> " + by + "";

            return text;
        }

        public static string GetTeaserFromContent(string htmlString, int characterCount)
        {
            string htmlTagPattern = "<.*?>";
            var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            htmlString = regexCss.Replace(htmlString, string.Empty);
            htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
            htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            htmlString = htmlString.Replace("&nbsp;", string.Empty);
            if (htmlString.Length <= characterCount)
            {
                return htmlString;
            }
            return htmlString.Substring(0, characterCount);
        }

        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
            "đ",
            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
            "í","ì","ỉ","ĩ","ị",
            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
            "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "d",
            "e","e","e","e","e","e","e","e","e","e","e",
            "i","i","i","i","i",
            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
            "u","u","u","u","u","u","u","u","u","u","u",
            "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }

        public static bool CheckUSB()
        {
            try
            {


                bool isUsb = false;
                ManagementObjectSearcher theSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");
                foreach (ManagementBaseObject o in theSearcher.Get())
                {
                    var currentObject = (ManagementObject)o;
                    ManagementObject theSerialNumberObjectQuery = new ManagementObject("Win32_PhysicalMedia.Tag='" + currentObject["DeviceID"] + "'");
                    var data = theSerialNumberObjectQuery["SerialNumber"].ToString();
                    if (theSerialNumberObjectQuery["SerialNumber"].ToString() == SerialUSB)
                    {
                        isUsb = true;
                    }
                }

                return isUsb;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static string GetRootPath()
        {
            try
            {
                var root = "";
                DriveInfo[] allDrives = DriveInfo.GetDrives();

                foreach (DriveInfo d in allDrives)
                {
                    if (d.DriveType.ToString() == "Removable")
                    {
                        string rootPath = d.RootDirectory.ToString() + "run.bat";
                        bool checkFileRoot = System.IO.File.Exists(rootPath);
                        if (checkFileRoot)
                        {
                            root = d.RootDirectory.ToString();
                        }
                    }
                }

                return root;
            }
            catch(Exception)
            {
                return "";
            }
        }
    }
}