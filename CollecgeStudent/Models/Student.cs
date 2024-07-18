using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CollecgeStudent.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public double Balance { get; set; }

        public Student(string identityNumber, string firstName, string lastName, string phone, double balance)
        {
            IdentityNumber = identityNumber;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            this.Balance = balance;
        }

        public Student(DataRow dr)
        {
            if (dr == null) throw new ArgumentNullException(nameof(dr));
            ID = (int)dr["ID"];
            IdentityNumber = dr["IdentityNumber"].ToString();
            FirstName = dr["FirstName"].ToString()!;
            LastName = dr["LastName"].ToString()!;
            Phone = dr["Phone"].ToString()!;
            Balance = double.Parse(dr["balance"].ToString());
        }
    }
}
