using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVD_rent.Models;
using DVD_rent.Controllers;
using DVD_rent.Forms;

namespace DVD_rent
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 

        /// Начальное подключение базы данных
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


            //Проверка существования директора
            bool isDirectorExist = false;
            List<Employee> employees = EmployeeController.GetAllEmployees();
            foreach (Employee e in employees)
            {
                if (e.Position == Position.director)
                {
                    isDirectorExist = true;
                    break;
                }
            }

            //Регистрация
            if (!isDirectorExist)
            {
                
                Registration regForm = new Registration();
                if (regForm.ShowDialog() == DialogResult.OK)
                {
                    isDirectorExist = true;
                }
            }

            //Авторизация
            if (isDirectorExist)
            {
                Authorization authForm = new Authorization();
                if (authForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Main(authForm.user));
                }
            }
        }
    }
}
