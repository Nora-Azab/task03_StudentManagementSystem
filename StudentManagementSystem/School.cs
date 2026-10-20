using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    public class School
    {
        private List<Student> Students { get; set; } = [];
        private List<Course> Courses { get; set; }= new List<Course>();
        private List<Instructor> Instructors { get; set; } = [];

        //TODO no ctor?

        public Student? FindStudent(int studentId)
        {
            for (int i = 0; i < Students.Count; i++)
                if (Students[i].StudentId == studentId)
                    return Students[i];
            return null;
        }
        public Course? FindCourse(int courseId)
        {
            for (int i = 0; i < Courses.Count; i++)
                if (Courses[i].CourseId == courseId)
                    return Courses[i];
            return null;
        }
        public Instructor? FindInstructor(int instructorId)
        {
            for (int i = 0; i < Instructors.Count; i++)
                if (Instructors[i].InstructorId == instructorId)
                    return Instructors[i];
            return null;
        }
        //==========
        public bool AddStudent(Student student)
        {
            if(student == null) return false;
            if(FindStudent(student.StudentId) != null) return false;

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
            if (course.Instructor == null || FindInstructor(course.Instructor.InstructorId) == null) return false;
            if (FindCourse(course.CourseId) != null) return false;
            
            Courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            if (instructor == null) return false;
            if (FindInstructor(instructor.InstructorId) != null) return false;
            Instructors.Add(instructor);
            return true;
        }
        //=================
        public bool EnrollStudentInCourse(int  studentId , int courseId)
        {
            Student? studentTarget = FindStudent(studentId);
            if(studentTarget == null) return false;

            //TODO لو مكنتش حولت الكورس ل nullable what will happen?
            Course? courseTarget = FindCourse(courseId);
            if(courseTarget == null) return false;

            /// i will call the "Enroll" method in the "Student" class because it already checks if the student is enrolled before in the course or not :)
            /// and adding the course manually will not check the dublication of the course in the student courses list :)
            return studentTarget.Enroll(courseTarget); 

            //it's wrong :)
            /// studentTarget.Courses.Add(courseTarget);//better than calling the "Enroll" method because i already checked if the course is null or not and if the student is enrolled in it or not
            /// return true;
        }

    }
}
