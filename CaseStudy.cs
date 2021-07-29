using System;
using System.Collections.Generic;
using System.Text;


namespace CaseStudy1
{

    class Student
    {
        internal int sID { get; set; }
        internal String sName { get; set; }
        internal String sDOB { get; set; }
        internal String sphone { get; set; }
        internal Student(int sID, String sName, String sDOB, String sPhone)
        {
            this.sID = sID;
            this.sName = sName;
            this.sDOB = sDOB;
            this.sphone = sPhone;
        }

        public Student()
        {
        }
    }
    class Course
    {
        internal int cID { get; set; }
        internal String cName { get; set; }
        internal String cDuration { get; set; }
        internal int cFees { get; set; }
        internal float cMonthlyFees;
        internal Course(int cID, String cName, String cDuration, int cFees)
        {
            this.cID = cID;
            this.cName = cName;
            this.cDuration = cDuration;
            this.cFees = cFees;

        }
        internal virtual float calculateMonthlyFee(int cFees)
        {
            int extraCharge = 100;
            cMonthlyFees = (float)((cFees / 12) + extraCharge);
            return cMonthlyFees;

        }
    }
    class DegreeCourse : Course
    {
        internal enum Level
        {
            Bachelors = 1, Masters = 2
        };
        Boolean isPlacementAvailable { get; set; }
        internal int level;

        internal DegreeCourse(string levellp, Boolean isPA, int cID, String cName, String cDuration, int cFees) : base(cID, cName, cDuration, cFees)
        {
            level = (int)Enum.Parse(typeof(Level), levellp);

            this.isPlacementAvailable = isPA;

        }
        internal override float calculateMonthlyFee(int cFees)
        {
            if (isPlacementAvailable)
            {
                int extraCharge = 100;
                cMonthlyFees = (float)((cFees / 12) + extraCharge);
                return ((float)(cMonthlyFees * 0.1) + cMonthlyFees);
            }
            else
            {
                int extraCharge = 100;
                cMonthlyFees = (float)((cFees / 12) + extraCharge);
                return cMonthlyFees;
            }

        }
    }
    class DiplomaCourse : Course
    {
        internal enum Type
        {
            Professional = 1, Academic = 2
        };

        internal int type1;

        internal DiplomaCourse(string TypeLp, int cID, String cName, String cDuration, int cFees) : base(cID, cName, cDuration, cFees)
        {

            type1 = (int)Enum.Parse(typeof(Type), TypeLp);



        }

