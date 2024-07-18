using CollecgeStudent.DAL;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace CollecgeStudent
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();
            string? conn = config["ConnectionString"];

            DBContext dbContext = new DBContext(conn);
            dbContext.ExecuteQuery("select * from Students;", null);
            Dal dal = new Dal(dbContext);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm(dal));
        }
    }
}