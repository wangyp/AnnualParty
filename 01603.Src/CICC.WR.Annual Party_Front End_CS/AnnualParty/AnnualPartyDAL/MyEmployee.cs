using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.IO;

namespace CICC.WR.AnnualPartyDAL
{
  public  class MyEmployee
    {
      public string EmployeeNumber { get; set; }
      public string Name { get; set; }
      public string Dept { get; set; }
      public Image Photo { get; set; }
      public bool Checkin { get; set; }
      public string Alias { get; set; }

      public string Pinyin { get; set; }
      public string ShortPinyin { get; set; }

      public MyEmployee()
      {
      }
        //public MyEmployee(IDataReader reader)
        //{
        //    LoadBasic(reader);
      

      public void LoadBasic(Employee reader)
      {
          this.EmployeeNumber = reader.EmployeeNumber;
          this.Name = reader.Name;
          this.Dept = reader.Dept;
          this.Checkin = reader.CheckIn;
          this.Pinyin = reader.PinyinFull;
          this.ShortPinyin = reader.PinyinShort;
          //this.EmployeeNumber = (string)reader["EmployeeNumber"];
          //this.Name = (string)reader["Name"];
          //this.Dept = (string)reader["Dept"];
          //this.Checkin = (bool)reader["CheckIn"];
          //if (!Convert.IsDBNull(reader["PinyinFull"]))
          //{
          //    this.Pinyin = (string)reader["PinyinFull"];
          //}
          //if (!Convert.IsDBNull(reader["PinyinShort"]))
          //{
          //    this.ShortPinyin = (string)reader["PinyinShort"];
          //}
      }
      public void LoadWithPhoto(Photo reader)
      {
    
          if (reader!=null)
          {
              byte[] bImg = reader.PhotoData;
              this.Photo = AnnualPartySqlHelper.GetImage(bImg);
          }
      }


    }
}
