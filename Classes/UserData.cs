using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BotSettingMenu.Classes
{
    public class Credentials
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class UserData
    {
        private static string _FileLoc = @"E:/Coding/C#/BotSettingMenu/settings.json";
        private static string _JsonData = File.ReadAllText(_FileLoc);
        private static dynamic _JsonObj = JsonConvert.DeserializeObject(_JsonData);

        public bool CheckCredentials(string _username, string _password)
        {
            bool result;

            string username = _JsonObj["login"]["username"];
            string password = _JsonObj["login"]["password"];

            if (_username == username && _password == password)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            // false = wrong credentials
            // true = right credentials
            return result;
        }

        public int ChangeUsername(string NewUserName, string CurrentPassword)
        {
            // 0 = Bad username
            // 1 = Bad password
            // 2 = Good

            if (string.IsNullOrEmpty(NewUserName) || string.IsNullOrWhiteSpace(NewUserName))
            {
                return 0;
            }
            else if (CurrentPassword != _JsonObj["login"]["password"].ToString())
            {
                return 1;
            }
            else
            {
                _JsonObj["login"]["username"] = NewUserName.ToLower();

                string NewJsonData = JsonConvert.SerializeObject(_JsonObj, Formatting.Indented);
                File.WriteAllText(_FileLoc, NewJsonData);

                return 2;
            }
        }

        public int ChangePassword(string NewPassword, string CurrentPassword)
        {
            // 0 = Bad current password
            // 1 = Bad new password
            // 2 = Good

            if (string.IsNullOrEmpty(NewPassword) || string.IsNullOrWhiteSpace(NewPassword))
            {
                return 0;
            }
            else if (CurrentPassword != _JsonObj["login"]["password"].ToString())
            {
                return 1;
            }
            else
            {
                _JsonObj["login"]["password"] = NewPassword;

                string NewJsonData = JsonConvert.SerializeObject(_JsonObj, Formatting.Indented);
                File.WriteAllText(_FileLoc, NewJsonData);

                return 2;
            }
        }
    }
}