        internal override float calculateMonthlyFee(int cFees)
        {
            if (type1 == 1)
            {

                return ((float)(cMonthlyFees * 0.1) + cMonthlyFees);
            }
            else
            {
                return ((float)(cMonthlyFees * 0.05) + cMonthlyFees);

            }
        }

    }
    class Enroll
    {
        internal Student student;
        internal Course course;
        internal DateTime enrollmentDate;
        internal Enroll(Student student, Course course, DateTime dateTime)
        {
            this.student = student;
            this.course = course;
            this.enrollmentDate = dateTime;
        }

    }
    class info
    {
        public void Display(Student student)
        {
            Console.WriteLine("StudnetID: {0} | StudentName: {1} | StudentDOB: {2} | Student Phone: {3}", student.sID, student.sName, student.sDOB, student.sphone);
        }
        public void display(Course course)
        {
            float n = course.calculateMonthlyFee((int)course.cFees);
            Console.WriteLine("CourseID: {0} | CourseName: {1} | CourseDuration: {2} | CourseFees: {3}",
                course.cID, course.cName, course.cDuration, n);
        }
    }
    class App
    {
        public static void scenario1()
        {
            Student student = new Student(1, "ashwin", "1999-10-31", "99404");
            Student student1 = new Student(2, "vishal", "1999-10-1", "2120120");
            Student student2 = new Student(1, "aniket", "1999-10-2", "121212");
            info info = new info();
            info.Display(student);
            info.Display(student1);
            info.Display(student2);


            Course course = new Course(1, "python", "1 year", 1000);
            Course course1 = new Course(2, "java", "2 year", 1500);
            Course course2 = new Course(3, "c#", "1 year", 1500);
            info info3 = new info();
            info3.display(course);
            info3.display(course1);
            info3.display(course2);
            info3.display(course2);
        }
        public static void scenario2()
        {
            Student[] students = new Student[2];
            students[0] = new Student(1, "bhava", "1999-10-22", "1221323");
            students[1] = new Student(1, "sam", "1998-10-22", "121333");

            info info1 = new info();
            foreach (var student in students)
            {
                info1.Display(student);
            }


        }
        public static void scenario3()
        {
            Console.WriteLine("enter number of students: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Student[] students = new Student[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("enter the studentid: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the student name:");
                string b = Console.ReadLine();
                Console.WriteLine("enter the dob:");
                string c = Console.ReadLine();
                Console.WriteLine("enter the phone:");
                string d = Console.ReadLine();
                students[i] = new Student(a, b, c, d);
            }

            info info2 = new info();
            foreach (var su in students)
            {
                info2.Display(su);
            }
        }
        public static void scenario4()
        {
            Console.WriteLine("enter number of students: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Student[] students = new Student[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("enter the studentid: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the student name:");
                string b = Console.ReadLine();
                Console.WriteLine("enter the dob:");
                string c = Console.ReadLine();
                Console.WriteLine("enter the phone:");
                string d = Console.ReadLine();
                students[i] = new Student(a, b, c, d);
                PAppEngine pAppEngine = new PAppEngine();
                pAppEngine.register(students[i]);

            }



            
        }
        public static void scenario5()
        {
            string levellp;
            Boolean isPA;
            int cID;
            String cName;
            String cDuration;
            int cFees;
            Console.WriteLine("enter the course you want to take:  ");
            string n1 = Console.ReadLine();
            if (n1 == "DegreeCourse")
            {

                Console.WriteLine("Enter the level of Course: ");
                levellp = Console.ReadLine();
                Console.WriteLine("Is placement available? (1-> yes, 0->No)");
                isPA = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine("Enter the Course ID");
                cID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the course name: ");
                cName = (Console.ReadLine());
                Console.WriteLine("Enter the Duration: ");
                cDuration = (Console.ReadLine());
                Console.WriteLine("Enter the fees ");
                cFees = Convert.ToInt32(Console.ReadLine());
                DegreeCourse degreeCourse = new DegreeCourse(levellp, isPA, cID, cName, cDuration, cFees);

                PAppEngine pAppEngine = new PAppEngine();
                pAppEngine.introduce(degreeCourse);




            }
            else if (n1 == "DiplomaCourse")
            {
                Console.WriteLine("Enter the level of Course: ");
                levellp = Console.ReadLine();

                Console.WriteLine("Enter the Course ID");
                cID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the course name: ");
                cName = (Console.ReadLine());
                Console.WriteLine("Enter the Duration: ");
                cDuration = (Console.ReadLine());
                Console.WriteLine("Enter the fees ");
                cFees = Convert.ToInt32(Console.ReadLine());
                DiplomaCourse degreeCourse = new DiplomaCourse(levellp, cID, cName, cDuration, cFees);
                PAppEngine pAppEngine = new PAppEngine();
                pAppEngine.introduce(degreeCourse);



            }
            else
            {
                Console.WriteLine("Enter the Course ID");
                cID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the course name: ");
                cName = (Console.ReadLine());
                Console.WriteLine("Enter the Duration: ");
                cDuration = (Console.ReadLine());
                Console.WriteLine("Enter the fees ");
                cFees = Convert.ToInt32(Console.ReadLine());
                Course degreeCourse = new Course(cID, cName, cDuration, cFees);
                PAppEngine pAppEngine = new PAppEngine();
                pAppEngine.introduce(degreeCourse);
            }
        }
            static void Main()
        {
            int ch;
            do
            {


                Console.WriteLine("1. Student Details");
                Console.WriteLine("2. Course Details");
                Console.WriteLine("3.Register Yourself ");
                Console.WriteLine("4.Enroll to a course");
                Console.WriteLine("Enter the number accordingly: ");
                int k = Convert.ToInt32(Console.ReadLine());
                PAppEngine pAppEngine = new PAppEngine();
                info info = new info();
                //App.scenario4();
                switch (k)
                {
                    case 1:
                        List<Student> students = new List<Student>();

                        students = pAppEngine.listOfStudents();

                        foreach (var student in students)
                        {
                            info.Display(student);
                        }
                        break;
                    case 2:
                        List<Course> courses = new List<Course>();

                        courses = pAppEngine.listOfCourses();

                        foreach (var course in courses)
                        {
                            info.display(course);
                        }
                        break;
                    case 3:
                        App.scenario4();
                        break;
                    case 4:
                        App.scenario4();
                        App.scenario5();
                        break;
                }
                Console.WriteLine("Do you want to EXit 1-yes 0-NO");
                ch = Convert.ToInt32(Console.ReadLine());

            } while (ch == 0);
             
            //Student student1 = new Student(1, "ashwin", "1999-10-31", "99404");
            //Course course1 = new Course(2, "java", "2 year", 1500);
            //inMemoryAppEngine.enroll(student1, course1);
            //List<Enroll> enrolls = new List<Enroll>();
            //enrolls = inMemoryAppEngine.ListOfEnrollments();


            //foreach (var enroll in enrolls)
            //{
            //    inMemoryAppEngine.register(enroll.student);

            //    inMemoryAppEngine.introduce(enroll.course);

            //}
        }
        
    }
        class InMemoryAppEngine : AppEngine
        {

