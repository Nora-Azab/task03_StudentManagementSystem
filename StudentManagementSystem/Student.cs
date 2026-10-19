using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    public class Student
    {

        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public List<Course> Courses { get; set; } = [];//TODO ref
        public Student(int studentId, string name, int age)
        {
            StudentId = studentId;
            Name = name;
            Age = age;
        }
        //---------
        public bool Enroll(Course course)
        {
            if(course == null) return false;
            
            //if the course is enrolled already before :)
            for (int i = 0; i < Courses.Count; i++)
                if (course.CourseId == Courses[i].CourseId)
                    return false;

            Courses.Add(course);
            return true;
        }
        //---------
        public string PrintDetails()
        {
            string details = $"\nStudent Details :\nid : {StudentId} ::: Name : {Name} ::: Age : {Age}\n";

            details += "Courses Name : \n";
            for(int i = 0;i<Courses.Count; ++i)
            {
                details += $"{Courses[i].Title}\n";
            }

            return details ;

        }
    }
}
