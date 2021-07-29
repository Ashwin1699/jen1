using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace CaseStudy1
{
    class PAppEngine:AppEngine
    {

        public void introduce(Course course)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-UO1SOET;Initial Catalog=Student;Integrated Security=true");
                con.Open();
                
                cmd = new SqlCommand("insert into tbCourse(cID,cName,cDuration,cFees) values(@id,@name,@Duration,@Fees)", con);
                cmd.Parameters.AddWithValue("@id", course.cID);
                cmd.Parameters.AddWithValue("@name", course.cName);
                cmd.Parameters.AddWithValue("@Duration", course.cDuration);
                cmd.Parameters.AddWithValue("@Fees", course.cFees);
                int i=cmd.ExecuteNonQuery();
                Console.WriteLine("No. of row affected: {0}",i);
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);

            }
            finally
            {
                con.Close();
            }
         }
        public void register(Student student)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-UO1SOET;Initial Catalog=Student;Integrated Security=true");
                con.Open();
                //Insertion
                cmd = new SqlCommand("insert into tbStudent(sID,sName,sDOB,sPhone) values(@id,@name,@DOB,@Phone)", con);
                cmd.Parameters.AddWithValue("@id", student.sID);
                cmd.Parameters.AddWithValue("@name", student.sName);
                cmd.Parameters.AddWithValue("@DOB", student.sDOB);
                cmd.Parameters.AddWithValue("@Phone", student.sphone);
                int i=cmd.ExecuteNonQuery();
                Console.WriteLine("No. Of row affected: {0}", i);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
        public List<Student> listOfStudents()
        {
            List<Student> students = new List<Student>();
            
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-UO1SOET;Initial Catalog=Student;Integrated Security=true");
                con.Open();
                SqlDataReader dr;
                cmd = new SqlCommand("select * from tbStudent",con);
                dr = cmd.ExecuteReader();
               
                while(dr.Read())
                {
                    Student student = new Student((int)dr[0],(string)dr[1],(string)dr[2],(string)dr[3]);
                    
                    students.Add(student);
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                
                con.Close();

            }
            return students;

        }
        public List<Course> listOfCourses()
        {
            List<Course> courses = new List<Course>();

            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-UO1SOET;Initial Catalog=Student;Integrated Security=true");
                con.Open();
                SqlDataReader dr;
                cmd = new SqlCommand("select * from tbCourse", con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Course course = new Course((int)dr[0], (string)dr[1], (string)dr[2], (int)dr[3]);

                    courses.Add(course);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {

                con.Close();

            }
            return courses;

        }

        public void enroll(Student student, Course course)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-UO1SOET;Initial Catalog=Student;Integrated Security=true");
                con.Open();
                //Inserting Course
                cmd = new SqlCommand("insert into tbCourse(cID,cName,cDuration,cFees) values(@id,@name,@Duration,@Fees)", con);
                cmd.Parameters.AddWithValue("@id", course.cID);
                cmd.Parameters.AddWithValue("@name", course.cName);
                cmd.Parameters.AddWithValue("@Duration", course.cDuration);
                cmd.Parameters.AddWithValue("@Fees", course.cFees);
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("No. of row affected: {0}", i);
                //Inserting Student
                cmd = new SqlCommand("insert into tbStudent(sID,sName,sDOB,sPhone) values(@id,@name,@DOB,@Phone)", con);
                cmd.Parameters.AddWithValue("@id", student.sID);
                cmd.Parameters.AddWithValue("@name", student.sName);
                cmd.Parameters.AddWithValue("@DOB", student.sDOB);
                cmd.Parameters.AddWithValue("@Phone", student.sphone);
                int n = cmd.ExecuteNonQuery();
                Console.WriteLine("No. Of row affected: {0}", n);
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
        public List<Enroll> ListOfEnrollments()
        {
            //Yeh nhi aarha hai!
            List<Enroll> enrolls = new List<Enroll>();
            
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-UO1SOET;Initial Catalog=Student;Integrated Security=true");
                con.Open();
                SqlDataReader dr;
               
                cmd = new SqlCommand("select * from tbStudent", con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Student student = new Student((int)dr[0], (string)dr[1], (string)dr[2], (string)dr[3]);

                    
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {

                con.Close();

            }
            return enrolls;
        }
    }
}
