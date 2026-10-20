using System.ComponentModel.Design;

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
                    case 3:
                        AddCourse(school);
                        break;
                    case 4:
                        EnrollStudentInCourse(school);
                        break;
                    case 5:
                        ShowAllStudents(school);
                        break;
                    case 6:
                        ShowAllCourses(school);
                        break;
                    case 7:
                        ShowAllInstructors(school);
                        break;
                    case 8:
                        FindStudentByIdOrName(school);
                        break;
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
                Console.WriteLine("press any key to continue :)");
                Console.ReadKey(true);
            } while (true);
        }
        //==================
        static void ShowSchoolMenu()
        {
            Console.WriteLine("============= School Menu =============");
            Console.WriteLine("1. Add Student");//done
            Console.WriteLine("2. Add Instructor");//done
            Console.WriteLine("3. Add Course");//done
            Console.WriteLine("4. Enroll Student in Course");//done
            Console.WriteLine("5. Show All Students");//done
            Console.WriteLine("6. Show All Courses"); //done
            Console.WriteLine("7. Show All Instructors");//done
            Console.WriteLine("8. Find Student by id or name");//done
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
            string name = ReadString("Name");
            int age = ReadAge();
            Console.WriteLine("=====================================");
            //-----------------
            if (school.AddStudent(new Student(id, name, age)))
            {
                Console.WriteLine($"{name} added successfully :)");
            }
            else
            {
                Console.WriteLine("this student with this id already exists, try again :)");
            }
        }
        //========
        static string ReadString(string target)//TODO : name must be strings not numbers :)
        {
            string? str;
            do
            {
                Console.Write($"{target} : ");
                str = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(str))
                {
                    //خصوصا عشان هنسيرش بيه بعد كده
                    Console.WriteLine($"{target} is invalid (cannot be empty) :)");
                }
            } while (string.IsNullOrWhiteSpace(str));
            return str;
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
            string name = ReadString("Name");
            string specialization = ReadString("Specialization");
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
        //TODO : is imp to check for specialization of instructor = course title or not ? [ChooseInstructor]
        static void AddCourse(School school)
        {
            Console.Clear();
            Console.WriteLine("=========Adding New Course=========");
            Console.Write("Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            string title = ReadString("Title");

            //-----------------
            if (school.Instructors.Count == 0)
            {
                Console.WriteLine("No instructors yet, add an instructor first :)");
                return;
            }

            Console.WriteLine($"Assign {title} course to an instructor :");
            Instructor? choosenInstructor;
            do
            {
                choosenInstructor = ChooseInstructor(school);
                if (choosenInstructor == null)
                    Console.WriteLine("Invalid instructor selection, please try again :)");
                else
                    break;

            } while (true);
            //وبكدة اختارنا واحد من المدرسين 
            //-----------------
            //choosenInstructor will not be null here at all due to "do-while" above, so we can safely add the course :)
            if (school.AddCourse(new Course(id, title, choosenInstructor)))
                Console.WriteLine($"Course {title} added successfully and assigned to instructor {choosenInstructor.Name} :)");
            else
                Console.WriteLine("this course with this id already exists, try again :)");



        }
        //========
        static Instructor? ChooseInstructor(School school)
        {
            Console.WriteLine("=============================");
            foreach (Instructor instructor in school.Instructors)
            {
                Console.WriteLine($"\t\t(Id: {instructor.InstructorId}, Name: {instructor.Name})");
            }
            Console.WriteLine("=============================");
            Console.Write("choose an instructor by id: ");
            int choosenId = Convert.ToInt32(Console.ReadLine());
            return school.FindInstructorById(choosenId);//to be sure that user chose the correct id + to get the instructor which i will pass to the course constructor :)
        }
        //========
        static void EnrollStudentInCourse(School school)
        {
            Console.Clear();
            Console.WriteLine("========Enroll Student in a Course========");
            Console.Write("student id: ");
            int studentId = Convert.ToInt32(Console.ReadLine());
            if (school.FindStudentById(studentId) == null)
            {
                Console.WriteLine("this student id is not found");
                return;
            }
            Console.Write("course id: ");
            int courseId = Convert.ToInt32(Console.ReadLine());
            if (school.FindCourseById(courseId) == null)
            {
                Console.WriteLine("this course id is not found");
                return;
            }

            if (school.EnrollStudentInCourse(studentId, courseId))
            {
                Console.WriteLine($"Student enrolled in the course successfully :)");
            }
            else
            {
                Console.WriteLine("Failed to enroll student in course (maybe already enrolled or course is not available) :(");
            }


        }
        //========
        static void ShowAllStudents(School school)
        {
            Console.Clear();
            if(school.Students.Count == 0)
            {
                Console.WriteLine("No students found in the school yet :(");
                return;
            }
            Console.WriteLine("========All Students========");
            foreach (Student student in school.Students)
            {
                Console.WriteLine(student.PrintDetails());
            }
        }
        //========
        static void ShowAllCourses(School school)
        {
            Console.Clear();
            if (school.Courses.Count == 0)
            {
                Console.WriteLine("No courses found in the school yet :(");
                return;
            }
            Console.WriteLine("========All Courses========");
            foreach (Course course in school.Courses)
            {
                Console.WriteLine(course.PrintDetails());
            }
        }
        //=======
        static void ShowAllInstructors(School school)
        {
            Console.Clear();
            if (school.Instructors.Count == 0)
            {
                Console.WriteLine("No instructors found in the school yet :(");
                return;
            }
            Console.WriteLine("========All Instructors========");
            foreach (Instructor instructor in school.Instructors)
            {
                Console.WriteLine(instructor.PrintDetails());
            }
        }
        //========
        static void FindStudentByIdOrName(School school)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========Find Student by Id or Name========");
                Console.WriteLine("1. Find by ID");
                Console.WriteLine("2. Find by Name");
                Console.WriteLine("0. Back to the main menu :)");
                Console.WriteLine("==========================================");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        return; // رجوع للمنيو الرئيسي
                    case 1:
                        {
                            int id = Convert.ToInt32(Console.ReadLine());
                            Student? s = school.FindStudentById(id);
                            Console.WriteLine(s != null ? s.PrintDetails() : "Student not found :(");
                            break;
                        }
                    case 2:
                        {
                            string name = ReadString("Student Name");
                            List<Student> list = school.FindStudentsByName(name);
                            if (list.Count > 0)
                                foreach (Student s in list)
                                    Console.WriteLine(s.PrintDetails());
                            else
                                Console.WriteLine("No students found :(");
                            break;
                        }
                    default:
                        Console.WriteLine("Invalid choice, try again :)");
                        break;
                }

                Console.WriteLine("press any key to continue :)");
                Console.ReadKey(true);
            }
        }
        //========
         

    }

}

