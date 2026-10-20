using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    public class Student
    {

        public int StudentId { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }

        private List<Course> Courses { get; set; } = [];

        /// i don't allow for "Courses" to be a parameter in the constructor
        /// i let the school to enter the student with "no courses" at first
        /// if the student has some courses .. and i need to add anew course >> so will not make sense to say that the student has that course and then add it in the list
        /// so i will let the school to enroll the student in courses through the "Enroll" method only :)
        public Student(int studentId, string name, int age)
        {
            StudentId = studentId;
            Name = name;
            Age = age;
        }
        //---------
        public bool Enroll(Course course)//instead of making the "Courses" list public and let the school to add courses directly to it :)
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
