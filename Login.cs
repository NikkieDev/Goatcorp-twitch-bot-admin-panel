using BotSettingMenu.Classes;

namespace BotSettingMenu
{
    public partial class Login : Form
    {
        private static UserData UserDataObj = new UserData();
        private static Menu MenuForm = new Menu();
        private static UserMenu UserMenuForm = new UserMenu();
        private static Login FormObj = new Login();

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SubmitLogin_Click(object sender, EventArgs e)
        {
            bool check = UserDataObj.CheckCredentials(UserNameBox.Text, PasswordBox.Text);

            if (check == true)
            {
                MessageBoxButtons SuccessButtons = MessageBoxButtons.OK;
                MessageBox.Show("Login successful", "Success", SuccessButtons);

                this.Hide();
                MenuForm.Show();
                FormObj.Close();
            }
            else
            {
                MessageBoxButtons FailedButtons = MessageBoxButtons.OK;
                MessageBox.Show("login failed", "Failed", FailedButtons);
            }
        }

        private void UserNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangeUsername_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserMenuForm.Show();
            FormObj.Close();
        }
    }
}