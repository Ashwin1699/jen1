using System;
using System.Collections.Generic;

using System.Text;

using System.Data.SqlClient;
using System.Data;
using CaseStudy1;


namespace Casestudyyy
{
    class PersistentAppEngine : CaseStudy1.AppEngine
    {


        public static void Main()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                CaseStudy1.Student student = new Student();
                con = new SqlConnection("Data Source =DESKTOP-UO1SOET; Initial Catalog= Northwind ; Integrated Security= true");
                con.Open();

                //insert
                //internal Student(int sID, String sName, String sDOB, String sPhone)
                cmd = new SqlCommand("insert into Student(sID,sName,sDOB,sphoneNo) values(@sid,@sname,@sdob,@sphoneNo)", con);
                cmd.Parameters.AddWithValue("@sID", student.sID);
                cmd.Parameters.AddWithValue("@sName", student.sName);
                cmd.Parameters.AddWithValue("@sDOB", student.sDOB);
                cmd.Parameters.AddWithValue("@sPhone", student.sphone);
                int i = cmd.ExecuteNonQuery(); // returns int
                Console.WriteLine("No of Rows Affected:{0}", i);
                cmd.Parameters.Clear();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }

        public void enroll(Student student, Course course)
        {
            throw new NotImplementedException();
        }

        public void introduce(Course course)
        {
            throw new NotImplementedException();
        }

        public List<Enroll> ListOfEnrollments()
        {
            throw new NotImplementedException();
        }

        public List<Student> listOfStudents()
        {
            throw new NotImplementedException();
        }

        public void register(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
