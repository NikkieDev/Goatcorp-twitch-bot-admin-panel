using BotSettingMenu.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BotSettingMenu
{
    public partial class UserMenu : Form
    {
        private static Login LoginForm = new Login();

        private static UserData UserDataObj = new UserData();

        private static string _FileLoc = @"E:/Coding/C#/BotSettingMenu/settings.json";
        private static string _JsonData = File.ReadAllText(_FileLoc);
        private static dynamic _JsonObj = JsonConvert.DeserializeObject(_JsonData);

        public UserMenu()
        {
            InitializeComponent();
        }

        private void UserMenuLabel_Click(object sender, EventArgs e)
        {

        }

        private void NewUserNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void ChangeUsernameButton_Click(object sender, EventArgs e)
        {

            int result = UserDataObj.ChangeUsername(NewUserNameBox.Text, CurrentPasswordBox.Text);

            MessageBoxButtons _buttons = MessageBoxButtons.OK;
            DialogResult Msg;

            if (result == 0)
            {
                MessageBox.Show("Username cannot be empty!", "Invalid username", _buttons);
            }
            else if (result == 1)
            {
                MessageBox.Show("You have entered the wrong password!", "Invalid password.", _buttons);
            }
            else if (result == 2)
            {
                string NewUserName = _JsonObj["login"]["username"];
                MessageBox.Show($"Successfully changed your username to {NewUserName}", "Success", _buttons);

                this.Hide();
                LoginForm.Show();
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NewUserNameBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
