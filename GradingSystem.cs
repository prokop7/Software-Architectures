using System;
using System.Collections.Generic;

namespace sa_task1
{
    public class GradingSystem
    {
        Dictionary<string, double> gradeParts = new Dictionary<string, double>();

        public Dictionary<string, (double min, double max)> GradeBoundaries = new Dictionary<string, (double, double)>()
        {
            {"A", (85, double.MaxValue)},   // Because A>=85
            {"B", (70, 85)},
            {"C", (55, 70)},
            {"D", (0, 55)},
        };
        public string GetAvgLetterGrade(StudentGrade sGrade)
        {
            double avg = CalculateAverage(sGrade);
            return GetLetterGrade(avg);
        }

        public string GetLetterGrade(double grade)
        {
            foreach (var item in GradeBoundaries)
            {
                if (grade >= item.Value.min && grade < item.Value.max)
                    return item.Key;
            }
            return "No grade";
        }
        
        // name - name of the grading's part
        // weight - weight of this part in total course
        public void AddGradingPart(string name, double weight) => gradeParts.Add(name, weight);
        public double CalculateAverage(StudentGrade sGrade)
        {
            double res = 0;
            foreach (var keyValuePair in gradeParts)
            {
                if (sGrade.grades.ContainsKey(keyValuePair.Key))
                    res += sGrade.grades[keyValuePair.Key] * keyValuePair.Value;
            }
            return res;
        }

        internal void PrintStudentsOverallGrades(StudentGrade student)
        {
            var grades = student.grades;
            foreach(var keyValuePair in grades)
            {
                string letter = GetLetterGrade(keyValuePair.Value);
                double contributePercentage = gradeParts.ContainsKey(keyValuePair.Key) ? gradeParts[keyValuePair.Key] : 0;
                Console.WriteLine(  $"Part:{keyValuePair.Key,8}\t" +
                                    $"Grade:{keyValuePair.Value,4}\t" +
                                    $"Letter:{letter,2}\t" +
                                    $"Contribute:{keyValuePair.Value * contributePercentage,6:F1}");
            }
            Console.WriteLine($"Sum :\t\t\t\tLetter:{GetAvgLetterGrade(student),2}\tGrade     :{CalculateAverage(student),6:F1}\n\n");
        }
    }
}
