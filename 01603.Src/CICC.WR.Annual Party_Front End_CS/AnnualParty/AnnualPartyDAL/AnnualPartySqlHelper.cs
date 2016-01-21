using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Drawing;
using System.IO;
using System.Linq;

namespace CICC.WR.AnnualPartyDAL
{
   public class AnnualPartySqlHelper
    {
       //private string conn="";
       private AnnualPartySqlHelper()
       {
           //conn = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
       }
       private static AnnualPartySqlHelper instance = null;
       public static AnnualPartySqlHelper Instance
       {
           get
           {
               if (instance == null)
               {
                   instance = new AnnualPartySqlHelper();
               }
               return instance;
           }
       }

       private static Image GetNoPhotoImage()
       {
           string path = ConfigurationManager.AppSettings["NoPhotoImage"];
           if (!string.IsNullOrEmpty(path))
           {
               try
               {
                   Image img = new Bitmap(path);
                   return img;
               }
               catch
               {
                   return ResourceLib.NoPhoto;
               }
           }
           return ResourceLib.NoPhoto;

       }

       public Image GetEmployeePhoto(string employeeNumber)
       {
            AnnualPartyEntities entities=new AnnualPartyEntities();
           var photo = entities.Photo.SingleOrDefault(e => e.EmployeeNumber == employeeNumber);
           if (photo != null)
           {
               byte[] bImg = photo.PhotoData;
                return AnnualPartySqlHelper.GetImage(bImg);
           }
            else
            {
                return GetNoPhotoImage();
            }
           // string sql = "select Photo from Photo where EmployeeNumber=@en";
           //var reader = SqlHelper.ExecuteReader(conn, System.Data.CommandType.Text, sql, new SqlParameter("@en",employeeNumber));
           //try
           //{
           //    if (reader.Read())
           //    {
           //        if (!Convert.IsDBNull(reader["Photo"]))
           //        {
           //            byte[] bImg = (byte[])reader["Photo"];
           //            return AnnualPartySqlHelper.GetImage(bImg);
           //        }
           //        else
           //        {
           //            return GetNoPhotoImage();
           //        }
           //    }
           //    return GetNoPhotoImage();
           //}
           //finally
           //{
           //    reader.Close();
           //}
       }

       #region CheckIn Using
       /// <summary>
       /// 获得所有的员工，不管是否签到的
       /// </summary>
       /// <returns></returns>
       public Dictionary<string,MyEmployee> GetAllEmployee(bool withPhoto)
       {
           //string sql = "select * from " + (withPhoto ? "vEmployeeFull" : "Employee");
           //var reader = SqlHelper.ExecuteReader(conn, System.Data.CommandType.Text, sql);
           AnnualPartyEntities entities=new AnnualPartyEntities();
           Dictionary<string, MyEmployee> employees = new Dictionary<string, MyEmployee>();
           foreach (var reader in entities.Employee)
           {
               
               MyEmployee emp = new MyEmployee();
               if (withPhoto)
               {
                var p=   entities.Photo.SingleOrDefault(e => e.EmployeeNumber == reader.EmployeeNumber);
                   emp.LoadWithPhoto(p);
               }
               else
               {
                   emp.LoadBasic(reader);
               }
               employees.Add(emp.EmployeeNumber, emp);
           }
     
           return employees;
       }

       public List<MyEmployee> SearchEmployee(string word)
       {
      AnnualPartyEntities entities=new AnnualPartyEntities();
          var result= entities.Employee.Where(e=>e.Alias==word||e.PinyinShort==word||e.PinyinFull==word);
           List<MyEmployee> employees = new List<MyEmployee>();
           foreach (var employeeResult in result)
           {
               var e = new MyEmployee();
                e.LoadBasic(employeeResult);
                employees.Add(e);
            }
         
           return employees;
       }

       /// <summary>
       /// 获得当前已签到的人数
       /// </summary>
       /// <returns></returns>
       public int GetCheckInCount()
       {
            AnnualPartyEntities entities=new AnnualPartyEntities();
           return entities.Employee.Where(e => e.CheckIn).Count();
       
       }


