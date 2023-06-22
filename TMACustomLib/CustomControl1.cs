using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace TMACustomLib
{
    public class CustomControl1 : Control
    {
        static CustomControl1()
        {

            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1), new FrameworkPropertyMetadata(typeof(CustomControl1)));
        }
    }
    
    //storing the current user so that it can be used as a sort of primary key to locate everything
    public static class STS
    {
        public static string currentUser;
        public static int numWeek;

    };

    public class Module
    {
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataReader reader;
        public readonly string connectionString = $"Server=tcp:poeserverpart2.database.windows.net,1433;Initial Catalog=FarmCentralDB;Persist Security Info=False;User ID=st10092020;Password=Githubp@ss;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public List<Module> modules = new List<Module>();
        public List<Module> GetList()
        {
            return modules;
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public int NumCredits { get; set; }
        public int ClassHrs { get; set; }
        public int NumWeeks { get; set; }
        public int TimePerModule { get; set; }
        public int Remtime { get; set; }
        public int SelfStudy { get; set; }
        public DateTime StartDate { get; set; }
        public int SelfStudyHrs { get; set; }
        public DateTime StudyDate { get; set; }
        //cs_constructors
        //availible at: https://www.w3schools.com/cs/cs_constructors.php
        //accessed: 13 September 2022
        public Module(string code, string name, int numCredits, int classHrs, int timePerModule, int remtime, int selfStudy, int numWeeks)
        {
            Code = code;
            Name = name;
            NumCredits = numCredits;
            ClassHrs = classHrs;
            TimePerModule = timePerModule;
            Remtime = remtime;
            SelfStudy = selfStudy;
            NumWeeks = numWeeks;
        }


        //calculating the self study time required per module
        public int CalculateTimePerModule()
        {
            TimePerModule = ((NumCredits * 10) / NumWeeks - ClassHrs);
            return TimePerModule;
        }
        //adding the module object to the list
        public void AddModule()
        {
            modules.Add(new Module(Code, Name, NumCredits, ClassHrs, TimePerModule, Remtime, SelfStudy, NumWeeks));
        }
        //displays the required elements from the list
        public string List()
        {
            for (int i = 0; i < modules.Count; i++)
            {
                foreach (var element in modules)
                {
                    return $"{Code}: {TimePerModule} Hours of Self-Study Required\n";
                }

            }
            return $"{Code}: {TimePerModule} Hours of Self-Study Required\n";
        }
        //displays the required elements from the list
        public string ToStringy()
        {
            return $"{Code} now has {Remtime} Hours of self-study remaining\n";
        }

        //Method to hash password
        //https://www.youtube.com/watch?v=2yEiwjUEZ78
        //bug array
        //accessed:14 November 2022
        public static string HashPassword(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedPassword);
        }

        public string Printer()
        {
            return $" Module Code: {Code}\n Module Name: {Name}\n Number of credits: {NumCredits}\n Hours of class: {ClassHrs}\n Self-Study hours: {TimePerModule}\n=================================\n";
        }
    }
}
