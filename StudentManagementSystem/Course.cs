using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    public class Course
    {

        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; } //TODO ref

        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            this.Instructor = instructor;
        }
        //-----------------
        public string PrintDetails()
        {
            string details = $"\nCourse Details :\nid : {CourseId} ::: Title : {Title} ::: Course Instructor Name : ";
            
            if (Instructor != null)
                details += $"{Instructor.Name}\n";
            else
                details += "No Instructor Assigned\n";
            
            return details ;
        }

    }
}
