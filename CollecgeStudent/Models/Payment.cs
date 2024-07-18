using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CollecgeStudent.Models
{
    public class Payment
    {
        public int  ID { get; set; }
        public double TotalPayment { get; set; }
        public int StudentID { get; set; }
        public int CycleID { get; set; }

        public Payment(double totalPayment, int studentID, int cycleID)
        {
            TotalPayment = totalPayment;
            StudentID = studentID;
            CycleID = cycleID;
        }


        public Payment(DataRow dr)
        {
            if (dr == null) throw new ArgumentNullException(nameof(dr));
            ID = (int)dr["ID"];
            StudentID = (int)dr["Students_ID"];
            CycleID = (int)dr["Cycle_ID"];
            TotalPayment = double.Parse(dr["TotalPayment"].ToString());
        }
    }
}
