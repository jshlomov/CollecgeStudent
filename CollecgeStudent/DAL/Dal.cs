using CollecgeStudent.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollecgeStudent.DAL
{
    public class Dal
    {
        DBContext dbContext;

        public Dal(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Student GetStudentByID(string IdentityNumber)
        {
            try
            {
                string query = @"IF EXISTS (SELECT 1 FROM Students
			                                WHERE IdentityNumber = @IdentityNumber)
                                BEGIN
	                                SELECT * FROM Students
	                                WHERE IdentityNumber = @IdentityNumber
                                END
                                ELSE
                                BEGIN
	                                SELECT 0
                                END";

                DataTable dt = dbContext.ExecuteQuery(query,
                    new SqlParameter[] { new SqlParameter("@IdentityNumber", IdentityNumber) });
                if (dt != null && (int)dt.Rows[0][0] != 0) return new Student(dt.Rows[0]);
                else throw new Exception("הלקוח לא נמצא");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseCycle> GetCourseCycleList()
        {
            List<CourseCycle> courseCycles = new List<CourseCycle>();
            string query = @"SELECT cr.ID as CourseID, Name, cy.ID as CycleID, BeginningDate, Price
                            FROM Courses cr
                            JOIN Cycles cy
                            ON cr.ID = cy.Course_ID";

            DataTable dt = dbContext.ExecuteQuery(query, null);
            foreach (DataRow dr in dt.Rows)
            {
                courseCycles.Add(new CourseCycle(dr));
            }
            return courseCycles;
        }

        public List<CourseCycle> GetCourseCycleListByID(int id)
        {
            List<CourseCycle> courseCycles = new List<CourseCycle>();
            string query = @"SELECT cr.ID as CourseID, Name, cy.ID as CycleID, BeginningDate, Price
                            FROM Courses cr
                            JOIN Cycles cy
                            ON cr.ID = cy.Course_ID
                            JOIN StudentsInCycles si
                            ON si.Cycle_ID = cr.ID
                            WHERE si.ID = @ID";

            DataTable dt = dbContext.ExecuteQuery(query, new SqlParameter[] { new SqlParameter("@ID", id) });
            foreach (DataRow dr in dt.Rows)
            {
                courseCycles.Add(new CourseCycle(dr));
            }
            return courseCycles;
        }

        public int InsertPayment(int studentID, int cycleID, double payment)
        {
            string query = @"BEGIN TRANSACTION
                            INSERT INTO Payments (TotalPayment ,Students_ID, Cycle_ID) VALUES
                            (@payment, @Students_ID, @courseID)
                        
                            update Students
                            set Balance = Balance - @payment
                            where ID = @Students_ID;
                            COMMIT TRANSACTION";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Students_ID", studentID),
                new SqlParameter("@courseID", cycleID),
                new SqlParameter("@payment", payment)
            };
            int dt = dbContext.ExecuteNonQuery(query, parameters);
            return dt;
        }

        public List<Payment> GetPaymentList(int id)
        {
            List<Payment> paymentList = new List<Payment>();
            string query = @"SELECT * FROM Payments
                            WHERE Students_ID = @ID";

            DataTable dt = dbContext.ExecuteQuery(query, new SqlParameter[] { new SqlParameter("@ID", id) });
            foreach (DataRow dr in dt.Rows)
            {
                paymentList.Add(new Payment(dr));
            }
            return paymentList;
        }

        public int InsertStudentToCourse(int stuId, int cycleId)
        {
            string query = @"IF NOT EXISTS (SELECT 1 FROM StudentsInCycles
				                            WHERE Students_ID = @Students_ID
				                            AND Cycle_ID = @cycleId)
	                            BEGIN
		                            INSERT INTO StudentsInCycles (Cycle_ID, Students_ID) values
                                    OUTPUT INSERTED.ID
		                            (@cycleId, @stuId);
	                            END
                            ELSE
	                            BEGIN
		                            SELECT 0;
	                            END";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Students_ID", stuId),
                new SqlParameter("@courseID", cycleId),
            };
            int dt = dbContext.ExecuteNonQuery(query, parameters);
            if (dt == 0) throw new Exception("כבר רשום");
            else return dt;
        }
    }
}
