using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugginAndExceptionHandling_CS
{
    class Program
    {
        struct course
        {
            public string courseName;
            public int creditHours;
            public int gradePoints;
        };

        static void Main(string[] args)
        {
            course[] courseList = PopulateTranscript();
            double GPA = GetGPA(courseList);
            Console.WriteLine("Your GPA is currently: " + GPA);
            Console.ReadLine();
        }

        
        private static course[] PopulateTranscript()
        {
            course[] courseList = new course[5];

            for (int counter = 0; counter < courseList.Length; counter++)
            {
                course newCourse = new course();

                // Console.WriteLine("Enter a course name");
                newCourse.courseName = GetInput("course name");
                newCourse.creditHours = ConvertStringToInt(GetInput("credit hours"));
                newCourse.gradePoints = ConvertStringToInt(GetInput("grade points"));

                courseList[counter] = newCourse;               

            }

            return courseList;
        }

        private static double GetGPA(course[] courseList)
        {
            double result = 0.0;
            int totalCredHours = 0;
            int totalGradePoints = 0;

            foreach (course currentCourse in courseList)
            {
                totalCredHours += currentCourse.creditHours;
                totalGradePoints += currentCourse.gradePoints;
            }

            result = totalGradePoints / totalCredHours;

            return result;
        }

        private static string GetInput(string input)
        {
            Console.WriteLine($"Enter the { input } for this course");
            return Console.ReadLine();
        }

        private static int ConvertStringToInt(string input)
        {
            int result = 0;
            
            if (ValidateInteger(input))
                result = Int32.Parse(input);

            return result;
        }
        private static bool ValidateInteger(string input)
        {
            int convertFromString;
            bool isValid = false;
            // EX 1 Task 1.4:  Create a Try-Catch block to catch a FormatException exception  
           
                try
                {
                    convertFromString = Int32.Parse(input);
                    isValid = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    isValid = false;
                }
                // EX 1 Task 2.2:  Add a finally block to the exception handler, and then execute the garbage
                // collector with GC.Collect().
                finally
                {
                    GC.Collect();
                }

            return isValid;
        }
    }
}