            info info = new info();
            public void introduce(Course course)
            {

                info.display(course);
            }
            public void register(Student student)
            {
                info.Display(student);
            }
            public List<Student> listOfStudents()
            {
                Console.WriteLine("enter number of students: ");
                int n = Convert.ToInt32(Console.ReadLine());
                List<Student> students = new List<Student>();
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("enter the studentid: ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter the student name:");
                    string b = Console.ReadLine();
                    Console.WriteLine("enter the dob:");
                    string c = Console.ReadLine();
                    Console.WriteLine("enter the phone:");
                    string d = Console.ReadLine();
                    students[i] = new Student(a, b, c, d);
                }
                return students;


            }
            public void enroll(Student student, Course course)
            {
                info.display(course);
                info.Display(student);
            }
            public List<Enroll> ListOfEnrollments()
            {
                Student student = new Student(1, "ashwin", "1999-10-31", "99404");
                Student student1 = new Student(2, "vishal", "1999-10-1", "2120120");
                Student student2 = new Student(1, "aniket", "1999-10-2", "121212");
                Course course = new Course(1, "python", "1 year", 1000);
                Course course1 = new Course(2, "java", "2 year", 1500);
                Course course2 = new Course(3, "c#", "1 year", 1500);
                Console.WriteLine("Enter the enrollment date");
                DateTime date = Convert.ToDateTime(Console.ReadLine());
                List<Enroll> enrolls = new List<Enroll>();
                Enroll enroll = new Enroll(student, course, date);

                Enroll enroll1 = new Enroll(student1, course1, date);
                Enroll enroll2 = new Enroll(student2, course2, date);


                enrolls.Add(enroll);
                enrolls.Add(enroll1);
                enrolls.Add(enroll2);
                return enrolls;

            }

        }
        interface AppEngine
        {
            public void introduce(Course course);
            public void register(Student student);
            public List<Student> listOfStudents();
            public void enroll(Student student, Course course);
            public List<Enroll> ListOfEnrollments();
        }




        class Student_db
        {

        }
    
}
