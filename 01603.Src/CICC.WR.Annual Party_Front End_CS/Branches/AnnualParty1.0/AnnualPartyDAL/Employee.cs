using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.IO;

namespace CICC.WR.AnnualPartyDAL
{
  public  class Employee
    {
      public string EmployeeNumber { get; set; }
      public string Name { get; set; }
      public string Dept { get; set; }
      public Image Photo { get; set; }
      public bool Checkin { get; set; }
      public string Alias { get; set; }

      public string Pinyin { get; set; }
      public string ShortPinyin { get; set; }

      public Employee()
      {
      }
      public Employee(IDataReader reader)
      {
          LoadBasic(reader);
      }

      public void LoadBasic(IDataReader reader)
      {
          this.EmployeeNumber = (string)reader["EmployeeNumber"];
          this.Name = (string)reader["Name"];
          this.Dept = (string)reader["Dept"];
          this.Checkin = (bool)reader["CheckIn"];
          if (!Convert.IsDBNull(reader["PinyinFull"]))
          {
              this.Pinyin = (string)reader["PinyinFull"];
          }
          if (!Convert.IsDBNull(reader["PinyinShort"]))
          {
              this.ShortPinyin = (string)reader["PinyinShort"];
          }
      }
      public void LoadWithPhoto(IDataReader reader)
      {
          LoadBasic(reader);
          if (!Convert.IsDBNull(reader["Photo"]))
          {
              byte[] bImg = (byte[])reader["Photo"];
              this.Photo = AnnualPartySqlHelper.GetImage(bImg);
          }
      }


    }
}
