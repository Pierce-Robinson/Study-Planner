using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using TMA.MVVM.View;
using TMACustomLib;

namespace TMA.MVVM.Pages
{
    /// <summary>
    /// Interaction logic for TimeStudiedPage.xaml
    /// </summary>
    public partial class TimeStudiedPage : Page
    {

        LoginView lv = new LoginView();
        SqlConnection conn;
        SqlCommand comm;
        //local vairables
        public string cbString;
        public int remTime;
        public SqlDataReader reader;
        public int sh;
        public int ModSelfStudy;
        public TimeStudiedPage()
        {
            InitializeComponent();
            /*Threading
            *Link:https://www.tutorialspoint.com/csharp/csharp_multithreading.htm
            *Accessed:14 November 2022 */
            //Loads the data into a combo box using a thread so as to not disturb the rest of the process
            Thread UpThread = new Thread(UpdateTS);
            UpThread.Start();
            
        }

        private void btnSaveTS_Click(object sender, RoutedEventArgs e)
        {
                     
            try
            {
                int ind = cbModCode.SelectedIndex;
                cbString = cbModCode.SelectedItem.ToString();
                sh = Convert.ToInt32(txtStudiedHours.Text);
                //calculating remaining time
                RemTime();
                //studyied time
                TimeStudied();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            txtStudiedHours.Clear();
        }

        public void TimeStudied()
        {

            try
            {
                //accessed 14 november 2022
                //https://www.c-sharpcorner.com/UploadFile/718fc8/save-delete-search-and-update-record-using-sqlparameter-cl/
                // updating databases
                HomePage.mc.SelfStudy = Convert.ToInt32(txtStudiedHours.Text);
                var date = DateTime.Now.ToShortDateString();
                date = dpStudydate.SelectedDate.Value.Date.ToShortDateString();
                conn = new SqlConnection(lv.connectionString);
                comm = new SqlCommand();
                conn.Open();
                SqlParameter Username = new SqlParameter("@un", SqlDbType.NVarChar);
                SqlParameter ModuleCode = new SqlParameter("@mc", SqlDbType.NVarChar);
                SqlParameter SelfStudyHrs = new SqlParameter("@ssh", SqlDbType.Int);
                SqlParameter RemainingTime = new SqlParameter("@rmt", SqlDbType.Int);
                SqlParameter DateStudied = new SqlParameter("@ds", SqlDbType.Date);


                comm.Parameters.Add(Username);
                comm.Parameters.Add(ModuleCode);
                comm.Parameters.Add(SelfStudyHrs);
                comm.Parameters.Add(RemainingTime);
                comm.Parameters.Add(DateStudied);

                Username.Value = STS.currentUser;
                ModuleCode.Value = cbString;
                SelfStudyHrs.Value = Convert.ToInt32(txtStudiedHours.Text);
                RemainingTime.Value = remTime;
                DateStudied.Value = date;

                comm.Connection = conn;
                comm.CommandText = "update Module set SelfStudyHrs=@ssh,DateStudied=@ds, RemainingTime=@rmt where Username=@un and ModuleCode=@mc";

                try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Success, View the report page to see updated modules");

                }
                catch
                {
                    MessageBox.Show("Make sure too enter all information correctly", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                finally
                {
                    conn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Make sure too enter all information correctly", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /*Reading data from sql database
         *Link:https://stackoverflow.com/questions/4018114/read-data-from-sqldatareader
         *Accessed:14 November 2022*/
        public void RemTime()
        {
             
            try
            {
                using (var _connection = new SqlConnection(lv.connectionString))
                {
                    _connection.Open();

                    using (SqlCommand command = new SqlCommand($"SELECT * FROM Module WHERE Username = '{STS.currentUser}' AND ModuleCode ='{cbString}'", _connection))
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
                                ModSelfStudy = Convert.ToInt32(sqlDataReader["RemainingTime"].ToString());
                                remTime = ModSelfStudy - sh;
                                

                            }
                        }
                        
                        sqlDataReader.Close();
                    }
                    _connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Make sure too enter all information correctly", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }



        /*Reading data from sql database
         *Link:https://stackoverflow.com/questions/4018114/read-data-from-sqldatareader
         *Accessed:14 November 2022*/
        public void UpdateTS()
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
                                //uses a dispatcher because it updates the UI
                                this.Dispatcher.Invoke(() =>
                                {
                                    cbModCode.Items.Add(ModuleCode);
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
                MessageBox.Show("Make sure too enter all information correctly", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
