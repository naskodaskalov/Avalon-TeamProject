﻿
namespace Avalon.Client
{
    using Service;
    using System.Windows;

    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;
            string confirmedPassword = passwordConfirmBox.Password;


            if (password != confirmedPassword)
            {
                invalidCredentialsLabel.Content = "Passwords don't macth!";
                invalidCredentialsLabel.Visibility = Visibility.Visible;
            }
            else if (username == "" || password == "" || confirmedPassword == "")
            {
                invalidCredentialsLabel.Content = "All information is needed";
                invalidCredentialsLabel.Visibility = Visibility.Visible;
            }
            else if (UserService.IsUserExist(username.ToLower()))
            {
                invalidCredentialsLabel.Content = "Username is taken!";
                invalidCredentialsLabel.Visibility = Visibility.Visible;
            }
            else
            {
                UserService.RegisterUser(username, password);
                MainWindow mainWin = new MainWindow();
                this.Close();
                mainWin.Show();
            }

        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Login loginWin = new Login();
            this.Close();
            loginWin.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}


    

