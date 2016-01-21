using System;
using System.Collections.Generic;
using System.Text;
using CICC.WR.AnnualPartyDAL;
using System.Drawing;

namespace CICC.WR.AnnualParty
{
   public static class GlobalData
    {
        private static Dictionary<string, MyEmployee> employees=new Dictionary<string,MyEmployee>();

        public static Dictionary<string, MyEmployee> Employees
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

        private static List<MyEmployee> employeeList = new List<MyEmployee>();

        public static List<MyEmployee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; }
        }
    }
}
