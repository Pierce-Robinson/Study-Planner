using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;
using TMACustomLib;

namespace TMA.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        //declaring connection string and sql commands   
        //
        /*Connection strings
         *Link:https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files
         *Accessed:14 November 2022*/
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataReader reader;
        public readonly string connectionString = $"Server=tcp:poeserverpart2.database.windows.net,1433;Initial Catalog=FarmCentralDB;Persist Security Info=False;User ID=st10092020;Password=Githubp@ss;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public LoginView()
        {
            InitializeComponent();
        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /*checking the login details
         *Link:https://parallelcodes.com/wpf-create-login-form-with-sql-database/
         *Accessed:14 November 2022*/
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //no threading used on login page to prevent the login happening without the user being  verified
            String message = "Invalid Credentials";
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("Select * from Users where Username=@Username", con);
                cmd.Parameters.AddWithValue("@Username", txtUsernamelogin.Text.ToString());
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Password"].ToString().Equals(Module.HashPassword(PassBox.Password.ToString()), StringComparison.InvariantCulture))
                    {
                        message = "777";
                        string user = txtUsernamelogin.Text.ToString();
                        string user2 = reader["Username"].ToString();
                    }
                }
                
                reader.Close();
                reader.Dispose();
                cmd.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
            }
            if (message == "777")
            {
                STS.currentUser = txtUsernamelogin.Text;
                MainWin mainWin = new MainWin();
                mainWin.Show();
                this.Close();
            }
            else
                MessageBox.Show(message, "Info");
        }

         /*checking the register details
         *Link:https://stackoverflow.com/questions/43563944/wpf-login-authentication-form-sql-server-database
         *Accessed:14 November 2022*/
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //hasing password on registration
            if(txtUsernamelogin.Text.Length > 3)
            {
                string haPa = Module.HashPassword(PassBox.Password);
                string query = $"INSERT INTO Users ([Username], [Password], [SemesterWeeks], [SemStartDate]) VALUES ('{txtUsernamelogin.Text}','{haPa}','999','2022-12-12');";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        int num = command.ExecuteNonQuery();
                        STS.currentUser = txtUsernamelogin.Text;
                        MainWin mainWin = new MainWin();
                        mainWin.Show();
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                        MessageBox.Show("Username is too short");

            }

        }
    }
}