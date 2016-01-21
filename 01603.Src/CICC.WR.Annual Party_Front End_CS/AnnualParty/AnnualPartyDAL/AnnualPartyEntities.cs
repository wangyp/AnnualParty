using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CICC.WR.AnnualPartyDAL
{

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Alias { get; set; }
        public string PinyinFull { get; set; }
        public string PinyinShort { get; set; }
        public bool CheckIn { get; set; }
        public Nullable<System.DateTime> CheckinTime { get; set; }
        public int Award { get; set; }
        public Nullable<System.DateTime> AwardTime { get; set; }
        public string AwardName { get; set; }
    }
    [Table("Photo")]
    public partial class Photo
    {
        [Key]
        public string EmployeeNumber { get; set; }
        public byte[] PhotoData { get; set; }
    }
    public partial class AnnualPartyEntities : DbContext
    {
        public AnnualPartyEntities()
            : base("name=AnnualPartyEntities")
        {
            // Turn off the Migrations, (NOT a code first Db)
            Database.SetInitializer<AnnualPartyEntities>(null);
        }

        //[Table("Employee")]
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
    }
}
