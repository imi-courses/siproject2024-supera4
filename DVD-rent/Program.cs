using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVD_rent.Models;
using DVD_rent.Controllers;

namespace DVD_rent
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        public static void InitializeDatabase()
        {
            using (var db = new Context())
            {
                try
                {
                    db.Pledges.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    // Handle potential database connection errors
                    Console.WriteLine($"Error initializing database: {ex.Message}");
                    throw; // Re-throw the exception to prevent the app from starting if the database is unavailable
                }
            }
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitializeDatabase();
            authorization authForm = new authorization();
            authForm.ShowDialog();

            if (authForm.UserSuccessfullyAuthenticated)
            {
                Application.Run(new Main(authForm.user));    
            }
        }
    }
}
