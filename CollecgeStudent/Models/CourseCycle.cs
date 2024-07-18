using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollecgeStudent.Models
{
    public class CourseCycle
    {
        public int ID { get; set; }
        public int CycleID { get; set; }
        public string Name { get; set; }
        public DateTime BeginningDate { get; set; }
        public double Price { get; set; }

        public CourseCycle(string name, DateTime beginningDate, double price)
        {
            Name = name;
            BeginningDate = beginningDate;
            Price = price;
        }

        public CourseCycle(DataRow dr)
        {
            if (dr == null) throw new ArgumentNullException(nameof(dr));
            ID = (int)dr["CourseID"];
            CycleID = (int)dr["CycleID"];
            Name = dr["Name"].ToString()!;
            BeginningDate = (DateTime)dr["BeginningDate"]!;
            Price = double.Parse(dr["Price"].ToString());
        }
    }
}
