using System;

namespace sa_task1
{
    class Program
    {

#region A students 
        static StudentGrade MakeStudentA1()
        {            
            StudentGrade student = new StudentGrade();
            student.AddGrade("hw1", 80);
            student.AddGrade("hw2", 80);
            student.AddGrade("hw3", 80);
            student.AddGrade("final", 80);
            student.AddGrade("mid", 80);
            student.AddGrade("project", 100);
            return student;
        }
        
        static StudentGrade MakeStudentA2()
        {            
            StudentGrade student = new StudentGrade();
            student.AddGrade("hw1", 80);
            student.AddGrade("hw2", 80);
            student.AddGrade("hw3", 40);
            student.AddGrade("final", 100);
            student.AddGrade("mid", 100);
            student.AddGrade("project", 100);
            return student;
        }

        static StudentGrade MakeStudentA3()
        {            
            StudentGrade student = new StudentGrade();
            student.AddGrade("hw1", 100);
            student.AddGrade("hw2", 100);
            student.AddGrade("hw3", 100);
            student.AddGrade("final", 70);
            student.AddGrade("mid", 85);
            student.AddGrade("project", 100);
            return student;
        }
        
        static StudentGrade MakeStudentA4()
        {            
            StudentGrade student = new StudentGrade();
            student.AddGrade("hw1", 80);
            student.AddGrade("hw2", 90);
            student.AddGrade("hw3", 70);
            student.AddGrade("final", 100);
            student.AddGrade("mid", 100);
            student.AddGrade("project", 70);
            return student;
        }
        
        static StudentGrade MakeStudentA5()
        {            
            StudentGrade student = new StudentGrade();
            student.AddGrade("hw1", 0);
            student.AddGrade("hw2", 100);
            student.AddGrade("hw3", 100);
            student.AddGrade("final", 100);
            student.AddGrade("mid", 100);
            student.AddGrade("project", 100);
            return student;
        }

#endregion

#region D students
        private static StudentGrade MakeStudentD1()
        {
            StudentGrade student = new StudentGrade();
            student.AddGrade("hw1", 0);
            student.AddGrade("hw2", 0);
            student.AddGrade("hw3", 0);
            student.AddGrade("final", 0);
            student.AddGrade("mid", 0);
            student.AddGrade("project", 100);
            return student;
        }
        private static StudentGrade MakeStudentD2()
        {
            StudentGrade student = new StudentGrade();
            student.AddGrade("hw1", 100);
            student.AddGrade("hw2", 100);
            student.AddGrade("hw3", 100);
            student.AddGrade("final", 100);
            student.AddGrade("mid", 0);
            student.AddGrade("project", 0);
            return student;
        }
        private static StudentGrade MakeStudentD3()
        {
            StudentGrade student = new StudentGrade();
            student.AddGrade("hw1", 0);
            student.AddGrade("hw2", 0);
            student.AddGrade("hw3", 0);
            student.AddGrade("final", 0);
            student.AddGrade("mid", 95);
            student.AddGrade("project", 0);
            return student;
        }
        private static StudentGrade MakeStudentD4()
        {
            StudentGrade student = new StudentGrade();
            student.AddGrade("hw1", 0);
            student.AddGrade("hw2", 100);
            student.AddGrade("hw3", 100);
            student.AddGrade("final", 0);
            student.AddGrade("mid", 0);
            student.AddGrade("project", 100);
            return student;
        }
#endregion
        static void Main(string[] args)
        {
            // Creating grading system
            GradingSystem gs = new GradingSystem();
            gs.AddGradingPart("hw1", 0.1);
            gs.AddGradingPart("hw2", 0.1);
            gs.AddGradingPart("hw3", 0.1);
            gs.AddGradingPart("project", 0.3);
            gs.AddGradingPart("mid", 0.2);
            gs.AddGradingPart("final", 0.2);

            Console.WriteLine("Five cases with A students\n");
            gs.PrintStudentsOverallGrades(MakeStudentA1());
            gs.PrintStudentsOverallGrades(MakeStudentA2());
            gs.PrintStudentsOverallGrades(MakeStudentA3());
            gs.PrintStudentsOverallGrades(MakeStudentA4());
            gs.PrintStudentsOverallGrades(MakeStudentA5());

            Console.WriteLine("Four cases with D students which has at least one A\n");
            gs.PrintStudentsOverallGrades(MakeStudentD1());
            gs.PrintStudentsOverallGrades(MakeStudentD2());
            gs.PrintStudentsOverallGrades(MakeStudentD3());
            gs.PrintStudentsOverallGrades(MakeStudentD4());
            
            
        }
    }
}