       public bool CheckIn(string employeeNumber)
       {
            AnnualPartyEntities entities = new AnnualPartyEntities();
           var emp = entities.Employee.SingleOrDefault(e => e.EmployeeNumber == employeeNumber);
           emp.CheckIn = true;
            emp.CheckinTime=DateTime.Now;
           entities.SaveChanges();
           return true;
           // string sql = "update Employee set checkin=1,CheckinTime=GETDATE() where EmployeeNumber=@number";
           //return SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, sql, new SqlParameter("@number", employeeNumber)) > 0;
       }
        public bool CheckInAll()
        {
            AnnualPartyEntities entities = new AnnualPartyEntities();
            foreach (var emp in entities.Employee)
            {
       
            emp.CheckIn = true;
            emp.CheckinTime = DateTime.Now;
            }
            entities.SaveChanges();
            return true;
            // string sql = "update Employee set checkin=1,CheckinTime=GETDATE() where EmployeeNumber=@number";
            //return SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, sql, new SqlParameter("@number", employeeNumber)) > 0;
        }
        /// <summary>
        /// 取消签到
        /// </summary>
        /// <param name="employeeNumber"></param>
        /// <returns></returns>
        public bool CheckOut(string employeeNumber)
       {
            AnnualPartyEntities entities = new AnnualPartyEntities();
            var emp = entities.Employee.SingleOrDefault(e => e.EmployeeNumber == employeeNumber);
            emp.CheckIn = false;
            emp.CheckinTime = null;
            entities.SaveChanges();
            return true;
           // string sql = "update Employee set checkin=0 where EmployeeNumber=@number";
           //return SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, sql, new SqlParameter("@number", employeeNumber)) > 0;
       }
       /// <summary>
       /// 清空签到结果
       /// </summary>
       /// <returns></returns>
       public bool ClearCheckIn()
        {
            AnnualPartyEntities entities = new AnnualPartyEntities();

           foreach (var employee in entities.Employee)
           {
               employee.CheckIn = false;
               employee.CheckinTime = null;
           }
           entities.SaveChanges();
           return true;
            //string sql = "update Employee set checkin=0,CheckinTime=null";
            //return SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, sql) > 0;
        }

       // public bool UpdateShortPinyin(string number, string shortPy)
       //{
       //    string sql = "update Employee set PinyinShort=@short where EmployeeNumber=@number";
       //    return SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, sql,new SqlParameter("@short",shortPy), new SqlParameter("@number", number)) > 0;
       //}

       #endregion

       #region DrawLotteryUsing
       /// <summary>
       /// 获得所有签到的员工，用于抽奖
       /// </summary>
       /// <returns></returns>
       public Dictionary<string, MyEmployee> GetAllCheckInEmployee(bool withPhoto)
       {
           //string sql = "select * from " + (withPhoto ? "vEmployeeFull" : "Employee")+" where CheckIn=1 and Award=-1";
           //var reader = SqlHelper.ExecuteReader(conn, System.Data.CommandType.Text, sql);
           Dictionary<string, MyEmployee> employees = new Dictionary<string, MyEmployee>();
            AnnualPartyEntities entities = new AnnualPartyEntities();
           foreach (var reader in entities.Employee)
           {
              
               MyEmployee emp = new MyEmployee();
                emp.LoadBasic(reader);
                if (withPhoto)
                {
                    var pho = entities.Photo.SingleOrDefault(e => e.EmployeeNumber == reader.EmployeeNumber);
                   emp.LoadWithPhoto(pho);
               }
              
               employees.Add(emp.EmployeeNumber, emp);
           }
         
           return employees;
       }

