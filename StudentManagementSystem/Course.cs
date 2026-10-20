using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    public class Course
    {

        public int CourseId { get; private set; }
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
            string details = $"Course Details :\nid : {CourseId} , Title : {Title} , Course Instructor Name : ";
            
            if (Instructor != null)
                details += $"{Instructor.Name}";
            else
                details += "No Instructor Assigned";
            
            return details ;
        }

    }
}
