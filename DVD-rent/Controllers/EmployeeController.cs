using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVD_rent.Models;

namespace DVD_rent.Controllers
{
    class EmployeeController
    {
        //Id, Position, Login, Password, FullName
        public static void AddEmployee(Position position, string login, string password, string fullname)
        {
            using (Context db = new Context())
            {
                db.Employees.Add(new Employee { Position = position, Login = login, Password = password, FullName = fullname });
                db.SaveChanges();
            }
        }
        public static void EditEmployee(int id, Position position, string login, string password, string fullname)
        {
            try
            {
                Employee employee = GetEmployeeById(id);
                employee.Position = position;
                employee.Login = login;
                employee.Password = password;
                employee.FullName = fullname;

                Context db = new Context();
                //if ()
                //{
                //throw new Exception("incorrect password");
                //}
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught an exception: {ex.Message}");
            }
        }

        public static Employee GetEmployeeById(int id)
        {
            using (Context db = new Context())
            {
                return db.Employees.Find(id);
            }
        }
        public static void DeleteEmployeeById(int id)
        {
            using (Context db = new Context())
            {
                Employee employee = GetEmployeeById(id);
                db.Employees.Attach(employee);
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
        }
        public static List<Employee> GetAllEmployees()
        {
            using (Context db = new Context())
            {
                return db.Employees.ToList();
            }
        }
    }
}