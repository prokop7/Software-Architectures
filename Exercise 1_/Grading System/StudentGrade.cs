using System.Collections.Generic;

namespace sa_task1
{
    public class StudentGrade
    {
        public Dictionary<string, double> grades  {get;set;} = new Dictionary<string, double>();
        public void AddGrade(string name, double grade) => grades.Add(name, grade);
    }
}
