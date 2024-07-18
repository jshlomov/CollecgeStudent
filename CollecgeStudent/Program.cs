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
            /*
             * פירוט קצר על הפרוייקט
             * עשיתי את המסך של התלמיד שנרשם לקורסים ומשלם עליהם וכמובן יכול לראות את כל הפרטים שלו
             * ב DBContext עשיתי את כל השאילתות לדאטה בייס בעזרת פרמטרים
             * ב DAL נמצאים כל השאילתות שבהם הפרונט משתמש
             * 
             * לא הספקתי לעשות גם פרוייקט למנהל המכללה שם הייתי עושה הרשמות וכדו'
             * כמו כןשם הייתי עושה את הבונוסים והחישובים של הרווח והמחירים של הקורסים
             * הטבלאות וכל ענייני האס קיו אל נמצאים ב SQLAssets
             */

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