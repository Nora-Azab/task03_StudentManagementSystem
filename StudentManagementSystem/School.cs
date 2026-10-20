using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    public class School
    {
        //TODO : i tried to make them private "عشان محدش يعدلهم من بره"
        //but i need to acces them so i will make them public but with private set :)
        public List<Student> Students { get; private set; } = [];
        public List<Course> Courses { get; private set; }= new List<Course>();
        public List<Instructor> Instructors { get; private set; } = [];

        //TODO no ctor?

        public Student? FindStudentById(int studentId)
        {
            for (int i = 0; i < Students.Count; i++)
                if (Students[i].StudentId == studentId)
                    return Students[i];
            return null;
        }
        public Course? FindCourseById(int courseId)
        {
            for (int i = 0; i < Courses.Count; i++)
                if (Courses[i].CourseId == courseId)
                    return Courses[i];
            return null;
        }
        public Instructor? FindInstructorById(int instructorId)
        {
            for (int i = 0; i < Instructors.Count; i++)
                if (Instructors[i].InstructorId == instructorId)
                    return Instructors[i];
            return null;
        }
        //==========
        public List<Student> FindStudentsByName(string studentName)
        {
            List<Student> foundStudents = [];
            for (int i = 0; i < Students.Count; i++)
                if (Students[i].Name == studentName)
                    foundStudents.Add(Students[i]);
            return foundStudents;
        }
        public List<Instructor> FindInstructorsByName(string instructorName)
        {
            List<Instructor> foundInstructors = [];
            for (int i = 0; i < Instructors.Count; i++)
                if (Instructors[i].Name == instructorName)
                    foundInstructors.Add(Instructors[i]);
            return foundInstructors;
        } 
        public Course? FindCourseByName(string courseName) //مفيش اكتر من كورس بنفس الاسم منطقي يعني
        {
            for (int i = 0; i < Courses.Count; i++)
                if (Courses[i].Title == courseName)
                    return Courses[i];
            return null;
        }   
        //==========
        public bool AddStudent(Student student)
        {
            if(student == null) return false;
            if(FindStudentById(student.StudentId) != null) return false;

            Students.Add(student);// find -> null   Not found, so i will add him :)
            return true;

        }
        public bool AddCourse(Course course)
        {
            if (course == null) return false;

            //i assume that the course must have an instructor
            //because in the menu in "program" class => select the instructor by ID => when u choose "AddCourse"
            //
            /// important mark :)
            /// i added "FindInstructor" لأن ممكن حد يدخل للكورس مدرس ولكن المدرس ده مش مسجل في المدرسة فبالتالي مش هينفع اضيف الكورس ده
            /// will not seperate the two conditions because OR => if the first is true (null) will not check the second
            /// and if "course.Instructor" = null => i will not access "course.Instructor.InstructorId" because it will throw an exception :)
            if (course.Instructor == null || FindInstructorById(course.Instructor.InstructorId) == null) return false;
            if (FindCourseById(course.CourseId) != null) return false;
            
            Courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            if (instructor == null) return false;
            if (FindInstructorById(instructor.InstructorId) != null) return false;
            Instructors.Add(instructor);
            return true;
        }
        //=================
        public bool EnrollStudentInCourse(int  studentId , int courseId)
        {
            Student? studentTarget = FindStudentById(studentId);
            if(studentTarget == null) return false;

            //TODO لو مكنتش حولت الكورس ل nullable what will happen?
            Course? courseTarget = FindCourseById(courseId);
            if(courseTarget == null) return false;

            /// i will call the "Enroll" method in the "Student" class because it already checks if the student is enrolled before in the course or not :)
            /// and adding the course manually will not check the dublication of the course in the student courses list :)
            return studentTarget.Enroll(courseTarget); 

            //it's wrong :)
            /// studentTarget.Courses.Add(courseTarget);//better than calling the "Enroll" method because i already checked if the course is null or not and if the student is enrolled in it or not
            /// return true;
        }
        //================
        public bool IsStudentEnrolledInCourse(int studentId, int courseId)
        {
            Student? s = FindStudentById(studentId);
            if (s == null) return false;

            foreach (Course c in s.Courses)
                if (c.CourseId == courseId)
                    return true;

            return false;
        }
    }
}
