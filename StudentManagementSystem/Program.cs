namespace StudentManagementSystem
{

    /* TODO :
     Functional Requirements:
        1. Add a new Student
        2. View all Students
        3. Search for a Student by ID
        4. Update Student Information
        5. Delete a Student
        6. Add a new Course
        7. Add a new Instructor
        8. Enroll a Student in a Course
        9. View all Courses
        10. View all Instructors
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            School school = new School();
            int choice;
            do
            {
                Console.Clear();
                ShowSchoolMenu();
                Console.Write("Enter your choice => ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddStudent(school);
                        break;
                    case 2:
                        AddInstructor(school);
                        break;
                    //case 3:
                    //    AddCourse(school);
                    //    break;
                    //case 4:
                    //    EnrollStudentInCourse(school);
                    //    break;
                    //case 5:
                    //    ShowAllStudents(school);
                    //    break;
                    //case 6:
                    //    ShowAllCourses(school);
                    //    break;
                    //case 7:
                    //    ShowAllInstructors(school);
                    //    break;
                    //case 8:
                    //      FindStudentByIdOrName(school);
                    //    break;
                    //case 9:
                    //    FindCourseByIdOrName(school);
                    //    break;
                    //case 10:
                    //    CheckStudentEnrollInCourse(school);
                    //    break;
                    //case 11:
                    //    GetInstructorNameByCourseName(school);
                    //    break;
                    case 12:
                        Console.WriteLine("Good Bye :)");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again:)");
                        break;
                }
                Console.ReadKey(true);
                Console.WriteLine("press any key to continue :)");
            } while (true);
        }
        //==================
        static void ShowSchoolMenu()
        {
            Console.WriteLine("============= School Menu =============");
            Console.WriteLine("1. Add Student");//done
            Console.WriteLine("2. Add Instructor");//done
            Console.WriteLine("3. Add Course");
            Console.WriteLine("4. Enroll Student in Course");
            Console.WriteLine("5. Show All Students");
            Console.WriteLine("6. Show All Courses");
            Console.WriteLine("7. Show All Instructors");
            Console.WriteLine("8. Find Student by id or name");
            Console.WriteLine("9. Find Course by id or name");
            Console.WriteLine("10. Check if student is enrolled in specific course");
            Console.WriteLine("11. Return instructor name by course name");
            Console.WriteLine("12. Exit");
            Console.WriteLine("=======================================");
        }
        //===========
        static void AddStudent(School school)
        {
            Console.Clear();
            Console.WriteLine("=========Adding New Student=========");
            Console.Write("Id : ");
            ///  this will happen when i pass the student to the school class to add it to the list of students :)
            /// i will check if the id is already exist or not in the school class :)
            int id = Convert.ToInt32(Console.ReadLine());
            string name = ReadName();
            int age = ReadAge();
            Console.WriteLine("=====================================");
            //-----------------
            if ( school.AddStudent(new Student(id, name, age)) )
            {
                Console.WriteLine($"{name} added successfully :)");
            }
            else
            {
                Console.WriteLine("this student with this id already exists, try again :)");
            }
        }
        //========
        static string ReadName()//TODO : name must be strings not numbers :)
        {
            string? name;
            do
            {
                Console.Write("Name : ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    //خصوصا عشان هنسيرش بيه بعد كده
                    Console.WriteLine("Invalid Name (cannot be empty) :)");
                }
            } while (string.IsNullOrWhiteSpace(name));
            return name;
        }
        //========
        static int ReadAge()//TODO : must be numbers only
        {
            int age;
            do
            {
                Console.Write("Age : ");
                age = Convert.ToInt32(Console.ReadLine());
                if (age <= 0)
                {
                    Console.WriteLine("Invalid Age (must be positive and greater than zero) :)");
                }
            } while (age <= 0);
            return age;
        }
        //========
        static void AddInstructor(School school)
        {
            Console.Clear();
            Console.WriteLine("=========Adding New Instructor=========");
            Console.Write("Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            string name = ReadName();
            Console.Write("Specialization : ");
            string specialization = Console.ReadLine() ?? "";
            Console.WriteLine("=====================================");
            //-----------------
            if (school.AddInstructor(new Instructor(id, name, specialization)))
            {
                Console.WriteLine($"Mr. {name} added successfully :)");
            }
            else
            {
                Console.WriteLine("this instructor with this id already exists, try again :)");
            }
        }
        //========


    }
}
