using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    public class Instructor
    {

        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public Instructor(int instructorId, string name, string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }
        //-------------
        public string PrintDetails()
        {
            return $"\nInstructor Details :\nid : {InstructorId} ::: Name : {Name} ::: Specialization : {Specialization}\n";
        }

    }
}
