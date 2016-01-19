using System;
using System.Collections.Generic;
using System.Text;
using CICC.WR.AnnualPartyDAL;
using System.Drawing;

namespace CICC.WR.AnnualParty
{
   public static class GlobalData
    {
        private static Dictionary<string, Employee> employees=new Dictionary<string,Employee>();

        public static Dictionary<string, Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }
        private static Dictionary<string, Image> photos = new Dictionary<string, Image>();
        public static Dictionary<string, Image> EmployeePhotos
        {
            get { return photos; }
            set { photos = value; }
        }

        private static List<Employee> employeeList = new List<Employee>();

        public static List<Employee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; }
        }
    }
}
