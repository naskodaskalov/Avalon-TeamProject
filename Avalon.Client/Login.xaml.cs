namespace Avalon.Client
{
    using Avalon.Service;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            DatabaseService.InitializeDatabase();
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text.ToLower();
            string password = passwordBox.Password;
            Mouse.OverrideCursor = Cursors.Wait;

            usernameTextBox.IsEnabled = false;
            passwordBox.IsEnabled = false;
            btnLogin.IsEnabled = false;

            if (SecurityService.Login(username,password))
            {
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
            }
            else
            {
                invalidCredentialsLabale.Visibility = Visibility.Visible;
                usernameTextBox.IsEnabled = true;
                passwordBox.IsEnabled = true;
                btnLogin.IsEnabled = true;
            }
            Mouse.OverrideCursor = null;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Register registerWin = new Register();
            registerWin.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
