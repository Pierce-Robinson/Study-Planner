using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using TMA.MVVM.View;
using TMACustomLib;

namespace TMA.MVVM.Pages
{
    /// <summary>
    /// Interaction logic for AddModulePage.xaml
    /// </summary>
    public partial class AddModulePage : Page
    {
        LoginView lv = new LoginView();

        public AddModulePage()
        {
            InitializeComponent();
            Thread UpdateThread = new Thread(Updatetxtbox);
            UpdateThread.Start();

        }

        private void btnAddMod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HomePage.mc.Code = txtModuleCode.Text;
                HomePage.mc.Name = txtModuleName.Text;
                HomePage.mc.NumCredits = Convert.ToInt32(txtModuleCredits.Text);
                HomePage.mc.ClassHrs = Convert.ToInt32(txtClassHours.Text);

                HomePage.mc.TimePerModule = ((HomePage.mc.NumCredits * 10) / HomePage.mc.NumWeeks - HomePage.mc.ClassHrs);
            }
            catch
            {
                MessageBox.Show("Make sure too enter all information correctly", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            txtCurrentMod.Clear();
            
            try
            {   //INSERT
                string query = $"INSERT INTO Module ([ModuleCode], [ModuleName], [ModuleCredits], [ModClassHours], [Username], [SelfStudyTime], [RemainingTime]) VALUES ('{txtModuleCode.Text}','{txtModuleName.Text}','{int.Parse(txtModuleCredits.Text)}','{int.Parse(txtClassHours.Text)}','{STS.currentUser}','{HomePage.mc.TimePerModule}','{HomePage.mc.TimePerModule}');";
                using (SqlConnection conn = new SqlConnection(lv.connectionString))
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        int num = command.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Make sure too enter all information correctly", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    //}
                }

                using (var _connection = new SqlConnection(lv.connectionString))
                {
                    _connection.Open();

                    using (SqlCommand command = new SqlCommand($"SELECT * FROM Module WHERE Username = '{STS.currentUser}'", _connection))
                    {

                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                string ModuleCode = sqlDataReader["ModuleCode"].ToString();
                                string ModuleName = sqlDataReader["ModuleName"].ToString();
                                int ModuleCredits = Convert.ToInt32(sqlDataReader["ModuleCredits"].ToString());
                                int ModClassHours = Convert.ToInt32(sqlDataReader["ModClassHours"].ToString());
                                int ModSelfStudy = Convert.ToInt32(sqlDataReader["SelfStudyTime"].ToString());
                                txtCurrentMod.Text += $" Module Code: {ModuleCode}\n Module Name: {ModuleName}\n Number of credits: {ModuleCredits}\n Hours of class: {ModClassHours}\n Total Self-Study hours: {ModSelfStudy}\n=================================\n";

                            }
                        }
                        sqlDataReader.Close();
                    }
                    _connection.Close();
                }
            }
            catch
            {
               
            }
            txtModuleCode.Clear();
            txtClassHours.Clear();
            txtModuleName.Clear();
            txtModuleCredits.Clear();
        }


        /*Reading data from sql database
         *Link:https://stackoverflow.com/questions/4018114/read-data-from-sqldatareader
         *Accessed:14 November 2022*/
        public void Updatetxtbox()
        {
            try
            {
                using (var _connection = new SqlConnection(lv.connectionString))
                {
                    _connection.Open();

                    using (SqlCommand command = new SqlCommand($"SELECT * FROM Module WHERE Username = '{STS.currentUser}'", _connection))
                    {

                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                string ModuleCode = sqlDataReader["ModuleCode"].ToString();
                                string ModuleName = sqlDataReader["ModuleName"].ToString();
                                int ModuleCredits = Convert.ToInt32(sqlDataReader["ModuleCredits"].ToString());
                                int ModClassHours = Convert.ToInt32(sqlDataReader["ModClassHours"].ToString());
                                int ModSelfStudy = Convert.ToInt32(sqlDataReader["SelfStudyTime"].ToString());
                                //dispatcher used for when updating a ui element using a thread
                                this.Dispatcher.Invoke(() =>
                                {
                                    txtCurrentMod.Text += $" Module Code: {ModuleCode}\n Module Name: {ModuleName}\n Number of credits: {ModuleCredits}\n Hours of class: {ModClassHours}\n Self-Study hours: {ModSelfStudy}\n=================================\n";

                                });

                            }
                        }
                        sqlDataReader.Close();
                    }
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