       /// <summary>
       /// 将中奖结果写入数据库
       /// </summary>
       /// <param name="number"></param>
       /// <param name="award"></param>
       /// <returns></returns>
       public bool UpdateAward(string number, int award, string awardName)
       {
           AnnualPartyEntities entities = new AnnualPartyEntities();
           var emp = entities.Employee.SingleOrDefault(e => e.EmployeeNumber == number);
           emp.Award = award;
           emp.AwardTime = DateTime.Now;

           entities.SaveChanges();
           return true;
           // string sql = "update Employee set Award=@award,AwardTime=getdate(),AwardName=@aindex where EmployeeNumber=@number";
           //return SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, sql, 
           //    new SqlParameter("@award", award), 
           //    new SqlParameter("@number", number),
           //    new SqlParameter("@aindex", awardName)) > 0;
       }

       /// <summary>
       /// 清空中奖结果
       /// </summary>
       /// <returns></returns>
       public bool ClearAward()
       {
            AnnualPartyEntities entities = new AnnualPartyEntities();

            foreach (var employee in entities.Employee)
            {
                employee.Award = -1;
                employee.AwardTime = null;
               
            }
            entities.SaveChanges();
            return true;
            //string sql = "update Employee set Award=-1,AwardTime=null,AwardName=''";
            //return SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, sql) > 0;
        }

       /// <summary>
       /// 获得中奖的总人数
       /// </summary>
       /// <returns></returns>
       public int GetAwardUserCount()
       {
            AnnualPartyEntities entities = new AnnualPartyEntities();
          var count= entities.Employee.Where(e => e.Award != -1).Count();
           return count;
           // string sql = "select count(1) from Employee where Award!=-1";
           //return (int)SqlHelper.ExecuteScalar(conn, System.Data.CommandType.Text, sql);
       }

       /// <summary>
       /// 获得所有员工人数
       /// </summary>
       /// <returns></returns>
       public int GetTotalUserCount()
       {
            AnnualPartyEntities entities = new AnnualPartyEntities();
            var count = entities.Employee.Count();
            return count;
            //string sql = "select count(1) from Employee";
            //return (int)SqlHelper.ExecuteScalar(conn, System.Data.CommandType.Text, sql);
        }

       /// <summary>
       /// 获得照片数
       /// </summary>
       /// <returns></returns>
       public int GetTotalUserPhotoCount()
       {
            AnnualPartyEntities entities = new AnnualPartyEntities();
            var count = entities.Photo.Count();
            return count;
            //string sql = "select count(1) from Photo";
            //return (int)SqlHelper.ExecuteScalar(conn, System.Data.CommandType.Text, sql);
        }

       #endregion


       internal static Image GetImage(byte[] bData)
       {
           try
           {
               if (bData.Length == 0)
               {
                   return GetNoPhotoImage();
               }
               using (Stream fStream = new MemoryStream(bData.Length))
               {
                   BinaryWriter bWriter = new BinaryWriter(fStream);
                   bWriter.Write((byte[])bData);
                   bWriter.Flush();
                   System.Drawing.Bitmap bitMap = new System.Drawing.Bitmap(fStream);
                   bWriter.Close();
                   fStream.Close();
                   return bitMap;
               }
           }
           catch (System.IO.IOException e)
           {
               throw new Exception(e.Message + "Read image data error!");
           }
       }


