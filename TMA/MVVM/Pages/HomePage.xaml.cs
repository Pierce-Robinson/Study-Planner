using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using TMA.MVVM.View;
using TMACustomLib;

namespace TMA.MVVM.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        LoginView lv = new LoginView();
        public static Module mc;
        MainWin mw = new MainWin();
        SqlConnection conn;
        SqlCommand comm;
        public HomePage()
        {
            InitializeComponent();
            mc = new Module("", "", 0, 0, 0, 0, 0, 0);
            using (var _connection = new SqlConnection(lv.connectionString))
            {
                _connection.Open();

                using (SqlCommand command = new SqlCommand($"SELECT * FROM Users WHERE Username = '{STS.currentUser}'", _connection))
                {

                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            mc.NumWeeks = Convert.ToInt32(sqlDataReader["SemesterWeeks"]);
                            DateTime StartDate = Convert.ToDateTime(sqlDataReader["SemStartDate"]);
                            
                        }
                    }
                    sqlDataReader.Close();
                }
                _connection.Close();
            }


        }


        private void btnHomeSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {   //accessed 14 november 2022
                //https://www.c-sharpcorner.com/UploadFile/718fc8/save-delete-search-and-update-record-using-sqlparameter-cl/
                // updating databases
                HomePage.mc.NumWeeks = Convert.ToInt32(txtNumWeeks.Text);
                var date = DateTime.Now.ToShortDateString();
                date = dpSemStart.SelectedDate.Value.Date.ToShortDateString();
                conn = new SqlConnection(lv.connectionString);
                comm = new SqlCommand();
                conn.Open();
                SqlParameter Username = new SqlParameter("@un", SqlDbType.NVarChar);
                SqlParameter SemesterWeeks = new SqlParameter("@sw", SqlDbType.Int);
                SqlParameter SemStartDate = new SqlParameter("@ssd", SqlDbType.Date);


                comm.Parameters.Add(Username);
                comm.Parameters.Add(SemesterWeeks);
                comm.Parameters.Add(SemStartDate);

                Username.Value = STS.currentUser;
                SemesterWeeks.Value = Convert.ToInt32(txtNumWeeks.Text);
                SemStartDate.Value = date;

                comm.Connection = conn;
                comm.CommandText = "update Users set SemesterWeeks=@sw,SemStartDate=@ssd where Username=@un";

                try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Saved Successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
    }
}

