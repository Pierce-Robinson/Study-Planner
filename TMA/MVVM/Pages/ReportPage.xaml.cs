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
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        LoginView lv = new LoginView();
        public ReportPage()
        {
            InitializeComponent();
            /*Threading
            *Link:https://www.tutorialspoint.com/csharp/csharp_multithreading.htm
            *Accessed:14 November 2022 */
            //threading to speed up
            Thread AllThread = new Thread(AllModules);
            AllThread.Start();
            Thread StudyThread = new Thread(SelfStudy);
            StudyThread.Start();

        }

        //sql method to call all modules
        /*Reading data from sql database
         *Link:https://stackoverflow.com/questions/4018114/read-data-from-sqldatareader
         *Accessed:14 November 2022*/
        public void AllModules()
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
                                this.Dispatcher.Invoke(() =>
                                {
                                    txtAllModules.Text += $" Module Code: {ModuleCode}\n Module Name: {ModuleName}\n Number of credits: {ModuleCredits}\n Hours of class: {ModClassHours}\n Self-Study hours: {ModSelfStudy}\n=================================\n";

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
        //sql method to call all modules
        /*Reading data from sql database
         *Link:https://stackoverflow.com/questions/4018114/read-data-from-sqldatareader
         *Accessed:14 November 2022*/
        public void SelfStudy()
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
                                int RemainingTime = Convert.ToInt32(sqlDataReader["RemainingTime"].ToString());
                                //possibly update rem mod self study
                                this.Dispatcher.Invoke(() =>
                                {
                                    txtStudyUpdate.Text += $"{ModuleCode} has {RemainingTime} Hours of self-study\n===============================\n";

                                });

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

        }
    }
}