       #region Admin
       /// <summary>
       /// 删除所有员工信息和照片
       /// </summary>
       public void DeleteTableData()
       {
            //string sql = "delete from Employee";
            AnnualPartyEntities entities =new AnnualPartyEntities();
           foreach (var employee in entities.Employee)
           {
               entities.Employee.Remove(employee);
           }
           
           //SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, sql);
           //sql = "delete from Photo";
           //SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, sql);
       }
       /// <summary>
       /// 插入一个员工照片
       /// </summary>
       /// <param name="number"></param>
       /// <param name="img"></param>
       public void InitPhoto(string number, Image img)
       {
            AnnualPartyEntities entities = new AnnualPartyEntities();
            Photo p=new Photo() {EmployeeNumber = number,PhotoData = ImageToByte(img) };
           entities.Photo.Add(p);
           entities.SaveChanges();
           //string sql = "insert into Photo values(@num,@img)";
           //SqlParameter p1 = new SqlParameter("@num", number);
           //SqlParameter p2 = new SqlParameter("@img", ImageToByte(img));
           //SqlHelper.ExecuteNonQuery(conn, System.Data.CommandType.Text, sql,p1,p2);
       }
       /// <summary>
       /// 获得照片数
       /// </summary>
       /// <returns></returns>
       public int GetPhotoCount()
       {
            AnnualPartyEntities entities = new AnnualPartyEntities();
          return entities.Photo.Count();
           // string sql = "select count(1) from Photo";
           //return (int)SqlHelper.ExecuteScalar(conn, System.Data.CommandType.Text, sql);
       }
       private byte[] ImageToByte(Image picture)
       {
           using (MemoryStream ms = new MemoryStream())
           {
               if (picture == null)
                   return new byte[ms.Length];
               Bitmap t = new Bitmap(picture);
               t.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
               //byte[] BPicture = new byte[ms.Length];
               //BPicture = ms.GetBuffer();
               //return BPicture;
               return ms.ToArray();
           }
       }
       /// <summary>
       /// 从HR系统中获取员工信息和照片信息
       /// </summary>
       /// <param name="conn"></param>
       /// <param name="sql"></param>
       /// <returns></returns>
       public List<MyEmployee> GetAllEmployeeFromHrDB(string conn,string sql)
       {
           SqlDataReader reader = SqlHelper.ExecuteReader(conn, CommandType.Text, sql);
           List<MyEmployee> empList = new List<MyEmployee>();
           while (reader.Read())
           {
               MyEmployee e = new MyEmployee();
               e.EmployeeNumber = (string)reader["EmployeeID"];
               e.Name = (string) reader["ChineseName"];
               e.Dept = (string) reader["Department"];
               if (!Convert.IsDBNull(reader["alias"]))
               {
                   e.Alias = (string) reader["alias"];
               }
               string py = "";
               if (!Convert.IsDBNull(reader["lastname"]))
               {
                  py += (string)reader["lastname"];
               }
               if (!Convert.IsDBNull(reader["firstname"]))
               {
                   py += (string)reader["firstname"];
               }
               e.Pinyin = py;
               if (!Convert.IsDBNull(reader["Photo"]))
               {
                   byte[] bImg = (byte[])reader["Photo"];
                   e.Photo = GetImage(bImg);
               }
               else
               {
                   e.Photo = null;
               }
               empList.Add(e);
           }
           return empList;
       }
       /// <summary>
       /// 插入一个员工信息
       /// </summary>
       /// <param name="e"></param>
       public void InitEmployee(MyEmployee e)
       {
            AnnualPartyEntities entities = new AnnualPartyEntities();
            Employee employee=new Employee();
           employee.EmployeeNumber = e.EmployeeNumber;
           employee.Dept = e.Dept;
           employee.Name = e.Name;
           employee.PinyinFull = e.Pinyin;
           employee.PinyinShort = e.ShortPinyin;
           employee.Alias = e.Alias;
           entities.Employee.Add(employee);
           entities.SaveChanges();
           // string sql =
           //    "insert into Employee(EmployeeNumber,Name,Dept,Alias,PinyinFull,PinyinShort) values(@num,@name,@dept,@alias,@pinyin,@pinyinshort)";
           //SqlParameter p1 = new SqlParameter("@num", e.EmployeeNumber);
           //SqlParameter p2 = new SqlParameter("@name", e.Name);
           //SqlParameter p3 = new SqlParameter("@dept", e.Dept);
           //SqlParameter p4 = new SqlParameter("@alias", e.Alias);
           //SqlParameter p5 = new SqlParameter("@pinyin", e.Pinyin);
           //SqlParameter p6 = new SqlParameter("@pinyinshort", e.ShortPinyin);
           //SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql, p1, p2, p3, p4, p5, p6);
       }

       #endregion
    }
}
